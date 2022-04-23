#include <iostream>
#include "autentikacio.h"
#include "dolgozo.h"
#include "eszkoz.h"
#include "megrendeles.h"
#include "ugyfel.h"
#include "tarolo.h"
#include <conio.h>
#include <string.h>

using namespace std;

string Beje(Autentikacio auten){
    cout << "Bejelentkezes" << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    return auten.login();
}

string Termeklistaz(Tarolo tar){
    cout << "ELERHETO TERMEKEK LISTAZASA" << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "" << endl;
    for (unsigned int i=0;i<tar.eszkSize;i++){
        if((tar.eszkTptr+i)->getElerheto()){
        cout << "Termek neve: " << (tar.eszkTptr+i)->getNev() << endl;
        cout << "Tipus: " << (tar.eszkTptr+i)->getTipus() << endl;
        cout << "Azonosito: " << (tar.eszkTptr+i)->getId() << endl;
        cout << "Raktarkeszlet: ";
            if((tar.eszkTptr+i)->getElerheto()){
                cout << "Raktaron" << endl;
            }
            else{
                cout << "Nincs raktaron" << endl;
            }
        cout << "Napi ar: " <<  (tar.eszkTptr+i)->getNapi_ar() << " Ft" << endl;
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    }
    }
    string temp="0";
        while(temp.compare("-1")!=0){
            cout << "Vissza a kezdolapra: -1" << endl;
            cout << "" << endl;
            cout << "Adja meg a kivant muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
            cin >> temp;
        }
        return temp;
}


bool eszkozRendel(Tarolo t234){
    cout << "TERMEK RENDELESE" << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "Adja meg a rendeles adatait! (Kilepes: -1)" << endl;
    cout << "" << endl;
    string temp="too";
    int van=0;
    int idx;
    bool rendSiker=false;
    unsigned int szamlal=0;

        while(temp.compare("-2")!=0 && temp.compare("-1")!=0){
            temp="";
            cout << "Termek azonosito (Ha tovabb szeretne lepni, irja be: -2): ";
            cin >> temp;

            for (unsigned int i=0;i<t234.eszkSize;i++){
                if(temp.compare((t234.eszkTptr+i)->getId()) == 0){        //Ha van ilyen eszköz...
                    if(szamlal==0){
                        if(t234.megrSize!=1){
                            Megrendeles * tempTptr = new Megrendeles[t234.megrSize+1];      //uj (1-el nagyobb) dinamikus tomb
                            for (unsigned int i = 0; i < t234.megrSize; i++){
                                tempTptr[i] = t234.megrTptr[i];
                            }
                            delete [] t234.megrTptr;
                            t234.megrTptr=tempTptr;
                        szamlal=1;
                    }
                    van=1;
                    idx=t234.megrSize-1;
                    (t234.megrTptr+idx)->setEszkId(temp);
                    (t234.megrTptr+idx)->setEszkNev((t234.eszkTptr+i)->getNev()+" ("+temp+")");
                    (t234.megrTptr+idx)->setVegosszeg((t234.eszkTptr+i)->getNapi_ar());
                }
            }

        }
    }
        if(temp.compare("-1")==0){
            return rendSiker;
        }


    if(van==0){
        return rendSiker;
    }
    else{
        (t234.megrTptr+idx)->setStatus("Uj");
        (t234.megrTptr+idx)->setRendId("rendeles"+to_string(t234.megrSize));
    }

    temp="";
    cout << "Vezeteknev: ";
    cin >> temp;
    if(temp.compare("-1") != 0){
        (t234.megrTptr+(t234.megrSize-1))->setVnev(temp);
    }
    else if(temp.compare("-1") == 0){
        return rendSiker;
    }
    temp="";
    cout << "Keresztnev: ";
    cin >> temp;
    if(temp.compare("-1") != 0){
        (t234.megrTptr+(t234.megrSize-1))->setKnev(temp);
    }
    else if(temp.compare("-1") == 0){
        return rendSiker;
    }
    temp="";
    cout << "Szallitasi cim (Formatum: Iranyitoszam,Telepules,Kozterulet neve,Kozterulet tipusa,Hazszam): ";
    cout << "" << endl;
    cin >> temp;
    if(temp.compare("-1") != 0){
        (t234.megrTptr+(t234.megrSize-1))->setSzall_cim(temp);
    }
    else if(temp.compare("-1") == 0){
        return rendSiker;
    }
    temp="";
    cout << "Szamlazasi cim (Formatum: Iranyitoszam,Telepules,Kozterulet neve,Kozterulet tipusa,Hazszam): ";
    cout << "" << endl;
    cin >> temp;
        if(temp.compare("-1") != 0){
            (t234.megrTptr+(t234.megrSize-1))->setSzaml_cim(temp);
        }
        else if(temp.compare("-1") == 0){
            return rendSiker;
        }
    temp="";
    cout << "Telefonszam: ";
    cin >> temp;
    if(temp.compare("-1") != 0){
        (t234.megrTptr+(t234.megrSize-1))->setTelefon(temp);
    }
    else if(temp.compare("-1") == 0){
        return rendSiker;
    }
    temp="";
    cout << "Email cim: ";
    cin >> temp;
    if(temp.compare("-1") != 0){
        (t234.megrTptr+(t234.megrSize-1))->setEmail(temp);
    }
    else if(temp.compare("-1") == 0){
        return rendSiker;
    }
    temp="";
    cout << "Adoszam (Ha nincs, akkor beirando: 'nincs'): ";
    cin >> temp;
    if(temp.compare("-1") != 0){
        (t234.megrTptr+(t234.megrSize-1))->setAdoszam(temp);
    }
    else if(temp.compare("-1") == 0){
        return rendSiker;
    }
    cout << "" << endl;
    string veglegesit="K";

    while(veglegesit.compare("Y")!=0 && veglegesit.compare("N")!=0){
        cout << "Leadja a rendelest? (Y/N): ";
        cin >> veglegesit;
    }

    if(van==1 && veglegesit.compare("Y")==0){
        rendSiker=true;
    }
    else{
        rendSiker=false;
    }
    return rendSiker;
}

