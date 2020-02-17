using System;
using System.Collections.Generic;
using System.Text;

namespace Schepen_opdracht
{
    class ContainerShip : VrachtSchip
    {
        public ContainerShip(int capaciteit, int lengte, int breedte, string naam) : base(lengte, breedte, naam)
        {
            Capaciteit = capaciteit;
        }
        public int Capaciteit { get; set; }
    }

}
