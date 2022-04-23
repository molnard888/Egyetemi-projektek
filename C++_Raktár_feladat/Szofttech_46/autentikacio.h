#ifndef AUTENTIKACIO_H
#define AUTENTIKACIO_H

#include <iostream>
#include <string.h>
#include "dolgozo.h"
#include "admin.h"

using namespace std;

class Autentikacio
{
public:
    unsigned  int dolgSize=1;
    unsigned  int admSize=1;
    Dolgozo * dolgTptr = new Dolgozo[dolgSize];
    admin * admTptr = new admin[admSize];
    string nev, jelszo;
    string login();
    Autentikacio();
    ~Autentikacio();

};

#endif // AUTENTIKACIO_H
