using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktarkezelo
{
    public class Class_Naplo
    {
        public Class_Naplo(int logId, int storageId, string username, string datetime, string process, string details)
        {
            NaploID = logId;
            Raktar = storageId;
            Felhasznalonev = username;
            Idopont = datetime;
            Muvelet = process;
            Reszletek = details;
        }

        public int NaploID { get; set; }
        public int Raktar { get; set; }
        public string Felhasznalonev { get; set; }
        public string Idopont { get; set; }
        public string Muvelet { get; set; }
        public string Reszletek { get; set; }

    }
}
