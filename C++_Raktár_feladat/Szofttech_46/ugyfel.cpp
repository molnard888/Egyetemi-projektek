#include "ugyfel.h"

#include <iostream>
#include <string.h>

using namespace std;


int Ugyfel::eszkozKereses(Tarolo tar)
{
    string choice="0";
    string param="";
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "KERESES" << endl;
    cout << "----------------------------------------------------------------------------------------------------------------" << endl;
    cout << "Nev szerint: 1" << endl;
    cout << "Tipus szerint: 2" << endl;
    cout << "Azonosito szerint: 3" << endl;
    cout << "Elerhetoseg szerint: 4" << endl;
    cout << "Ar szerint: 5" << endl;
    cout << "Vissza kezdolapra: 6" << endl;
    cout << "" << endl;
    cout << "Adja meg a kivant muvelet sorszamat (1-6) es nyomja le az ENTER billentyut!: ";
    cin >> choice;

    switch (stoi(choice)) {
        case 1:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "Adja meg a nevet: ";
            param="";
            cin >> param;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;

            for (unsigned int i=0;i<tar.eszkSize;i++){
                if((tar.eszkTptr+i)->getNev().compare(param) == 0){

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
            return stoi(choice);
            break;
        }
        case 2:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "Adja meg a tipust: ";
            param="";
            cin >> param;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;

            for (unsigned int i=0;i<tar.eszkSize;i++){
                if((tar.eszkTptr+i)->getTipus().compare(param) == 0){

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
            return stoi(choice);
            break;
        }
        case 3:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "Adja meg az azonositot: ";
            param="";
            cin >> param;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;

            for (unsigned int i=0;i<tar.eszkSize;i++){
                if((tar.eszkTptr+i)->getId().compare(param) == 0){

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
        return stoi(choice);
        break;
        }
        case 4:{
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "Adja meg az elerhetoseget (Y/N): ";
            param="";
            cin >> param;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;

            for (unsigned  int i=0;i<tar.eszkSize;i++){
                if((tar.eszkTptr+i)->getElerheto()==true && param.compare("Y")){

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
                if((tar.eszkTptr+i)->getElerheto()==false && param.compare("N")){

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
            return stoi(choice);
            break;
        }
        case 5:{
            param="";
            string param1="";
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;
            cout << "Adja meg a minimum arat: ";
            cin >> param;
            cout << "Adja meg a maximum arat: ";
            cin >> param1;
            cout << "----------------------------------------------------------------------------------------------------------------" << endl;

            unsigned int minim=stoi(param);
            unsigned int maxim=stoi(param1);
            for (unsigned  int i=0;i<tar.eszkSize;i++){
                if((tar.eszkTptr+i)->getNapi_ar() >= minim && (tar.eszkTptr+i)->getNapi_ar() <= maxim){

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
           return stoi(choice);
            break;
        }
    default:{
        return 6;
        break;
    }

    }




}




string Ugyfel::getVnev() const
{
    return Vnev;
}

void Ugyfel::setVnev(const string &value)
{
    Vnev = value;
}

string Ugyfel::getKnev() const
{
    return Knev;
}

void Ugyfel::setKnev(const string &value)
{
    Knev = value;
}

string Ugyfel::getSzall_cim() const
{
    return szall_cim;
}

void Ugyfel::setSzall_cim(const string &value)
{
    szall_cim = value;
}

string Ugyfel::getSzaml_cim() const
{
    return szaml_cim;
}

void Ugyfel::setSzaml_cim(const string &value)
{
    szaml_cim = value;
}

string Ugyfel::getTelefon() const
{
    return telefon;
}

void Ugyfel::setTelefon(const string &value)
{
    telefon = value;
}

string Ugyfel::getEmail() const
{
    return email;
}

void Ugyfel::setEmail(const string &value)
{
    email = value;
}

string Ugyfel::getAdoszam() const
{
    return adoszam;
}

void Ugyfel::setAdoszam(const string &value)
{
    adoszam = value;
}

Ugyfel::Ugyfel()
{

}

Ugyfel::~Ugyfel()
{

}

