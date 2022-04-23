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
public class Felszerelesek extends javax.swing.JFrame {
    private static TableModel tm;
    private int filterByColumn;
    private final ImageIcon sikerIcon = new ImageIcon(getClass().getResource("/icons/icons8_ok_48px.png"));
    private final ImageIcon hibaIcon = new ImageIcon(getClass().getResource("/icons/icons8_cancel_48px.png"));
    private final ImageIcon kerdesIcon = new ImageIcon(getClass().getResource("/icons/icons8_help_48px.png"));
    

    /**
     * Creates new form FelszerelesekWindow
     */
    public Felszerelesek() {
        initComponents();
        
        tm = new TableModel();
        DefaultTableCellRenderer centerRenderer = new DefaultTableCellRenderer();
        DefaultTableCellRenderer rightRenderer = new DefaultTableCellRenderer();
        centerRenderer.setHorizontalAlignment(JLabel.CENTER);
        rightRenderer.setHorizontalAlignment(JLabel.RIGHT);
    
        felszerelesekTable.setModel(tm);
        felszerelesekTable.getColumnModel().getColumn(0).setMinWidth(250);
        felszerelesekTable.getColumnModel().getColumn(1).setMinWidth(150);
        felszerelesekTable.getColumnModel().getColumn(2).setMinWidth(30);
        felszerelesekTable.getColumnModel().getColumn(2).setCellRenderer(centerRenderer);
        felszerelesekTable.getColumnModel().getColumn(3).setMinWidth(30);
        felszerelesekTable.getColumnModel().getColumn(3).setCellRenderer(centerRenderer);
        felszerelesekTable.getColumnModel().getColumn(4).setMinWidth(100);
        felszerelesekTable.getColumnModel().getColumn(5).setMinWidth(100);
        felszerelesekTable.getColumnModel().getColumn(5).setCellRenderer(rightRenderer);
        felszerelesekTable.getColumnModel().getColumn(6).setMinWidth(150);
        felszerelesekTable.getColumnModel().getColumn(7).setMinWidth(150);
        felszerelesekTable.getTableHeader().setFont(new java.awt.Font("Tahoma", 1, 14));
        felszerelesekTable.getTableHeader().setOpaque(false);
        felszerelesekTable.getTableHeader().setBackground(new Color(196, 196, 196));
        szuresToggleButton.addItemListener(itemListener);
        szuresComboBox.setVisible(false);
        szuresTextField.setVisible(false);
    }
    
    public Felszerelesek(String WebcamResult) {
        initComponents();
        
        tm = new TableModel(WebcamResult);
        DefaultTableCellRenderer centerRenderer = new DefaultTableCellRenderer();
        DefaultTableCellRenderer rightRenderer = new DefaultTableCellRenderer();
        centerRenderer.setHorizontalAlignment(JLabel.CENTER);
        rightRenderer.setHorizontalAlignment(JLabel.RIGHT);
    
        felszerelesekTable.setModel(tm);
        felszerelesekTable.getColumnModel().getColumn(0).setMinWidth(250);
        felszerelesekTable.getColumnModel().getColumn(1).setMinWidth(150);
        felszerelesekTable.getColumnModel().getColumn(2).setMinWidth(30);
        felszerelesekTable.getColumnModel().getColumn(2).setCellRenderer(centerRenderer);
        felszerelesekTable.getColumnModel().getColumn(3).setMinWidth(30);
        felszerelesekTable.getColumnModel().getColumn(3).setCellRenderer(centerRenderer);
        felszerelesekTable.getColumnModel().getColumn(4).setMinWidth(100);
        felszerelesekTable.getColumnModel().getColumn(5).setMinWidth(100);
        felszerelesekTable.getColumnModel().getColumn(5).setCellRenderer(rightRenderer);
        felszerelesekTable.getColumnModel().getColumn(6).setMinWidth(150);
        felszerelesekTable.getColumnModel().getColumn(7).setMinWidth(150);
        felszerelesekTable.getTableHeader().setFont(new java.awt.Font("Tahoma", 1, 14));
        felszerelesekTable.getTableHeader().setOpaque(false);
        felszerelesekTable.getTableHeader().setBackground(new Color(196, 196, 196));
        szuresToggleButton.addItemListener(itemListener);
        szuresComboBox.setVisible(false);
        szuresTextField.setVisible(false);
        felszerelesekTable.setSize(1150, 570);
    }
    
    
    ItemListener itemListener = new ItemListener() {
        @Override
        public void itemStateChanged(ItemEvent itemEvent) {
            int state1 = itemEvent.getStateChange();
            
            if (state1 == ItemEvent.SELECTED) {
                felszerelesekTable.setSize(1150, 520);
                szuresComboBox.setVisible(true);
                szuresTextField.setVisible(true);
            } else {
                szuresComboBox.setVisible(false);
                szuresTextField.setVisible(false);
                felszerelesekTable.setSize(1150, 570);
            }
        }
    };
    
