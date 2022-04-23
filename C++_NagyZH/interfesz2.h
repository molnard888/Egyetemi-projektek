#ifndef INTERFESZ2_H
#define INTERFESZ2_H

#include "vizsgalat.h"

// 2-es opcio:
// a beolvaso fuggveny kapja meg a Vizsgalat-ot, referenciakent
class Interfesz2
{
public:
    Interfesz2() = default;
    virtual ~Interfesz2() = default;

    virtual void beolvas (Vizsgalat& v) const = 0;
};

#endif // INTERFESZ2_H
