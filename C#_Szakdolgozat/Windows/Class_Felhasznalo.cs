namespace Raktarkezelo
{
    public class Class_Felhasznalo
    {
        public Class_Felhasznalo(string username, int storageid, string password, int permission, string lastname, string firstname, string phone, string email)
        {
            Felhasznalonev = username;
            Raktar = storageid;
            Jelszo = password;
            Jogosultsag = permission;
            Vezeteknev = lastname;
            Keresztnev = firstname;
            Telefon = phone;
            Email = email;
        }

        public string Felhasznalonev { get; set; }
        public int Raktar { get; set; }
        public string Jelszo { get; set; }
        public int Jogosultsag { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}

