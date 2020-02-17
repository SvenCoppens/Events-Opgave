using System;
using System.Collections.Generic;
using System.Text;

namespace Events_2de_poging
{
    class StockbeheerEventArgs
    {
        public Dictionary<ProductType, int> Benodigdheden { get; set; }
        public StockbeheerEventArgs(Dictionary<ProductType,int> benodigdheden)
        {
            Benodigdheden = benodigdheden;
        }
    }
}
