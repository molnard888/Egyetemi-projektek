#ifndef SZEMELY_H
#define SZEMELY_H

#include <string>
#include <iostream>
using namespace std;

class Szemely
{
    string vezeteknev;
    string keresztnev;
    bool nem; // false=ferfi, true=no
    int eletkor;
public:
    Szemely() = default; // hogy mukodjon a map::operator[]
    Szemely(const string& vnev, const string& knev, bool nem, int kor);

    const string& getVezeteknev () const;
    const string& getKeresztnev () const;
    bool ferfi () const;
    bool no () const;
    int getEletkor () const;

    friend istream& operator >> (istream& is, Szemely& sz);
    friend ostream& operator << (ostream& os, const Szemely& sz);
};

#endif // SZEMELY_H
