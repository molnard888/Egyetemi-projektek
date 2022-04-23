/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package felszerelesraktarnyilvantartoapp;

/**
 *
 * @author Daniel
 */
public class Kolcsonzes {
    private String ID;

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
    }
    private String nev;
    private String telefon;
    private String QRkod;
    private String kolcskezd;
    private String kolcsveg;
    private String kolcshely;
    private String kolcsleadhely;
   
    

    public String getQRkod() {
        return QRkod;
    }

    public void setQRkod(String QRkod) {
        this.QRkod = QRkod;
    }


    public String getNev() {
        return nev;
    }

    public void setNev(String nev) {
        this.nev = nev;
    }

    public String getTelefon() {
        return telefon;
    }

    public void setTelefon(String telefon) {
        this.telefon = telefon;
    }

    public String getKolcskezd() {
        return kolcskezd;
    }

    public void setKolcskezd(String kolcskezd) {
        this.kolcskezd = kolcskezd;
    }

    public String getKolcsveg() {
        return kolcsveg;
    }

    public void setKolcsveg(String kolcsveg) {
        this.kolcsveg = kolcsveg;
    }

    public String getKolcshely() {
        return kolcshely;
    }

    public void setKolcshely(String kolcshely) {
        this.kolcshely = kolcshely;
    }

    public String getKolcsleadhely() {
        return kolcsleadhely;
    }

    public void setKolcsleadhely(String kolcsleadhely) {
        this.kolcsleadhely = kolcsleadhely;
    }
    
    public Kolcsonzes(String ID, String nev, String telefon, String QRkod, String kolcskezd, String kolcsveg, String kolcshely, String kolcsleadhely) {
        this.ID = ID;
        this.nev = nev;
        this.telefon = telefon;
        this.kolcskezd = kolcskezd;
        this.kolcsveg = kolcsveg;
        this.kolcshely = kolcshely;
        this.kolcsleadhely = kolcsleadhely;
        this.QRkod = QRkod;
    }
    
    public String printOutKolcsonzesWithSeparator()
    {
        return( this.ID+";"+this.nev+";"+this.telefon+";"+this.kolcskezd+";"+this.kolcsveg+";"+this.kolcshely+";"
                +this.kolcsleadhely+";"+this.QRkod+"\n");
    }
}
