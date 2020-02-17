using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Opgave
{
    class StockArgs
    {
        public StockArgs(Dictionary<ProductType,int> benodigdheden)
        {
            Benodigdheden = benodigdheden;
        }
        public Dictionary<ProductType, int> Benodigdheden;
    }
}
