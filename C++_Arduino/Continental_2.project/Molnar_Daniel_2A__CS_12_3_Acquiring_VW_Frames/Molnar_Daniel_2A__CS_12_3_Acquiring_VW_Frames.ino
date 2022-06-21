/*****************************************************************************/
/* Automotive Software and Hardware Development in Practice I.               */
/*****************************************************************************/
/* The CONTINENTAL Subject - School Year: 2020/2021 - Semester: 1st          */
/*****************************************************************************/
/* Microcontroller: ARDUINO UNO                                              */
/*****************************************************************************/
/* Program: "CS_12_3_Acquiring_VW_Frames"                                    */
/*****************************************************************************/
/* LIN slave: VW IBS sensor.                                                 */
/*****************************************************************************/

#include <SoftwareSerial.h>   //Module with functions for SERIAL communication shall be used.

#define TRUE  1   //Macros for Boolean expressions.
#define FALSE 0

#define RX  6   //The pin dedicated to the RECEIVE pin of the LIN bus (BLUE wire).
#define TX  9   //The pin dedicated to the TRANSMIT pin of the LIN bus (GREEN wire).
#define LIN_BAUD_RATE  19200  //The speed of communication of the LIN bus is 19200 baud (bit/s).
#define FRAME_LENGTH  10    //The entire LIN frame consists of 10 bytes: PID, 8 data bytes, CHKSUM.

/* Length of the dominand (LOW) part of the break field in microseconds. */
#define BREAK_FIELD_DOMINANT_TIME    937.5    // 1/(19200 bit/s) * 18
/* Length of the recessive (HIGH) part of the break field in microseconds. */
#define BREAK_FIELD_RECESSIVE_TIME   104.166  // 1/(19200 bit/s) * 2
/* This means the form "__________________--"*/

/* Length of a bit on the LIN bus in microseconds. */
#define BIT_TIME  52.083333   //This constant is not used in the code. It is just a useful piece of information. 1/(19200 bit/s) Unit: microseconds.

#define WAKE_UP_BREAK   25    //First a separate break field is sent to the LIN bus. If the sensor was in SLEEP mode it will wake it up.
                              //If the sensor was in NORMAL mode this break field will have no effect. Unit: ms.

#define RESPONSE_TIME   4000    //Time delay between the end of the header and before acquiring the response bytes, microseconds.

#define ACQUISITION_PERIOD  1000    //The period of frame acquisition, ms.

#define SYNC  0x55    //Synchronization byte necessary for the acquisition of a LIN frame.

/* Logic masks for each bit of IDs. */
#define MASK_0 0x01    //000001
#define MASK_1 0x02    //000010
#define MASK_2 0x04    //000100
#define MASK_3 0x08    //001000
#define MASK_4 0x10    //010000
#define MASK_5 0x20    //100000

#define ID_MASK 0x3F   //00111111 - Mask for calculating the ID from the PID.

/* Defining symbol 'LIN' as a serial interface with pins RX and TX. */
SoftwareSerial LIN (RX,TX);

 

/*************************************************************************************/
/* Prototype:   byte calculate_PID(byte ID)                                          */
/* Description: The function calculates the PID from the ID at LIN communication.    */
/*************************************************************************************/
/* Calculation of the Protected IDentifier from the IDentifier.                      */
/*  ID =  0  0 b5 b4 b3 b2 b1 b0                                                     */
/* PID = p1 p0 b5 b4 b3 b2 b1 b0                                                     */
/* p0 XOR b0 XOR b1 XOR b2 XOR b4 = 0                                                */
/* p1 XOR b1 XOR b3 XOR b4 XOR b5 = 1                                                */
/*    This imples that                                                               */
/* p0 =   b0 ^ b1 ^ b2 ^ b4                                                          */
/* p1 = ~(b1 ^ b3 ^ b4 ^ b5)                                                         */
/*************************************************************************************/
/* Input(s):    byte ID.                                                             */
/* Output(s):   byte PID.                                                            */
/*************************************************************************************/
byte calculate_PID(byte ID)   //ID = 0,...,63
{
  byte PID, p1, p0, b5, b4, b3, b2, b1, b0;   //Variables for the separated bits

  ID = ID & ID_MASK;   //For security purposes. Now ID = 0,...,63.

  /* Extracting each bit from ID and shifting them to the same place. */
  b0 = ID & MASK_0;
  b1 = ( ID & MASK_1 ) >> 1;
  b2 = ( ID & MASK_2 ) >> 2;
  b3 = ( ID & MASK_3 ) >> 3;
  b4 = ( ID & MASK_4 ) >> 4;
  b5 = ( ID & MASK_5 ) >> 5;

  p0 = ( b0 ^ b1 ^ b2 ^ b4 ) << 6;      //Forming parity bit #0 and shifting it to its place.
  p1 = ( ~(b1 ^ b3 ^ b4 ^ b5) ) << 7;   //Forming parity bit #1 and shifting it to its place.

  PID = ID | p0 | p1;   //Making the PID from the ID and the 2 parity pits.

  return PID;
}


