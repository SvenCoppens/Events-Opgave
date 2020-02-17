using System;

namespace Events_2de_poging
{
    class Program
    {
        static void Main()
        {
            Winkel colruyt = new Winkel();
            Sales verkoop = new Sales();
            Stockbeheer frigo = new Stockbeheer();
            Groothandelaar afzetters = new Groothandelaar();
            colruyt.WinkelVerkoop += verkoop.WinkelVerkoopEventHandlerSales;
            colruyt.WinkelVerkoop += frigo.WinkelVerkoopEventHandlerStock;
            frigo.BestellingBijGrootHandelaar += afzetters.WinkelBevoorrading;
            //eerst nog wat print methodes schrijven om te kijken of alles wel correct verloopt.
            // ook zorgen dat mijn Bestelling datatype correct afdrukt.

        }
    }
}
