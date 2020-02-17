using System;
using System.Collections.Generic;
using System.Text;

namespace Schepen_opdracht
{
    class RoRoSchip : VrachtSchip
    {
        public RoRoSchip(int lengte, int breedte, string naam) : base(lengte, breedte, naam)
        {

        }
        public int AantalAutos { get; set; }
        public int AantalTrucks { get; set; }
    }
}
