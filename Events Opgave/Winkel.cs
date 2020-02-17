using System;
using System.Collections.Generic;
using System.Text;

namespace Events_Opgave
{
    class Winkel
    {
        public delegate void WinkelverkoopEventHandler(object source, WinkelEventArgs args);
        public event WinkelverkoopEventHandler Winkelverkoop;

        public void VerkoopProduct(Bestelling bestelling)
        {
            Console.WriteLine($"verkoopproduct - {bestelling}");
            OnWinkelverkoop(bestelling);
        }
        protected virtual void OnWinkelverkoop(Bestelling bestelling)
        {
            if (Winkelverkoop!= null)
            {
                Winkelverkoop(this, new WinkelEventArgs { bestelling = bestelling });
            }
        }
    }
}
