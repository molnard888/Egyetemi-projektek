using System;
using System.Collections.Generic;
using System.Text;

namespace T_2_OXOOBF
{
    public class Class_Felhasznalo
    {
        public Class_Felhasznalo(string username, string storageid, string jelszo, string jogosultsag, string vezeteknev, string keresztnev, string telefon, string email)
        {
            Felhasznalonev = username;
            Raktar = storageid;
            Jelszo = jelszo;
            Jogosultsag = jogosultsag;
            Vezeteknev = vezeteknev;
            Keresztnev = keresztnev;
            Telefon = telefon;
            Email = email;
        }

        public string Felhasznalonev { get; set; }
        public string Raktar { get; set; }
        public string Jelszo { get; set; }
        public string Jogosultsag { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
