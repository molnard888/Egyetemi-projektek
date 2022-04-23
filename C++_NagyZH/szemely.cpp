#include "szemely.h"

Szemely::Szemely(const string &vnev, const string &knev, bool nem, int kor):
    vezeteknev(vnev),
    keresztnev(knev),
    nem(nem),
    eletkor(kor)
{
}

const string &Szemely::getVezeteknev() const
{
    return vezeteknev;
}

const string &Szemely::getKeresztnev() const
{
    return keresztnev;
}

bool Szemely::ferfi() const
{
    return !nem;
}

bool Szemely::no() const
{
    return nem;
}

int Szemely::getEletkor() const
{
    return eletkor;
}

ostream &operator <<(ostream &os, const Szemely &sz)
{
    os << sz.vezeteknev << " ";
    os << sz.keresztnev << " ";
    os << (sz.nem ? 'N' : 'F') << "/";
    os << sz.eletkor;
    os << std::flush;
    return os;
}

istream &operator >>(istream &is, Szemely &sz)
{
    return is >> sz.vezeteknev >> sz.keresztnev >> sz.nem >> sz.eletkor;
}
