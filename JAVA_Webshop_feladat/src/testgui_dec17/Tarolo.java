/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testgui_dec17;

import java.util.Scanner; 
import java.util.*;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Collections;
import java.util.concurrent.ThreadLocalRandom;
import java.io.FileWriter; 
import static java.lang.Integer.parseInt;

public class Tarolo {
    
    Termek termekTomb[] = new Termek[60];
     public static int j=0;
    int TombSize=60;
    Tarolo(){
    
        BufferedReader objReader = null;
    try {
    String strCurrentLine;

    objReader = new BufferedReader(new FileReader("termekek.txt"));

   while ((strCurrentLine = objReader.readLine()) != null && j<TombSize) {
    
    String[] LineArray = strCurrentLine.split(";");
    
    termekTomb[j] = new Termek(parseInt(LineArray[0]),LineArray[1],LineArray[2],parseInt(LineArray[3]),parseInt(LineArray[4]));
    
    /*System.out.print( termekTomb[j].nev + ", " + termekTomb[j].kategoria + ", " 
            + termekTomb[j].ar + ", " + termekTomb[j].darab);
    System.out.println();   */
    j++;
    
    }
    }

   catch (IOException e) {

   System.out.println("A fájlt nem lehet megnyitni");

  } finally {

   try {
    if (objReader != null)
     objReader.close();
   } catch (IOException ex) {
    ex.printStackTrace();
   }
    }
    
    }  

}

