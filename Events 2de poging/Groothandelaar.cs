using System;
using System.Collections.Generic;
using System.Text;

namespace Events_2de_poging
{
    class Groothandelaar
    {
        public List<Dictionary<ProductType, int>> LijstBestelling { get; set; }
        public void WinkelBevoorrading(object source, StockbeheerEventArgs args)
        {
            if(source is Stockbeheer)
            {
                LijstBestelling.Add(args.Benodigdheden);
                (source as Stockbeheer).StockAanvullen(args.Benodigdheden);
            }
        }

    }
}
