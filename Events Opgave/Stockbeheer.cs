using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Opgave { 
    // vraag, kan ik hier anders niet gewoon mijn event van stock toevoegen aan de eventhandler en gewoon de bron controleren

    // hij houdt hier het maximum en minimum als variabelen bij.
    // niet vergeten een method toe te voegen om de groothandelaar te laten oproepen dat alles terug op 100 staat.
    class Stockbeheer
    {
        public int stockMinimum { get; set; } = 25;
        private Dictionary<ProductType, int> stock;
        public Stockbeheer()
        {
            stock = new Dictionary<ProductType, int>();
        }
        public void InitStock()
        {
            foreach (ProductType product in Enum.GetValues(typeof(ProductType)))
            {
                stock.Add(product, 100);
            }
        }
        public void onWinkelVerkoop(object source, WinkelEventArgs args)
        {
            // hier een if toevoegen dat hij moet bestellen als er iets onder het minimum gaat, en dan gewoon
            //afdrukken doet hij hier ook bij elke bestelling
            if(source is Winkel)
            {
                stock[args.bestelling.Product] -= args.bestelling.Aantal;
                if(stock[args.bestelling.Product] <= stockMinimum)
                {
                    Dictionary<ProductType, int> benodigdheden = new Dictionary<ProductType, int>();
                    foreach(KeyValuePair<ProductType,int> entry in stock)
                    {
                        if(entry.Value<100)
                        benodigdheden.Add(entry.Key, 100 - entry.Value);
                    }
                    StockNodig(this,new StockArgs(benodigdheden));
                }
            }
        }
        public void Aanvullen(Dictionary<ProductType,int> aantallen)
        {
            foreach(KeyValuePair<ProductType,int> entry in aantallen)
            {
                if (stock.ContainsKey(entry.Key))
                    stock[entry.Key] += entry.Value;
            }
        }
        public void PrintStock()
        {
            foreach(KeyValuePair<ProductType,int> entry in stock)
            {
                Console.WriteLine($"Stock: {entry.Key}, {entry.Value}");
            }
        }
        public delegate void Bevoorrading(object source, StockArgs args);
        public event Bevoorrading StockNodig;
    }
}
