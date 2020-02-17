using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Opgave
{
    class Sales
    {
        //private maken
        public Dictionary<string, List<Bestelling>> rapport;
        public Sales()
        {
            rapport = new Dictionary<string, List<Bestelling>>();
        }
        public void OnWinkelverkoop(object source, WinkelEventArgs args)
        {
            if(source is Winkel)
            {
                if (rapport.ContainsKey(args.bestelling.Address))
                {
                    rapport[args.bestelling.Address].Add(args.bestelling);
                }
                else
                {
                    List<Bestelling> bestelling = new List<Bestelling>();
                    bestelling.Add(args.bestelling);
                    rapport.Add(args.bestelling.Address, bestelling);
                }
            }
        }
        public void ShowRapport()
        {

            Console.WriteLine("Sales - rapport");
            foreach(KeyValuePair<string,List<Bestelling>> entry in rapport)
            {
                Console.WriteLine(entry.Key);
                Dictionary<ProductType, int> aantallen = new Dictionary<ProductType, int>();
                foreach (Bestelling bestelling in entry.Value)
                {
                    if (aantallen.ContainsKey(bestelling.Product))
                    {
                        aantallen[bestelling.Product] += bestelling.Aantal;
                    }
                    else
                    {
                        aantallen.Add(bestelling.Product, bestelling.Aantal);
                    }
                }
                foreach (KeyValuePair <ProductType, int> verkochteProducten in aantallen)
                {
                    Console.WriteLine($"     {verkochteProducten.Key},{verkochteProducten.Value}");
                }
                    
            }
        }
    }
}
