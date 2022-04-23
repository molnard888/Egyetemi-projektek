/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

import com.google.zxing.WriterException;
import java.awt.Color;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.regex.Pattern;
import javax.swing.DefaultComboBoxModel;
import javax.swing.ImageIcon;
import javax.swing.JFileChooser;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.RowFilter;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.table.DefaultTableCellRenderer;
import javax.swing.table.TableRowSorter;

/**
 *
 * @author oldman96
 */
public class Kolcsonzesek extends javax.swing.JFrame {

    /**
     * Creates new form FelszerelesekWindow
     */
    
    private static KolcsonzesekTableModel tm;
    private Felszereles f = null;
    private int filterByColumn;
    private final ImageIcon sikerIcon = new ImageIcon(getClass().getResource("/icons/icons8_ok_48px.png"));
    private final ImageIcon hibaIcon = new ImageIcon(getClass().getResource("/icons/icons8_cancel_48px.png"));
    private final ImageIcon kerdesIcon = new ImageIcon(getClass().getResource("/icons/icons8_help_48px.png"));
    
    public Kolcsonzesek() {
        initComponents();
        
        tm = new KolcsonzesekTableModel();
        DefaultTableCellRenderer centerRenderer = new DefaultTableCellRenderer();
        DefaultTableCellRenderer rightRenderer = new DefaultTableCellRenderer();
        centerRenderer.setHorizontalAlignment(JLabel.CENTER);
        rightRenderer.setHorizontalAlignment(JLabel.RIGHT);
    
        kolcsonzesekTable.setModel(tm);
        kolcsonzesekTable.getColumnModel().getColumn(0).setMinWidth(70);
        kolcsonzesekTable.getColumnModel().getColumn(0).setCellRenderer(centerRenderer);
        kolcsonzesekTable.getColumnModel().getColumn(1).setMinWidth(150);
        kolcsonzesekTable.getColumnModel().getColumn(1).setCellRenderer(centerRenderer);
        kolcsonzesekTable.getColumnModel().getColumn(2).setMinWidth(140);
        kolcsonzesekTable.getColumnModel().getColumn(2).setCellRenderer(centerRenderer);
        kolcsonzesekTable.getColumnModel().getColumn(3).setMinWidth(130);
        kolcsonzesekTable.getColumnModel().getColumn(3).setCellRenderer(centerRenderer);
        kolcsonzesekTable.getColumnModel().getColumn(4).setMinWidth(130);
        kolcsonzesekTable.getColumnModel().getColumn(4).setCellRenderer(centerRenderer);
        kolcsonzesekTable.getColumnModel().getColumn(5).setMinWidth(90);
        kolcsonzesekTable.getColumnModel().getColumn(5).setCellRenderer(centerRenderer);
        kolcsonzesekTable.getColumnModel().getColumn(6).setMinWidth(90);
        kolcsonzesekTable.getColumnModel().getColumn(6).setCellRenderer(centerRenderer);
        //kolcsonzesekTable.getColumnModel().getColumn(7).setMinWidth(150);
        kolcsonzesekTable.getTableHeader().setFont(new java.awt.Font("Tahoma", 1, 14));
        kolcsonzesekTable.getTableHeader().setOpaque(false);
        kolcsonzesekTable.getTableHeader().setBackground(new Color(196, 196, 196));
        szuresToggleButton.addItemListener(itemListener);
        szuresComboBox.setVisible(false);
        szuresTextField.setVisible(false);
    }

    
        ItemListener itemListener = new ItemListener() {
        @Override
        public void itemStateChanged(ItemEvent itemEvent) {
            int state1 = itemEvent.getStateChange();
            
            if (state1 == ItemEvent.SELECTED) {
                kolcsonzesekTable.setSize(1150, 520);
                szuresComboBox.setVisible(true);
                szuresTextField.setVisible(true);
            } else {
                szuresComboBox.setVisible(false);
                szuresTextField.setVisible(false);
                kolcsonzesekTable.setSize(1150, 570);
            }
        }
    };
    
    private void tableFilter(String filterText){
        
        if(filterByColumn<7){
            TableRowSorter<KolcsonzesekTableModel> sorter = new TableRowSorter<>(tm);
            sorter.setRowFilter(RowFilter.regexFilter("(?i)" + filterText, filterByColumn));
            if(szuresTextField.getText().length()==0){
                kolcsonzesekTable.setRowSorter(null);
            }
            kolcsonzesekTable.setRowSorter(sorter);
        }
        else{
            
            Kolcsonzesek.setTm(new KolcsonzesekTableModel());
            Kolcsonzesek.refreshTable();
        }
        
        
        
    }
    
    
    
