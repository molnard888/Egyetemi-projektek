namespace Raktarkezelo
{
    public class Class_Eladas
    {
        public Class_Eladas(string name, string phone, string address, int storageid, string itemnumbers, string saleid, int sum, string saledatetime)
        {
            Nev = name;
            Telefon = phone;
            Cim = address;
            RaktarID = storageid;
            Azonositok = itemnumbers;
            VasarlasID = saleid;
            Vegosszeg = sum;
            VasarlasIdo = saledatetime;
        }

        public string Nev { get; set; }
        public string Telefon { get; set; }
        public string Cim { get; set; }
        public int RaktarID { get; set; }
        public string Azonositok { get; set; }
        public string VasarlasID { get; set; }
        public int Vegosszeg { get; set; }
        public string VasarlasIdo { get; set; }
    }

}