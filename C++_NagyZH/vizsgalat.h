#ifndef VIZSGALAT_H
#define VIZSGALAT_H

#include <map>
#include <list>
#include <iostream>
#include <exception>
#include <condition_variable>
#include <algorithm>
#include <mutex>
using namespace std;

#include "szemely.h"

//#include "megfigyeleredmeny.h"
//#include "megfigyelplacebo.h"

class Vizsgalat
{
    map<unsigned,Szemely> resztvevok;
    map<unsigned,int> ertekeles;
    map<unsigned,bool> placebo;
public:
    Vizsgalat() = default;
    Vizsgalat(const Vizsgalat& orig);
    Vizsgalat& operator = (const Vizsgalat& orig);

    void kiir (bool idMutat=false, ostream& os=cout) const;

    void setEredmeny (unsigned id, const Szemely& sz, int ertek);
    void setPlaceboLista (const list<unsigned>& idlista, bool placebo_e);

    void kiirAdottErtekeles (int ertek) const;

};

#endif // VIZSGALAT_H