    public static void setTm(KolcsonzesekTableModel _tm){
        tm=_tm;
    }
    
    public static void refreshTable(){
        kolcsonzesekTable.repaint();
    }
    
    
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        szuresTextField = new javax.swing.JTextField();
        szuresComboBox = new javax.swing.JComboBox<>();
        jScrollPane1 = new javax.swing.JScrollPane();
        kolcsonzesekTable = new javax.swing.JTable();
        reszletekBtn = new javax.swing.JButton();
        exportalasBtn = new javax.swing.JButton();
        LeadásBtn = new javax.swing.JButton();
        megseBtn1 = new javax.swing.JButton();
        torlesBtn = new javax.swing.JButton();
        szuresToggleButton = new javax.swing.JToggleButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Kölcsönzések");

        szuresTextField.setBackground(new java.awt.Color(243, 237, 237));
        szuresTextField.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyReleased(java.awt.event.KeyEvent evt) {
                szuresTextFieldKeyReleased(evt);
            }
        });

        szuresComboBox.setModel(new DefaultComboBoxModel(new String[]{"Kölcsönzés azonosító", "Név", "Telefon", "Kölcsönzés kezdete", "Kölcsönzés vége", "Kiadási hely", "Leadási hely"}));
        szuresComboBox.addItemListener(new java.awt.event.ItemListener() {
            public void itemStateChanged(java.awt.event.ItemEvent evt) {
                szuresComboBoxItemStateChanged(evt);
            }
        });

        jScrollPane1.setVerticalScrollBarPolicy(javax.swing.ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS);
        jScrollPane1.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));

        kolcsonzesekTable.setAutoCreateRowSorter(true);
        kolcsonzesekTable.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        kolcsonzesekTable.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null}
            },
            new String [] {
                "ID", "Név", "Telefon", "Kölcsönzés kezdete", "Kölcsönzés vége", "Kiadás helye", "Leadás helye"
            }
        ) {
            boolean[] canEdit = new boolean [] {
                false, false, false, false, false, false, false
            };

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        kolcsonzesekTable.setIntercellSpacing(new java.awt.Dimension(8, 5));
        kolcsonzesekTable.setRowHeight(60);
        jScrollPane1.setViewportView(kolcsonzesekTable);

        reszletekBtn.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        reszletekBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8_info_32px.png"))); // NOI18N
        reszletekBtn.setText("Részletek");
        reszletekBtn.setBorderPainted(false);
        reszletekBtn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        reszletekBtn.setFocusPainted(false);
        reszletekBtn.setFocusable(false);
        reszletekBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                reszletekBtnActionPerformed(evt);
            }
        });

        exportalasBtn.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        exportalasBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8_export_csv_32px.png"))); // NOI18N
        exportalasBtn.setText("Exportálás");
        exportalasBtn.setBorderPainted(false);
        exportalasBtn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        exportalasBtn.setFocusPainted(false);
        exportalasBtn.setFocusable(false);
        exportalasBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                exportalasBtnActionPerformed(evt);
            }
        });

        LeadásBtn.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        LeadásBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8_edit_32px.png"))); // NOI18N
        LeadásBtn.setText("Leadás");
        LeadásBtn.setBorderPainted(false);
        LeadásBtn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        LeadásBtn.setFocusPainted(false);
        LeadásBtn.setFocusable(false);
        LeadásBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                LeadásBtnActionPerformed(evt);
            }
        });

        megseBtn1.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        megseBtn1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8_close_window_32px_2.png"))); // NOI18N
        megseBtn1.setText("Mégse");
        megseBtn1.setBorderPainted(false);
        megseBtn1.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        megseBtn1.setFocusPainted(false);
        megseBtn1.setFocusable(false);
        megseBtn1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                megseBtn1ActionPerformed(evt);
            }
        });

        torlesBtn.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        torlesBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8-delete-list-32.png"))); // NOI18N
        torlesBtn.setText("Törlés");
        torlesBtn.setBorderPainted(false);
        torlesBtn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        torlesBtn.setFocusPainted(false);
        torlesBtn.setFocusable(false);
        torlesBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                torlesBtnActionPerformed(evt);
            }
        });

        szuresToggleButton.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        szuresToggleButton.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8_filter_32px.png"))); // NOI18N
        szuresToggleButton.setText("Szűrés");
        szuresToggleButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                szuresToggleButtonActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(26, 26, 26)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jScrollPane1)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING, false)
                            .addComponent(szuresComboBox, 0, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                            .addComponent(reszletekBtn, javax.swing.GroupLayout.DEFAULT_SIZE, 150, Short.MAX_VALUE))
                        .addGap(18, 18, 18)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(szuresToggleButton, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(exportalasBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(LeadásBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(torlesBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(szuresTextField))
                        .addGap(175, 175, 175)
                        .addComponent(megseBtn1, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(24, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(33, 33, 33)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 519, Short.MAX_VALUE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(szuresComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(szuresTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(reszletekBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(szuresToggleButton, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(exportalasBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(LeadásBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(torlesBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(megseBtn1, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(25, 25, 25))
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void szuresTextFieldKeyReleased(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_szuresTextFieldKeyReleased
        String filterText = Pattern.quote(szuresTextField.getText());
        tableFilter(filterText);
    }//GEN-LAST:event_szuresTextFieldKeyReleased

    private void szuresComboBoxItemStateChanged(java.awt.event.ItemEvent evt) {//GEN-FIRST:event_szuresComboBoxItemStateChanged
        filterByColumn = szuresComboBox.getSelectedIndex();
    }//GEN-LAST:event_szuresComboBoxItemStateChanged

    private void reszletekBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_reszletekBtnActionPerformed
        //a kijelolt sor lekerese
        
         
         if(kolcsonzesekTable.getSelectedRow()!= -1){
                    try{
                       String QRcodeFromDB="";
                       Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
                       Statement stmt=con.createStatement(); 
                       Kolcsonzes kolcs = tm.getKolcsonzes(kolcsonzesekTable.convertRowIndexToModel(kolcsonzesekTable.getSelectedRow()));
                       if(!kolcs.getID().equals("")){
                           ResultSet AdatLekeroQuery=stmt.executeQuery("select QRKod from kolcsonzesektbl where ID='"+kolcs.getID()+"';");
                           while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
                            { 
                               QRcodeFromDB=AdatLekeroQuery.getString(1);
                            }
                            AdatLekeroQuery=stmt.executeQuery("select gyartoktbl.Gyarto, tipustbl.Tipus, kategoriatbl.Kategoria, alkategoriatbl.Alkategoria, raktartbl.Evjarat, raktartbl.BeszAr, "
                                    + "telephelyektbl.Telephely, allapottbl.Allapot, raktartbl.BeszHely, raktartbl.Gyariszam, raktartbl.QRKod"
                                    + "  from raktartbl "
                                    + "INNER JOIN gyartoktbl ON raktartbl.Gyarto=gyartoktbl.ID "
                                    + "INNER JOIN tipustbl ON raktartbl.Tipus=tipustbl.ID "
                                    + "INNER JOIN kategoriatbl ON raktartbl.Kategoria=kategoriatbl.ID "
                                    + "INNER JOIN alkategoriatbl ON kategoriatbl.AlkategoriaID=alkategoriatbl.ID "
                                    + "INNER JOIN telephelyektbl ON raktartbl.Telephely=telephelyektbl.ID "
                                    + "INNER JOIN allapottbl ON raktartbl.Allapot=allapottbl.ID WHERE raktartbl.QRKod='"+QRcodeFromDB+"';");  

                            while(AdatLekeroQuery.next())  // ha van még sor --> sor beolvasása
                            { 
                             f = new Felszereles(AdatLekeroQuery.getString(1), AdatLekeroQuery.getString(2), AdatLekeroQuery.getString(3), 
                                                AdatLekeroQuery.getString(4), AdatLekeroQuery.getString(5), AdatLekeroQuery.getString(6), 
                                                AdatLekeroQuery.getString(7), AdatLekeroQuery.getString(8), AdatLekeroQuery.getString(9), 
                                                AdatLekeroQuery.getString(10), AdatLekeroQuery.getString(11) );
                            }
                            con.close();

                            java.awt.EventQueue.invokeLater(() -> {
                             try {
                                 new Reszletek(f).setVisible(true);
                             } catch (WriterException ex) {
                                 Logger.getLogger(Kolcsonzesek.class.getName()).log(Level.SEVERE, null, ex);
                             } catch (IOException ex) {
                                 Logger.getLogger(Kolcsonzesek.class.getName()).log(Level.SEVERE, null, ex);
                             }});

                        }
                   }
                   catch(Exception e)
                   {
                       JOptionPane.showMessageDialog(null,e);
                       System.out.println(e);
                   }  
        } 
    }//GEN-LAST:event_reszletekBtnActionPerformed

    private void exportalasBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_exportalasBtnActionPerformed
        JFileChooser fileChooser = new JFileChooser();
        fileChooser.addChoosableFileFilter(new FileNameExtensionFilter("Text/csv", "csv"));
        int option = fileChooser.showSaveDialog(this);
        if(option == JFileChooser.APPROVE_OPTION){
            File file = fileChooser.getSelectedFile();
            String fname = file.getAbsolutePath();
            if(!fname.endsWith(".csv") ) {
                file = new File(fname + ".csv");
            }
            try {
                FileWriter save = new FileWriter(file);
                for(int i = 0; i < tm.getNumberOfKolcsonzesek(); i++){
                    save.write(tm.getKolcsonzes(i).printOutKolcsonzesWithSeparator());
                }
                save.close();
                JOptionPane.showMessageDialog(this, "Lista exportálva.","Sikeres mentés!", JOptionPane.INFORMATION_MESSAGE, sikerIcon);

            }catch (Exception e) {
                JOptionPane.showMessageDialog(this, "Sikertelen exportálás.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
                System.out.println(e.getMessage());
            }
        } else JOptionPane.showMessageDialog(this, "Sikertelen exportálás.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
    }//GEN-LAST:event_exportalasBtnActionPerformed

    private void LeadásBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_LeadásBtnActionPerformed
        
        if(kolcsonzesekTable.getSelectedRowCount() == 0){
            JOptionPane.showMessageDialog(this, "Nincs kijelölve kölcsönzés.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        }
        else if(kolcsonzesekTable.getSelectedRowCount() > 1){
            JOptionPane.showMessageDialog(this, "Egyszerre csak egy kölcsönzést módosíthat.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        } else{
            Kolcsonzes f = tm.getKolcsonzes(kolcsonzesekTable.convertRowIndexToModel(kolcsonzesekTable.getSelectedRow()));
            java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    try {
                        new Leadás(f).setVisible(true);

                    } catch (Exception ex) {
                        Logger.getLogger(Felszerelesek.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            });

        }

    }//GEN-LAST:event_LeadásBtnActionPerformed

    private void megseBtn1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_megseBtn1ActionPerformed
        
        this.dispose();
    }//GEN-LAST:event_megseBtn1ActionPerformed

    private void torlesBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_torlesBtnActionPerformed
        if(kolcsonzesekTable.getSelectedRowCount() == 0){
            JOptionPane.showMessageDialog(this, "Nincs kijelölve kölcsönzés.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        }
        else if(kolcsonzesekTable.getSelectedRowCount() > 1){
            JOptionPane.showMessageDialog(this, "Egyszerre csak egy kölcsönzést törölhet.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        } /* else if(tm.getKolcsonzes(kolcsonzesekTable.convertRowIndexToModel(kolcsonzesekTable.getSelectedRow())).getAllapot().equals("Selejt")){
            JOptionPane.showMessageDialog(this, "A felszerelés már selejtezve van.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon); 
        }*/ else{
            Object[] options = {"Igen", "Mégse"};
            int n = JOptionPane.showOptionDialog(this, "Biztosan törölni szeretné a kölcsönzést?", "Biztos benne?",
                JOptionPane.OK_CANCEL_OPTION, JOptionPane.INFORMATION_MESSAGE, kerdesIcon, options, options[1]);
            if(n==JOptionPane.YES_OPTION){
                Kolcsonzes f = tm.getKolcsonzes(kolcsonzesekTable.convertRowIndexToModel(kolcsonzesekTable.getSelectedRow()));
                try{
                    Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");
                    Statement stmt=con.createStatement();
                    stmt.executeUpdate("delete from kolcsonzesektbl"
                        + " where QRKod like '"+f.getQRkod()+"' and KolcsDateFrom like '"+f.getKolcskezd()+"';");
                    Kolcsonzesek.setTm(new KolcsonzesekTableModel());
                    Kolcsonzesek.refreshTable();
                    JOptionPane.showMessageDialog(this, "Módosítás végrehajtva!\n","Sikeres törlés!", JOptionPane.INFORMATION_MESSAGE, sikerIcon);
                    con.close();

                } catch(Exception e){
                    JOptionPane.showMessageDialog(this, "Módosítás sikertelen\n" + e,"Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
                }
            }
        }
    }//GEN-LAST:event_torlesBtnActionPerformed

    private void szuresToggleButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_szuresToggleButtonActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_szuresToggleButtonActionPerformed
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
    private javax.swing.JButton LeadásBtn;
    private javax.swing.JButton exportalasBtn;
    private javax.swing.JScrollPane jScrollPane1;
    private static javax.swing.JTable kolcsonzesekTable;
    private javax.swing.JButton megseBtn1;
    private javax.swing.JButton reszletekBtn;
    private javax.swing.JComboBox<String> szuresComboBox;
    private javax.swing.JTextField szuresTextField;
    private javax.swing.JToggleButton szuresToggleButton;
    private javax.swing.JButton torlesBtn;
    // End of variables declaration//GEN-END:variables
}
