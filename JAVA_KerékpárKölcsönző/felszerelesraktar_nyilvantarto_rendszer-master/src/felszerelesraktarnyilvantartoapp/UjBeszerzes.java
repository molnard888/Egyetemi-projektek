/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

import java.security.SecureRandom;
import javax.swing.JOptionPane;
import java.util.ArrayList;
import java.sql.Connection;  
import java.sql.DriverManager;  
import java.sql.Statement;
import java.sql.ResultSet;
import java.util.Iterator;
import java.util.Set;
import java.util.HashSet;
import java.util.Collections;
import javax.swing.JFrame;
import java.util.Random;
import java.util.UUID;
import javax.swing.DefaultComboBoxModel;
/**
 *
 * @author oldman96
 */
public class UjBeszerzes extends javax.swing.JFrame {
    
    
    private ArrayList<String> kategoriak = new ArrayList<String>();
    private ArrayList<String> kategoriakUnique = new ArrayList<String>();
    private ArrayList<String> alkategoriak = new ArrayList<String>();
    private ArrayList<String> telephelyek = new ArrayList<String>();
    private String KategoriaComboboxSelectedValue;
    private ArrayList<String> EgyezoKategoriaIndexek = new ArrayList<String>();
    private ArrayList<String> alkategoriakChecked = new ArrayList<String>();
    // ArrayList<String> allapotok = new ArrayList<String>();
    
    
    /**
     * Creates new form FelszerelesekWindow
     */
    
    public UjBeszerzes() {
        
        initComponents();
        ComboboxFeltoltes();
    }
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    
    private void ComboboxFeltoltes(){
        
        try{
            /* if(!allapotok.isEmpty())
            {
                allapotok.clear();
            }  */
            if(!kategoriak.isEmpty())
            {
                kategoriak.clear();
            }
            if(!alkategoriak.isEmpty())
            {
                alkategoriak.clear();
            }
            if(!telephelyek.isEmpty())
            {
                telephelyek.clear();
            }
            if(!kategoriakUnique.isEmpty())
            {
                kategoriakUnique.clear();
            }
            if(!EgyezoKategoriaIndexek.isEmpty())
            {
                EgyezoKategoriaIndexek.clear();
            }
            if(!alkategoriakChecked.isEmpty())
            {
                alkategoriakChecked.clear();
            }
            
            Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
            Statement stmt=con.createStatement(); 
            
            ResultSet AdatLekeroQuery=stmt.executeQuery("select kategoriatbl.Kategoria from kategoriatbl");
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
                kategoriak.add(AdatLekeroQuery.getString(1));
            }
            
            
            AdatLekeroQuery=stmt.executeQuery("select alkategoriatbl.Alkategoria from alkategoriatbl");
            
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
                alkategoriak.add(AdatLekeroQuery.getString(1));
                //System.out.println(AdatLekeroQuery.getString(1));
            }
            int idx=0;
            for(int i=0; i < kategoriak.size(); i++){
                if(kategoriak.get(i).equals(kategoriak.get(0)))
                {
                    EgyezoKategoriaIndexek.add(Integer.toString(i));
                    idx++;
                }
            }
            for(int j=0; j < EgyezoKategoriaIndexek.size(); j++){
                alkategoriakChecked.add(alkategoriak.get(Integer.parseInt(EgyezoKategoriaIndexek.get(j))));
            }
            
            
                    
