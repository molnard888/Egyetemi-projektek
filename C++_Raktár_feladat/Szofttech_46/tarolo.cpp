#include "tarolo.h"
#include "dolgozo.h"
#include "eszkoz.h"
#include "megrendeles.h"
#include "ugyfel.h"
#include <iostream>
#include <string.h>

using namespace std;


Tarolo::Tarolo()
{
    eszkTptr->setId("tools1");
    eszkTptr->setNev("Hidraulikus bontokalapacs");
    eszkTptr->setTipus("Bontokalapacs");
    eszkTptr->setElerheto(true);
    eszkTptr->setNapi_ar(9200);

    (eszkTptr+1)->setId("tools2");
    (eszkTptr+1)->setNev("Lapvibrator");
    (eszkTptr+1)->setTipus("Lapvibrator");
    (eszkTptr+1)->setElerheto(true);
    (eszkTptr+1)->setNapi_ar(10500);

    (eszkTptr+2)->setId("tools3");
    (eszkTptr+2)->setNev("Ipari nedves-szaraz porszivo");
    (eszkTptr+2)->setTipus("Porszivo");
    (eszkTptr+2)->setElerheto(true);
    (eszkTptr+2)->setNapi_ar(7900);

    (eszkTptr+3)->setId("tools4");
    (eszkTptr+3)->setNev("Aszfaltvago");
    (eszkTptr+3)->setTipus("Aszfaltvago");
    (eszkTptr+3)->setElerheto(true);
    (eszkTptr+3)->setNapi_ar(9800);

    (eszkTptr+4)->setId("tools5");
    (eszkTptr+4)->setNev("Betonkevero");
    (eszkTptr+4)->setTipus("Betonkevero");
    (eszkTptr+4)->setElerheto(true);
    (eszkTptr+4)->setNapi_ar(5000);

    (eszkTptr+5)->setId("tools6");
    (eszkTptr+5)->setNev("Asztali gyemantvago");
    (eszkTptr+5)->setTipus("Gyemantvago");
    (eszkTptr+5)->setElerheto(true);
    (eszkTptr+5)->setNapi_ar(8500);

    megrTptr->setEszkId("");
    megrTptr->setStatus("");
}

Tarolo::~Tarolo()
{
}






