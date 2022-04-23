#include "eszkoz.h"

#include <iostream>
#include <string.h>

using namespace std;

string Eszkoz::getId() const
{
    return id;
}

void Eszkoz::setId(const string &value)
{
    id = value;
}

string Eszkoz::getNev() const
{
    return EszkNev;
}

void Eszkoz::setNev(const string &value)
{
    EszkNev = value;
}

string Eszkoz::getTipus() const
{
    return tipus;
}

void Eszkoz::setTipus(const string &value)
{
    tipus = value;
}

bool Eszkoz::getElerheto() const
{
    return elerheto;
}

void Eszkoz::setElerheto(bool value)
{
    elerheto = value;
}

unsigned int Eszkoz::getNapi_ar() const
{
    return napi_ar;
}

void Eszkoz::setNapi_ar(unsigned int value)
{
    napi_ar = value;
}

Eszkoz::Eszkoz()
{
}


Eszkoz::~Eszkoz()
{
}
