#include <iostream>
#include <fstream>
#include <vector>
#include <future>
#include <thread>
#include <chrono>
using namespace std;

//#include "adapter1.h"
//#include "adapter2.h"
//#include "adapter3.h"
#include "generator.h"
#include "vizsgalat.h"

int main()
{
    cout << "main() eleje!\n" << endl;
    cout << "Fajlok generalasa ... " << endl;
    Generator::fajlokatGeneral();
    cout << "KESZ!\n " << endl;

//    {
//        cout << "Vizsgalat: setEredmeny, setPlaceboLista" << " teszt\n" << endl;
//        Vizsgalat v;
//        v.setEredmeny(11,Szemely("Toth","Akos",false,30),7);
//        v.setEredmeny(22,Szemely("Kovacs","Barbara",true,27),5);
//        v.setEredmeny(33,Szemely("Balogh","Csaba",false,35),9);
//        v.setEredmeny(44,Szemely("Vastagh","Dora",true,32),4);
//        list<unsigned> p1={11,44}, p2={22,33};
//        v.setPlaceboLista(p1,true);
//        v.setPlaceboLista(p2,false);
//        v.kiir();
//        cout << "\nTeszt vege.\n" << endl;
//        cout << "Vizsgalat: kiirAdottErtekeles" << " teszt\n" << endl;
//        for (int i=1;i<=10;i++)
//        {
//            cout << "Ertekeles: " << i << ": ";
//            v.kiirAdottErtekeles(i);
//        }
//        cout << "\nTeszt vege.\n" << endl;
//    }

//    {
//        cout << "Adapter" << " teszt\n" << endl;
//        Vizsgalat v;
//        //{
//        //    cout << "Interfesz1 hasznalata\n" << endl;
//        //    Interfesz1* adapter = new Adapter1(&v);
//        //    adapter->beolvas();
//        //    delete adapter;
//        //}
//        //{
//        //    cout << "Interfesz2 hasznalata\n" << endl;
//        //    Interfesz2* adapter = new Adapter2;
//        //    adapter->beolvas(v);
//        //    delete adapter;
//        //}
//        //{
//        //    cout << "Interfesz3 hasznalata\n" << endl;
//        //    Interfesz3* adapter = new Adapter3;
//        //    const Vizsgalat* vptr = adapter->beolvas();
//        //    v = *vptr;
//        //    delete vptr;
//        //    delete adapter;
//        //}
//        cout << "Kivonat a beolvasott adatokbol: " << endl;
//        for (int i=1;i<=10;i++)
//        {
//            cout << "Ertekeles: " << i << ": ";
//            v.kiirAdottErtekeles(i);
//        }
//        {
//            cout << "\nVizsgalat teljes kiirasa fajlba ... " << endl;
//            ofstream teszt("beolvasott.txt");
//            v.kiir(true,teszt);
//            cout << "KESZ!" << endl;
//        }
//        cout << "\nTeszt vege.\n" << endl;

//        cout << "Vizsgalat: lekerdezes" << " teszt\n" << endl;
//        try {
//            cout << v.lekerdezes(true,18,30,1) << endl;
//            cout << v.lekerdezes(true,24,35,2) << endl;
//            cout << v.lekerdezes(true,0,40,3) << endl;
//            cout << v.lekerdezes(false,38,0,1) << endl;
//            cout << v.lekerdezes(false,19,19,2) << endl;
//            cout << v.lekerdezes(false,0,0,3) << endl;
//            cout << v.lekerdezes(false,3,12,3) << endl;
//        }
//        catch (exception& exc)
//        {
//            cout << exc.what() << endl;
//        }
//        cout << "\nTeszt vege.\n" << endl;
//    }

//    {
//        cout << "Vizsgalat: MegfigyelEredmeny, MegfigyelPlacebo" << " teszt\n" << endl;
//        Vizsgalat v;
//        promise<unsigned> p_id;
//        future<unsigned> f_id = p_id.get_future();
//        MegfigyelEredmeny megfEredm(&p_id,"Balogh","Csaba");
//        v.regisztral(&megfEredm);
//        thread t([&](){
//            v.setEredmeny(1111,Szemely("Toth","Akos",false,30),7);
//            v.setEredmeny(2222,Szemely("Kovacs","Barbara",true,27),5);
//            v.setEredmeny(3333,Szemely("Balogh","Csaba",false,35),9);
//            v.setEredmeny(4444,Szemely("Vastagh","Dora",true,32),4);
//            this_thread::sleep_for(chrono::milliseconds(200));
//            cout << "Mellekszal vege." << endl;
//        });
//        cout << "Megfigyelve: Balogh Csaba, id=" << flush;
//        unsigned id = f_id.get();
//        cout << id << endl;
//        MegfigyelPlacebo megfPlac(id);
//        v.regisztral(&megfPlac);
//        list<unsigned> p1={1111,4444}, p2={2222,3333};
//        v.setPlaceboLista(p1,true);
//        v.setPlaceboLista(p2,false);
//        t.join();
//        cout << "\nTeszt vege.\n" << endl;
//    }

//    {
//        cout << "Vizsgalat: getResztvevoSzam, setPiros, setZold" << " teszt\n" << endl;
//        using namespace chrono;
//        Vizsgalat v;
//        v.setEredmeny(11,Szemely("Kovacs","Antal",false,30),7);
//        v.setEredmeny(22,Szemely("Toth","Bianka",true,27),6);
//        v.setEredmeny(33,Szemely("Nagy","Csaba",false,30),5);
//        v.setEredmeny(44,Szemely("Kiss","Dora",true,32),5);
//        map<int,unsigned> rszam = v.getResztvevoSzam();
//        for (auto p : rszam)
//            cout << p.first << " ev -> " << p.second << " fo\n";
//        cout << "Szuneteltetes tesztelese:" << endl;
//        mutex mtx;
//        auto idomeres = [&](){
//            auto beg = system_clock::now();
//            v.getResztvevoSzam();
//            double s = duration<double>(system_clock::now()-beg).count();
//            lock_guard<mutex> g(mtx);
//            cout << "Lefutas: " << (s>0.1 ? "KESLELTETETT" : "AZONNALI") << endl;
//        };
//        list<thread> tl;
//        tl.push_back(thread(idomeres)); // Lefutas: AZONNALI
//        this_thread::sleep_for(milliseconds(200));
//        cout << "setPiros()" << endl;
//        v.setPiros();
//        tl.push_back(thread(idomeres));
//        this_thread::sleep_for(milliseconds(200));
//        cout << "setZold()" << endl;
//        v.setZold(); // Lefutas: KESLELTETETT
//        tl.push_back(thread(idomeres)); // Lefutas: AZONNALI
//        for (auto& t : tl)
//            t.join();
//        cout << "\nTeszt vege.\n" << endl;
//    }

    cout << "main() vege!" << endl;

    return 0;
}
