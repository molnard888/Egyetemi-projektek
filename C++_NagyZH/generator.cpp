#include "generator.h"

#include "szemely.h"

#include <fstream>
#include <map>
#include <list>
#include <vector>
#include <string>
#include <random>
using namespace std;

void Generator::fajlokatGeneral()
{
    static const int N = 1000; // resztvevok szama
    static const int ID_START = 2000; // kezdo ID
    static const int ID_PLUS_MAX = 4; // max szomszedos ID-k kozti kulonbseg
    static const int F_PL = 2; // placebo fajlok szama
    static const int F_RES = 3; // ertekeles fajlok szama
    static const int F_RV = 2; // resztvevo fajlok szama
    static const int EMIN = 1; // ertekeles min
    static const int EMAX = 10; // ertekeles max
    static const int KORMIN = 18; // eletkor min
    static const int KORMAX = 49; // eletkor max
    static const vector<string> vnevek =
        {"Toth","Horvath","Svab","Kovacs","Lovasz","Pasztor",
         "Nemes","Kiraly","Nagy","Kiss","Kis","Papp","Pap","Revesz"
         "Szabo","Pinter","Kadar","Bognar","Bako","Meszaros",
         "Csapo","Eross","Vekony","Barany","Farkas","Molnar",
         "Nemeth","Foldi","Baro","Herczeg","Falus","Csaszar",
         "Budai","Voros","Fenyo","Szekely","Szerb","Szilagyi"};
    static const vector<string> knevek_f =
        {"Almos","Akos","Bela","Bence","Csaba","Cecil","Denes","Daniel",
         "Elemer","Endre","Ferenc","Fulop","Frigyes","Geza","Gergely","Gyorgy",
         "Gyula","Hugo","Imre","Istvan","Ivan","Janos","Jeno","Karoly","Krisztian",
         "Lajos","Laszlo","Miklos","Mihaly","Mate","Matyas","Marton","Norbert",
         "Otto","Peter","Pal","Robert","Rajmund","Sandor","Soma","Tamas","Tibor","Ubul",
         "Viktor","Vendel","Vilmos","Zeteny","Zsolt"};
    static const vector<string> knevek_n =
        {"Anna","Aniko","Bianka","Cecilia","Diana","Dalma","Eniko",
         "Eszter","Fanni","Gizella","Gyongyver","Hedvig","Hanna","Imola",
         "Ilona","Ildiko","Jazmin","Jolan","Judit","Krisztina","Kata","Lili",
         "Luca","Maria","Monika","Nora","Nikoletta","Orsolya","Piroska",
         "Rita","Renata","Ramona","Terez","Tunde","Ursula","Viktoria",
         "Vanda","Zita","Zsofia","Zsuzsanna"};
    mt19937 rnd;
    rnd.seed(12345678);
    static auto ertekel = [&](bool placebo, bool no_e, int kor){
        double korarany = (static_cast<double>(kor)-KORMIN)/(KORMAX-KORMIN);
        double mean;
        double stddev;
        if (placebo)
        {
            mean = 5.0;
            stddev = 2.0;
        }
        else
        {
            mean = (no_e ? 6.2 : 7.6) - korarany * 1.6;
            stddev = (no_e ? 1.7 : 3.1) + korarany * 2.2;
        }
        normal_distribution<double> d(mean,stddev);
        while (1)
        {
            int e = d(rnd);
            if (EMIN <= e && e <= EMAX)
                return e;
        }
    };
    vector<unsigned> ids;
    auto shuffle = [&](){
        const int meret = ids.size();
        for (int i=0;i<meret;i++)
        {
            uniform_int_distribution<int> d_sort(i,meret-1);
            int j = d_sort(rnd);
            unsigned csere = ids[i];
            ids[i] = ids[j];
            ids[j] = csere;
        }
    };
    map<unsigned,bool> placebo;
    map<unsigned,int> fajlnev;
    {
        uniform_int_distribution<int> d_idplus(1,ID_PLUS_MAX);
        int currentid = ID_START;
        for (int i=0;i<N;i++)
        {
            currentid += d_idplus(rnd);
            ids.push_back(currentid);
        }
        shuffle();
        for (int i=0;i<N/2;i++)
            placebo[ids[i]] = true;
        for (int i=N/2;i<N;i++)
            placebo[ids[i]] = false;
        shuffle();
        for (int f=0;f<F_PL;f++)
        {
            int a = f*N/F_PL;
            int b = (f+1)*N/F_PL;
            for (int i=a;i<b;i++)
                fajlnev[ids[i]] = f;
        }
        shuffle();
        for (int f=0;f<F_PL;f++)
        {
            int counter = 0;
            for (int i=0;i<N;i++)
            {
                const unsigned id = ids[i];
                if (fajlnev[id] == f)
                    counter++;
            }
            ofstream out(string("placebok-") + to_string(f+1) + ".txt");
            out << counter << "\n";
            for (int i=0;i<N;i++)
            {
                const unsigned id = ids[i];
                if (fajlnev[id] == f)
                    out << id << " " << placebo[id] << "\n";
            }
        }
        shuffle();
    }
    map<unsigned,Szemely> resztvevok;
    {
        uniform_int_distribution<int> d_vnevek(0,vnevek.size()-1);
        uniform_int_distribution<int> d_fn(0,1);
        uniform_int_distribution<int> d_f(0,knevek_f.size()-1);
        uniform_int_distribution<int> d_n(0,knevek_n.size()-1);
        uniform_int_distribution<int> d_kor(KORMIN,KORMAX);
        for (unsigned id : ids)
        {
            const string& vnev = vnevek[d_vnevek(rnd)];
            const bool no_e = d_fn(rnd);
            const string& knev = no_e ? knevek_n[d_n(rnd)] : knevek_f[d_f(rnd)];
            const int eletkor = d_kor(rnd);
            resztvevok[id] = Szemely(vnev,knev,no_e,eletkor);
        }
        shuffle();
        for (int f=0;f<F_RV;f++)
        {
            int a = f*N/F_RV;
            int b = (f+1)*N/F_RV;
            ofstream out(string("resztvevok-") + to_string(f+1) + ".txt");
            out << b-a << "\n";
            for (int i=a;i<b;i++)
            {
                const unsigned id = ids[i];
                const Szemely& r = resztvevok[id];
                out << id << " " << r.getVezeteknev() << " ";
                out << r.getKeresztnev() << " ";
                out << r.no() << " " << r.getEletkor() << "\n";
            }
        }
        shuffle();
    }
    map<unsigned,int> ertekeles;
    {
        shuffle();
        for (unsigned id : ids)
        {
            const Szemely& sz = resztvevok[id];
            ertekeles[id] = ertekel(placebo[id],sz.no(),sz.getEletkor());
        }
        shuffle();
        for (int f=0;f<F_RES;f++)
        {
            int a = f*N/F_RES;
            int b = (f+1)*N/F_RES;
            ofstream out(string("ertekelesek-") + to_string(f+1) + ".txt");
            out << b-a << "\n";
            for (int i=a;i<b;i++)
                out << ids[i] << " " << ertekeles[ids[i]] << "\n";
        }
        shuffle();
    }
}