int rendelesKiir(bool rendRtrn, Tarolo t234){
    if(rendRtrn){
            cout << "" << endl;
            cout << "Sikeres rendeles!" << endl;
            cout << "" << endl;
            cout << "Rendeles azonositoja: " << (t234.megrTptr)->getRendId() << endl;
            cout << "Rendelt termekek: " << (t234.megrTptr+(t234.megrSize-1))->getEszkNev() << endl;
            cout << "Nev: " << (t234.megrTptr+(t234.megrSize-1))->getVnev() << " " <<
                 (t234.megrTptr+(t234.megrSize-1))->getKnev() << endl;
            cout << "Telefonszam: " << (t234.megrTptr+(t234.megrSize-1))->getTelefon() << endl;
            cout << "Email: " << (t234.megrTptr+(t234.megrSize-1))->getEmail() << endl;
            cout << "Szallitasi cim: " << (t234.megrTptr+(t234.megrSize-1))->getSzall_cim() << endl;
            cout << "Szamlazasi cim: " << (t234.megrTptr+(t234.megrSize-1))->getSzaml_cim() << endl;
            cout << "Adoszam: " << (t234.megrTptr+(t234.megrSize-1))->getAdoszam() << endl;
            cout << "Statusz: " << (t234.megrTptr+(t234.megrSize-1))->getStatus() << endl;
            cout << "Vegosszeg: " << (t234.megrTptr+(t234.megrSize-1))->getVegosszeg() << endl;
        }
    else{
            cout << "" << endl;
            cout << "Sikertelen rendeles!" << endl;
            cout << "" << endl;
        }
        string temp="3";
        while(temp.compare("1")!=0 && temp.compare("2")!=0){
            cout << "" << endl;
            cout << "Uj rendeles leadasa: 1" << endl;
            cout << "Vissza a kezdolapra: 2" << endl;
            cout << "" << endl;
            cout << "Adja meg a kivant muvelet sorszamat (1-2) es nyomja le az ENTER billentyut!: ";
            cin >> temp;
        }
        return stoi(temp);
}

