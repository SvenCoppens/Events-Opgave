using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Opgave
{
    class Bestelling
    {
        public Bestelling(ProductType product, double prijs, int aantal, string adres)
        {
            Address = adres;
            Prijs = prijs;
            Aantal = aantal;
            Product = product;
        }
        public string Address { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public ProductType Product { get; set; }
        public override string ToString()
        {
            return $"{Address}: {Product}, {Aantal}: {Prijs*Aantal}";
        }
    }
}
