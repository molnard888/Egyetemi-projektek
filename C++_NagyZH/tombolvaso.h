#ifndef TOMBOLVASO_H
#define TOMBOLVASO_H

#include <iostream>
#include <string>
#include <vector>
#include <utility>
#include <fstream>
#include <mutex>
using namespace std;

template <class T>
void tombOlvaso (const string& fajl,
                 vector<pair<unsigned,T>>& celvektor)
{
    ifstream in(fajl);
    if (!in.is_open())
    {
        cout << "Hiba! Nem tudom megnyitni: '" << fajl << "'." << endl;
        throw 1;
    }
    unsigned N, id;
    in >> N;
    T elem;
    for (unsigned i=0;i<N;i++)
    {
        in >> id >> elem;
        celvektor.push_back(pair<unsigned,T>(id,elem));
    }
}

#endif // TOMBOLVASO_H
