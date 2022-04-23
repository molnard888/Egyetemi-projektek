/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author oldman96
 */
public class FelhasznalokTableModel extends AbstractTableModel{

    private static List<String> felhasznalok;
    private final String[] columnNames;
    
    
    public FelhasznalokTableModel() {
        this.columnNames = new String[]{"Felhasználó"};
        FelhasznaloBeolvas();
    }
        
    
    public void FelhasznaloBeolvas(){
        felhasznalok = new ArrayList<>();
        try{
            if(!felhasznalok.isEmpty())
            {
                felhasznalok.clear();
            }
            Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
            Statement stmt=con.createStatement(); 
            ResultSet AdatLekeroQuery=stmt.executeQuery("select felhasznalonev"
                    + "  from felhasznaloktbl "
                    + "ORDER BY felhasznalonev");  
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
             String felh = AdatLekeroQuery.getString(1);
             felhasznalok.add(felh);
            }
            con.close();

        }
        catch(Exception e)
        {
            System.out.println(e);
        }  
    
    }
    
    public String getValueAt(int rowIndex) {
        return felhasznalok.get(rowIndex);
    }
    
    
    @Override
    public int getRowCount() {
          return felhasznalok.size();
    }


    @Override
    public int getColumnCount() {
         return this.columnNames.length;
    }


    @Override
    public String getColumnName(int col) {
        return this.columnNames[col];
    }

    @Override
    public String getValueAt(int rowIndex, int columnIndex) {
        return felhasznalok.get(rowIndex);
    }
    
    public static void setValueAt(String value) {
        felhasznalok.add(value);
    }
    
    public static void deleteValueAt(int rowIndex){
        felhasznalok.remove(rowIndex);
    }
    
}