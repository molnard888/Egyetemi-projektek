/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

/**
 *
 * @author oldman96
 */
public class Felszereles {
    private String gyarto;
    private String tipus;
    private String kategoria;
    private String alkategoria;
    private String evjarat;
    private String beszerzesiAr;
    private String telephely;
    private String allapot;
    private String beszerzesiHely;
    private String gyariszam;
    private String QRKod;
    
    

    public  String getTelephely() {
        return telephely;
    }

    public void setTelephely(String telephely) {
        this.telephely = telephely;
    }

    public String getAllapot() {
        return allapot;
    }

    public void setAllapot(String allapot) {
        this.allapot = allapot;
    }

    public String getGyariszam() {
        return gyariszam;
    }

    public void setGyariszam(String gyariszam) {
        this.gyariszam = gyariszam;
    }

    public String getQRKod() {
        return QRKod;
    }

    public void setQRKod(String QRKod) {
        this.QRKod = QRKod;
    }
   

    public String getGyarto() {
        return gyarto;
    }

    public void setGyarto(String gyarto) {
        this.gyarto = gyarto;
    }

    public String getTipus() {
        return tipus;
    }

    public void setTipus(String tipus) {
        this.tipus = tipus;
    }

    public String getKategoria() {
        return kategoria;
    }

    public void setKategoria(String kategoria) {
        this.kategoria = kategoria;
    }

    public String getAlkategoria() {
        return alkategoria;
    }

    public void setAlkategoria(String alkategoria) {
        this.alkategoria = alkategoria;
    }
    
    public String getEvjarat() {
        return evjarat;
    }

    public void setEvjarat(String evjarat) {
        this.evjarat = evjarat;
    }

    public String getBeszerzesiAr() {
        return beszerzesiAr;
    }

    public void setBeszerzesiAr(String beszerzesiAr) {
        this.beszerzesiAr = beszerzesiAr;
    }

    public String getBeszerzesiHely() {
        return beszerzesiHely;
    }

    public void setBeszerzesiHely(String beszerzesiHely) {
        this.beszerzesiHely = beszerzesiHely;
    }

    

    public Felszereles(String gyarto, String tipus, String kategoria, String alkategoria, String evjarat, String beszAr, String telephely, String allapot, String beszHely, String gyariszam, String QRKod) {
        this.gyarto = gyarto;
        this.tipus = tipus;
        this.kategoria = kategoria;
        this.alkategoria = alkategoria;
        this.evjarat = evjarat;
        this.beszerzesiAr = beszAr;
        this.telephely = telephely;
        this.allapot = allapot;
        this.beszerzesiHely = beszHely;
        this.gyariszam = gyariszam;
        this.QRKod = QRKod;
    }
    
    public void printOutFelszerelesToConsole()
    {
        System.out.print( this.gyarto+", "+this.tipus+", "+this.kategoria+", "+this.alkategoria+", "+this.evjarat+", "+this.beszerzesiAr+", "+this.telephely+", "
                +this.allapot+", "+this.beszerzesiHely+", "+this.gyariszam+", "+this.QRKod+"\n");
    }
    
    public String printOutFelszerelesWithSeparator()
    {
        return( this.gyarto+";"+this.tipus+";"+this.kategoria+";"+this.alkategoria+";"+this.evjarat+";"+this.beszerzesiAr+";"+this.telephely+";"
                +this.allapot+";"+this.beszerzesiHely+";"+this.gyariszam+";"+this.QRKod+"\n");
    }
    
}