/*************************************************************************************/
/* Prototype:   void generate_break_field(void)                                      */
/* Description: Generating the BREAK FIELD on the LIN bus.                           */
/*************************************************************************************/
/* Input(s):    -                                                                    */
/* Output(s):   -                                                                    */
/* Other interface:   The Tx (Transmit) pin defined for the LIN bus.                 */
/*************************************************************************************/
/* Special feature: The entire break field takes exactly the time of 2 bytes.        */
/*************************************************************************************/
void generate_break_field(void)
{
  digitalWrite(TX, LOW);
  delayMicroseconds(BREAK_FIELD_DOMINANT_TIME);   //Time period of 18 dominant bits.
  digitalWrite(TX, HIGH);
  delayMicroseconds(BREAK_FIELD_RECESSIVE_TIME);  //Time period of 2 recessive bits.
}


/*************************************************************************************/
/* Prototype:   void close_LIN(void)                                                 */
/* Description: Flushing and closing the LIN bus.                                    */
/*************************************************************************************/
/* Input(s):    -                                                                    */
/* Output(s):   -                                                                    */
/* Other interface:   The LIN bus.                                                   */
/*************************************************************************************/
void close_LIN(void)
{
  LIN.end();      //Closing the LIN serial interface.
}


/*************************************************************************************/
/* Prototype:   void bus_init(void)                                                  */
/* Description: Defining pins for the LIN bus, opening the LIN bus and closing it.   */
/*              Generating a break field to wake-up the sensor.                      */
/*************************************************************************************/
/* Input(s):    -                                                                    */
/* Output(s):   -                                                                    */
/* Other interface:   The LIN bus.                                                   */
/*************************************************************************************/
void bus_init(void)
{
  pinMode(RX,INPUT);    //The RX pin of Arduiono will be the LIN input from the point of view of the MASTER.
  pinMode(TX,OUTPUT);   //The TX pin of Arduiono will be the LIN output from the point of view of the MASTER.
  
  LIN.begin(LIN_BAUD_RATE);   //Opening the LIN bus.
  while(!LIN);                //Waiting for the LIN bus to get built up.
  
  close_LIN();    //Closing the LIN bus.

  generate_break_field(); //Generating a wake-up break field if the SLAVE may have been in SLEEP mode. It must wake up!
  delay(WAKE_UP_BREAK);   //After the wake-up break field the sensor may need some time to really wake up.
}


/*************************************************************************************/
/* Prototype:   void display_init(void)                                              */
/* Description: Initializing the traditional serial bus and sending the greeting     */
/*              message.                                                             */
/*************************************************************************************/
/* Input(s):    -                                                                    */
/* Output(s):   -                                                                    */
/* Other interface:   The SERIAL bus.                                                */
/*************************************************************************************/
void display_init(void)
{
  Serial.begin(9600);   //Opening the traditional serial bus that is used for displaying the LIN communication.
  while(!Serial);       //Waiting for the serial bus to be built up.

  Serial.print("\n\n\n\nVW IBS sensor. CONTINENTAL GmbH.");    //Generating a friendly display header.
  Serial.print("\nPeriodic acquisition of frames 0x2F and 0x30.");
  Serial.print("\nFormat:");
  Serial.print("\nPID  D0 D1 D2 D3 D4 D5 D6 D7  CHKS - Calculated CHKS   Error message");

  delay(10000);
}


/*************************************************************************************/
/* Prototype:   void send_header(byte ID)                                            */
/* Description: Sending the header of the predefined LIN frame.                      */
/*************************************************************************************/
/* Input(s):    Identifier (ID) of the LIN frame to be acquired.                     */
/* Output(s):   -                                                                    */
/* Other interfaces:  The LIN bus.                                                   */
/*************************************************************************************/
void send_header(byte ID)
{
  byte PID;

  PID = calculate_PID(ID);  //ID->PID.

  generate_break_field();   //Generating the break field.
  
  LIN.begin(LIN_BAUD_RATE);   //Opening the LIN interface.
  while(!LIN);                //Waiting for the serial bus to get built up.
  
  LIN.write(SYNC);    //Sending out the synchronization byte.
  LIN.write(PID);     //Sending out the predefined PID.
 
  digitalWrite(TX, HIGH);  //Setting the bus to the recessive level again. 
}


