using System;
using System.Collections.Generic;
using System.Text;

namespace Schepen_opdracht
{
    class CruiseSchip : Schip
    {
        public CruiseSchip(int aantalPassagiers,int lengte, int breedte, string naam) : base(lengte, breedte, naam)
        {
            AantalPassagiers = aantalPassagiers;
        }
        public int AantalPassagiers { get; set; }
    }
}
