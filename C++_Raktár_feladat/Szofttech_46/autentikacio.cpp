#include "autentikacio.h"
#include <iostream>
#include <string.h>
#include "dolgozo.h"



using namespace std;



Autentikacio::Autentikacio()
{
    dolgTptr->setFnev("dolgozo001");
    dolgTptr->setVnev("Kovacs");
    dolgTptr->setKnev("Bela");
    dolgTptr->setCim("Veszprem, Egyetem u. 1.");
    dolgTptr->setTelefon("+36301112233");
    dolgTptr->setJelszo("dolg111");
    dolgTptr->setSzul_dat("1980.02.11");
    dolgTptr->setIsBelepve(false);

    admTptr->setFnev("admin001");
    admTptr->setVnev("Szabó");
    admTptr->setKnev("János");
    admTptr->setCim("Veszprem, Egyetem u. 2.");
    admTptr->setTelefon("+36302223344");
    admTptr->setJelszo("adm111");
    admTptr->setSzul_dat("1975.04.21");
    admTptr->setIsBelepve(false);
}

Autentikacio::~Autentikacio()
{
}


string Autentikacio::login()
{
    nev = "";
    jelszo = "";
    cout << "" << endl;
    cout << "Adja meg a belepesi adatokat!" << endl;
    cout << "Felhasznalonev: ";
    cin >> nev;
    cout << "Jelszo: ";
    string tjel;
    cin >> jelszo;
    cout << "" << endl;

    bool siker=false;
    string inp="0";
    for(unsigned int i=0;i<dolgSize;i++){
        if((nev.compare((dolgTptr+i)->getFnev())) == 0 &&
                (jelszo.compare((dolgTptr+i)->getJelszo())) == 0
                && (dolgTptr+i)->getIsAdmin() == false)
        {
            siker=true;
            inp=(dolgTptr+i)->getFnev();
            (dolgTptr+i)->setIsBelepve(true);
        }
    }
    for(unsigned int i=0;i<admSize;i++){
        if((nev.compare((admTptr+i)->getFnev())) == 0 &&
                (jelszo.compare((admTptr+i)->getJelszo())) == 0
                && (admTptr+i)->getIsAdmin() == true)
        {
            siker=true;
            inp=(admTptr+i)->getFnev();
            (admTptr+i)->setIsBelepve(true);
        }
    }
    if(siker==false){
    cout << "----------------------------------------------------------------------" << endl;
    cout << "Sikertelen bejelentkezes!" << endl;
    cout << "----------------------------------------------------------------------" << endl;
    while(inp.compare("1")!=0 && inp.compare("2")!=0){
        cout << "Belepesi adatok megadasa ismet: 1" << endl;
        cout << "Vissza a kezdolapra: 2" << endl;
        cout << "" << endl;
        cout << "Adja meg a kivant muvelet sorszamat (1-2) es nyomja le az ENTER billentyut!: ";
        cin >> inp;
    }
    }
    return inp;
}
