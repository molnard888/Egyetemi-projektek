#ifndef INTERFESZ3_H
#define INTERFESZ3_H

#include "vizsgalat.h"

// 3-es opcio:
// a beolvaso egy uj, dinamikusan foglalt Vizsgalat-ot ad vissza
class Interfesz3
{
public:
    Interfesz3() = default;
    virtual ~Interfesz3() = default;

    virtual Vizsgalat* beolvas () const = 0;
};
#endif // INTERFESZ3_H
