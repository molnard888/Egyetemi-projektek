#include "dolgozo.h"

#include <iostream>
#include <string.h>

using namespace std;


string Dolgozo::getFnev() const
{
    return Fnev;
}

void Dolgozo::setFnev(const string &value)
{
    Fnev = value;
}

string Dolgozo::getVnev() const
{
    return Vnev;
}

void Dolgozo::setVnev(const string &value)
{
    Vnev = value;
}

string Dolgozo::getKnev() const
{
    return Knev;
}

void Dolgozo::setKnev(const string &value)
{
    Knev = value;
}

string Dolgozo::getCim() const
{
    return cim;
}

void Dolgozo::setCim(const string &value)
{
    cim = value;
}

string Dolgozo::getTelefon() const
{
    return telefon;
}

void Dolgozo::setTelefon(const string &value)
{
    telefon = value;
}

string Dolgozo::getJelszo() const
{
    return jelszo;
}

void Dolgozo::setJelszo(const string &value)
{
    jelszo = value;
}

string Dolgozo::getSzul_dat() const
{
    return szul_dat;
}

void Dolgozo::setSzul_dat(const string &value)
{
    szul_dat = value;
}

bool Dolgozo::getIsBelepve() const
{
    return isBelepve;
}

void Dolgozo::setIsBelepve(bool value)
{
    isBelepve = value;
}

bool Dolgozo::getIsAdmin() const
{
    return isAdmin;
}

void Dolgozo::setIsAdmin(bool value)
{
    isAdmin = value;
}

Dolgozo::Dolgozo()
{
}

Dolgozo::Dolgozo(string &fnev, string &Vnev, string &Knev, string &cim, string &telefon,
                 string &jelszo, string &szul_dat, bool adm, bool belep):

    Fnev(fnev), Vnev(Vnev), Knev(Knev), cim(cim), telefon(telefon),
    jelszo(jelszo), szul_dat(szul_dat), isAdmin(adm), isBelepve(belep)
{
}

Dolgozo::~Dolgozo()
{

}


