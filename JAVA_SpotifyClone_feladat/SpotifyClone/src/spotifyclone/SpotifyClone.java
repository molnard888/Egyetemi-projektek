/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package spotifyclone;

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


public class SpotifyClone {

    static Tarolo[] Ttomb = new Tarolo[35];
    static int j=0;
    
 static void shuffleArray(Tarolo[] ar)
{
  // If running on Java 6 or older, use `new Random()` on RHS here
  Random rnd = ThreadLocalRandom.current();
  for (int i = ar.length - 1; i > 0; i--)
  {
    int index = rnd.nextInt(i + 1);
    // Simple swap
    Tarolo a = ar[index];
    ar[index] = ar[i];
    ar[i] = a;
  }
}
    
    
 public static void main(String[] args) {
        BufferedReader objReader = null;
    try {
    String strCurrentLine;

    objReader = new BufferedReader(new FileReader("Datafile.txt"));

   while ((strCurrentLine = objReader.readLine()) != null && j<35) {
    
    String[] LineArray = strCurrentLine.split(";");
    Ttomb[j] = new Tarolo(LineArray[0],LineArray[1],LineArray[2],Integer.parseInt(LineArray[3]));
    
    //System.out.print( Ttomb[j].cim + ", " + Ttomb[j].eloado + ", " + Ttomb[j].stilus + ", " + Ttomb[j].hossz);
    //System.out.println();
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
   
        
        System.out.println("------Lejátszó------"); 
        System.out.println("Lejátszás tárolási sorrendben: 1");
        System.out.println("Lejátszás véletlenszerű sorrendben: 2");
        System.out.println("Előadó számainak lejátszása egymás után: (Adja meg az előadó nevét!)");
        System.out.println("Számok stílusainak listázása: 4");
        System.out.println("Előadók listázása névsor szerint: 5");
        System.out.println("Egyéni Playlist létrehozása: 6");
         System.out.print("Adjon meg egy számot 1-tő 6-ig: ");
        System.out.println();
        
        
        Scanner in = new Scanner(System.in); 
        
        int Number=in.nextInt();
            switch (Number) {
            case 1:
                System.out.println("Lejátszás tárolási sorrendben:");
                for(int i=0;i<35;i++){
                    System.out.println("Cím: "+Ttomb[i].cim + " Előadó: " + Ttomb[i].eloado + " Stílus: " +
                            Ttomb[i].stilus + " Hossz: " + Ttomb[i].hossz + " másodperc");
                    System.out.println("-----Lejátszva-----");
                }   break;
            case 2:
                System.out.println("Lejátszás véletlenszerű sorrendben:");
                shuffleArray(Ttomb);
                    for (int i = 0; i < Ttomb.length; i++)
                    {
                      System.out.println("Cím: "+Ttomb[i].cim + " Előadó: " + Ttomb[i].eloado + " Stílus: " +
                            Ttomb[i].stilus + " Hossz: " + Ttomb[i].hossz + " másodperc");
                    System.out.println("-----Lejátszva-----");
                    }
                    System.out.println();
                break;
            case 3:
               in.nextLine();
               System.out.println("Adja meg az előadó nevét:");
               String str=in.nextLine();
               System.out.println("zeneszáma(i):");
               for(int k=0;k<35;k++){
                    if(Ttomb[k].eloado.equals(str))
                    {
                        System.out.println("Cím: "+Ttomb[k].cim + " Előadó: " + Ttomb[k].eloado + " Stílus: " +
                            Ttomb[k].stilus + " Hossz: " + Ttomb[k].hossz + " másodperc");
                    System.out.println("-----Lejátszva-----");
                    }
                }
                break;
            case 4:
                System.out.println("Számok stílusainak listázása:");
                for(int i=0;i<35;i++){
                    System.out.println(Ttomb[i].stilus);
                }
                break;
            case 5:
                System.out.println("Előadók listázása névsor szerint:");
                System.out.println();
                ArrayList<String> eloadok = new ArrayList<String>();
                
                
              for (int g = 0; g < 35; g++) 
	      { 
                  {
	          eloadok.add(Ttomb[g].eloado);
                  }
	      }    
	      Collections.sort(eloadok);
              System.out.println(eloadok.get(0));
              for (int h = 1; h < 35; h++) 
	      { 
                  if(eloadok.get(h) == null ? eloadok.get(h-1) != null : !eloadok.get(h).equals(eloadok.get(h-1)))
                  {
	          System.out.println(eloadok.get(h));
                  }
	      }    
                break;
              case 6:  
                  System.out.println();
                  System.out.println("Zeneszámok:");
                  for(int i=0;i<35;i++){
                    System.out.println("Sorszám:"+(i+1)+" Cím: "+Ttomb[i].cim + " Előadó: " + Ttomb[i].eloado + " Stílus: " +
                            Ttomb[i].stilus + " Hossz: " + Ttomb[i].hossz + " másodperc");
                  }
                  System.out.println();
                  System.out.println("Válasszon a listából és adja meg a sorszámo(ka)t (1-35),");
                  System.out.println("vesszővel (,) elválasztva,szóközök nélkül!:");
                  in.nextLine();
                    
                    String plli=in.nextLine();
                    
                    String[] Plist = plli.split(",");
                    
                    
                    try {
                        FileWriter myWriter = new FileWriter("Playlist.txt");
                        for(int i=0;i<Plist.length;i++){
                                    int b=Integer.parseInt(Plist[i])-1;
                                myWriter.write("Sorszám:"+(b+1)+" Cím: "+Ttomb[b].cim + " Előadó: " + Ttomb[b].eloado + " Stílus: " +
                                        Ttomb[b].stilus + " Hossz: " + Ttomb[b].hossz + " másodperc;   ");
                              }
                        
                        myWriter.close();
                        System.out.println("A lejátszási lista sikeresen mentve.");
                      } catch (IOException e) {
                        System.out.println("Hiba történt.");
                        e.printStackTrace();
                  }
              break;    
                
            }
            
            
           
            
            
            
 }
        
}

        
        
 
