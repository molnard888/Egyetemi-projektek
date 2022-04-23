#include "vizsgalat.h"

Vizsgalat::Vizsgalat(const Vizsgalat &orig):
    resztvevok(orig.resztvevok),
    ertekeles(orig.ertekeles),
    placebo(orig.placebo)
{
}

Vizsgalat &Vizsgalat::operator =(const Vizsgalat &orig)
{
    resztvevok = orig.resztvevok;
    ertekeles = orig.ertekeles;
    placebo = orig.placebo;
    return *this;
}

void Vizsgalat::kiir(bool idMutat, ostream &os) const
{
    for (const auto& p : resztvevok)
    {
        unsigned id = p.first;
        if (idMutat)
            os << id << ": ";
        os << p.second;
        os << ", erekeles: " << ertekeles.at(id);
        os << ", placebo? " << (placebo.at(id) ? "IGEN" : "NEM") << "\n";
    }
    os << flush;
}

void Vizsgalat::setEredmeny(unsigned id, const Szemely &sz, int ertek)
{
     resztvevok.insert(std::pair<unsigned,Szemely>(id,sz));
     ertekeles.insert(std::pair<unsigned,int>(id,ertek));
}

void Vizsgalat::setPlaceboLista(const list<unsigned> &idlista, bool placebo_e)
{
    for(auto l : idlista){
        placebo.insert(pair<unsigned,bool>(l,placebo_e));
    }
}

void Vizsgalat::kiirAdottErtekeles(int ertek) const
{
    unsigned int countH=0;
    unsigned int countP=0;
    for(auto m : ertekeles){
        for(auto iter : placebo){
            if(iter.first==m.first){
                if(iter.second)
                        countP++;
                if(!iter.second)
                        countH++;
            }
        }
    }
    cout<<"Placebo: "<<countP<<" "<<"Hatoanyag:"<<countH<<endl;
}
