#include "megrendeles.h"

#include <iostream>
#include <string.h>

using namespace std;

string Megrendeles::getEszkId() const
{
    return eszkId;
}

void Megrendeles::setEszkId(const string &value)
{
    eszkId += "; "+value;
}

string Megrendeles::getStatus() const
{
    return status;
}

void Megrendeles::setStatus(const string &value)
{
    status = value;
}

string Megrendeles::getVnev() const
{
    return Vnev;
}

void Megrendeles::setVnev(const string &value)
{
    Vnev = value;
}

string Megrendeles::getKnev() const
{
    return Knev;
}

void Megrendeles::setKnev(const string &value)
{
    Knev = value;
}

string Megrendeles::getSzall_cim() const
{
    return szall_cim;
}

void Megrendeles::setSzall_cim(const string &value)
{
    szall_cim = value;
}

string Megrendeles::getSzaml_cim() const
{
    return szaml_cim;
}

void Megrendeles::setSzaml_cim(const string &value)
{
    szaml_cim = value;
}

string Megrendeles::getTelefon() const
{
    return telefon;
}

void Megrendeles::setTelefon(const string &value)
{
    telefon = value;
}

string Megrendeles::getEmail() const
{
    return email;
}

void Megrendeles::setEmail(const string &value)
{
    email = value;
}

string Megrendeles::getAdoszam() const
{
    return adoszam;
}

void Megrendeles::setAdoszam(const string &value)
{
    adoszam = value;
}

string Megrendeles::getRendId() const
{
    return rendId;
}

void Megrendeles::setRendId(const string &value)
{
    rendId = value;
}

string Megrendeles::getEszkNev() const
{
    return EszkNev;
}

void Megrendeles::setEszkNev(const string &value)
{
    EszkNev += "[" + value + "] ";
}

string Megrendeles::getTipus() const
{
    return tipus;
}

void Megrendeles::setTipus(const string &value)
{
    tipus = value;
}

unsigned int Megrendeles::getVegosszeg() const
{
    return vegosszeg;
}

void Megrendeles::setVegosszeg(unsigned int value)
{
    vegosszeg += value;
}

Megrendeles::Megrendeles()
{

}

Megrendeles::~Megrendeles()
{

}
