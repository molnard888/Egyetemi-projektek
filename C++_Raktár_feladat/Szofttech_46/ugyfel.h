#ifndef UGYFEL_H
#define UGYFEL_H

#include <iostream>
#include <string.h>
#include "tarolo.h"
#include "autentikacio.h"

using namespace std;

class Ugyfel
{
    string Vnev, Knev, szall_cim, szaml_cim, telefon, email, adoszam;
public:
    Ugyfel();
    ~Ugyfel();
    void termekListaz(Tarolo tar);
    int eszkozKereses(Tarolo tar);

    string getVnev() const;
    void setVnev(const string &value);
    string getKnev() const;
    void setKnev(const string &value);
    string getSzall_cim() const;
    void setSzall_cim(const string &value);
    string getSzaml_cim() const;
    void setSzaml_cim(const string &value);
    string getTelefon() const;
    void setTelefon(const string &value);
    string getEmail() const;
    void setEmail(const string &value);
    string getAdoszam() const;
    void setAdoszam(const string &value);
};

#endif // UGYFEL_H