    private void tableFilter(String filterText){
        
        TableRowSorter<TableModel> sorter = new TableRowSorter<>(tm);
        sorter.setRowFilter(RowFilter.regexFilter("(?i)" + filterText, filterByColumn));
        if(szuresTextField.getText().length()==0){
            felszerelesekTable.setRowSorter(null);
        }
        felszerelesekTable.setRowSorter(sorter);
    }
    
    public static void setTm(TableModel _tm){
        tm=_tm;
    }
    
    public static void refreshTable(){
        felszerelesekTable.repaint();
    }
    

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        felszerelesekTable = new javax.swing.JTable();
        reszletekBtn = new javax.swing.JButton();
        exportalasBtn = new javax.swing.JButton();
        modositasBtn = new javax.swing.JButton();
        megseBtn1 = new javax.swing.JButton();
        selejtezesBtn = new javax.swing.JButton();
        szuresToggleButton = new javax.swing.JToggleButton();
        szuresTextField = new javax.swing.JTextField();
        szuresComboBox = new javax.swing.JComboBox<>();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Felszerelések listája");

        jScrollPane1.setVerticalScrollBarPolicy(javax.swing.ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS);
        jScrollPane1.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));

        felszerelesekTable.setAutoCreateRowSorter(true);
        felszerelesekTable.setFont(new java.awt.Font("Tahoma", 0, 14)); // NOI18N
        felszerelesekTable.setModel(new javax.swing.table.DefaultTableModel(
            new Object [][] {
                {null, null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null, null}
            },
            new String [] {
                "Gyártó (típus)", "Kategória", "Évjárat", "Állapot", "Raktár", "Beszerzési Ár", "Beszerzés helye", "Azonosító"
            }
        ) {
            boolean[] canEdit = new boolean [] {
                false, false, false, false, true, false, true, true
            };

            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return canEdit [columnIndex];
            }
        });
        felszerelesekTable.setIntercellSpacing(new java.awt.Dimension(8, 5));
        felszerelesekTable.setRowHeight(60);
        jScrollPane1.setViewportView(felszerelesekTable);

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

        modositasBtn.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        modositasBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8_edit_32px.png"))); // NOI18N
        modositasBtn.setText("Módosítás");
        modositasBtn.setBorderPainted(false);
        modositasBtn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        modositasBtn.setFocusPainted(false);
        modositasBtn.setFocusable(false);
        modositasBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                modositasBtnActionPerformed(evt);
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

        selejtezesBtn.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        selejtezesBtn.setIcon(new javax.swing.ImageIcon(getClass().getResource("/icons/icons8-delete-list-32.png"))); // NOI18N
        selejtezesBtn.setText("Selejtezés");
        selejtezesBtn.setBorderPainted(false);
        selejtezesBtn.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
        selejtezesBtn.setFocusPainted(false);
        selejtezesBtn.setFocusable(false);
        selejtezesBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                selejtezesBtnActionPerformed(evt);
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

        szuresTextField.setBackground(new java.awt.Color(243, 237, 237));
        szuresTextField.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyReleased(java.awt.event.KeyEvent evt) {
                szuresTextFieldKeyReleased(evt);
            }
        });

        szuresComboBox.setModel(new DefaultComboBoxModel(new String[]{"Gyártó (típus)", "Kategória", "Évjárat", "Állapot", "Telephely", "Beszerzési Ár", "Beszerzés helye", "S/N"}));
        szuresComboBox.addItemListener(new java.awt.event.ItemListener() {
            public void itemStateChanged(java.awt.event.ItemEvent evt) {
                szuresComboBoxItemStateChanged(evt);
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
                                .addComponent(modositasBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addGap(18, 18, 18)
                                .addComponent(selejtezesBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(szuresTextField))
                        .addGap(178, 178, 178)
                        .addComponent(megseBtn1, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(24, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(33, 33, 33)
                .addComponent(jScrollPane1, javax.swing.GroupLayout.DEFAULT_SIZE, 521, Short.MAX_VALUE)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(szuresComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(szuresTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(reszletekBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(szuresToggleButton, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(exportalasBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(modositasBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(selejtezesBtn, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(megseBtn1, javax.swing.GroupLayout.PREFERRED_SIZE, 65, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addGap(25, 25, 25))
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void reszletekBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_reszletekBtnActionPerformed
        //a kijelolt sor lekerese
        if(felszerelesekTable.getSelectedRow()!= -1){
            Felszereles f = tm.getFelszereles(felszerelesekTable.convertRowIndexToModel(felszerelesekTable.getSelectedRow()));
            java.awt.EventQueue.invokeLater(() -> {
                try {
                    new Reszletek(f).setVisible(true);
                } catch (WriterException ex) {
                    Logger.getLogger(Felszerelesek.class.getName()).log(Level.SEVERE, null, ex);
                } catch (IOException ex) {
                    Logger.getLogger(Felszerelesek.class.getName()).log(Level.SEVERE, null, ex);
                }
            });
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
                    for(int i = 0; i < tm.getNumberOfFelszerelesek(); i++){
                        save.write(tm.getFelszereles(i).printOutFelszerelesWithSeparator());
                    }
                    save.close();
                    JOptionPane.showMessageDialog(this, "Lista exportálva.","Sikeres mentés!", JOptionPane.INFORMATION_MESSAGE, sikerIcon);

                }catch (Exception e) {
                    JOptionPane.showMessageDialog(this, "Sikertelen exportálás.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
                    System.out.println(e.getMessage());
                } 
            } else JOptionPane.showMessageDialog(this, "Sikertelen exportálás.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
    }//GEN-LAST:event_exportalasBtnActionPerformed

    private void modositasBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_modositasBtnActionPerformed
        if(felszerelesekTable.getSelectedRowCount() == 0){
            JOptionPane.showMessageDialog(this, "Nincs kijelölve felszerelés.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        }
        else if(felszerelesekTable.getSelectedRowCount() > 1){
            JOptionPane.showMessageDialog(this, "Egyszerre csak egy felszerelést módosíthat.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        } else{
            Felszereles f = tm.getFelszereles(felszerelesekTable.convertRowIndexToModel(felszerelesekTable.getSelectedRow()));
                java.awt.EventQueue.invokeLater(new Runnable() {
                @Override
                public void run() {
                    try {
                        new Modositas(f).setVisible(true);
                        
                    } catch (Exception ex) {
                        Logger.getLogger(Felszerelesek.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            });
                
        }
        
        
    }//GEN-LAST:event_modositasBtnActionPerformed

    private void megseBtn1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_megseBtn1ActionPerformed
        this.dispose();
    }//GEN-LAST:event_megseBtn1ActionPerformed

    private void selejtezesBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_selejtezesBtnActionPerformed
        if(felszerelesekTable.getSelectedRowCount() == 0){
            JOptionPane.showMessageDialog(this, "Nincs kijelölve felszerelés.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        }
        else if(felszerelesekTable.getSelectedRowCount() > 1){
            JOptionPane.showMessageDialog(this, "Egyszerre csak egy felszerelést selejtezhet.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        } else if(tm.getFelszereles(felszerelesekTable.convertRowIndexToModel(felszerelesekTable.getSelectedRow())).getAllapot().equals("Selejt")){
            JOptionPane.showMessageDialog(this, "A felszerelés már selejtezve van.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        }else{
            Object[] options = {"Igen", "Mégse"};
            int n = JOptionPane.showOptionDialog(this, "Biztosan selejtezni szeretné a felszerelést?", "Biztos benne?",
                JOptionPane.OK_CANCEL_OPTION, JOptionPane.INFORMATION_MESSAGE, kerdesIcon, options, options[1]);
            if(n==JOptionPane.YES_OPTION){  
                Felszereles f = tm.getFelszereles(felszerelesekTable.convertRowIndexToModel(felszerelesekTable.getSelectedRow()));
                try{
                    String Allapot = "Selejt";
                    Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
                    Statement stmt=con.createStatement(); 
                    stmt.executeUpdate("update raktartbl"
                        + " set "
                            + "Allapot = (select allapottbl.ID from allapottbl where Allapot like '"+ Allapot +"%')"
                        + "where QRKod like '"+f.getQRKod()+"';");
                    Felszerelesek.setTm(new TableModel());
                    Felszerelesek.refreshTable();
                    JOptionPane.showMessageDialog(this, "Felszerezés selejtezve.","Sikeres mentés!", JOptionPane.INFORMATION_MESSAGE, sikerIcon);
                    con.close();

                } catch(Exception e){
                    JOptionPane.showMessageDialog(this, "Módosítás sikertelen\n" + e,"Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
                } 
            }                
        }
    }//GEN-LAST:event_selejtezesBtnActionPerformed

    private void szuresToggleButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_szuresToggleButtonActionPerformed
        // TODO add your handling code here:
    }//GEN-LAST:event_szuresToggleButtonActionPerformed

    private void szuresTextFieldKeyReleased(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_szuresTextFieldKeyReleased
        String filterText = Pattern.quote(szuresTextField.getText());
        tableFilter(filterText);
    }//GEN-LAST:event_szuresTextFieldKeyReleased

    private void szuresComboBoxItemStateChanged(java.awt.event.ItemEvent evt) {//GEN-FIRST:event_szuresComboBoxItemStateChanged
        filterByColumn = szuresComboBox.getSelectedIndex();
    }//GEN-LAST:event_szuresComboBoxItemStateChanged
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
    private javax.swing.JButton exportalasBtn;
    private static javax.swing.JTable felszerelesekTable;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JButton megseBtn1;
    private javax.swing.JButton modositasBtn;
    private javax.swing.JButton reszletekBtn;
    private javax.swing.JButton selejtezesBtn;
    private javax.swing.JComboBox<String> szuresComboBox;
    private javax.swing.JTextField szuresTextField;
    private javax.swing.JToggleButton szuresToggleButton;
    // End of variables declaration//GEN-END:variables
}
