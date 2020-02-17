using System;
using System.Collections.Generic;
using System.Text;

namespace Events_2de_poging
{
    class WinkelEventArgs
    {
        public WinkelEventArgs(Bestelling bestelling)
        {
            Bestelling = bestelling;
        }
        public Bestelling Bestelling { get; set; }
    }
}
