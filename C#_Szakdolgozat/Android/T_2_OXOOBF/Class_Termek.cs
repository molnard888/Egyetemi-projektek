using System;
using System.Collections.Generic;
using System.Text;

namespace T_2_OXOOBF
{
    public class Class_Termek
    {
        public Class_Termek(string itemNumber, string storageId, string brand, string type, string category, string price, string quantity, string innerLocRow, string innerLocColumn, string innerLocLevel)
        {
            Cikkszam = itemNumber;
            Raktar = storageId;
            Marka = brand;
            Tipus = type;
            Kategoria = category;
            Ar = price;
            Mennyiseg = quantity;
            Lokacio_Sor = innerLocRow;
            Lokacio_Oszlop = innerLocColumn;
            Lokacio_Szint = innerLocLevel;
        }

        public string Cikkszam { get; set; }
        public string Raktar { get; set; }
        public string Marka { get; set; }
        public string Tipus { get; set; }
        public string Kategoria { get; set; }
        public string Ar { get; set; }
        public string Mennyiseg { get; set; }
        public string Lokacio_Sor { get; set; }
        public string Lokacio_Oszlop { get; set; }
        public string Lokacio_Szint { get; set; }

    }
}

