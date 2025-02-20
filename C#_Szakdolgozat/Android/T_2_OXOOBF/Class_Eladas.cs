using System;
using System.Collections.Generic;
using System.Text;

namespace T_2_OXOOBF
{
    public class EladasClass
    {
        public EladasClass(string nev, string telefon, string cim, string raktarid, string cikkszamok, string vasarlasid, string vegosszeg, string vasarlasido)
        {
            Nev = nev;
            Telefon = telefon;
            Cim = cim;
            RaktarID = raktarid;
            Cikkszamok = cikkszamok;
            VasarlasID = vasarlasid;
            Vegosszeg = vegosszeg;
            VasarlasIdo = vasarlasido;
        }

        public string Nev { get; set; }
        public string Telefon { get; set; }
        public string Cim { get; set; }
        public string RaktarID { get; set; }
        public string Cikkszamok { get; set; }
        public string VasarlasID { get; set; }
        public string Vegosszeg { get; set; }
        public string VasarlasIdo { get; set; }

    }
}
