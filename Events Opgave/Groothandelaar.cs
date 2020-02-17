using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Opgave
{
    // deze heeft een  list van dictionaries van producttypes en ints (elke bevoorrading eigenlijk)
    // ook een method om alles te overlopen (elke bevoorrading die er al gebeurd is dus.)
    //dan ook een method om u laatste te tonen.
    class Groothandelaar
    {
        public List<Dictionary<ProductType, int>> Bevoorradingen {get;set;}
        public void OnTekort(object source, StockArgs args)
        {
            if (source is Stockbeheer)
            {
                Bevoorradingen.Add(args.Benodigdheden);
                Levering(source as Stockbeheer, args.Benodigdheden);
            }
        }
        public void Levering(Stockbeheer stock, Dictionary<ProductType,int> aantallen)
        {
            stock.Aanvullen(aantallen);
        }

    }
}