/*************************************************************************************/
/* Prototype:   byte receive_data(byte* ptr_frame_data)                              */
/* Description: Receiving the incoming characters of a LIN frame.                    */
/*************************************************************************************/
/* Input(s):    (Address of) the array for frame data.                               */
/* Output(s):   Flag of timeout                                                      */
/* Other interfaces:  The LIN bus.                                                   */
/*************************************************************************************/
byte receive_data(byte* ptr_frame_data)
{
  byte idx;
  byte l_timeout = FALSE;   //Flag indicating whether there was timeout.

  delayMicroseconds(RESPONSE_TIME);   //Some time delay after sending the header.

  if (LIN.available() < 9)    //The response must consist of 9 bytes. 8 data bytes and the checksum.
  {
    l_timeout = TRUE;
  }
  
  for(idx = 1; idx < FRAME_LENGTH; idx++)   //Receiving 8 data bytes and the checksum.
  {
      ptr_frame_data[idx] = LIN.read();   //Reading out the character.
  }
  
  close_LIN();  //Closing the LIN bus.

  return l_timeout;
}


/*************************************************************************************/
/* Prototype:   void display_byte_in_hexa(byte value)                                */
/* Description: Displaying a byte value as a hexadecimal number, like "00" or "FF"   */
/*************************************************************************************/
/* Input(s):    the byte value                                                       */
/* Output(s):   -                                                                    */
/* Other interface:   the serial port                                                */
/*************************************************************************************/
void display_byte_in_hexa(byte value)
{
  byte nh, nl;  //Higher nibble and lower nibble.

  nh = (value & 0xF0) >> 4;   //Let's benefit from the special arithmetics, i.e. powers of 2!
  nl = (value & 0x0F);

  Serial.print(nh, HEX);    //Displaying the hexadecimal digits.
  Serial.print(nl, HEX);
}


/*************************************************************************************/
/* Prototype:   void display_frame_data(byte* ptr_frame_data)                        */
/* Description: Displaying the incoming characters of a LIN frame.                   */
/*************************************************************************************/
/* Input(s):    (Address of) the array for frame data.                               */
/* Output(s):   -                                                                    */
/* Other interfaces:  The SERIAL bus.                                                */
/*************************************************************************************/
void display_frame_data(byte* ptr_frame_data)
{
  byte idx;
  byte l_ID;

  Serial.print("\n\nFrame ID: 0x");  //Displaying the header of the frame.
  l_ID = ptr_frame_data[idx] & ID_MASK;   //Masking out the ID from the PID.
  display_byte_in_hexa(l_ID);   //Displaying the ID.
  Serial.print("\n");
  
  for(idx = 0; idx < FRAME_LENGTH; idx++)  //Displaying the data bytes and the checksum of the frame.
  {
    display_byte_in_hexa(ptr_frame_data[idx]);
    Serial.print(" ");

    if ( (idx == 0) || (idx == 8) )   //After the PID and the last data byte an additional space is displayed.
    {
      Serial.print(" ");
    }
  }
}


/*************************************************************************************/
/* Prototype:   byte calculate_checksum(byte* ptr_frame_data)                        */
/* Description: Calculating the checksum of a frame from the data bytes.             */
/*************************************************************************************/
/* Input(s):    (Address of) the array for frame data.                               */
/* Output(s):   The calculated checksum.                                             */
/* Other interfaces:  -                                                              */
/*************************************************************************************/
byte calculate_checksum(byte* ptr_frame_data)
{
  byte enhanced_checksum;
  unsigned int sum = 0;   //Variable for the additions. WORD.
  byte idx;
  
  /* Calculating the checksum. */
  for (idx = 0; idx < FRAME_LENGTH-1; idx++)  //PID D0 D1 D2 D3 D4 D5 D6 D7
  {
    sum += ptr_frame_data[idx];   //Adding the 9 bytes.
  }
  
  /* Value 0xFF00 is used for masking the carries of the previous additions. */
  enhanced_checksum = ~((byte)((sum & 0x00FF) + ((sum & 0xFF00)>>8)));

  return enhanced_checksum;
}






