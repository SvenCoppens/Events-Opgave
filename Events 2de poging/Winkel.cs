using System;
using System.Collections.Generic;
using System.Text;

namespace Events_2de_poging
{
    class Winkel
    {
        public delegate void WinkelVerkoopEventHandler(object source, WinkelEventArgs args);
        public event WinkelVerkoopEventHandler WinkelVerkoop;
        public void ArtikelVerkopen(Bestelling bestelling)
        {
            Console.WriteLine($"Verkocht Artikel: {bestelling}");
            VerkoopEvent(this, new WinkelEventArgs(bestelling));
        }
        public void VerkoopEvent(object source,WinkelEventArgs args)
        {
            if (WinkelVerkoop != null)
            {
                WinkelVerkoop(this, args);
            }
        }
    }
}
