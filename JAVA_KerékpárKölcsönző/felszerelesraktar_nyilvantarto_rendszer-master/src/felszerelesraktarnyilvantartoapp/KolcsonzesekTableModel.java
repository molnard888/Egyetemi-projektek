/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

import javax.swing.table.AbstractTableModel;
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
 * @author Daniel
 */
public class KolcsonzesekTableModel extends AbstractTableModel{

    static private List<Kolcsonzes> kolcsonzesek = new ArrayList<>();
    static private Kolcsonzes f;
    private final String[] columnNames;
    
    public KolcsonzesekTableModel() {
        this.columnNames = new String[]{"Kölcsönzés ID", "Név", "Telefon", "Kölcsönzés kezdete", "Kölcsönzés vége", "Kiadási hely", "Leadási hely"};
        BeolvasToKolcsonzesek();
    }
    
    
    public static void BeolvasToKolcsonzesek(){
        kolcsonzesek = new ArrayList<>();
        try{
            if(!kolcsonzesek.isEmpty())
            {
                kolcsonzesek.clear();
            }
            Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
            Statement stmt=con.createStatement(); 
            ResultSet AdatLekeroQuery=stmt.executeQuery("select *"
                    + "  from kolcsonzesektbl order by KolcsDateFrom desc, KolcsDateTo asc;");  
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
             
             f = new Kolcsonzes(AdatLekeroQuery.getString(1), AdatLekeroQuery.getString(2), AdatLekeroQuery.getString(3), 
                                AdatLekeroQuery.getString(4), AdatLekeroQuery.getString(5), AdatLekeroQuery.getString(6), 
                                AdatLekeroQuery.getString(7), AdatLekeroQuery.getString(8));
             kolcsonzesek.add(f);
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
            case 0: return kolcsonzesek.get(rowIndex).getID();
            case 1: return kolcsonzesek.get(rowIndex).getNev();
            case 2: return kolcsonzesek.get(rowIndex).getTelefon();
            case 3: return kolcsonzesek.get(rowIndex).getKolcskezd();
            case 4: return kolcsonzesek.get(rowIndex).getKolcsveg();
            case 5: return kolcsonzesek.get(rowIndex).getKolcshely();
            case 6: return kolcsonzesek.get(rowIndex).getKolcsleadhely();
            default: return "not found";
        }
    }
    
    
    public Kolcsonzes getKolcsonzes(int rowIndex) {
        return kolcsonzesek.get(rowIndex);
    }
    
    public int getNumberOfKolcsonzesek(){
        return kolcsonzesek.size();
    }
    
    @Override
    public int getRowCount() {
          return kolcsonzesek.size();
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
