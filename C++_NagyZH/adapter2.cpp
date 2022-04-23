#include "adapter2.h"

Adapter2::Adapter2()
{

}

void Adapter2::beolvas(Vizsgalat &v) const
{
    vector<pair<unsigned,Szemely>> szem;
    vector<pair<unsigned,int>> ert;
    vector<pair<unsigned,bool>> plac;
    thread t1(tombOlvaso,"resztvevok-1.txt",szem);
    thread t2(tombOlvaso,"resztvevok-2.txt",szem);
    thread t3(tombOlvaso,"ertekelesek-1.txt",szem);
    thread t4(tombOlvaso,"ertekelesek-2.txt",szem);
    thread t5(tombOlvaso,"ertekelesek-3.txt",szem);
    thread t6(tombOlvaso,"placebok-1.txt",szem);
    thread t7(tombOlvaso,"placebok-2.txt",szem);
    t1.join;
    t2.join;
    t3.join;
    t4.join;
    t5.join;
    t6.join;
    t7.join;





}