/*************************************************************************************/
/*                MOLNAR DANIEL ( OXOOBF ) -------- SAJAT FUGGVENYEK                 */        
/*************************************************************************************/


/*************************************************************************************/
/* Prototype:   void decode_BDM_Strom_dyn(byte* frame_data)                          */
/* Description: Decoding and displaying signal 'BDM_Strom_dyn'.                      */
/*              Unit:     A                                                          */
/*              Position: 16                                                         */
/*              Length:   16                                                         */
/*              Offset:   -32768                                                     */
/*              Factor:   0.001 (LSB = 0.001 A = 1 mA)   (IF BDM_I_Bereich_dyn==0)   */
/*              Factor:   0.01  (LSB = 0.01 A = 10 mA)   (IF BDM_I_Bereich_dyn==1)   */
/*              Factor:   0.1   (LSB = 0.1 A = 100 mA)   (IF BDM_I_Bereich_dyn==2)   */                
/*                                                                                   */
/*              Format example: "-3.296 A". (IF BDM_I_Bereich_dyn==0)                */
/*              Format example: "-52.51 A". (IF BDM_I_Bereich_dyn==1)                */
/*              Format example: "-881.9 A". (IF BDM_I_Bereich_dyn==2)                */
/*              Format example: "ERROR".    (IF BDM_I_Bereich_dyn==3)                */
/*************************************************************************************/
/* Input(s):    Address of array containing the data bytes of LIN frame 0x2F.        */
/* Output(s):   -                                                                    */
/* Other interface:   the serial port                                                */
/*************************************************************************************/
void decode_BDM_Strom_dyn(byte* frame_data,unsigned int value)
{
  unsigned int raw_signal;               //Raw signal extracted from the LIN frame.
  signed int unscaled_current;            //Raw signal modified with the scaled offset.
  signed int amps;                        //Signal value in unit A.
  unsigned int absolute_unscaled_current;
  byte digit1, digit2, digit3;                    //Variables for displaying the signal's value.

  /* Extracting the signal from the incoming frame. */
  raw_signal = (unsigned int)((frame_data[4] << 8)| frame_data[3]);
  unscaled_current = (signed int)raw_signal - 32768;    //Offset/LSB!

  amps = (signed int)(unscaled_current);    // Converting the current value from milliams to amps. 1/LSB.

  /* Forming the absolute value of the current. This is needed for modulo arithmetics. */
  absolute_unscaled_current = unscaled_current;
  if (unscaled_current < 0)
  {
    absolute_unscaled_current = -unscaled_current;
  }
  
      if(value==0){
          Serial.print("\n");
          Serial.print("I = ");
          
          if(amps < 0 && (absolute_unscaled_current/1000 < 1)){
            Serial.print("-");
          }
        
          amps = (signed int)(unscaled_current / 1000);
          digit1 = (byte)((absolute_unscaled_current % 1000) / 100);   //Calculating the first decimal digit. 100 = 100×LSB.
          digit2 = (byte)((absolute_unscaled_current % 100) / 10);
          digit3 = (byte)(absolute_unscaled_current % 10);
      
          /* Displaying the signal.*/
        Serial.print(amps);
        Serial.print(".");
        Serial.print(digit1,DEC);
        Serial.print(digit2,DEC);
        Serial.print(digit3,DEC);
        Serial.print(" A");
        
      }
      
      else if(value==1){
          Serial.print("\n");
          Serial.print("I = ");
          if(amps < 0 && absolute_unscaled_current/100 < 1){
            Serial.print("-");
          }
          amps = (signed int)(unscaled_current / 100);
          digit1 = (byte)((absolute_unscaled_current % 100) / 10);   //Calculating the first decimal digit.
          digit2 = (byte)((absolute_unscaled_current % 10));         //Calculating the second decimal digit.
      
          /* Displaying the signal.*/
        Serial.print(amps);
        Serial.print(".");
        Serial.print(digit1,DEC);
        Serial.print(digit2,DEC);
        Serial.print(" A");
        
      }
      else if(value==2){
        Serial.print("\n");
        Serial.print("I = ");
          if(amps < 0 && absolute_unscaled_current/10 < 1){
            Serial.print("-");
          }
          amps = (signed int)(unscaled_current / 10);
          digit1 = (byte)(absolute_unscaled_current % 10);   //Calculating the first decimal digit.
          
      
          /* Displaying the signal.*/
        Serial.print(amps);
        Serial.print(".");
        Serial.print(digit1,DEC);
        Serial.print(" A");
        
      }
      else if(value==3){
          Serial.print("\n");
          Serial.print("ERROR");
      }

}


