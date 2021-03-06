/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testgui_dec17;

import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.io.FileWriter;
import java.io.IOException;
import static java.lang.Integer.parseInt;
import javax.swing.DefaultListModel;
import javax.swing.JList;
import java.util.ArrayList; // import the ArrayList class
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;


/**
 *
 * @author Dániel
 */
public class NewJFrame extends javax.swing.JFrame {
    
    static GridBagLayout layout=new GridBagLayout();
    private JList<String> termekList;
    String kos="Kosár";
    String whs="WishList";
    static Listazas p1;
    static Kereses p2;
    static Kosar p3;
    static Wishlist p4;
    static Tarolo tar=new Tarolo();
    static ArrayList<String> Kosar = new ArrayList<String>();
    
    
    /**
     * Creates new form NewJFrame
     */
    public NewJFrame() {
        initComponents();
        this.addWindowListener(new WindowAdapter(){
        @Override
        public void windowClosing(WindowEvent arg0) {
            
            if(p1.KSRlist.get(0)!=null && !p1.KSRlist.get(0).isEmpty()){
            try {
            createFile(kos, p1.KSRlist);
            } catch (IOException ex) {
                System.exit(0);
            }
            }
            else{
                System.exit(0);
            }
            
            if(p1.WLlist.get(0)!=null && !p1.WLlist.get(0).isEmpty()){
                try {
                    createFile(whs, p1.WLlist);
                } catch (IOException ex) {
                    
                    System.exit(0);
                }
            }
            else{
                System.exit(0);
            }
            
            
            System.exit(0);
        }
        });
        p1=new Listazas(tar);
        p2=new Kereses();
        p3=new Kosar();
        p4=new Wishlist();
        
        DynamicPanel.setLayout(layout);
        GridBagConstraints c=new GridBagConstraints();
        c.gridx=0;
        c.gridy=0;
        DynamicPanel.add(p1,c);
        c.gridx=0;
        c.gridy=0;
        DynamicPanel.add(p2,c);
        c.gridx=0;
        c.gridy=0;
        DynamicPanel.add(p3,c);
        c.gridx=0;
        c.gridy=0;
        DynamicPanel.add(p4,c);
        p1.setVisible(true);
        p2.setVisible(false);
        p3.setVisible(false);
        p4.setVisible(false);
        DynamicPanel.setSize(550, 474);
        
        DefaultListModel<String> listModel = new DefaultListModel<>();
        for(int i=0;i<tar.TombSize;i++){
            listModel.addElement(tar.termekTomb[i].ID + " / " + 
                    tar.termekTomb[i].nev + " / " +
                    tar.termekTomb[i].kategoria + " / " +tar.termekTomb[i].ar
                    + " FT / " + tar.termekTomb[i].darab + " DB");
        }
        p1.jList1.setModel(listModel);
        
        p1.KSRlist.add("A kosár üres");
        DefaultListModel<String> kosarModel = new DefaultListModel<>();
        for(int k=0;k<1;k++){
            kosarModel.addElement(p1.KSRlist.get(k));
        }
        p3.jList1.setModel(kosarModel);
        
        p1.WLlist.add("A wishlist üres");
        DefaultListModel<String> WLlistModel = new DefaultListModel<>();
        for(int k=0;k<1;k++){
            WLlistModel.addElement(p1.WLlist.get(k));
        }
        p4.jList1.setModel(WLlistModel);
        
    }
    
    private void createFile(String file, ArrayList<String> arrData)
            throws IOException {
        FileWriter writer = new FileWriter(file + ".txt");
        int size = arrData.size();
        for (int i=0;i<size;i++) {
            String str = (tar.termekTomb[parseInt(arrData.get(i))].ID + 
                    " / " + tar.termekTomb[parseInt(arrData.get(i))].nev + 
                    " / " + tar.termekTomb[parseInt(arrData.get(i))].kategoria + 
                    " / " + tar.termekTomb[parseInt(arrData.get(i))].ar + 
                    " FT");
            writer.write(str);
            if(i < size-1)
                writer.write("\n");
        }
        writer.close();
    }
    
    
    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel2 = new javax.swing.JPanel();
        jPanel1 = new javax.swing.JPanel();
        jButton1 = new javax.swing.JButton();
        jButton2 = new javax.swing.JButton();
        jButton3 = new javax.swing.JButton();
        jButton4 = new javax.swing.JButton();
        DynamicPanel = new javax.swing.JPanel();

