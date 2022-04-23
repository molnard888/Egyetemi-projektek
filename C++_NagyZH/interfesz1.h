#ifndef INTERFESZ1_H
#define INTERFESZ1_H

#include "vizsgalat.h"

// 1-es opcio:
// konstruktorban kapja meg a Vizsgalat-ot, pointerkent
class Interfesz1
{
protected:
    Vizsgalat* vptr;
public:
    Interfesz1(Vizsgalat* vptr): vptr(vptr) {}
    virtual ~Interfesz1() = default;

    virtual void beolvas () const = 0;
};

#endif // INTERFESZ1_H
