#include <EEPROM.h>


int buttonPin = 12;
int Led1 = 10;
int Led2 = 9;
int Prev_State = HIGH;
int Act_State = HIGH;
int Elapsed_T = 401;
int y = 0;
int Lef = 0;
int cnt = 1;
int start = -1;
int idoT_1 = 25;      // 10-40 ms
int vill_2 = 4;       // 2-6 vill.
int T1_2 = 50;        // 20-80 ms
int Tp21_3 = 240;     // 100-400 ms
int Tp22_3 = 270;     // 100-400 ms


char rx_byte = 0;
String rx_str = "";
int idoT_1_EEP5 = 0;      // 10-40 ms
int vill_2_EEP6 = 0;       // 2-6 vill.
int T1_2_EEP7 = 0;        // 20-80 ms
int Tp21_3_EEP8 = 0;     // 100-400 ms
int Tp22_3_EEP9 = 0; 
int tmp=0;
int ET2=400;



void uzemmod(int ct){
  switch (ct)
  {
    case 1:
          int intensity; 
          for (intensity = 0; intensity <= 240 && (digitalRead(buttonPin) == LOW); intensity += 12)   //Note the boundaries!
          {
            analogWrite(Led1, intensity);         //LED1 fading out due to the intensity level. Inverse logic!
            analogWrite(Led2, 240-intensity);         //LED1 fading out due to the intensity level. Inverse logic!
            //delay(idoT_1);    //Waiting Defa.: 25 ms.
            for(int r=0;r<idoT_1 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
                
              }
          }
        
          for (intensity = 240; intensity >= 0 && (digitalRead(buttonPin) == LOW); intensity -= 12)   //Note the boundaries!
          {
            analogWrite(Led1, intensity);         //LED1 glowing up due to the intensity level. Inverse logic!
            analogWrite(Led2, 240- intensity);
            //delay(idoT_1);
            for(int r=0;r<idoT_1 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
                
              }
          }

          if(digitalRead(buttonPin) == HIGH){
          digitalWrite(Led1,LOW);
          digitalWrite(Led2,LOW);
         }
         
      break;  
    case 2:   

         for(int k=0;k<vill_2 && (digitalRead(buttonPin) == LOW);k++){
          digitalWrite(Led1,HIGH);
        //delay(T1_2);
        for(int r=0;r<T1_2 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
                
              }
        digitalWrite(Led1,LOW);
        //delay(T1_2);
        for(int r=0;r<T1_2 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
                
              }
         }
         for(int k=0;k<vill_2 && (digitalRead(buttonPin) == LOW);k++){
          digitalWrite(Led2,HIGH);
        //delay(T1_2);
        for(int r=0;r<T1_2 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
               
              }
        digitalWrite(Led2,LOW);
        //delay(T1_2);
        for(int r=0;r<T1_2 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
                
                }
              }
      break;  

    case 3: 
  
        digitalWrite(Led2,HIGH);
        for(int r=0;r<Tp21_3 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
        }
        digitalWrite(Led2,LOW);

        
        digitalWrite(Led1,HIGH);
        for(int r=0;r<Tp22_3 && (digitalRead(buttonPin) == LOW);r++){
                delay(1);
        }
        digitalWrite(Led1,LOW);
                               //
      break;

      
    case 4: 
      digitalWrite(Led1,LOW);
      digitalWrite(Led2,LOW);
       break;
  } 
}

void setup() {
pinMode(buttonPin,INPUT_PULLUP);
pinMode(Led1,OUTPUT);
pinMode(Led2,OUTPUT);
Serial.begin(9600);
EEPROM.write(0, idoT_1);
EEPROM.write(1, vill_2);
EEPROM.write(2, T1_2);
EEPROM.write(3, Tp21_3);
EEPROM.write(4, Tp22_3);

if (EEPROM.read(5)>9 && EEPROM.read(5)<41){
  idoT_1=EEPROM.read(5);
}
if (EEPROM.read(6)>2 && EEPROM.read(6)<7){
  vill_2=EEPROM.read(6);
}
if (EEPROM.read(7)>19 && EEPROM.read(7)<81){
  T1_2=EEPROM.read(7);
}


String szamj="";
szamj+=EEPROM.read(8);
szamj+=EEPROM.read(9);
szamj+=EEPROM.read(10);
if (szamj.toInt()>99 && szamj.toInt()<401){
Tp21_3=szamj.toInt();
}


String szamje2="";
szamje2+=EEPROM.read(11);
szamje2+=EEPROM.read(12);
szamje2+=EEPROM.read(13);
if (szamje2.toInt()>99 && szamje2.toInt()<401){
Tp22_3=szamje2.toInt();
}

Serial.println("Ha konfigurálni szeretne, lépjen a kívánt üzemmódba, majd írja be a parancsot:");
      Serial.print(cnt);
      Serial.println(". üzemmód");
   /*    Serial.println(idoT_1);
       Serial.println(vill_2);
       Serial.println(T1_2);
       Serial.println(Tp21_3);
       Serial.println(Tp22_3);  */

}