string dolgozoFelulet(string &pop, Tarolo tar){
    string temp;

    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "DOLGOZOI FELULET" << endl;
    cout << "Belepve: " << pop << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "" << endl;
    cout << "Uj rendeles megtekintese: 1" << endl;
    cout << "Folyamatban levo rendeles megtekintese: 2" << endl;
    cout << "Termek torlese a rendszerbol: 3" << endl;
    cout << "Termek hozzaadasa a rendszerhez: 4" << endl;
    cout << "Termek adatainak modositasa: 5" << endl;
    cout << "Kijelentkezes: 6" << endl;
    while(temp.compare("1")!=0 && temp.compare("2")!=0 && temp.compare("3")!=0
          && temp.compare("4")!=0 && temp.compare("5")!=0 && temp.compare("6")!=0){
    cout << "" << endl;
    cout << "Adja meg a kivant muvelet sorszamat (1-6) es nyomja le az ENTER billentyut!: ";
    cin >> temp;
    }
    switch (stoi(temp)) {
        case 1:{
            unsigned int index;
            bool vanUj=false;
            for(unsigned int i=0;i<tar.megrSize;i++){
                if((tar.megrTptr+i)->getStatus().compare("Uj")==0){
                    vanUj=true;
                    index=i;
                    cout << "" << endl;
                    cout << "Rendeles azonositoja: " << (tar.megrTptr)->getRendId() << endl;
                    cout << "Rendelt termekek: " << (tar.megrTptr+i)->getEszkNev() << endl;
                    cout << "Nev: " << (tar.megrTptr+i)->getVnev() << " " <<
                         (tar.megrTptr+i)->getKnev() << endl;
                    cout << "Telefonszam: " << (tar.megrTptr+i)->getTelefon() << endl;
                    cout << "Email: " << (tar.megrTptr+i)->getEmail() << endl;
                    cout << "Szallitasi cim: " << (tar.megrTptr+i)->getSzall_cim() << endl;
                    cout << "Szamlazasi cim: " << (tar.megrTptr+i)->getSzaml_cim() << endl;
                    cout << "Adoszam: " << (tar.megrTptr+i)->getAdoszam() << endl;
                    cout << "Statusz: " << (tar.megrTptr+i)->getStatus() << endl;
                    cout << "Vegosszeg: " << (tar.megrTptr+i)->getVegosszeg() << " Ft" << endl;
                    i=tar.megrSize+10;
                }
            }
            if(vanUj==false){
                cout << "" << endl;
                cout << "Nincs uj rendeles." << endl;
            }
            temp="K";
            while(temp.compare("Y")!=0 && temp.compare("N")!=0 && vanUj==true){
                cout << "Elkezdi osszekesziteni a rendelest? (Y/N): ";
                cin >> temp;
            }

            cout << "" << endl;
            if(temp.compare("Y")==0){
                (tar.megrTptr+index)->setStatus("Folyamatban");
            }

            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a dolgozoi feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }

        break;
        }
        case 2:{
            bool vanFolyamatban=false;
            for(unsigned int i=0;i<tar.megrSize;i++){
                if((tar.megrTptr+i)->getStatus().compare("Folyamatban")==0){
                    vanFolyamatban=true;
                    cout << "" << endl;
                    cout << "Rendeles azonositoja: " << (tar.megrTptr)->getRendId() << endl;
                    cout << "Rendelt termekek: " << (tar.megrTptr+i)->getEszkNev() << endl;
                    cout << "Nev: " << (tar.megrTptr+i)->getVnev() << " " <<
                         (tar.megrTptr+i)->getKnev() << endl;
                    cout << "Telefonszam: " << (tar.megrTptr+i)->getTelefon() << endl;
                    cout << "Email: " << (tar.megrTptr+i)->getEmail() << endl;
                    cout << "Szallitasi cim: " << (tar.megrTptr+i)->getSzall_cim() << endl;
                    cout << "Szamlazasi cim: " << (tar.megrTptr+i)->getSzaml_cim() << endl;
                    cout << "Adoszam: " << (tar.megrTptr+i)->getAdoszam() << endl;
                    cout << "Statusz: " << (tar.megrTptr+i)->getStatus() << endl;
                    cout << "Vegosszeg: " << (tar.megrTptr+i)->getVegosszeg() << endl;
                }
            }
            if(vanFolyamatban==false){
                cout << "" << endl;
                cout << "Nincs folyamatban levo rendeles." << endl;
            }
            temp="K";
            while(temp.compare("Y")!=0 && temp.compare("N")!=0 && vanFolyamatban==true){
            cout << "Kesz a rendeles? (Y/N): ";
            cin >> temp;
            }
            cout << "" << endl;
            if(temp.compare("Y")==0){
                (tar.megrTptr+(tar.megrSize-1))->setStatus("Teljesitve");
            }

            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a dolgozoi feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }

        break;
        }
        case 3:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "TERMEK TORLESE (Visszalepes: -1)" << endl;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "" << endl;

            string str="0";
            bool talalat=false;
            while(talalat==false && str.compare("-1")!=0){
                cout << "Adja meg a torolni kivant termek azonositojat: ";
                cin >> str;
                if(str.compare("-1")!=0){
                for(unsigned int i=0;i<tar.eszkSize;i++){
                    if(str.compare((tar.eszkTptr+i)->getId())==0){
                        talalat=true;
                        i=tar.eszkSize+10;
                    }
                }
                }
            }
            if(talalat==true){
                for(unsigned int i=0;i<tar.eszkSize;i++){
                    if(str.compare((tar.eszkTptr+i)->getId())==0){
                        (tar.eszkTptr+i)->setNev("");
                        (tar.eszkTptr+i)->setElerheto(false);
                        (tar.eszkTptr+i)->setNapi_ar(0);
                        (tar.eszkTptr+i)->setTipus("");
                        cout << "" << endl;
                        cout << "Sikeresen torlve: " << str << endl;
                    }
                }
            }
            if(str.compare("-1")==0){
                temp=str;
            }
            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a dolgozoi feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }

        break;
        }
        case 4:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "TERMEK HOZZAADASA (Visszalepes: -1)" << endl;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "" << endl;

            string str="0";
            bool talalat=true;
            while(talalat==true && str.compare("-1")!=0){
                talalat=false;
                cout << "Adja meg a hozzaadni kivant termek azonositojat: ";
                cin >> str;
                if(str.compare("-1")!=0){
                for(unsigned int i=0;i<tar.eszkSize;i++){
                    if(str.compare((tar.eszkTptr+i)->getId())==0){
                        talalat=true;
                        cout << "" << endl;
                        cout << "A megadott azonosito mar foglalt!" << endl;
                        i=tar.eszkSize+10;
                    }
                }
                }
            }


            if(talalat==false){
                Eszkoz * tempEszkTptr = new Eszkoz[tar.eszkSize+1];      //uj (1-el nagyobb) dinamikus tomb
                for (unsigned int i = 0; i < tar.eszkSize; i++){
                    tempEszkTptr[i] = tar.eszkTptr[i];
                }
                delete [] tar.eszkTptr;
                tar.eszkTptr=tempEszkTptr;
                tar.eszkSize++;


                (tar.eszkTptr+(tar.eszkSize-1))->setId(str);
                cout << "" << endl;
                cout << "Adja meg a termek nevet: ";
                cin >> str;
                (tar.eszkTptr+(tar.eszkSize-1))->setNev(str);
                cout << "" << endl;
                cout << "Adja meg a termek tipusat: ";
                cin >> str;
                (tar.eszkTptr+(tar.eszkSize-1))->setTipus(str);
                str="0";
                while(str.compare("Y")!=0 && str.compare("N")!=0){
                cout << "" << endl;
                cout << "Adja meg a termek elerhetoseget (Y/N): ";
                cin >> str;
                }
                bool elerh=false;
                if(str.compare("Y")==0){
                    elerh=true;
                }
                (tar.eszkTptr+(tar.eszkSize-1))->setElerheto(elerh);
                cout << "" << endl;
                cout << "Adja meg a termek napi arat: ";
                cin >> str;
                (tar.eszkTptr+(tar.eszkSize-1))->setNapi_ar(stoi(str));
                cout << "" << endl;
                cout << "Sikeres hozzaadas!" << endl;

            }
            if(str.compare("-1")==0){
                temp=str;
            }
            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a dolgozoi feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }


        break;
        }
        case 5:{
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "TERMEK ADATAINAK MODOSITASA (Visszalepes: -1)" << endl;
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "" << endl;

        string str="0";
        unsigned int index;
        bool talalat=false;
        while(talalat==false && str.compare("-1")!=0){
            cout << "Adja meg a modositani kivant termek azonositojat: ";
            cin >> str;
            if(str.compare("-1")!=0){
            for(unsigned int i=0;i<tar.eszkSize;i++){
                if(str.compare((tar.eszkTptr+i)->getId())==0){
                    talalat=true;
                    index=i;
                    i=tar.eszkSize+10;
                }
            }
            }
            if(talalat==false && str.compare("-1")!=0){
                cout << "Nincs ilyen azonositoju termek!" << endl;
            }
        }
        if(talalat==true){
            str="0";
            while(str.compare("-1")!=0 && str.compare("1") != 0 && str.compare("2") != 0 &&
                  str.compare("3") != 0 && str.compare("4") != 0 && str.compare("5") != 0){
            cout << "Melyik adatot kivanja modositani?" << endl;
            cout << "Azonosito: 1" << endl;
            cout << "Nev: 2" << endl;
            cout << "Tipus: 3" << endl;
            cout << "Napi ar: 4" << endl;
            cout << "Elerhetoseg: 5" << endl;
            cout << "" << endl;
            cout << "Adja meg a muvelet sorszamat (1-5) es nyomja le az ENTER billentyut!: ";
            cin >> str;
            }
            switch (stoi(str)) {
                case 1:{
                    while(talalat==true && str.compare("-1")!=0){
                        talalat=false;
                        cout << "Adja meg a termek uj azonositojat: ";
                        cin >> str;
                        if(str.compare("-1")!=0){
                        for(unsigned int i=0;i<tar.eszkSize;i++){
                            if(str.compare((tar.eszkTptr+i)->getId())==0){
                                talalat=true;
                                cout << "" << endl;
                                cout << "A megadott azonosito mar foglalt!" << endl;
                                i=tar.eszkSize+10;
                            }
                        }
                        }
                    }
                    if(talalat==false){
                        (tar.eszkTptr+index)->setId(str);
                        }

                    break;
                }
                case 2:{
                    cout << "Adja meg a termek uj nevet: ";
                    cin >> str;
                    if(str.compare("-1")!=0){
                        (tar.eszkTptr+index)->setTipus(str);
                    }
                    else {
                        temp=str;
                        return temp;
                    }

                    break;
                }
                case 3:{
                        cout << "Adja meg a termek uj tipusat: ";
                        cin >> str;
                        if(str.compare("-1")!=0){
                            (tar.eszkTptr+index)->setTipus(str);
                        }
                        else {
                            temp=str;
                            return temp;
                        }
                    break;
                }
                case 4:{
                    cout << "Adja meg a termek uj napi arat: ";
                    cin >> str;
                    if(str.compare("-1")!=0){
                        (tar.eszkTptr+index)->setTipus(str);
                    }
                    else {
                        temp=str;
                        return temp;
                    }
                    break;
                }
                case 5:{
                    while(str.compare("-1")!=0 && str.compare("Y")!=0
                          && str.compare("N")!=0){
                        cout << "Adja meg a termek elerhetoseget (Y/N): ";
                        cin >> str;
                        cout << "" << endl;
                    }

                    if(str.compare("Y")==0 || str.compare("N")==0){
                        if(str.compare("Y")==0){
                        (tar.eszkTptr+index)->setElerheto(true);
                        }
                        else if(str.compare("N")==0){
                            (tar.eszkTptr+index)->setElerheto(false);
                            }
                    }
                    else if(str.compare("-1")==0){
                        temp=str;
                    }

                    break;
                }
            }



        }

            if(str.compare("-1")==0){
                temp=str;
            }
            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a dolgozoi feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }
            break;
            }
        case 6:{
            return temp="6";
        break;
        }
    }
    return temp;
  }


