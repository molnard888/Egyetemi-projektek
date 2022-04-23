/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testgui_dec17;

/**
 *
 * @author Dániel
 */
public class Termek {
    int ID;
    String nev;
    String kategoria;
    int ar;
    int darab;
   
    
    Termek(int azon, String ne, String kat, int ara, int db){
        ID=azon;
        nev=ne;
        kategoria=kat;
        ar=ara;
        darab=db;
    }
}
