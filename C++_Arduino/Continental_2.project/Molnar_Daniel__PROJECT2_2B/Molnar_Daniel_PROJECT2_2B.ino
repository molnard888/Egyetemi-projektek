String recievedString;
int value;
char AllowedChars[] = { 'A', 'B', 'C', 'D', 'E', 'F'
                      , 'a', 'b', 'c', 'd', 'e', 'f' 
                      , '0', '1', '2', '3', '4', '5'
                      , '6', '7', '8', '9', ' ' };

#define FRAME_LENGTH  8
#define NUMBER_OF_FRAMES 8


void display_byte_in_hexa(byte value)                // Displaying byte
{
  byte nh, nl;
  
  nh = (value & 0xF0) >> 4;       
  nl = (value & 0x0F);

  Serial.print(nh, HEX);
  Serial.print(nl, HEX);
}


                                                                      
void CharToFrame(){
  
//**************************************Is Input Allowed**************************************************************************/
byte Single_Frame [FRAME_LENGTH] = { 0x47, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

byte Multi_Frame[NUMBER_OF_FRAMES][FRAME_LENGTH] = {{ 0x47, 0x10, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },   
                                                      { 0x47, 0x21, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },   
                                                      { 0x47, 0x22, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },   
                                                      { 0x47, 0x23, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },   
                                                      { 0x47, 0x24, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },   
                                                      { 0x47, 0x25, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },   
                                                      { 0x47, 0x26, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF },   
                                                      { 0x47, 0x27, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }};


   //Serial.print(Multi_Frame[0][0],HEX);                                                   


    if (Serial.available()){                                                  //Parancs bekérése
    recievedString = Serial.readString();
    unsigned int recievedCharArray_LENGTH = recievedString.length();
    char recievedCharArray[recievedCharArray_LENGTH];
    recievedString.toCharArray(recievedCharArray, recievedCharArray_LENGTH+1);
    bool megvan=false;

    if(recievedCharArray[recievedCharArray_LENGTH-1]==' '){
        recievedCharArray_LENGTH--;
    }
    Serial.print("Command: ");
    for(unsigned int i=0;i<recievedCharArray_LENGTH;i++){             //Parancs kiírása
        Serial.print(recievedCharArray[i]);
    }
    //Serial.print("\n");
    //Serial.print(recievedCharArray_LENGTH);
    
    for(unsigned int i=0;i<recievedCharArray_LENGTH;i++){             //Parancs ellenőrzés (nem-megengedett karakterek)
        //Serial.print(recievedCharArray[i]);
        megvan=false;
        for(unsigned int k=0;k<23 && megvan==false;k++){
            if(recievedCharArray[i]==AllowedChars[k]){
              /* Serial.print("\n");
              Serial.print("MEGVAN");
              Serial.print("\n");  */
              megvan=true;
            }
        }
        if(megvan==false){
            i=recievedCharArray_LENGTH+50;
        }
    }
    
    if(megvan==false){
        /* Serial.print("\n");
        Serial.print("Invalid command format.");
        Serial.print("\n");   */
        
    }




    
    else{
        for(unsigned int i=0;i<recievedCharArray_LENGTH;i++){          //Parancs ellenőrzés ("XX" formátum)    
        //Serial.print(recievedCharArray[i]);
        megvan=false;
        for(unsigned int k=0;k<22 && megvan==false;k++){
            if(recievedCharArray[i]==AllowedChars[k]){
              /* Serial.print("\n");
              Serial.print("MEGVAN");
              Serial.print("\n");  */
              megvan=true;
            }
        }
        if(megvan==false){
            i=recievedCharArray_LENGTH+50;
        }
        if((i+1)%3==2){
            i++;
        }
    }
    
    }

    
    if(megvan==false){
       /* Serial.print("\n");
        Serial.print("Invalid command format.");
        Serial.print("\n");   */
    }



    
    else{
        for(unsigned int i=2;i<recievedCharArray_LENGTH;i++){               //Parancs ellenőrzés (szóközök helye)
          //Serial.print(recievedCharArray[i]);
          megvan=false;
          if(recievedCharArray[i]==' '){
                /* Serial.print("\n");
                Serial.print("MEGVAN");
                Serial.print("\n");  */
                megvan=true;
                i+=2;
              }
          if(megvan==false){
              i=recievedCharArray_LENGTH+50;
          }
    }
    }

    if(recievedCharArray[recievedCharArray_LENGTH-1] == ' ' || recievedCharArray[recievedCharArray_LENGTH-2] == ' '){
        megvan=false;
    }

    if(recievedCharArray_LENGTH < 2){
        megvan=false;
    }
    
    if(megvan==false){
        Serial.print("\n");
        Serial.print("Invalid command format.");
        Serial.print("\n");
        
    }
    if(megvan){
        Serial.print("\n");
        Serial.print("Command OK");
        Serial.print("\n");
    }
   


    //*********************************************************CHAR TO FRAME****************************************************
    if(megvan){
            byte TempByte;
            
            unsigned int szamlalo = recievedCharArray_LENGTH / 3;                 //szamlalo
            if((recievedCharArray_LENGTH % 3) == 2){
                szamlalo++;
            }
            //Serial.print(szamlalo);
            //Serial.print("\n");



 //*************************************************************SINGLE FRAME****************************************************           
            if(szamlalo >= 1 && szamlalo <= 6){
                unsigned int indx=0;
                Single_Frame[1]=szamlalo;
                
                for(unsigned int i=0;i<recievedCharArray_LENGTH;i+=3){
                    //Serial.print(" ");
                    
                    if(recievedCharArray[i]>=48 && recievedCharArray[i]<=57){                  // 0-9 characters to HEX
                        TempByte=recievedCharArray[i]-48;
                        
                        //Serial.print(TempByte,HEX);
                    }
                    if(recievedCharArray[i]>=65 && recievedCharArray[i]<=70){                  // A-F characters to HEX
                        TempByte=recievedCharArray[i]-55;
                        if(TempByte>=10 && TempByte<=15){
                        switch (TempByte) {
                              case 10:{
                                  TempByte=0x0A;
                                  break;
                              }
                              case 11:{
                                  TempByte=0x0B;
                                  break;
                              }
                              case 12:{
                                  TempByte=0x0C;
                                  break;
                              }
                              case 13:{
                                  TempByte=0x0D;
                                  break;
                              }
                              case 14:{
                                  TempByte=0x0E;
                                  break;
                              }
                              case 15:{
                                  TempByte=0x0F;
                                  break;
                              }
                        }
                    }
                    //Serial.print(TempByte,HEX);
                    }
                    if(recievedCharArray[i]>=97 && recievedCharArray[i]<=102){             // a-f characters to HEX
                        TempByte=recievedCharArray[i]-87;
                        if(TempByte>=10 && TempByte<=15){
                        switch (TempByte) {
                              case 10:{
                                  TempByte=0x0A;
                                  break;
                              }
                              case 11:{
                                  TempByte=0x0B;
                                  break;
                              }
                              case 12:{
                                  TempByte=0x0C;
                                  break;
                              }
                              case 13:{
                                  TempByte=0x0D;
                                  break;
                              }
                              case 14:{
                                  TempByte=0x0E;
                                  break;
                              }
                              case 15:{
                                  TempByte=0x0F;
                                  break;
                              }
                        }
                    }
                    //Serial.print(TempByte,HEX);
                    }




                    
                  if(recievedCharArray[i+1]>=48 && recievedCharArray[i+1]<=57){                   // 0-9 characters to HEX
                        Single_Frame[2+indx]=(TempByte<<4) | recievedCharArray[i+1]-48;
                        //Serial.print(Single_Frame[2+idx],HEX);
                        indx++;
                    }
                    
                    if(recievedCharArray[i+1]>=65 && recievedCharArray[i+1]<=70){                // A-F characters to HEX
                        byte RAW_TempByte=recievedCharArray[i+1]-55;
                            if(RAW_TempByte>=10 && RAW_TempByte<=15){
                                switch (RAW_TempByte) {
                                      case 10:{
                                          RAW_TempByte=0x0A;
                                          break;
                                      }
                                      case 11:{
                                          RAW_TempByte=0x0B;
                                          break;
                                      }
                                      case 12:{
                                          RAW_TempByte=0x0C;
                                          break;
                                      }
                                      case 13:{
                                          RAW_TempByte=0x0D;
                                          break;
                                      }
                                      case 14:{
                                          RAW_TempByte=0x0E;
                                          break;
                                      }
                                      case 15:{
                                          RAW_TempByte=0x0F;
                                          break;
                                      }
                                }
                        }
                    Single_Frame[2+indx]=(TempByte<<4) | RAW_TempByte;
                    //Serial.print(Single_Frame[2+idx],HEX);
                    indx++;
                    }

                    
                    if(recievedCharArray[i+1]>=97 && recievedCharArray[i+1]<=102){            // a-f characters to HEX
                        byte RAW_TempByte=recievedCharArray[i+1]-87;
                        
                            if(RAW_TempByte>=10 && RAW_TempByte<=15){
                                  switch (RAW_TempByte) {
                                        case 10:{
                                            RAW_TempByte=0x0A;
                                            break;
                                        }
                                        case 11:{
                                            RAW_TempByte=0x0B;
                                            break;
                                        }
                                        case 12:{
                                            RAW_TempByte=0x0C;
                                            break;
                                        }
                                        case 13:{
                                            RAW_TempByte=0x0D;
                                            break;
                                        }
                                        case 14:{
                                            RAW_TempByte=0x0E;
                                            break;
                                        }
                                        case 15:{
                                            RAW_TempByte=0x0F;
                                            break;
                                        }
                                  }
                        }
                    Single_Frame[2+indx]=(TempByte<<4) | RAW_TempByte;
                    //Serial.print(Single_Frame[2+idx],HEX);
                    indx++;
                    }
                  

                    
                }

                Serial.print("SF:");                                                   // Displaying Single frame
                  for(unsigned int index=0;index<FRAME_LENGTH;index++){
                      Serial.print(" ");
                      display_byte_in_hexa(Single_Frame[index]);
                  }
                  Serial.print("\n\n");
                  /* for(unsigned int index=1;index<FRAME_LENGTH;index++){
                      Single_Frame[index]=0xFF;   */
                  
            }









  /*************************************************************MULTI FRAME******************************************************************/
       else if(szamlalo<=47 && szamlalo >= 7){
                double meddigFutTemp = ((szamlalo-5) / 6);
                meddigFutTemp++;
                unsigned int RowIndex=0;
                unsigned int meddigFut = meddigFutTemp;
                if(meddigFutTemp > meddigFut){
                    meddigFut++;
                }
                byte TempByte;                                   
                byte Hasz = szamlalo/16;                                           //Hasznos bájtok számítása & to HEX
                byte HasznosBBB = szamlalo%16;
                if(HasznosBBB >= 10){                            
                    switch (HasznosBBB) { 
                              case 10:{
                                  HasznosBBB=0x0A;
                                  break;
                              }
                              case 11:{
                                  HasznosBBB=0x0B;
                                  break;
                              }
                              case 12:{
                                  HasznosBBB=0x0C;
                                  break;
                              }
                              case 13:{
                                  HasznosBBB=0x0D;
                                  break;
                              }
                              case 14:{
                                  HasznosBBB=0x0E;
                                  break;
                              }
                              case 15:{
                                  HasznosBBB=0x0F;
                                  break;
                              }
                        }
                }

                if(Hasz >= 10){
                    switch (Hasz) {
                              case 10:{
                                  Hasz=0x0A;
                                  break;
                              }
                              case 11:{
                                  Hasz=0x0B;
                                  break;
                              }
                              case 12:{
                                  Hasz=0x0C;
                                  break;
                              }
                              case 13:{
                                  Hasz=0x0D;
                                  break;
                              }
                              case 14:{
                                  Hasz=0x0E;
                                  break;
                              }
                              case 15:{
                                  Hasz=0x0F;
                                  break;
                              }
                        }
                }
                
                
                Multi_Frame[0][2]=(Hasz << 4) | HasznosBBB;
                unsigned int idx=3;

                
                for(unsigned int i=0;i<recievedCharArray_LENGTH;i+=3){                               
                    //Serial.print(" ");
                    
                    if(recievedCharArray[i]>=48 && recievedCharArray[i]<=57){                  //0-9 characters to HEX
                        TempByte=recievedCharArray[i]-48;
                        
                        //Serial.print(TempByte,HEX);
                    }
                    if(recievedCharArray[i]>=65 && recievedCharArray[i]<=70){                  //A-F characters to HEX
                        TempByte=recievedCharArray[i]-55;
                        if(TempByte>=10 && TempByte<=15){
                        switch (TempByte) {
                              case 10:{
                                  TempByte=0x0A;
                                  break;
                              }
                              case 11:{
                                  TempByte=0x0B;
                                  break;
                              }
                              case 12:{
                                  TempByte=0x0C;
                                  break;
                              }
                              case 13:{
                                  TempByte=0x0D;
                                  break;
                              }
                              case 14:{
                                  TempByte=0x0E;
                                  break;
                              }
                              case 15:{
                                  TempByte=0x0F;
                                  break;
                              }
                        }
                    }
                    //Serial.print(TempByte,HEX);
                    }
                    if(recievedCharArray[i]>=97 && recievedCharArray[i]<=102){            //a-f characters to HEX
                        TempByte=recievedCharArray[i]-87;
                        if(TempByte>=10 && TempByte<=15){
                        switch (TempByte) {
                              case 10:{
                                  TempByte=0x0A;
                                  break;
                              }
                              case 11:{
                                  TempByte=0x0B;
                                  break;
                              }
                              case 12:{
                                  TempByte=0x0C;
                                  break;
                              }
                              case 13:{
                                  TempByte=0x0D;
                                  break;
                              }
                              case 14:{
                                  TempByte=0x0E;
                                  break;
                              }
                              case 15:{
                                  TempByte=0x0F;
                                  break;
                              }
                        }
                    }
                    //Serial.print(TempByte,HEX);
                    }




                    
                  if(recievedCharArray[i+1]>=48 && recievedCharArray[i+1]<=57){                   //0-9 characters to HEX
                        if((idx%8 == 0) && RowIndex<NUMBER_OF_FRAMES){                            // Sor léptetés +1-el
                            RowIndex++;
                            idx=2;
                        }
                        Multi_Frame[RowIndex][idx]=(byte)((TempByte<<4) | (recievedCharArray[i+1]-48));
                        //Serial.print(Single_Frame[2+idx],HEX);
                        idx++;
                    }
                    
                    if(recievedCharArray[i+1]>=65 && recievedCharArray[i+1]<=70){                //A-F characters to HEX
                        byte RAW_TempByte=recievedCharArray[i+1]-55;
                            if(RAW_TempByte>=10 && RAW_TempByte<=15){
                                switch (RAW_TempByte) {
                                      case 10:{
                                          RAW_TempByte=0x0A;
                                          break;
                                      }
                                      case 11:{
                                          RAW_TempByte=0x0B;
                                          break;
                                      }
                                      case 12:{
                                          RAW_TempByte=0x0C;
                                          break;
                                      }
                                      case 13:{
                                          RAW_TempByte=0x0D;
                                          break;
                                      }
                                      case 14:{
                                          RAW_TempByte=0x0E;
                                          break;
                                      }
                                      case 15:{
                                          RAW_TempByte=0x0F;
                                          break;
                                      }
                                }
                        }
                        if((idx%8) == 0 && RowIndex<NUMBER_OF_FRAMES){                        // Sor léptetés +1-el
                            RowIndex++;
                            idx=2;
                        }
                        Multi_Frame[RowIndex][idx]=(TempByte<<4) | RAW_TempByte;
                    
                    idx++;
                    }

                    
                    if(recievedCharArray[i+1]>=97 && recievedCharArray[i+1]<=102){           //a-f characters to HEX
                        byte RAW_TempByte=recievedCharArray[i+1]-87;
                        
                            if(RAW_TempByte>=10 && RAW_TempByte<=15){
                                  switch (RAW_TempByte) {
                                        case 10:{
                                            RAW_TempByte=0x0A;
                                            break;
                                        }
                                        case 11:{
                                            RAW_TempByte=0x0B;
                                            break;
                                        }
                                        case 12:{
                                            RAW_TempByte=0x0C;
                                            break;
                                        }
                                        case 13:{
                                            RAW_TempByte=0x0D;
                                            break;
                                        }
                                        case 14:{
                                            RAW_TempByte=0x0E;
                                            break;
                                        }
                                        case 15:{
                                            RAW_TempByte=0x0F;
                                            break;
                                        }
                                  }
                        }
                        if((idx%8 == 0) && RowIndex<NUMBER_OF_FRAMES){                   // Sor léptetés +1-el
                            RowIndex++;
                            idx=2;
                        }
                        
                        Multi_Frame[RowIndex][idx]=((TempByte << 4) | RAW_TempByte);
                        idx++;
                    }
                  

                    
                }
                  Serial.print("\n");
                  Serial.print("FF: ");
                  Multi_Frame[0][0]=0x47;
                  //Serial.print(Multi_Frame[0][0],HEX);
                  //Serial.print(" ");
                  for(unsigned int sorind=0;sorind<=meddigFut;sorind++){                  // Displaying Multi frame
                        if(sorind!=0){
                            Serial.print("CF: ");
                        }
                      for(unsigned int index=0;index<FRAME_LENGTH;index++){
                          display_byte_in_hexa(Multi_Frame[sorind][index]);
                          Serial.print(" ");
                      }
                    Serial.print("\n");
                  }
                  Serial.print("\n");
                 /* for(unsigned int index=2;index<(FRAME_LENGTH);index++){
                    if(index%8 != 0 && index%8 != 1){
                      byte FFbyte=0xFF;
                      Multi_Frame[index]=FFbyte;
                  }   
                  }   */
            }       

            else{
                Serial.print("ERROR");
            }
            
      }
}
}






                      

void setup()
{
    Serial.begin(9600);
}


void loop()
{
  CharToFrame();
}
