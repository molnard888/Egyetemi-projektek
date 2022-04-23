package felszerelesraktarnyilvantartoapp;

import com.github.sarxos.webcam.Webcam;
import com.github.sarxos.webcam.WebcamPanel;
import com.github.sarxos.webcam.WebcamResolution;
import com.google.zxing.BinaryBitmap;
import com.google.zxing.LuminanceSource;
import com.google.zxing.MultiFormatReader;
import com.google.zxing.NotFoundException;
import com.google.zxing.Result;
import com.google.zxing.client.j2se.BufferedImageLuminanceSource;
import com.google.zxing.common.HybridBinarizer;
import java.awt.Dimension;
import java.awt.image.BufferedImage;
import java.util.concurrent.Executor;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadFactory;

public class WebcamBeolvas extends javax.swing.JFrame implements Runnable, ThreadFactory {

    private WebcamPanel panel = null;
    private Webcam webcam = null;
    private Result result=null;
    boolean bool=true;

    private static final long serialVersionUID = 6441489157408381878L;
    private Executor executor = Executors.newSingleThreadExecutor(this);

    public WebcamBeolvas() {
        
        initComponents();
        initWebcam();
        if (!webcam.isOpen()) {
            SetWebcamSize();
        }
        jPanel2.hide();
        this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
    }
    
    

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jPanel1 = new javax.swing.JPanel();
        jPanel2 = new javax.swing.JPanel();
        MegsemButton = new javax.swing.JButton();
        BeolvasButton = new javax.swing.JButton();
        result_field = new javax.swing.JTextField();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        getContentPane().setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        jPanel1.setBackground(new java.awt.Color(76, 80, 82));
        jPanel1.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

        jPanel2.setBackground(new java.awt.Color(250, 250, 250));
        jPanel2.setBorder(javax.swing.BorderFactory.createLineBorder(new java.awt.Color(230, 230, 230)));
        jPanel2.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());
        jPanel1.add(jPanel2, new org.netbeans.lib.awtextra.AbsoluteConstraints(30, 10, 440, 300));

        MegsemButton.setText("Mégsem");
        MegsemButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                MegsemButtonActionPerformed(evt);
            }
        });
        jPanel1.add(MegsemButton, new org.netbeans.lib.awtextra.AbsoluteConstraints(270, 320, 100, 30));

        BeolvasButton.setText("Beolvas");
        BeolvasButton.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                BeolvasButtonActionPerformed(evt);
            }
        });
        jPanel1.add(BeolvasButton, new org.netbeans.lib.awtextra.AbsoluteConstraints(120, 320, 100, 30));
        jPanel1.add(result_field, new org.netbeans.lib.awtextra.AbsoluteConstraints(50, 350, 380, -1));

        getContentPane().add(jPanel1, new org.netbeans.lib.awtextra.AbsoluteConstraints(0, 0, 500, 380));

        pack();
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void BeolvasButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_BeolvasButtonActionPerformed
        // TODO add your handling code here:
        
        if(jPanel2.isShowing())
        {
            jPanel2.hide();
        }
        else{
            jPanel2.show();
            result=null;
            bool=true;
        }
        result_field.setText("");
    }//GEN-LAST:event_BeolvasButtonActionPerformed

    private void MegsemButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_MegsemButtonActionPerformed
        // TODO add your handling code here:
        
        this.dispose();
    }//GEN-LAST:event_MegsemButtonActionPerformed

    /**
     * @param args the command line arguments
     */
    /* public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
    /*    try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Windows".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(WebcamBeolvas.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>
        //</editor-fold>

        //</editor-fold>

        /* Create and display the form */
     /*   java.awt.EventQueue.invokeLater(() -> {
            new WebcamBeolvas().setVisible(true);
        });
    } */

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton BeolvasButton;
    private javax.swing.JButton MegsemButton;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JTextField result_field;
    // End of variables declaration//GEN-END:variables

    private void SetWebcamSize(){
        Dimension size = WebcamResolution.QVGA.getSize();
        webcam.setViewSize(size);
        panel.setPreferredSize(size);
    }
    
    private void initWebcam() {
        
        webcam = Webcam.getWebcams().get(0); //0 is default webcam
        panel = new WebcamPanel(webcam);
        panel.setFPSDisplayed(true);
        jPanel2.add(panel, new org.netbeans.lib.awtextra.AbsoluteConstraints(0, 0, 470, 300));
        executor.execute(this);
    }

    @Override
    public void run() {
        
        
        do {
            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
                //e.printStackTrace();
            }
            
            while (bool){
                try {
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    //e.printStackTrace();
                }

                result = null;
                BufferedImage image = null;

                if (webcam.isOpen()) {
                    if ((image = webcam.getImage()) == null) {
                        continue;
                    }
                }

                LuminanceSource source = new BufferedImageLuminanceSource(image);
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));

                try {
                    result = new MultiFormatReader().decode(bitmap);
                } catch (NotFoundException e) {
                    //No result...
                }

                if (result != null && jPanel2.isShowing()) {
                   result_field.setText(result.getText());
                   Felszerelesek FelszList = new Felszerelesek(result.getText());
                   FelszList.setVisible(true);
                   bool=false;
                   this.dispose();
                }
            } 
        } while (true);
        
        
    }

    @Override
    public Thread newThread(Runnable r) {
        Thread t = new Thread(r, "My Thread");
        t.setDaemon(true);
        return t;
    }
}