string adminFelulet(string &pop, Tarolo tar, Autentikacio auten){
    string temp="0";
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "ADMIN FELULET" << endl;
    cout << "Belepve: " << pop << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "" << endl;
    cout << "Uj rendeles megtekintese: 1" << endl;
    cout << "Folyamatban levo rendeles megtekintese: 2" << endl;
    cout << "Termek torlese a rendszerbol: 3" << endl;
    cout << "Termek hozzaadasa a rendszerhez: 4" << endl;
    cout << "Termek adatainak modositasa: 5" << endl;
    cout << "Felhasznalo torlese a rendszerbol: 6" << endl;
    cout << "Felhasznalo hozzaadasa a rendszerhez: 7" << endl;
    cout << "Felhasznalo adatainak modositasa: 8" << endl;
    cout << "Kijelentkezes: 9" << endl;
    while(temp.compare("1")!=0 && temp.compare("2")!=0 && temp.compare("3")!=0
          && temp.compare("4")!=0 && temp.compare("5")!=0 && temp.compare("6")!=0
          && temp.compare("7")!=0 && temp.compare("8")!=0 && temp.compare("9")!=0){
        cout << "" << endl;
        cout << "Adja meg a kivant muvelet sorszamat (1-9) es nyomja le az ENTER billentyut!: ";
        cin >> temp;
    }

    switch (stoi(temp)) {
        case 1:{
            unsigned int index;
            bool vanUj=false;
            for(unsigned int i=0;i<tar.megrSize;i++){
                if((tar.megrTptr+i)->getStatus().compare("Uj")==0){
                    vanUj=true;
                    index=i;
                    cout << "" << endl;
                    cout << "Rendeles azonositoja: " << (tar.megrTptr)->getRendId() << endl;
                    cout << "Rendelt termekek: " << (tar.megrTptr+i)->getEszkNev() << endl;
                    cout << "Nev: " << (tar.megrTptr+i)->getVnev() << " " <<
                         (tar.megrTptr+i)->getKnev() << endl;
                    cout << "Telefonszam: " << (tar.megrTptr+i)->getTelefon() << endl;
                    cout << "Email: " << (tar.megrTptr+i)->getEmail() << endl;
                    cout << "Szallitasi cim: " << (tar.megrTptr+i)->getSzall_cim() << endl;
                    cout << "Szamlazasi cim: " << (tar.megrTptr+i)->getSzaml_cim() << endl;
                    cout << "Adoszam: " << (tar.megrTptr+i)->getAdoszam() << endl;
                    cout << "Statusz: " << (tar.megrTptr+i)->getStatus() << endl;
                    cout << "Vegosszeg: " << (tar.megrTptr+i)->getVegosszeg() << " Ft" << endl;
                    i=tar.megrSize+10;
                }
            }
            if(vanUj==false){
                cout << "" << endl;
                cout << "Nincs uj rendeles." << endl;
            }
            temp="K";
            while(temp.compare("Y")!=0 && temp.compare("N")!=0 && vanUj==true){
                cout << "Elkezdi osszekesziteni a rendelest? (Y/N): ";
                cin >> temp;
            }

            cout << "" << endl;
            if(temp.compare("Y")==0){
                (tar.megrTptr+index)->setStatus("Folyamatban");
            }

            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a admin feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }

        break;
        }
        case 2:{
            bool vanFolyamatban=false;
            for(unsigned int i=0;i<tar.megrSize;i++){
                if((tar.megrTptr+i)->getStatus().compare("Folyamatban")==0){
                    vanFolyamatban=true;
                    cout << "" << endl;
                    cout << "Rendeles azonositoja: " << (tar.megrTptr)->getRendId() << endl;
                    cout << "Rendelt termekek: " << (tar.megrTptr+i)->getEszkNev() << endl;
                    cout << "Nev: " << (tar.megrTptr+i)->getVnev() << " " <<
                         (tar.megrTptr+i)->getKnev() << endl;
                    cout << "Telefonszam: " << (tar.megrTptr+i)->getTelefon() << endl;
                    cout << "Email: " << (tar.megrTptr+i)->getEmail() << endl;
                    cout << "Szallitasi cim: " << (tar.megrTptr+i)->getSzall_cim() << endl;
                    cout << "Szamlazasi cim: " << (tar.megrTptr+i)->getSzaml_cim() << endl;
                    cout << "Adoszam: " << (tar.megrTptr+i)->getAdoszam() << endl;
                    cout << "Statusz: " << (tar.megrTptr+i)->getStatus() << endl;
                    cout << "Vegosszeg: " << (tar.megrTptr+i)->getVegosszeg() << endl;
                }
            }
            if(vanFolyamatban==false){
                cout << "" << endl;
                cout << "Nincs folyamatban levo rendeles." << endl;
            }
            temp="K";
            while(temp.compare("Y")!=0 && temp.compare("N")!=0 && vanFolyamatban==true){
            cout << "Kesz a rendeles? (Y/N): ";
            cin >> temp;
            }
            cout << "" << endl;
            if(temp.compare("Y")==0){
                (tar.megrTptr+(tar.megrSize-1))->setStatus("Teljesitve");
            }

            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a admin feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }

        break;
        }
        case 3:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "TERMEK TORLESE (Visszalepes: -1)" << endl;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "" << endl;

            string str="0";
            bool talalat=false;
            while(talalat==false && str.compare("-1")!=0){
                cout << "Adja meg a torolni kivant termek azonositojat: ";
                cin >> str;
                if(str.compare("-1")!=0){
                for(unsigned int i=0;i<tar.eszkSize;i++){
                    if(str.compare((tar.eszkTptr+i)->getId())==0){
                        talalat=true;
                        i=tar.eszkSize+10;
                    }
                }
                }
            }
            if(talalat==true){
                for(unsigned int i=0;i<tar.eszkSize;i++){
                    if(str.compare((tar.eszkTptr+i)->getId())==0){
                        (tar.eszkTptr+i)->setNev("");
                        (tar.eszkTptr+i)->setElerheto(false);
                        (tar.eszkTptr+i)->setNapi_ar(0);
                        (tar.eszkTptr+i)->setTipus("");
                        cout << "" << endl;
                        cout << "Sikeresen torlve: " << str << endl;
                    }
                }
            }
            if(str.compare("-1")==0){
                temp=str;
            }
            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a admin feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }

        break;
        }
        case 4:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "TERMEK HOZZAADASA (Visszalepes: -1)" << endl;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "" << endl;

            string str="0";
            bool talalat=true;
            while(talalat==true && str.compare("-1")!=0){
                talalat=false;
                cout << "Adja meg a hozzaadni kivant termek azonositojat: ";
                cin >> str;
                if(str.compare("-1")!=0){
                for(unsigned int i=0;i<tar.eszkSize;i++){
                    if(str.compare((tar.eszkTptr+i)->getId())==0){
                        talalat=true;
                        cout << "" << endl;
                        cout << "A megadott azonosito mar foglalt!" << endl;
                        i=tar.eszkSize+10;
                    }
                }
                }
            }


            if(talalat==false){
                Eszkoz * tempEszkTptr = new Eszkoz[tar.eszkSize+1];      //uj (1-el nagyobb) dinamikus tomb
                for (unsigned int i = 0; i < tar.eszkSize; i++){
                    tempEszkTptr[i] = tar.eszkTptr[i];
                }
                delete [] tar.eszkTptr;
                tar.eszkTptr=tempEszkTptr;
                tar.eszkSize++;


                (tar.eszkTptr+(tar.eszkSize-1))->setId(str);
                cout << "" << endl;
                cout << "Adja meg a termek nevet: ";
                cin >> str;
                (tar.eszkTptr+(tar.eszkSize-1))->setNev(str);
                cout << "" << endl;
                cout << "Adja meg a termek tipusat: ";
                cin >> str;
                (tar.eszkTptr+(tar.eszkSize-1))->setTipus(str);
                str="0";
                while(str.compare("Y")!=0 && str.compare("N")!=0){
                cout << "" << endl;
                cout << "Adja meg a termek elerhetoseget (Y/N): ";
                cin >> str;
                }
                bool elerh=false;
                if(str.compare("Y")==0){
                    elerh=true;
                }
                (tar.eszkTptr+(tar.eszkSize-1))->setElerheto(elerh);
                cout << "" << endl;
                cout << "Adja meg a termek napi arat: ";
                cin >> str;
                (tar.eszkTptr+(tar.eszkSize-1))->setNapi_ar(stoi(str));
                cout << "" << endl;
                cout << "Sikeres hozzaadas!" << endl;

            }
            if(str.compare("-1")==0){
                temp=str;
            }
            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a admin feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }


        break;
        }
        case 5:{
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "TERMEK ADATAINAK MODOSITASA (Visszalepes: -1)" << endl;
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "" << endl;

        string str="0";
        unsigned int index;
        bool talalat=false;
        while(talalat==false && str.compare("-1")!=0){
            cout << "Adja meg a modositani kivant termek azonositojat: ";
            cin >> str;
            if(str.compare("-1")!=0){
            for(unsigned int i=0;i<tar.eszkSize;i++){
                if(str.compare((tar.eszkTptr+i)->getId())==0){
                    talalat=true;
                    index=i;
                    i=tar.eszkSize+10;
                }
            }
            }
            if(talalat==false && str.compare("-1")!=0){
                cout << "Nincs ilyen azonositoju termek!" << endl;
            }
        }
        if(talalat==true){
            str="0";
            while(str.compare("-1")!=0 && str.compare("1") != 0 && str.compare("2") != 0 &&
                  str.compare("3") != 0 && str.compare("4") != 0 && str.compare("5") != 0){
            cout << "Melyik adatot kivanja modositani?" << endl;
            cout << "Azonosito: 1" << endl;
            cout << "Nev: 2" << endl;
            cout << "Tipus: 3" << endl;
            cout << "Napi ar: 4" << endl;
            cout << "Elerhetoseg: 5" << endl;
            cout << "" << endl;
            cout << "Adja meg a muvelet sorszamat (1-5) es nyomja le az ENTER billentyut!: ";
            cin >> str;
            }
            switch (stoi(str)) {
                case 1:{
                    while(talalat==true && str.compare("-1")!=0){
                        talalat=false;
                        cout << "Adja meg a termek uj azonositojat: ";
                        cin >> str;
                        if(str.compare("-1")!=0){
                        for(unsigned int i=0;i<tar.eszkSize;i++){
                            if(str.compare((tar.eszkTptr+i)->getId())==0 &&
                                    (tar.eszkTptr+i)->getNev().compare("")!=0){
                                talalat=true;
                                cout << "" << endl;
                                cout << "A megadott azonosito mar foglalt!" << endl;
                                i=tar.eszkSize+10;
                            }
                        }
                        }
                    }
                    if(talalat==false){
                        (tar.eszkTptr+index)->setId(str);
                        }

                    break;
                }
                case 2:{
                    cout << "Adja meg a termek uj nevet: ";
                    cin >> str;
                    if(str.compare("-1")!=0){
                        (tar.eszkTptr+index)->setTipus(str);
                    }
                    else {
                        temp=str;
                        return temp;
                    }

                    break;
                }
                case 3:{
                        cout << "Adja meg a termek uj tipusat: ";
                        cin >> str;
                        if(str.compare("-1")!=0){
                            (tar.eszkTptr+index)->setTipus(str);
                        }
                        else {
                            temp=str;
                            return temp;
                        }
                    break;
                }
                case 4:{
                    cout << "Adja meg a termek uj napi arat: ";
                    cin >> str;
                    if(str.compare("-1")!=0){
                        (tar.eszkTptr+index)->setTipus(str);
                    }
                    else {
                        temp=str;
                        return temp;
                    }
                    break;
                }
                case 5:{
                    while(str.compare("-1")!=0 && str.compare("Y")!=0
                          && str.compare("N")!=0){
                        cout << "Adja meg a termek elerhetoseget (Y/N): ";
                        cin >> str;
                        cout << "" << endl;
                    }

                    if(str.compare("Y")==0 || str.compare("N")==0){
                        if(str.compare("Y")==0){
                        (tar.eszkTptr+index)->setElerheto(true);
                        }
                        else if(str.compare("N")==0){
                            (tar.eszkTptr+index)->setElerheto(false);
                            }
                    }
                    else if(str.compare("-1")==0){
                        temp=str;
                    }

                    break;
                }
            }



        }

            if(str.compare("-1")==0){
                temp=str;
            }
            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a admin feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }
            break;
            }
    case 6:{
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "DOLGOZO TORLESE (Visszalepes: -1)" << endl;
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "" << endl;

        string str="0";
        bool talalat=false;
        unsigned int idx;
        while(talalat==false && str.compare("-1")!=0){

            cout << "Adja meg a torolni kivant dolgozo felhasznalonevet: ";
            cin >> str;
            if(str.compare("-1")!=0){
            for(unsigned int i=0;i<auten.dolgSize;i++){

                if(str.compare((auten.dolgTptr+i)->getFnev())==0){
                    talalat=true;
                    idx=i;
                    i=auten.dolgSize+10;
                }
            }
            }
            if(talalat==false){
            cout << "Nincs ilyen a rendszerben!" << endl;
            }

        }
        if(talalat==true){
                    (auten.dolgTptr+idx)->setVnev("");
                    (auten.dolgTptr+idx)->setKnev("");
                    (auten.dolgTptr+idx)->setCim("");
                    (auten.dolgTptr+idx)->setIsBelepve(false);
                    (auten.dolgTptr+idx)->setTelefon("");
                    (auten.dolgTptr+idx)->setSzul_dat("");
                    (auten.dolgTptr+idx)->setJelszo("");

                    cout << "" << endl;
                    cout << "Sikeresen torlve: " << str << endl;
        }
        if(str.compare("-1")==0){
            temp=str;
        }
        temp="3";
        while(temp.compare("-1")!=0){
            cout << "" << endl;
            cout << "Vissza a admin feluletre: -1" << endl;
            cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
            cin >> temp;
        }

    break;
    }
    case 7:{
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "DOLGOZO HOZZAADASA (Visszalepes: -1)" << endl;
        cout << "----------------------------------------------------------------------------------------------------------------" << endl;
        cout << "" << endl;

        string str="0";
        bool talalat=true;
        while(talalat==true && str.compare("-1")!=0){
            talalat=false;
            cout << "Adja meg a hozzaadni kivant dolgozo felhasznalonevet: ";
            cin >> str;
            if(str.compare("-1")!=0){
            for(unsigned int i=0;i<auten.dolgSize;i++){
                if(str.compare((auten.dolgTptr+i)->getFnev())==0){
                    talalat=true;
                    cout << "" << endl;
                    cout << "A megadott felhasznalonev mar foglalt!" << endl;
                    i=auten.dolgSize+10;
                }
            }
            for(unsigned int i=0;i<auten.admSize;i++){
                if(str.compare((auten.admTptr+i)->getFnev())==0){
                    talalat=true;
                    cout << "" << endl;
                    cout << "A megadott felhasznalonev mar foglalt!" << endl;
                    i=auten.admSize+10;
                }
            }
            }
        }


        if(talalat==false){
            Dolgozo * tempDolgTptr = new Dolgozo[auten.dolgSize+1];      //uj (1-el nagyobb) dinamikus tomb
            for (unsigned int i = 0; i < auten.dolgSize; i++){
                tempDolgTptr[i] = auten.dolgTptr[i];
            }
            delete [] auten.dolgTptr;
            auten.dolgTptr=tempDolgTptr;
            auten.dolgSize++;


            cout << "" << endl;
            cout << "Adja meg a dolgozo vezeteknevet: ";
            cin >> str;
            if(str.compare("-1")!=0){
            (auten.dolgTptr+(auten.dolgSize-1))->setVnev(str);
            }
            if(str.compare("-1")!=0){
            cout << "" << endl;
            cout << "Adja meg a dolgozo keresztnevet: ";
            cin >> str;
            if(str.compare("-1")!=0){
            (auten.dolgTptr+(auten.dolgSize-1))->setKnev(str);
            }
            }
            if(str.compare("-1")!=0){
            cout << "" << endl;
            cout << "Adja meg a dolgozo cimet (Formatum: Iranyitoszam,Telepules,Kozterulet neve,Kozterulet tipusa,Hazszam): ";
            cout << "" << endl;
            cin >> str;
            if(str.compare("-1")!=0){
            (auten.dolgTptr+(auten.dolgSize-1))->setCim(str);
            }
            }
            if(str.compare("-1")!=0){
            cout << "" << endl;
            cout << "Adja meg a dolgozo telefonszamat: ";
            cin >> str;
            if(str.compare("-1")!=0){
            (auten.dolgTptr+(auten.dolgSize-1))->setTelefon(str);
            }
            }
            if(str.compare("-1")!=0){
            cout << "" << endl;
            cout << "Adja meg a dolgozo jelszavat: ";
            cin >> str;
            if(str.compare("-1")!=0){
            (auten.dolgTptr+(auten.dolgSize-1))->setJelszo(str);
            }
            }
            if(str.compare("-1")!=0){
                while(str.compare("-1")!=0 && str.compare("Y")!=0
                      && str.compare("N")!=0){
                    cout << "Kivan ADMIN jogot adni a felhasznalonak? (Y/N): ";
                    cin >> str;
                    cout << "" << endl;
                }
                if(str.compare("-1")!=0){
                if(str.compare("N")!=0){
                (auten.dolgTptr+(auten.dolgSize-1))->setIsAdmin(false);
                }
                else {
                    (auten.dolgTptr+(auten.dolgSize-1))->setIsAdmin(true);
                }
            }
            if(str.compare("-1")!=0){
            cout << "" << endl;
            cout << "Adja meg a dolgozo szuletesi datumat (Formatum: 1990.01.09): ";
            cin >> str;
            if(str.compare("-1")!=0){
            (auten.dolgTptr+(auten.dolgSize-1))->setSzul_dat(str);
            }
            }
            cout << "" << endl;
            if(str.compare("-1")!=0){
                (auten.dolgTptr+(auten.dolgSize-1))->setIsBelepve(false);
            cout << "Sikeres hozzaadas!" << endl;
            if((auten.dolgTptr+(auten.dolgSize-1))->getIsAdmin()==true){        //Admin jog-->Admin tombbe átkerül

                admin * tempAdmTptr = new admin[auten.admSize+1];      //uj (1-el nagyobb) dinamikus tomb
                for (unsigned int i = 0; i < auten.admSize; i++){
                    tempAdmTptr[i] = auten.admTptr[i];
                }
                tempAdmTptr[auten.admSize].setFnev((auten.dolgTptr+(auten.dolgSize-1))->getFnev());
                tempAdmTptr[auten.admSize].setVnev((auten.dolgTptr+(auten.dolgSize-1))->getVnev());
                tempAdmTptr[auten.admSize].setKnev((auten.dolgTptr+(auten.dolgSize-1))->getKnev());
                tempAdmTptr[auten.admSize].setCim((auten.dolgTptr+(auten.dolgSize-1))->getCim());
                tempAdmTptr[auten.admSize].setTelefon((auten.dolgTptr+(auten.dolgSize-1))->getTelefon());
                tempAdmTptr[auten.admSize].setJelszo((auten.dolgTptr+(auten.dolgSize-1))->getJelszo());
                tempAdmTptr[auten.admSize].setSzul_dat((auten.dolgTptr+(auten.dolgSize-1))->getSzul_dat());
                tempAdmTptr[auten.admSize].setIsAdmin((auten.dolgTptr+(auten.dolgSize-1))->getIsAdmin());
                tempAdmTptr[auten.admSize].setIsBelepve(false);

                delete [] auten.admTptr;
                auten.admTptr=tempAdmTptr;
                auten.admTptr++;

                Dolgozo * tempDolgTptr = new Dolgozo[auten.dolgSize-1];      //uj (1-el kisebb) dinamikus tomb
                for (unsigned int i = 0; i < (auten.dolgSize-1); i++){
                    tempDolgTptr[i] = auten.dolgTptr[i];
                }
                delete [] auten.dolgTptr;
                auten.dolgTptr=tempDolgTptr;
                auten.dolgSize--;
            }
            }
            else {
                cout << "Sikertelen hozzaadas!" << endl;
                Dolgozo * tempDolgTptr = new Dolgozo[auten.dolgSize-1];      //uj (1-el kisebb) dinamikus tomb
                for (unsigned int i = 0; i < (auten.dolgSize-1); i++){
                    tempDolgTptr[i] = auten.dolgTptr[i];
                }
                delete [] auten.dolgTptr;
                auten.dolgTptr=tempDolgTptr;
                auten.dolgSize--;
            }

        }
        if(str.compare("-1")==0){
            temp=str;
        }
        temp="3";
        while(temp.compare("-1")!=0){
            cout << "" << endl;
            cout << "Vissza a admin feluletre: -1" << endl;
            cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
            cin >> temp;
        }

}
    break;
    }
    case 8:{
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "DOLGOZO ADATAINAK MODOSITASA (Visszalepes: -1)" << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "" << endl;
    string str="0";
    unsigned int index;
    bool talalat=false;
    while(talalat==false && str.compare("-1")!=0){
        cout << "Adja meg a dolgozo felhasznalonevet: ";
        cin >> str;
        if(str.compare("-1")!=0){
        for(unsigned int i=0;i<auten.dolgSize;i++){

            if(str.compare((auten.dolgTptr+i)->getFnev())==0){
                talalat=true;
                index=i;
                i=auten.dolgSize+10;
            }
        }
        }
        if(talalat==false){
        cout << "Nincs ilyen a rendszerben!" << endl;
        }
    }

    if(talalat==true){
        str="0";
        while(str.compare("-1")!=0 && str.compare("1") != 0 && str.compare("2") != 0 &&
              str.compare("3") != 0 && str.compare("4") != 0 && str.compare("5") != 0 &&
              str.compare("6") != 0 && str.compare("7") != 0 && str.compare("8") != 0){
        cout << "Melyik adatot kivanja modositani?" << endl;
        cout << "Felhasznalonev: 1" << endl;
        cout << "Vezeteknev: 2" << endl;
        cout << "Keresztnev: 3" << endl;
        cout << "Cim: 4" << endl;
        cout << "Telefon: 5" << endl;
        cout << "Jelszo: 6" << endl;
        cout << "Szuletesi datum: 7" << endl;
        cout << "Jogosultsag: 8" << endl;

        cout << "" << endl;
        cout << "Adja meg a muvelet sorszamat (1-8) es nyomja le az ENTER billentyut!: ";
        cin >> str;
        }
        switch (stoi(str)) {
            case 1:{
                while(talalat==true && str.compare("-1")!=0){
                    talalat=false;
                    cout << "Adja meg dolgozo uj felhasznalonevet: ";
                    cin >> str;
                    if(str.compare("-1")!=0){
                    for(unsigned int i=0;i<auten.dolgSize;i++){
                        if(str.compare((auten.dolgTptr+i)->getFnev())==0){
                            talalat=true;
                            cout << "" << endl;
                            cout << "A megadott felhasznalonev mar foglalt!" << endl;

                            i=auten.dolgSize+10;
                        }
                    }
                    }
                }
                if(talalat==false){
                    (auten.dolgTptr+index)->setFnev(str);
                    }
                if(str.compare("-1")==0){
                    temp=str;
                }
                temp="3";
                while(temp.compare("-1")!=0){
                    cout << "" << endl;
                    cout << "Vissza a admin feluletre: -1" << endl;
                    cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                    cin >> temp;
                }

                break;
            }
            case 2:{
                cout << "Adja meg a dolgozo vezeteknevet: ";
                cin >> str;
                if(str.compare("-1")!=0){
                    (auten.dolgTptr+index)->setVnev(str);
                }
                else {
                    temp=str;
                    return temp;
                }
                if(str.compare("-1")==0){
                    temp=str;
                }
                temp="3";
                while(temp.compare("-1")!=0){
                    cout << "" << endl;
                    cout << "Vissza a admin feluletre: -1" << endl;
                    cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                    cin >> temp;
                }

                break;
            }
            case 3:{
                    cout << "Adja meg a dolgozo keresztnevet: ";
                    cin >> str;
                    if(str.compare("-1")!=0){
                        (auten.dolgTptr+index)->setKnev(str);
                    }
                    else {
                        temp=str;
                        return temp;
                    }
                    if(str.compare("-1")==0){
                        temp=str;
                    }
                    temp="3";
                    while(temp.compare("-1")!=0){
                        cout << "" << endl;
                        cout << "Vissza a admin feluletre: -1" << endl;
                        cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                        cin >> temp;
                    }
                break;
            }
            case 4:{
                cout << "Adja meg a dolgozo cimet: ";
                cin >> str;
                if(str.compare("-1")!=0){
                    (auten.dolgTptr+index)->setCim(str);
                }
                else {
                    temp=str;
                    return temp;
                }
                if(str.compare("-1")==0){
                    temp=str;
                }
                temp="3";
                while(temp.compare("-1")!=0){
                    cout << "" << endl;
                    cout << "Vissza a admin feluletre: -1" << endl;
                    cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                    cin >> temp;
                }
                break;
            }
            case 5:{
                    cout << "Adja meg a dolgozo telefonszamat: ";
                    cin >> str;
                    if(str.compare("-1")!=0){
                        (auten.dolgTptr+index)->setTelefon(str);
                    }
                    else {
                        temp=str;
                        return temp;
                    }
                    if(str.compare("-1")==0){
                        temp=str;
                    }
                    temp="3";
                    while(temp.compare("-1")!=0){
                        cout << "" << endl;
                        cout << "Vissza a admin feluletre: -1" << endl;
                        cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                        cin >> temp;
                    }
                break;
            }
        case 6:{
                cout << "Adja meg a dolgozo uj jelszavat: ";
                cin >> str;
                if(str.compare("-1")!=0){
                    (auten.dolgTptr+index)->setKnev(str);
                }
                else {
                    temp=str;
                    return temp;
                }
                if(str.compare("-1")==0){
                    temp=str;
                }
                temp="3";
                while(temp.compare("-1")!=0){
                    cout << "" << endl;
                    cout << "Vissza a admin feluletre: -1" << endl;
                    cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                    cin >> temp;
                }
            break;
        }
        case 7:{
            cout << "Adja meg a dolgozo szuletesi datumat: ";
            cin >> str;
            if(str.compare("-1")!=0){
                (auten.dolgTptr+index)->setCim(str);
            }
            else {
                temp=str;
                return temp;
            }
            if(str.compare("-1")==0){
                temp=str;
            }
            temp="3";
            while(temp.compare("-1")!=0){
                cout << "" << endl;
                cout << "Vissza a admin feluletre: -1" << endl;
                cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                cin >> temp;
            }
            break;
        }
        case 8:{
                cout << "Adja meg a dolgozo jogosultsagat: ";
                cin >> str;
                if(str.compare("-1")!=0){
                    while(str.compare("-1")!=0 && str.compare("Y")!=0
                          && str.compare("N")!=0){
                        cout << "ADMIN jog? (Y/N): ";
                        cin >> str;
                        cout << "" << endl;
                    }
                    if(str.compare("-1")!=0){
                    if(str.compare("N")!=0){
                    (auten.dolgTptr+index)->setIsAdmin(false);
                    }
                    else {
                        (auten.dolgTptr+index)->setIsAdmin(true);
                    }
                    if((auten.dolgTptr+index)->getIsAdmin()==true){        //Admin jog-->Admin tombbe átkerül

                        admin * tempAdmTptr = new admin[auten.admSize+1];      //uj (1-el nagyobb) dinamikus tomb
                        for (unsigned int i = 0; i < auten.admSize; i++){
                            tempAdmTptr[i] = auten.admTptr[i];
                        }

                        tempAdmTptr[auten.admSize].setFnev((auten.dolgTptr+index)->getFnev());
                        tempAdmTptr[auten.admSize].setVnev((auten.dolgTptr+index)->getVnev());
                        tempAdmTptr[auten.admSize].setKnev((auten.dolgTptr+index)->getKnev());
                        tempAdmTptr[auten.admSize].setCim((auten.dolgTptr+index)->getCim());
                        tempAdmTptr[auten.admSize].setTelefon((auten.dolgTptr+index)->getTelefon());
                        tempAdmTptr[auten.admSize].setJelszo((auten.dolgTptr+index)->getJelszo());
                        tempAdmTptr[auten.admSize].setSzul_dat((auten.dolgTptr+index)->getSzul_dat());
                        tempAdmTptr[auten.admSize].setIsAdmin((auten.dolgTptr+index)->getIsAdmin());
                        tempAdmTptr[auten.admSize].setIsBelepve(false);

                        delete [] auten.admTptr;
                        auten.admTptr=tempAdmTptr;
                        auten.admSize++;
                        unsigned int k=0;
                        Dolgozo * tempDolgTptr = new Dolgozo[auten.dolgSize-1];      //uj (1-el kisebb) dinamikus tomb
                        for (unsigned int i = 0; i < (auten.dolgSize-1); i++){
                            if(index!=i){
                            tempDolgTptr[k] = auten.dolgTptr[i];
                            k++;
                            }
                        }
                        delete [] auten.dolgTptr;
                        auten.dolgTptr=tempDolgTptr;
                        auten.dolgSize--;
                    }
                    }
                }
                if(str.compare("-1")==0){
                    temp=str;
                }
                temp="3";
                while(temp.compare("-1")!=0){
                    cout << "" << endl;
                    cout << "Vissza a admin feluletre: -1" << endl;
                    cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
                    cin >> temp;
                }


            break;
        }

        if(str.compare("-1")==0){
            temp=str;
        }
        temp="3";
        while(temp.compare("-1")!=0){
            cout << "" << endl;
            cout << "Vissza a admin feluletre: -1" << endl;
            cout << "Adja meg a muvelet sorszamat (-1) es nyomja le az ENTER billentyut!: ";
            cin >> temp;
        }
        }
        break;
        }
    break;
    }


       case 9:{
            return temp="9";
        break;
        }
    }
    return temp;
  }




