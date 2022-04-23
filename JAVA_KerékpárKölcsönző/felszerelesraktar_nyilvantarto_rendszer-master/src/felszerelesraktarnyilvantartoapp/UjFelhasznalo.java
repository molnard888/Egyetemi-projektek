/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

import com.sun.javafx.geom.Curve;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
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
import javax.swing.ImageIcon;
/**
 *
 * @author oldman96
 */
public class UjFelhasznalo extends javax.swing.JFrame {
    
    
    private ArrayList<String> kategoriak = new ArrayList<String>();
    private ArrayList<String> kategoriakUnique = new ArrayList<String>();
    private ArrayList<String> alkategoriak = new ArrayList<String>();
    private ArrayList<String> telephelyek = new ArrayList<String>();
    private String KategoriaComboboxSelectedValue;
    private ArrayList<String> EgyezoKategoriaIndexek = new ArrayList<String>();
    private ArrayList<String> alkategoriakChecked = new ArrayList<String>();
    private final ImageIcon sikerIcon = new ImageIcon(getClass().getResource("/icons/icons8_ok_48px.png"));
    private final ImageIcon hibaIcon = new ImageIcon(getClass().getResource("/icons/icons8_cancel_48px.png"));
    // ArrayList<String> allapotok = new ArrayList<String>();
    
    
    /**
     * Creates new form FelszerelesekWindow
     */
    
    public UjFelhasznalo() {
        initComponents();
    }
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    

    
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        fnevLabel = new javax.swing.JLabel();
        fnevTextfield = new javax.swing.JTextField();
        jelszoLabel = new javax.swing.JLabel();
        jelszoTextfield = new javax.swing.JTextField();
        MentesButton = new javax.swing.JButton();
        MegseButton = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setTitle("Új felhasználó");

        fnevLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        fnevLabel.setText("Felhasználónév:");

        fnevTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N

        jelszoLabel.setFont(new java.awt.Font("Segoe UI", 1, 18)); // NOI18N
        jelszoLabel.setText("Jelszó:");

        jelszoTextfield.setFont(new java.awt.Font("Segoe UI", 0, 14)); // NOI18N

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
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(fnevLabel)
                            .addComponent(jelszoLabel))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(fnevTextfield)
                            .addComponent(jelszoTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(12, 12, 12)
                        .addComponent(MentesButton, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addGap(18, 18, 18)
                        .addComponent(MegseButton, javax.swing.GroupLayout.PREFERRED_SIZE, 150, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addContainerGap(29, Short.MAX_VALUE))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(30, 30, 30)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(fnevLabel)
                            .addComponent(fnevTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(jelszoLabel)
                            .addComponent(jelszoTextfield, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(96, 96, 96)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                            .addComponent(MegseButton, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE)
                            .addComponent(MentesButton, javax.swing.GroupLayout.PREFERRED_SIZE, 40, javax.swing.GroupLayout.PREFERRED_SIZE))))
                .addContainerGap(35, Short.MAX_VALUE))
        );

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void MentesButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_MentesButtonActionPerformed
        // TODO add your handling code here:
        //System.out.println(GyartoTextfield.getText());
        
        try{
            Connection con=DriverManager.getConnection("jdbc:mysql://localhost:3307/raktardb","root","projektlabor");  
            Statement stmt=con.createStatement(); 
            ResultSet AdatLekeroQuery=stmt.executeQuery("select COUNT(*) from felhasznaloktbl WHERE Felhasznalonev='"+fnevTextfield.getText()+"';");
            String eredm ="1";
            while(AdatLekeroQuery.next()){
                eredm = AdatLekeroQuery.getString(1);
            }
           if(!eredm.equals("0")){
               JOptionPane.showMessageDialog(this, "Már létezik ilyen felhasználó.","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
           } else if(fnevTextfield.getText().equals("") || jelszoTextfield.getText().equals("")){
               JOptionPane.showMessageDialog(this, "Érvénytelen felhasználónév/jelszó","Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
           }else{
               String hashedPassword = FelszerelesraktarNyilvantartoApp.passwordMD5(jelszoTextfield.getText());
               stmt.executeUpdate("INSERT INTO `felhasznaloktbl` (Felhasznalonev, Jelszo) VALUE ('"+ fnevTextfield.getText() +"', '"+ hashedPassword +"');");
               FelhasznalokTableModel.setValueAt(fnevTextfield.getText());
               Felhasznalok.refreshTable();
               JOptionPane.showMessageDialog(this, "Felhasználó létrehozva.","Sikeres mentés!", JOptionPane.INFORMATION_MESSAGE, sikerIcon);
           }
           
           this.dispose();
           con.close();
        }
        catch(Exception e)
        {
            JOptionPane.showMessageDialog(this, "Létrehozás sikertelen.\n" + e,"Hiba!", JOptionPane.INFORMATION_MESSAGE, hibaIcon);
        }
           
    }//GEN-LAST:event_MentesButtonActionPerformed

    private void MegseButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_MegseButtonActionPerformed
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
    private javax.swing.JButton MegseButton;
    private javax.swing.JButton MentesButton;
    private javax.swing.JLabel fnevLabel;
    private javax.swing.JTextField fnevTextfield;
    private javax.swing.JLabel jelszoLabel;
    private javax.swing.JTextField jelszoTextfield;
    // End of variables declaration//GEN-END:variables
}