/*************************************************************************************/
/* Prototype:   void decode_BDM_I_Bereich_dyn(byte* frame_data)                      */
/* Description: Decoding and displaying signal 'BDM_I_Bereich_dyn'.                  */
/*              Unit:     -                                                          */
/*              Position: 14                                                         */
/*              Length:   2                                                          */
/*                                                                                   */
/*************************************************************************************/
/* Input(s):    Address of array containing the data bytes of LIN frame 0x2F.        */
/* Output(s):   -                                                                    */
/* Other interface:   the serial port                                                */
/*************************************************************************************/
unsigned int decode_BDM_I_Bereich_dyn(byte* frame_data)
{
  unsigned int value;   
  
  /* Extracting the signal from the incoming frame. */
  value = ((unsigned int)((frame_data[2] & 0xC0)>>6));
   /* Serial.print("\n");
    Serial.print("BDM_I_Bereich_dyn = ");
    Serial.print(value);  */
  
  return value;
}

/*************************************************************************************/
/* Prototype:   void decode_BDM_Spannung_dyn(byte* frame_data)                       */
/* Description: Decoding and displaying signal 'BDM_Spannung_dyn'.                   */
/*              Unit:     V                                                          */
/*              Position: 0                                                          */
/*              Length:   14                                                         */
/*              Offset:   4                                                          */
/*              Factor:   0.001 (LSB = 0.001 V = 1 mV)                               */
/*                                                                                   */
/*              Format example: "U = 12.312 V".                                      */
/*************************************************************************************/
/* Input(s):    Address of array containing the data bytes of LIN frame 0x2F.        */
/* Output(s):   -                                                                    */
/* Other interface:   the serial port                                                */
/*************************************************************************************/
void decode_BDM_Spannung_dyn(byte* frame_data)
{
  unsigned int raw_signal;    //Variable for the raw signal extracted from the LIN frame.
  unsigned int unscaled_voltage;  //Raw signal modified with the rescaled offset.
  unsigned int volts;   //Signal value in unit V.
  byte digit1, digit2, digit3;  //Variables for displaying the signal's value.

  /* Extracting the signal from the incoming frame. */
  raw_signal = ((unsigned int)(frame_data[2] & 0x3F) << 8) + (unsigned int)frame_data[1];

  unscaled_voltage = raw_signal + 4000;    // + offset/LSB
  volts = unscaled_voltage / 1000;    // 1/LSB
 
  /* Forming the absolute value of the current. This is needed for modulo arithmetics. */
  digit1 = (byte)(((unscaled_voltage) % 1000) / 100);   //Calculating the first decimal digit.
  digit2 = (byte)(((unscaled_voltage) % 100) / 10);     //Calculating the second decimal digit.
  digit3 = (byte)((unscaled_voltage) % 10);             //Calculating the third decimal digit.

  /* Displaying the signal.*/
  Serial.print("\n");
  Serial.print("U = ");
  Serial.print(volts,DEC);
  Serial.print(".");
  Serial.print(digit1,DEC);
  Serial.print(digit2,DEC);
  Serial.print(digit3,DEC);
  Serial.print(" V");
}


/*************************************************************************************/
/* Prototype:   void decode_BDM_Temp_dyn(byte* frame_data)                           */
/* Description: Decoding and displaying signal 'BDM_Temp_dyn'.                       */
/*              Unit:     °C                                                         */
/*              Position: 32                                                         */
/*              Length:   8                                                          */
/*              Offset:   -40                                                        */
/*              Factor:   1 (LSB = 1°C)                                              */
/*                                                                                   */
/*              Format example: "32 C".                                              */
/*************************************************************************************/
/* Input(s):    Address of array containing the data bytes of LIN frame 0x2A.        */
/* Output(s):   -                                                                    */
/* Other interface:   the serial port                                                */
/*************************************************************************************/
void decode_BDM_Temp_dyn(byte* frame_data)
{
  unsigned short int raw_signal;
  signed short int temperature;

  raw_signal = frame_data[5];
  
  temperature = (signed short int)raw_signal - 40;    //Offset!

  /* Displaying the signal.*/
  Serial.print("\n");
  Serial.print("T = ");
  Serial.print(temperature,DEC);
  Serial.print(" C");
}

