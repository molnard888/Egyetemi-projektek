using System;
using System.Collections.Generic;
using System.Text;

namespace T_2_OXOOBF
{
    public class Class_Naplo
    {
        public Class_Naplo(string logId, string storageId, string username, string datetime, string process, string details)
        {
            NaploID = logId;
            Raktar = storageId;
            Felhasznalonev = username;
            Idopont = datetime;
            Muvelet = process;
            Reszletek = details;
        }

        public string NaploID { get; set; }
        public string Raktar { get; set; }
        public string Felhasznalonev { get; set; }
        public string Idopont { get; set; }
        public string Muvelet { get; set; }
        public string Reszletek { get; set; }

    }

}