void loop() {
  
Act_State = digitalRead(buttonPin);

if (Act_State == HIGH && Prev_State == LOW && Elapsed_T<400 )
    {
      digitalWrite(Led1,LOW);
      digitalWrite(Led2,LOW);
      int tmmm=400-Elapsed_T;
      delay(tmmm);
      Elapsed_T=400;
      Act_State = HIGH;
    }
else{
      if (Act_State == LOW && Prev_State == HIGH && Elapsed_T>=400 )
    {
      
      cnt++;
      Elapsed_T=0;
      uzemmod(cnt);
      Serial.print(cnt);
      Serial.println(". üzemmód");
      
    }
    
    if (Act_State == LOW && Prev_State == LOW)
    {
      uzemmod(cnt);
    }
  
}

    if (Serial.available() > 0) {    // is a character available?
        rx_byte = Serial.read();  
        // get the character
        if (rx_byte != '\n') {
          // a character of the string was received
          rx_str += rx_byte;
        }
        else /* if(rx_str != "0") */{
          int len = rx_str.length();
          int lgen = len-(len-1);
          String ini = rx_str.substring(0, 1);
          String szamjegy = rx_str.substring(lgen, len);
          int num = rx_str.substring(lgen, len).toInt();

          if (cnt > 0 && cnt < 4){
            
          
          if (cnt == 1 && ini == "A")        // 1.uzemmod konf
          {
            if (num>9 && num<41){
              idoT_1 = num;
              EEPROM.write( 5 , num);
              Serial.println("Sikeres konfigurálás!");
              Serial.print("idoT_1 értéke: ");
              Serial.println(EEPROM.read(5));
            }
            else { Serial.println("Érvénytelen konfiguráció!"); }
          }

          
          if (cnt == 2)                             // 2.uzemmod konf
          {
            if ( ini == "F" && (num>1 && num<7) ){
              vill_2 = num;
              EEPROM.write( 6 , num);
              Serial.println("Sikeres konfigurálás!");              //vill_2 = 4;       // 2-6 vill.
               Serial.print("vill_2 értéke: ");                                                     //int T1_2 = 50; 
              Serial.println(EEPROM.read(6));
            }
            
            else if ( ini == "B" && (num>19 && num<81) ){
              T1_2 = num;
              EEPROM.write( 7 , num);
              Serial.println("Sikeres konfigurálás!");
              Serial.print("T1_2 értéke: ");
              Serial.println(EEPROM.read(7));
            }
            else { Serial.println("Érvénytelen konfiguráció!"); }
          }
          
          if (cnt == 3)                                       // 3.uzemmod konf
          {
            if ( ini == "C" && (num>99 && num<401)){
              Tp21_3 = num;
              EEPROM.write( 8 , szamjegy.substring(0, 1).toInt());
              EEPROM.write( 9 , szamjegy.substring(1, 2).toInt());
              EEPROM.write( 10 , szamjegy.substring(2, 3).toInt());
              Serial.println("Sikeres konfigurálás!");
              Serial.print("Tp21_3 értéke: ");
              Serial.print(EEPROM.read(8));
              Serial.print(EEPROM.read(9));
              Serial.println(EEPROM.read(10));
            }
            else if ( ini == "D" && (num>99 && num<401)){
              Tp22_3 = num;
              EEPROM.write( 11 , szamjegy.substring(0, 1).toInt());
              EEPROM.write( 12 , szamjegy.substring(1, 2).toInt());
              EEPROM.write( 13 , szamjegy.substring(2, 3).toInt());
              Serial.println("Sikeres konfigurálás!");
              Serial.print("Tp22_3 értéke: ");
              Serial.print(EEPROM.read(11));
              Serial.print(EEPROM.read(12));
              Serial.println(EEPROM.read(13));
            }
            else { Serial.println("Érvénytelen konfiguráció!"); }
          }

          }

          else { Serial.println("Érvénytelen konfiguráció!"); }
          rx_str = "";
        }
        
      } // end: if (Serial.available() > 0)



if (cnt >= 4){
  cnt=0; 
}

if (Elapsed_T < 400){
  delay(20);
  Elapsed_T+=20;
}


Prev_State = Act_State;
}
