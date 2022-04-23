/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

import static felszerelesraktarnyilvantartoapp.Tarolo.Beolvas;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import javax.swing.ImageIcon;
import javax.swing.JOptionPane;
import javax.swing.RowFilter;
import javax.swing.table.AbstractTableModel;
import javax.swing.table.TableRowSorter;

/**
 *
 * @author oldman96
 */
public class TableModel extends AbstractTableModel{

    static private List<Felszereles> felszerelesek;
    static private Felszereles f;
    private final String[] columnNames;
    
    
    public TableModel() {
        this.columnNames = new String[]{"Gyártó (típus)", "Kategória", "Évjárat", "Állapot", "Telephely", "Beszerzési Ár", "Beszerzés helye", "S/N"};
        //felszerelesek = new ArrayList<>();
        Beolvas();
    }
    
    public TableModel(String WebcamResult) {
        this.columnNames = new String[]{"Gyártó, típus", "Kategória", "Évjárat", "Állapot", "Telephely", "Beszerzési Ár", "Beszerzés helye", "S/N"};
        //felszerelesek = new ArrayList<>();
        Beolvas(WebcamResult);
    }
    
    
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
                    + "INNER JOIN allapottbl ON raktartbl.Allapot=allapottbl.ID "
                    + "ORDER BY gyartoktbl.Gyarto");  
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
             f = new Felszereles(AdatLekeroQuery.getString(1), AdatLekeroQuery.getString(2), AdatLekeroQuery.getString(3), 
                                AdatLekeroQuery.getString(4), AdatLekeroQuery.getString(5), AdatLekeroQuery.getString(6), 
                                AdatLekeroQuery.getString(7), AdatLekeroQuery.getString(8), AdatLekeroQuery.getString(9), AdatLekeroQuery.getString(10), AdatLekeroQuery.getString(11) );
             felszerelesek.add(f);
            }
            con.close();

        }
        catch(Exception e)
        {
            JOptionPane.showMessageDialog(null,e);
        }  
    
    }
    
    public static void Beolvas(String WebcamResult){
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
                    + "INNER JOIN allapottbl ON raktartbl.Allapot=allapottbl.ID "
                    + "ORDER BY gyartoktbl.Gyarto");  
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
             if(AdatLekeroQuery.getString(11).equals(WebcamResult)){
                 f = new Felszereles(AdatLekeroQuery.getString(1), AdatLekeroQuery.getString(2), AdatLekeroQuery.getString(3), 
                                AdatLekeroQuery.getString(4), AdatLekeroQuery.getString(5), AdatLekeroQuery.getString(6), 
                                AdatLekeroQuery.getString(7), AdatLekeroQuery.getString(8), AdatLekeroQuery.getString(9), AdatLekeroQuery.getString(10), AdatLekeroQuery.getString(11) );
                 
                felszerelesek.add(f);
             }
             
            }
            con.close();

        }
        catch(Exception e)
        {
            JOptionPane.showMessageDialog(null,e);
        }  
    
    }
    


    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        switch(columnIndex){
            case 0: return felszerelesek.get(rowIndex).getGyarto() + " " + felszerelesek.get(rowIndex).getTipus();
            case 1: return felszerelesek.get(rowIndex).getKategoria() + " / " + felszerelesek.get(rowIndex).getAlkategoria();
            case 2: return felszerelesek.get(rowIndex).getEvjarat();
            case 3: return felszerelesek.get(rowIndex).getAllapot();
            case 4: return felszerelesek.get(rowIndex).getTelephely();
            case 5: return felszerelesek.get(rowIndex).getBeszerzesiAr() + " Ft";
            case 6: return felszerelesek.get(rowIndex).getBeszerzesiHely();
            case 7: return felszerelesek.get(rowIndex).getGyariszam();
            default: return "not found";
        }
    }
    
    
    public Felszereles getFelszereles(int rowIndex) {
        return felszerelesek.get(rowIndex);
    }
    
    public int getNumberOfFelszerelesek(){
        return felszerelesek.size();
    }
    
    @Override
    public int getRowCount() {
          return felszerelesek.size();
    }


    @Override
    public int getColumnCount() {
         return columnNames.length;
    }


    @Override
    public String getColumnName(int col) {
        return columnNames[col];
    }

    
}

