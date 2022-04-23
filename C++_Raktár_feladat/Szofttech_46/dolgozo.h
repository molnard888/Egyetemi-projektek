#ifndef DOLGOZO_H
#define DOLGOZO_H


#include <iostream>
#include <string.h>

using namespace std;

class Dolgozo
{
    string Fnev, Vnev, Knev, cim, telefon, jelszo, szul_dat;
    bool isAdmin=false, isBelepve;
public:

    Dolgozo();
    Dolgozo(string &id, string &Vnev, string &Knev, string &cim, string &telefon,
            string &jelszo, string &szul_dat, bool adm, bool belep);
    ~Dolgozo();


    string getFnev() const;
    void setFnev(const string &value);
    string getVnev() const;
    void setVnev(const string &value);
    string getKnev() const;
    void setKnev(const string &value);
    string getCim() const;
    void setCim(const string &value);
    string getTelefon() const;
    void setTelefon(const string &value);
    string getJelszo() const;
    void setJelszo(const string &value);
    string getSzul_dat() const;
    void setSzul_dat(const string &value);
    bool getIsBelepve() const;
    void setIsBelepve(bool value);
    bool getIsAdmin() const;
    void setIsAdmin(bool value);
};

#endif // DOLGOZO_H
