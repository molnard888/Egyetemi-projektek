/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

import java.sql.Connection;  
import java.sql.DriverManager;  
import java.sql.Statement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JOptionPane;


/**
 *
 * @author oldman96
 */
public class Tarolo {
    static private List<Felszereles> felszerelesek;
    static private Felszereles f;
    
    
    //parameteres beolvas fgv.
    public static void Beolvas(List<Felszereles> _felszerelesek, Felszereles _f){
        //_felszerelesek = new ArrayList<>();
        try{
            if(!_felszerelesek.isEmpty())
            {
                _felszerelesek.clear();
            }
            Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
            Statement stmt=con.createStatement(); 
            ResultSet AdatLekeroQuery=stmt.executeQuery("select gyartoktbl.Gyarto, tipustbl.Tipus, kategoriatbl.Kategoria, alkategoriatbl.Alkategoria, raktartbl.Evjarat, raktartbl.BeszAr, "
                    + "telephelyektbl.Telephely, allapottbl.Allapot, raktartbl.BeszHely, raktartbl.Gyariszam, raktartbl.QRKod"
                    + "  from raktartbl "
                    + "INNER JOIN gyartoktbl ON raktartbl.Gyarto=gyartoktbl.ID "
                    + "INNER JOIN tipustbl ON raktartbl.Tipus=tipustbl.ID "
                    + "INNER JOIN kategoriatbl ON raktartbl.Kategoria=kategoriatbl.ID "
                    + "INNER JOIN alkategoriatbl ON kategoriatbl.AlkategoriaID=alkategoriatbl.ID "
                    + "INNER JOIN telephelyektbl ON raktartbl.Telephely=telephelyektbl.ID "
                    + "INNER JOIN allapottbl ON raktartbl.Allapot=allapottbl.ID");  
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
             _f = new Felszereles(AdatLekeroQuery.getString(1), AdatLekeroQuery.getString(2), AdatLekeroQuery.getString(3), 
                                AdatLekeroQuery.getString(4), AdatLekeroQuery.getString(5), AdatLekeroQuery.getString(6), 
                                AdatLekeroQuery.getString(7), AdatLekeroQuery.getString(8), AdatLekeroQuery.getString(9), AdatLekeroQuery.getString(10), AdatLekeroQuery.getString(11) );
             _felszerelesek.add(_f);
            }
            con.close();
            
            /* for(int i=0; i < felszerelesek.size(); i++){
            felszerelesek.get(i).printOutFelszerelesToConsole();
            }  */

        }
        catch(Exception e)
        {
            System.out.println(e);
        }  
    }
    
    
    //parameter nelkuli beolvas fgv.
    public static void Beolvas(){
        felszerelesek = new ArrayList<>();
        try{
            if(!felszerelesek.isEmpty())
            {
                felszerelesek.clear();
            }
            Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
            Statement stmt=con.createStatement(); 
            ResultSet AdatLekeroQuery=stmt.executeQuery("select gyartoktbl.Gyarto, tipustbl.Tipus, kategoriatbl.Kategoria, alkategoriatbl.Alkategoria, raktartbl.Evjarat, raktartbl.BeszAr, "
                    + "telephelyektbl.Telephely, allapottbl.Allapot, raktartbl.BeszHely, raktartbl.Gyariszam, raktartbl.QRKod"
                    + "  from raktartbl "
                    + "INNER JOIN gyartoktbl ON raktartbl.Gyarto=gyartoktbl.ID "
                    + "INNER JOIN tipustbl ON raktartbl.Tipus=tipustbl.ID "
                    + "INNER JOIN kategoriatbl ON raktartbl.Kategoria=kategoriatbl.ID "
                    + "INNER JOIN alkategoriatbl ON kategoriatbl.AlkategoriaID=alkategoriatbl.ID "
                    + "INNER JOIN telephelyektbl ON raktartbl.Telephely=telephelyektbl.ID "
                    + "INNER JOIN allapottbl ON raktartbl.Allapot=allapottbl.ID");  
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
             f = new Felszereles(AdatLekeroQuery.getString(1), AdatLekeroQuery.getString(2), AdatLekeroQuery.getString(3), 
                                AdatLekeroQuery.getString(4), AdatLekeroQuery.getString(5), AdatLekeroQuery.getString(6), 
                                AdatLekeroQuery.getString(7), AdatLekeroQuery.getString(8), AdatLekeroQuery.getString(9), AdatLekeroQuery.getString(10), AdatLekeroQuery.getString(11) );
             felszerelesek.add(f);
            }
            con.close();
            
            /* for(int i=0; i < felszerelesek.size(); i++){
            felszerelesek.get(i).printOutFelszerelesToConsole();
            }  */

        }
        catch(Exception e)
        {
            JOptionPane.showMessageDialog(null,e);
            System.out.println(e);
        }  
    }
    
   
}
