#ifndef ADAPTER2_H
#define ADAPTER2_H
#include <vector>
#include <thread>
#include "interfesz2.h"
#include "tombolvaso.h"
#include "vizsgalat.h"



using namespace std;

class Adapter2 : public Interfesz2
{
public:
    Adapter2();
    void beolvas(Vizsgalat &v) const override;
};

#endif // ADAPTER2_H