/*************************************************************************************/
/* Prototype:   void decode_BZE_SOC_K20(byte* frame_data)                            */
/* Description: Decoding and displaying signal 'BZE_SOC_K20'.                        */
/*              Unit:     %                                                          */
/*              Position: 38                                                         */
/*              Length:   7                                                          */
/*              Offset:   0                                                          */
/*              Factor:   1 (LSB = 1%)                                               */
/*                                                                                   */
/*              Format example: "47 %".                                              */
/*************************************************************************************/
/* Input(s):    Address of array containing the data bytes of LIN frame 0x30.        */
/* Output(s):   -                                                                    */
/* Other interface:   the serial port                                                */
/*************************************************************************************/
void decode_BZE_SOC_K20(byte* frame_data){
    unsigned int percents;

     percents = ((unsigned int)(frame_data[6] & 0x1F) << 2) + (unsigned int)((frame_data[5] & 0xC0) >> 6);
     Serial.print("\n");
     Serial.print("SOC = ");
     Serial.print(percents);
     Serial.print(" %");
}
/*************************************************************************************/
/*              MOLNAR DANIEL ( OXOOBF ) -------- SAJAT FUGGVENYEK VEGE              */        
/*************************************************************************************/






/*************************************************************************************/
/* Prototype:   void acquire_frame(byte ID)                                          */
/* Description: Acquiring frame of identifier ID.                                    */
/*************************************************************************************/
/* Input(s):    -                                                                    */
/* Output(s):   -                                                                    */
/* Other interface:   The SERIAL port                                                */
/*************************************************************************************/
void acquire_frame(byte ID)
{
  byte frame_data[FRAME_LENGTH] = {0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
  byte checksum_calc;   //Variable for the calculated checksum.
  byte timeout;   //Flag to indicate whether there was timeout at the response of the slave.
  byte frameids[2] = { 0x2F, 0x30 };      
  
  frame_data[0] = calculate_PID(ID);    //Putting the PID to the first position.
  send_header(ID);    //Sending out the header.
  timeout = receive_data(frame_data);   //Receiving incoming data and the flag of timeout.
  display_frame_data(frame_data);   //Displaying the frame.

  checksum_calc = calculate_checksum(frame_data);   //For the checksum the PID is used, not the ID.
  Serial.print("- ");
  display_byte_in_hexa(checksum_calc);    //Displaying the calculated checksum.
  
  if (timeout == TRUE)    //Was there timeout?
  {
    Serial.print("     No signals");
  }
  else if (checksum_calc != frame_data[9])    //If the checksum received does not match the calculated value...
  {
    Serial.print("     No signals");
  }    

  
/*************************************************************************************/
/*              MOLNAR DANIEL ( OXOOBF ) -------- SAJAT FUGGVENYEK MEGHIVASA         */        
/*************************************************************************************/
  if (  timeout == FALSE && checksum_calc == frame_data[9] &&  ID==frameids[0])    // 0x2F ID eseten
  {
    unsigned int value;
    decode_BDM_Spannung_dyn(frame_data);                    
    value=decode_BDM_I_Bereich_dyn(frame_data);
    decode_BDM_Strom_dyn(frame_data,value);
    decode_BDM_Temp_dyn(frame_data);
    Serial.print("\n"); 
  }
  else if(  timeout == FALSE && checksum_calc == frame_data[9] &&  ID==frameids[1])  // 0x30 ID eseten
  {
    decode_BZE_SOC_K20(frame_data); 
    Serial.print("\n");
  }
/*************************************************************************************/
/*       MOLNAR DANIEL ( OXOOBF ) -------- SAJAT FUGGVENYEK MEGHIVASANAK VEGE        */        
/*************************************************************************************/
  
}





/*************************************************************************************/
/* Prototype:   void setup(void)                                                     */
/* Description: Calling initializing functions of the project.                       */
/*************************************************************************************/
/* Input(s):    -                                                                    */
/* Output(s):   -                                                                    */
/* Other interfaces:  -                                                              */
/*************************************************************************************/
void setup()
{
  display_init();
  bus_init();
}


/*************************************************************************************/
/* Prototype:   void loop(void)                                                      */
/* Description: Periodic acquisition of frames 0x2F and 0x30.                        */
/*************************************************************************************/
/* Input(s):    -                                                                    */
/* Output(s):   -                                                                    */
/* Other interfaces:  -                                                              */
/*************************************************************************************/
void loop()
{
  acquire_frame(0x2F);
  delay(ACQUISITION_PERIOD);
  acquire_frame(0x30);
  delay(ACQUISITION_PERIOD);
}
