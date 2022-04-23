#ifndef TAROLO_H
#define TAROLO_H

#include "eszkoz.h"
#include "megrendeles.h"
#include "dolgozo.h"
#include "admin.h"
#include <iostream>
#include <string.h>

using namespace std;

class Tarolo
{
public:
    Tarolo();
    ~Tarolo();
    unsigned int megrSize=1;
    unsigned int eszkSize=6;
    Megrendeles * megrTptr = new Megrendeles[megrSize];
    Eszkoz * eszkTptr = new Eszkoz[eszkSize];

};

#endif // TAROLO_H
