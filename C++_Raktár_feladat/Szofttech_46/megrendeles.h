#ifndef MEGRENDELES_H
#define MEGRENDELES_H

#include <iostream>
#include <string.h>

using namespace std;

class Megrendeles
{
    string Vnev, Knev, szall_cim, szaml_cim, telefon, email, adoszam, rendId, status, eszkId, EszkNev, tipus;
    unsigned int vegosszeg=0;
public:
    Megrendeles();
    ~Megrendeles();
    string getEszkId() const;
    void setEszkId(const string &value);
    string getStatus() const;
    void setStatus(const string &value);
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
    string getRendId() const;
    void setRendId(const string &value);
    string getEszkNev() const;
    void setEszkNev(const string &value);
    string getTipus() const;
    void setTipus(const string &value);
    unsigned int getVegosszeg() const;
    void setVegosszeg(unsigned int value);
};

#endif // MEGRENDELES_H
