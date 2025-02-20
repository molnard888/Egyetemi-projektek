using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktarkezelo
{
    public class TermekBasicInfo
    {
        public TermekBasicInfo(string itemNumber, string brand, string type, string category, string price)
        {
            Azonosito = itemNumber;
            Marka = brand;
            Tipus = type;
            Kategoria = category;
            Ar = price;
        }

        public string Azonosito { get; set; }
        public string Marka { get; set; }
        public string Tipus { get; set; }
        public string Kategoria { get; set; }
        public string Ar { get; set; }
    
    }
}
























































