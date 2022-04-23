#ifndef ESZKOZOK_H
#define ESZKOZOK_H

#include <iostream>
#include <string.h>

using namespace std;



class Eszkoz
{
    string id, EszkNev, tipus;
    bool elerheto;
    unsigned int napi_ar;
public:

    Eszkoz();
    ~Eszkoz();
    string getId() const;
    void setId(const string &value);
    string getNev() const;
    void setNev(const string &value);
    string getTipus() const;
    void setTipus(const string &value);
    bool getElerheto() const;
    void setElerheto(bool value);
    unsigned int getNapi_ar() const;
    void setNapi_ar(unsigned int value);
};

#endif // ESZKOZOK_H
