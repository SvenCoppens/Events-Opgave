using System;
using System.Collections.Generic;
using System.Text;

namespace Schepen_opdracht
{
    class VrachtSchip : Schip
    {
        public VrachtSchip(int lengte, int breedte, string naam) : base(lengte, breedte, naam)
        {

        }
        public double cargoWaarde { get; set; }
    }
}
