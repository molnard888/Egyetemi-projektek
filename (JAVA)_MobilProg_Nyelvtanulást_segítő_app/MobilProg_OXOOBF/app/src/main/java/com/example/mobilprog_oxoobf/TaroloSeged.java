package com.example.mobilprog_oxoobf;


import java.util.ArrayList;
import java.util.List;

public class TaroloSeged {
    public static String Username="";
    public static String Language="";
    public static String Category="";
    public static int KerdesSzamlalo = 0;
    public static int OsszKerdes = 20;
    public static List<Integer> VoltMar = new ArrayList<Integer>();
    public static List<String> Szavak = new ArrayList<String>();
    public static String HelyesValasz;
    public static int Pontszam;


    public static Thread thread1;



    public static void Nullaz(){
        Username="";
        Language="";
        Category="";
        KerdesSzamlalo = 0;
        OsszKerdes = 20;
        VoltMar.clear();
        Szavak.clear();
        HelyesValasz="";
        Pontszam = 0;
        thread1 = null;
    }

}
