namespace Raktarkezelo
{
    public class Class_Termek
    {
        public Class_Termek(string itemNumber, int storageId, string brand, string type, string category, int price, int quantity, int innerLocRow, int innerLocColumn, int innerLocLevel)
        {
            Azonosito = itemNumber;
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

        public string Azonosito { get; set; }
        public int Raktar { get; set; }
        public string Marka { get; set; }
        public string Tipus { get; set; }
        public string Kategoria { get; set; }
        public int Ar { get; set; }
        public int Mennyiseg { get; set; }
        public int Lokacio_Sor { get; set; }
        public int Lokacio_Oszlop { get; set; }
        public int Lokacio_Szint { get; set; }

    }
}






