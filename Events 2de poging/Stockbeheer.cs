using System;
using System.Collections.Generic;
using System.Text;

namespace Events_2de_poging
{
    class Stockbeheer
    {
        public Dictionary<ProductType, int> Stock { get; set; }
        public int Maximum { get; set; }
        public int Minimum { get; set; }
        public Stockbeheer()
        {
            Stock = new Dictionary<ProductType, int>();
        }
        public void NewStock(int maximum)
        {
            foreach(ProductType product in Enum.GetValues(typeof(ProductType)))
            {
                if (Stock.ContainsKey(product))
                {
                    Stock[product] = maximum;
                }
                else Stock.Add(product, maximum);
            }
        }
        public void WinkelVerkoopEventHandlerStock(object source, WinkelEventArgs args)
        {
            Stock[args.Bestelling.Product] -= args.Bestelling.Aantal;
            if (Stock[args.Bestelling.Product] <= 25)
            {
                Dictionary<ProductType, int> AantallenNodig = new Dictionary<ProductType, int>();
                foreach(KeyValuePair<ProductType,int> Entry in Stock)
                {
                    AantallenNodig.Add(Entry.Key, Maximum - Entry.Value);
                }
                Benodigdheden(this, new StockbeheerEventArgs(AantallenNodig));
            }
        }
        public void StockAanvullen(Dictionary<ProductType,int> Aantallen)
        {
            foreach(KeyValuePair<ProductType,int>entry in Aantallen) 
            {
                Stock[entry.Key] += entry.Value;
            } 
        }
        public delegate void StockTekort(object source, StockbeheerEventArgs args);
        public event StockTekort BestellingBijGrootHandelaar;
        public void Benodigdheden(object source, StockbeheerEventArgs args)
        {
            BestellingBijGrootHandelaar(this, args);
        }
    }
}