            AdatLekeroQuery=stmt.executeQuery("select telephelyektbl.Telephely from telephelyektbl");
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
                telephelyek.add(AdatLekeroQuery.getString(1));
                //System.out.println(AdatLekeroQuery.getString(1));
            }        
            Set<String> set = new HashSet<>(kategoriak);
            kategoriakUnique.addAll(set);
            Collections.reverse(kategoriakUnique);
            //kategoriak.forEach(part -> System.out.println(part));
            
            /* AdatLekeroQuery=stmt.executeQuery("select allapottbl.Allapot from allapottbl");
            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
            { 
                allapotok.add(AdatLekeroQuery.getString(1));
                //System.out.println(AdatLekeroQuery.getString(1));
            }
            allapotok.remove( allapotok.size()-1 ); */
            
            con.close();
            
            // 16 hosszu random text
            final String AB = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            SecureRandom rnd = new SecureRandom();
            StringBuilder sb = new StringBuilder(16);
            for(int i = 0; i < 16; i++)
            sb.append(AB.charAt(rnd.nextInt(AB.length())));
            RaktariAzonositoTextfield.setText(sb.toString());
            KategoriaCombobox.setModel(new DefaultComboBoxModel<String>(kategoriakUnique.toArray(new String[0])));
            AlkategoriaCombobox.setModel(new DefaultComboBoxModel<String>(alkategoriakChecked.toArray(new String[0])));
            RaktarhelyCombobox.setModel(new DefaultComboBoxModel<String>(telephelyek.toArray(new String[0])));
        }
        catch(Exception e)
        {
            JOptionPane.showMessageDialog(null,e);
        }  
    }
    
    
    
    
    
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        MegnevezesLabel = new javax.swing.JLabel();
        GyartoLabel = new javax.swing.JLabel();
        GyartoTextfield = new javax.swing.JTextField();
        TipusLabel = new javax.swing.JLabel();
        TipusTextfield = new javax.swing.JTextField();
        AdatokLabel = new javax.swing.JLabel();
        KategoriaLabel = new javax.swing.JLabel();
        KategoriaCombobox = new javax.swing.JComboBox<>();
        AlkategoriaLabel = new javax.swing.JLabel();
        AlkategoriaCombobox = new javax.swing.JComboBox<>();
        EvjaratLabel = new javax.swing.JLabel();
        EvjaratSpinner = new javax.swing.JSpinner();
        AllapotLabel = new javax.swing.JLabel();
        AllapotSpinner = new javax.swing.JSpinner();
        BeszerzArLabel = new javax.swing.JLabel();
        BeszerzArTextfield = new javax.swing.JTextField();
        BeszerzHelyLabel = new javax.swing.JLabel();
        BeszerzHelyTextfield = new javax.swing.JTextField();
        SnLabel = new javax.swing.JLabel();
        SnTextfield = new javax.swing.JTextField();
        RaktarhelyLabel = new javax.swing.JLabel();
        RaktarhelyCombobox = new javax.swing.JComboBox<>();
        RaktariAzonositoLabel = new javax.swing.JLabel();
        RaktariAzonositoTextfield = new javax.swing.JTextField();
        MentesButton = new javax.swing.JButton();
        MegseButton = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Új felszerelés felvétele");

        MegnevezesLabel.setFont(new java.awt.Font("Segoe UI", 1, 24)); // NOI18N
        MegnevezesLabel.setText("Megnevezés:");

        GyartoLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        GyartoLabel.setText("Gyártó:");

        GyartoTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N

        TipusLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        TipusLabel.setText("Típus:");

        TipusTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N

        AdatokLabel.setFont(new java.awt.Font("Segoe UI", 1, 24)); // NOI18N
        AdatokLabel.setText("Adatok:");

        KategoriaLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        KategoriaLabel.setText("Kategória:");

        KategoriaCombobox.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N
        KategoriaCombobox.setModel(new javax.swing.DefaultComboBoxModel<String>(kategoriakUnique.toArray(new String[0])));
        KategoriaCombobox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                KategoriaComboboxActionPerformed(evt);
            }
        });

        AlkategoriaLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        AlkategoriaLabel.setText("Alkategória:");

        AlkategoriaCombobox.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N
        AlkategoriaCombobox.setModel(new javax.swing.DefaultComboBoxModel<String>(alkategoriakChecked.toArray(new String[0])));

        EvjaratLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        EvjaratLabel.setText("Évjárat:");

        EvjaratSpinner.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N
        EvjaratSpinner.setModel(new javax.swing.SpinnerNumberModel(2021, 1900, 2021, 1));

        AllapotLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        AllapotLabel.setText("Állapot:");

        AllapotSpinner.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N
        AllapotSpinner.setModel(new javax.swing.SpinnerNumberModel(100, 0, 100, 1));

        BeszerzArLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        BeszerzArLabel.setText("Beszerzési ár:");

        BeszerzArTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N

        BeszerzHelyLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        BeszerzHelyLabel.setText("Beszerzés helye:");

        BeszerzHelyTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N

        SnLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        SnLabel.setText("S/N:");

        SnTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N

        RaktarhelyLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        RaktarhelyLabel.setText("Raktárhely:");

        RaktarhelyCombobox.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N
        RaktarhelyCombobox.setModel(new javax.swing.DefaultComboBoxModel<String>(telephelyek.toArray(new String[0])));

        RaktariAzonositoLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        RaktariAzonositoLabel.setText("Raktári azonosító:");

        RaktariAzonositoTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N
        RaktariAzonositoTextfield.setEnabled(false);

        MentesButton.setText("Mentés");
        MentesButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                MentesButtonActionPerformed(evt);
            }
        });

        MegseButton.setText("Mégse");
        MegseButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                MegseButtonActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(16, 16, 16)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(AdatokLabel)
                            .addComponent(MegnevezesLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 190, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                                    .addGroup(layout.createSequentialGroup()
                                        .addComponent(SnLabel)
                                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                        .addComponent(SnTextfield))
                                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                        .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                            .addComponent(BeszerzArLabel)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addComponent(BeszerzArTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, 223, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                            .addComponent(BeszerzHelyLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 141, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addComponent(BeszerzHelyTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, 223, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                            .addComponent(EvjaratLabel)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addComponent(EvjaratSpinner, javax.swing.GroupLayout.PREFERRED_SIZE, 100, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGap(18, 18, 18)
                                            .addComponent(AllapotLabel)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addComponent(AllapotSpinner, javax.swing.GroupLayout.PREFERRED_SIZE, 97, javax.swing.GroupLayout.PREFERRED_SIZE))))
                                .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                                    .addGap(47, 47, 47)
                                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                        .addGroup(layout.createSequentialGroup()
                                            .addComponent(KategoriaLabel)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                            .addComponent(KategoriaCombobox, javax.swing.GroupLayout.PREFERRED_SIZE, 229, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGap(54, 54, 54)
                                            .addComponent(AlkategoriaLabel)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addComponent(AlkategoriaCombobox, javax.swing.GroupLayout.PREFERRED_SIZE, 230, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addGroup(layout.createSequentialGroup()
                                            .addComponent(RaktarhelyLabel)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addComponent(RaktarhelyCombobox, javax.swing.GroupLayout.PREFERRED_SIZE, 230, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGap(268, 268, 268)
                                            .addComponent(RaktariAzonositoLabel)
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                            .addComponent(RaktariAzonositoTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, 351, javax.swing.GroupLayout.PREFERRED_SIZE))
                                        .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                                            .addComponent(MentesButton, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGap(57, 57, 57)
                                            .addComponent(MegseButton, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                                            .addGap(39, 39, 39)))))))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(66, 66, 66)
                        .addComponent(GyartoLabel)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(GyartoTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, 251, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(73, 73, 73)
                        .addComponent(TipusLabel)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(TipusTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, 373, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(25, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(37, 37, 37)
                .addComponent(MegnevezesLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 35, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(GyartoLabel)
                    .addComponent(GyartoTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(TipusLabel)
                    .addComponent(TipusTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(47, 47, 47)
                .addComponent(AdatokLabel)
                .addGap(16, 16, 16)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(KategoriaLabel)
                    .addComponent(KategoriaCombobox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(AlkategoriaLabel)
                    .addComponent(AlkategoriaCombobox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(42, 42, 42)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(EvjaratLabel)
                    .addComponent(EvjaratSpinner, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(AllapotLabel)
                    .addComponent(AllapotSpinner, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(27, 27, 27)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(BeszerzArLabel)
                    .addComponent(BeszerzArTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(BeszerzHelyLabel)
                    .addComponent(BeszerzHelyTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(SnLabel)
                    .addComponent(SnTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 38, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(RaktarhelyLabel)
                    .addComponent(RaktarhelyCombobox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(RaktariAzonositoLabel)
                    .addComponent(RaktariAzonositoTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(85, 85, 85)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(MentesButton, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(MegseButton, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(58, 58, 58))
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void KategoriaComboboxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_KategoriaComboboxActionPerformed
        // TODO add your handling code here:
        EgyezoKategoriaIndexek.clear();
        alkategoriakChecked.clear();
        int idx=0;
            for(int i=0; i < kategoriak.size(); i++){
                if(kategoriak.get(i).equals(KategoriaCombobox.getSelectedItem()))
                {
                    EgyezoKategoriaIndexek.add(Integer.toString(i));
                    idx++;
                }
            }
            for(int j=0; j < EgyezoKategoriaIndexek.size(); j++){
                alkategoriakChecked.add(alkategoriak.get(Integer.parseInt(EgyezoKategoriaIndexek.get(j))));
            }
        AlkategoriaCombobox.setModel(new javax.swing.DefaultComboBoxModel<String>(alkategoriakChecked.toArray(new String[0])));
    }//GEN-LAST:event_KategoriaComboboxActionPerformed

    private void MentesButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_MentesButtonActionPerformed
        // TODO add your handling code here:
        //System.out.println(GyartoTextfield.getText());
        
        try{
            String Evjarat = "";
            String Allapot = "";
            Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
            Statement stmt=con.createStatement(); 
            
            try {
                EvjaratSpinner.commitEdit();
            } catch ( java.text.ParseException e ) 
            {
                System.out.println(e);
            }
            if((Integer)EvjaratSpinner.getValue()<2022 && (Integer)EvjaratSpinner.getValue()>1500)
            {
                Evjarat = EvjaratSpinner.getValue().toString();
            }
            
                
            try {
                AllapotSpinner.commitEdit();
            } catch ( java.text.ParseException e ) 
            {
                System.out.println(e);
            }
            if((Integer)AllapotSpinner.getValue()<101 && (Integer)AllapotSpinner.getValue()>-1)
            {
                Allapot = AllapotSpinner.getValue().toString();
            }
            
            
            if(!GyartoTextfield.getText().equals("") && !TipusTextfield.getText().equals("") && !BeszerzArTextfield.getText().equals("") && !BeszerzHelyTextfield.getText().equals("")
                     && !SnTextfield.getText().equals("") && !RaktariAzonositoTextfield.getText().equals("") && !Allapot.equals("") && !Evjarat.equals(""))
            {
                ArrayList<String> gyartok = new ArrayList<String>();
                ArrayList<String> tipusok = new ArrayList<String>();
                
                ResultSet AdatLekeroQuery=stmt.executeQuery("SELECT gyartoktbl.Gyarto FROM gyartoktbl WHERE Gyarto='"+GyartoTextfield.getText()+"';");
                while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
                { 
                    gyartok.add(AdatLekeroQuery.getString(1));
                    //System.out.println(AdatLekeroQuery.getString(1));
                }     
                if(gyartok.isEmpty())
                {
                    stmt.executeUpdate("INSERT INTO `gyartoktbl` (Gyarto) VALUES ('"+ GyartoTextfield.getText() +"');");
                }
                
                AdatLekeroQuery=stmt.executeQuery("SELECT tipustbl.Tipus FROM tipustbl WHERE Tipus='"+TipusTextfield.getText()+"';");
                while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
                { 
                    tipusok.add(AdatLekeroQuery.getString(1));
                    //System.out.println(AdatLekeroQuery.getString(1));
                }     
                if(tipusok.isEmpty())
                {
                stmt.executeUpdate("INSERT INTO `tipustbl` (Tipus) VALUES ('"+ TipusTextfield.getText() +"');");
                }
                
                
                stmt.executeUpdate("insert into raktartbl (Gyarto, Tipus, Kategoria, Evjarat, BeszAr, Telephely, Allapot, BeszHely, Gyariszam, QRKod) VALUE ( "
                    + " (select gyartoktbl.ID from gyartoktbl where Gyarto like '"+GyartoTextfield.getText()+"'),"
                    + " (select tipustbl.ID from tipustbl where Tipus like '"+TipusTextfield.getText()+"'),"
                    + " (select k.ID from kategoriatbl k join alkategoriatbl ak on k.AlkategoriaID = ak.ID where Kategoria like '"+KategoriaCombobox.getSelectedItem()+"'"
                            +" and Alkategoria like '"+AlkategoriaCombobox.getSelectedItem()+"'),"
                    + " (select "+ Evjarat +" ),"
                    + " (select "+ BeszerzArTextfield.getText() +" ),"
                    + " (select telephelyektbl.ID from telephelyektbl where Telephely like '"+ RaktarhelyCombobox.getSelectedItem() +"'),"
                    + " (select allapottbl.ID from allapottbl where Allapot like '"+Allapot+"%'),"
                    + " (select '"+BeszerzHelyTextfield.getText()+"'),"
                    + " (select '"+SnTextfield.getText()+"'),"
                    + " (select '"+RaktariAzonositoTextfield.getText()+"') );");
                
                JOptionPane.showMessageDialog(this,"Sikeres mentés!");
                
                    
            }
            con.close();
        }
        catch(Exception e)
        {
            JOptionPane.showMessageDialog(null,e);
        } 
            if(!kategoriak.isEmpty())
            {
                kategoriak.clear();
            }
            if(!alkategoriak.isEmpty())
            {
                alkategoriak.clear();
            }
            if(!telephelyek.isEmpty())
            {
                telephelyek.clear();
            }
            if(!kategoriakUnique.isEmpty())
            {
                kategoriakUnique.clear();
            }
            if(!EgyezoKategoriaIndexek.isEmpty())
            {
                EgyezoKategoriaIndexek.clear();
            }
            if(!alkategoriakChecked.isEmpty())
            {
                alkategoriakChecked.clear();
            }
           
    }//GEN-LAST:event_MentesButtonActionPerformed

    private void MegseButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_MegseButtonActionPerformed
        // TODO add your handling code here:
        if(!kategoriak.isEmpty())
            {
                kategoriak.clear();
            }
            if(!alkategoriak.isEmpty())
            {
                alkategoriak.clear();
            }
            if(!telephelyek.isEmpty())
            {
                telephelyek.clear();
            }
            if(!kategoriakUnique.isEmpty())
            {
                kategoriakUnique.clear();
            }
            if(!EgyezoKategoriaIndexek.isEmpty())
            {
                EgyezoKategoriaIndexek.clear();
            }
            if(!alkategoriakChecked.isEmpty())
            {
                alkategoriakChecked.clear();
            }
        this.dispose();
    }//GEN-LAST:event_MegseButtonActionPerformed
//
//    /**
//     * @param args the command line arguments
//     */
//    public static void main(String args[]) {
//        /* Set the Nimbus look and feel */
//        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
//        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
//         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
//         */
//        try {
//            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
//                if ("Nimbus".equals(info.getName())) {
//                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
//                    break;
//                }
//            }
//        } catch (ClassNotFoundException ex) {
//            java.util.logging.Logger.getLogger(FelszerelesekWindow.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
//        } catch (InstantiationException ex) {
//            java.util.logging.Logger.getLogger(FelszerelesekWindow.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
//        } catch (IllegalAccessException ex) {
//            java.util.logging.Logger.getLogger(FelszerelesekWindow.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
//        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
//            java.util.logging.Logger.getLogger(FelszerelesekWindow.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
//        }
//        //</editor-fold>
//
//        /* Create and display the form */
//        java.awt.EventQueue.invokeLater(new Runnable() {
//            public void run() {
//                new FelszerelesekWindow().setVisible(true);
//            }
//        });
//    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JLabel AdatokLabel;
    private javax.swing.JComboBox<String> AlkategoriaCombobox;
    private javax.swing.JLabel AlkategoriaLabel;
    private javax.swing.JLabel AllapotLabel;
    private javax.swing.JSpinner AllapotSpinner;
    private javax.swing.JLabel BeszerzArLabel;
    private javax.swing.JTextField BeszerzArTextfield;
    private javax.swing.JLabel BeszerzHelyLabel;
    private javax.swing.JTextField BeszerzHelyTextfield;
    private javax.swing.JLabel EvjaratLabel;
    private javax.swing.JSpinner EvjaratSpinner;
    private javax.swing.JLabel GyartoLabel;
    private javax.swing.JTextField GyartoTextfield;
    private javax.swing.JComboBox<String> KategoriaCombobox;
    private javax.swing.JLabel KategoriaLabel;
    private javax.swing.JLabel MegnevezesLabel;
    private javax.swing.JButton MegseButton;
    private javax.swing.JButton MentesButton;
    private javax.swing.JComboBox<String> RaktarhelyCombobox;
    private javax.swing.JLabel RaktarhelyLabel;
    private javax.swing.JLabel RaktariAzonositoLabel;
    private javax.swing.JTextField RaktariAzonositoTextfield;
    private javax.swing.JLabel SnLabel;
    private javax.swing.JTextField SnTextfield;
    private javax.swing.JLabel TipusLabel;
    private javax.swing.JTextField TipusTextfield;
    // End of variables declaration//GEN-END:variables
}