        javax.swing.GroupLayout jPanel2Layout = new javax.swing.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 253, Short.MAX_VALUE)
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 268, Short.MAX_VALUE)
        );

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 314, Short.MAX_VALUE)
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 433, Short.MAX_VALUE)
        );

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setTitle("OXOOBF");
        setMinimumSize(new java.awt.Dimension(900, 700));
        setPreferredSize(new java.awt.Dimension(900, 700));

        jButton1.setText("Termékek");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });

        jButton2.setText("Keresés");
        jButton2.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton2ActionPerformed(evt);
            }
        });

        jButton3.setText("Kosár");
        jButton3.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton3ActionPerformed(evt);
            }
        });

        jButton4.setText("Wishlist");
        jButton4.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton4ActionPerformed(evt);
            }
        });

        DynamicPanel.setName("[700, 680]"); // NOI18N
        DynamicPanel.setPreferredSize(new java.awt.Dimension(700, 680));

        javax.swing.GroupLayout DynamicPanelLayout = new javax.swing.GroupLayout(DynamicPanel);
        DynamicPanel.setLayout(DynamicPanelLayout);
        DynamicPanelLayout.setHorizontalGroup(
            DynamicPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 0, Short.MAX_VALUE)
        );
        DynamicPanelLayout.setVerticalGroup(
            DynamicPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGap(0, 480, Short.MAX_VALUE)
        );

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jButton1, javax.swing.GroupLayout.DEFAULT_SIZE, 112, Short.MAX_VALUE)
                        .addGap(79, 79, 79)
                        .addComponent(jButton2, javax.swing.GroupLayout.DEFAULT_SIZE, 103, Short.MAX_VALUE)
                        .addGap(85, 85, 85)
                        .addComponent(jButton3, javax.swing.GroupLayout.DEFAULT_SIZE, 103, Short.MAX_VALUE)
                        .addGap(80, 80, 80)
                        .addComponent(jButton4, javax.swing.GroupLayout.DEFAULT_SIZE, 104, Short.MAX_VALUE))
                    .addGroup(layout.createSequentialGroup()
                        .addContainerGap()
                        .addComponent(DynamicPanel, javax.swing.GroupLayout.DEFAULT_SIZE, 660, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jButton4)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(jButton1)
                        .addComponent(jButton2)
                        .addComponent(jButton3)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(DynamicPanel, javax.swing.GroupLayout.DEFAULT_SIZE, 480, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents
    
    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        p1.setVisible(true);
           p2.setVisible(false);
           p3.setVisible(false);
           p4.setVisible(false);
    }//GEN-LAST:event_jButton1ActionPerformed

    private void jButton2ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton2ActionPerformed
        p2.setVisible(true);
           p1.setVisible(false); 
           p3.setVisible(false);
           p4.setVisible(false);// TODO add your handling code here:
    }//GEN-LAST:event_jButton2ActionPerformed

    private void jButton3ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton3ActionPerformed
        if(p1.KSRlist.get(0).equals("A kosár üres"))
            {  
            }
        else{
        DefaultListModel<String> kosarModel = new DefaultListModel<>();
        int vego=0;
        for(int k=0;k<p1.KSRlist.size();k++){
            kosarModel.addElement(tar.termekTomb[parseInt(p1.KSRlist.get(k))].ID + 
                    " / " + tar.termekTomb[parseInt(p1.KSRlist.get(k))].nev + 
                    " / " + tar.termekTomb[parseInt(p1.KSRlist.get(k))].kategoria + 
                    " / " + tar.termekTomb[parseInt(p1.KSRlist.get(k))].ar + 
                    " FT");
            vego=vego+(tar.termekTomb[parseInt(p1.KSRlist.get(k))].ar);
        }
        p3.jList1.setModel(kosarModel);
        
        p3.Vegosszeg.setText(String.valueOf(vego));
        }
        
        
        
        p3.setVisible(true);
           p1.setVisible(false); 
           p2.setVisible(false);
           p4.setVisible(false); 
    }//GEN-LAST:event_jButton3ActionPerformed

    private void jButton4ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton4ActionPerformed
        if(p1.WLlist.get(0).equals("A wishlist üres"))
            { 
            }
        else{
            DefaultListModel<String> WLlistModel = new DefaultListModel<>();
        int vego=0;
        for(int k=0;k<p1.WLlist.size();k++){
            WLlistModel.addElement(tar.termekTomb[parseInt(p1.WLlist.get(k))].ID + 
                    " / " + tar.termekTomb[parseInt(p1.WLlist.get(k))].nev + 
                    " / " + tar.termekTomb[parseInt(p1.WLlist.get(k))].kategoria + 
                    " / " + tar.termekTomb[parseInt(p1.WLlist.get(k))].ar + 
                    " FT");
            vego=vego+(tar.termekTomb[parseInt(p1.WLlist.get(k))].ar);
        }
        p4.jList1.setModel(WLlistModel);
        
        p4.Vegosszeg.setText(String.valueOf(vego));
        }
        
        
        
        
        p4.setVisible(true);
           p1.setVisible(false); 
           p2.setVisible(false);
           p3.setVisible(false); 
    }//GEN-LAST:event_jButton4ActionPerformed
    
    
    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        JFrame frame = new JFrame("HelloWorldSwing");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(NewJFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(NewJFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(NewJFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(NewJFrame.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new NewJFrame().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JPanel DynamicPanel;
    private javax.swing.JButton jButton1;
    private javax.swing.JButton jButton2;
    private javax.swing.JButton jButton3;
    private javax.swing.JButton jButton4;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    // End of variables declaration//GEN-END:variables
}
