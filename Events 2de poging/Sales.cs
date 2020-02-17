using System;
using System.Collections.Generic;
using System.Text;

namespace Events_2de_poging
{
    class Sales
    {
        public Dictionary<string,List<Bestelling>> AlleBestellingen { get; set; }
        public Sales()
        {
            AlleBestellingen = new Dictionary<string, List<Bestelling>>();
        }
        public void WinkelVerkoopEventHandlerSales(object source, WinkelEventArgs args)
        {
            if(source is Winkel)
            {
                if (AlleBestellingen.ContainsKey(args.Bestelling.Adres))
                {
                    AlleBestellingen[args.Bestelling.Adres].Add(args.Bestelling);
                }
                else
                {
                    List<Bestelling> temp = new List<Bestelling> { args.Bestelling };
                    AlleBestellingen.Add(args.Bestelling.Adres, temp);
                }
            }
        }
        public void RapportAfdrukken()
        {
            Console.WriteLine($"Sales - rapport");
            foreach(KeyValuePair<string,List<Bestelling>> keyEntry in AlleBestellingen)
            {
                Console.WriteLine($"{keyEntry.Key}");
                Dictionary<ProductType, int> totaalAantallen = new Dictionary<ProductType, int>();
                foreach(Bestelling individueleBestelling in keyEntry.Value)
                {
                    if (totaalAantallen.ContainsKey(individueleBestelling.Product))
                    {
                        totaalAantallen[individueleBestelling.Product] += individueleBestelling.Aantal;
                    }
                    else totaalAantallen.Add(individueleBestelling.Product, individueleBestelling.Aantal);
                }
                foreach(KeyValuePair< ProductType, int> valueEntry in totaalAantallen)
                {
                    Console.WriteLine($"   {valueEntry.Key},{valueEntry.Value}");
                }
            }
        }
    }
}