void muveletHivas(Autentikacio auten, Tarolo tar, Ugyfel ugyf){
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "Kezdolap" << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "" << endl;
    cout << "Elerheto termekek listazasa: 1" << endl;
    cout << "Termek keresese: 2" << endl;
    cout << "Termek rendelese: 3" << endl;
    cout << "Bejelentkezes: 4" << endl;
    //cout << "Elfelejtett jelszo: 5" << endl;
    cout << "" << endl;
    cout << "Adja meg a kivant muvelet sorszamat (1-4) es nyomja le az ENTER billentyut!: ";
    string muv="0";
    cin >> muv;
    while(muv.compare("1") != 0 && muv.compare("2") != 0 &&
          muv.compare("3") != 0 && muv.compare("4") != 0 /* && muv.compare("5") != 0 */){
        cout << "" << endl;
        cout << "Hibas parancs!" << endl;
        cout << "Adja meg a kivant muvelet sorszamat (1-4) es nyomja le az ENTER billentyut!: ";
        cin >> muv;

    }
    if (muv.compare("1") == 0 || muv.compare("2") == 0 ||
            muv.compare("3") == 0 || muv.compare("4") == 0 /* || muv.compare("5") == 0 */){
        cout << "" << endl;
         cout << "----------------------------------------------------------------------------------------------------------------" << endl;
         //cout << "A valasztott muvelet: ";
        switch (stoi(muv)){
            case 4: {
                        static string pop;
                        pop=Beje(auten);
                        while (pop.find("dolgozo")==string::npos && pop.find("admin")==string::npos ){
                            if (pop.compare("1")==0){
                                pop=Beje(auten);
                            }
                            else if(pop.compare("2")==0){
                                muveletHivas(auten,tar,ugyf);
                                pop=5;
                            }
                        }
                        if (pop.find("dolgozo")!=string::npos){
                            string temp="-1";
                            while(temp.compare("-1")==0){

                            temp=dolgozoFelulet(pop,tar);

                            if(temp.compare("6")==0){
                            for(unsigned int i=0;i<auten.dolgSize;i++){
                                if((auten.dolgTptr+i)->getFnev().compare(pop)==0)
                                {
                                    (auten.dolgTptr+i)->setIsBelepve(false);
                                }
                            }
                            muveletHivas(auten,tar,ugyf);
                            }
                            else if(temp.compare("-1")==0){
                            temp=dolgozoFelulet(pop,tar);
                            }
                            }
                        }
                        else if (pop.find("admin")!=string::npos){
                            string temp="-1";
                            while(temp.compare("-1")==0){
                            temp=adminFelulet(pop,tar,auten);

                            if(temp.compare("9")==0){
                            for(unsigned int i=0;i<auten.admSize;i++){
                                if((auten.admTptr+i)->getFnev().compare(pop)==0)
                                {
                                    (auten.admTptr+i)->setIsBelepve(false);
                                }
                            }
                            muveletHivas(auten,tar,ugyf);
                            }
                            else if(temp.compare("-1")==0){
                            temp=adminFelulet(pop,tar,auten);
                            }
                            }
                        }

                        break;
                    }

            case 1: {
                string tmp=Termeklistaz(tar);
                if(tmp.compare("-1")==0){
                    muveletHivas(auten,tar,ugyf);
                }
                break;
                }
            case 3: {

                bool rendelRtrn=eszkozRendel(tar);

                switch(rendelesKiir(rendelRtrn,tar)){
                    case 1: {
                        eszkozRendel(tar);
                        break;
                    }
                    case 2: {
                        muveletHivas(auten,tar,ugyf);
                        break;
                    }
                }

                break;
        }
        /*    case 5: {
                cout << "ELFELEJTETT JELSZO" << endl;
                cout << "----------------------------------------------------------------------------------------------------------------" << endl;
                break;
        }  */
            case 2: {
                unsigned int hat;
                string heet;
                //cout << "TERMEK KERESESE" << endl;
                //cout << "----------------------------------------------------------------------------------------------------------------" << endl;
                hat=ugyf.eszkozKereses(tar);
                if(hat!=6){
                    cout << "Vissza a kezdolapra: 1" << endl;
                    cout << "Uj kereses inditasa: 2" << endl;
                    cout << "Adja meg a muvelet azonositojat: ";
                    cin >>  heet;
                    if(heet.compare("2")==0){
                        hat=ugyf.eszkozKereses(tar);
                    }
                    else{
                        muveletHivas(auten,tar,ugyf);
                    }
                }
                else{
                    muveletHivas(auten,tar,ugyf);
                }

                break;
        }
        }
    }
    muv="0";
}


int main()
{
    Tarolo T1;
    Ugyfel ugyfe;
    Autentikacio auten;
    muveletHivas(auten,T1, ugyfe);



    return 0;
}

