using System;
using System.Collections.Generic;
using System.Text;

namespace Events_2de_poging
{
    class Bestelling
    {
        public ProductType Product { get;}
        public double Prijs { get;}
        public int Aantal { get;}
        public string Adres { get; }
        public Bestelling(ProductType product,double prijs, int aantal,string adres)
        {
            Product = product;
            Prijs = prijs;
            Aantal = aantal;
            Adres = adres;
        }
    }
}
