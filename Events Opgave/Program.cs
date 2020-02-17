using System;
using System.Collections.Generic;

namespace Events_Opgave
{
    class Program
    {
        static void Main()
        {
            Winkel w=new Winkel();
            Stockbeheer sb = new Stockbeheer();
            sb.InitStock();
            w.Winkelverkoop += sb.onWinkelVerkoop;
            Sales s = new Sales();
            w.Winkelverkoop += s.OnWinkelverkoop;
            sb.PrintStock();
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 3.99, 35, "Dorpstraat 5,Lievegem"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 25, "Dorpstraat 5,Lievegem"));
            w.VerkoopProduct(new Bestelling(ProductType.Dubbel, 3.99, 35, "Kerkstraat 155,Zele"));
            w.VerkoopProduct(new Bestelling(ProductType.Kriek, 2.99, 55, "Dorpstraat 5,Lievegem"));
            s.ShowRapport();

            sb.PrintStock();
            //// Rapport Test
            //Bestelling best1 = new Bestelling(ProductType.Kriek, 4.5,10,"thuis");
            //List<Bestelling> listje = new List<Bestelling>();
            //listje.Add(best1);
            //listje.Add(best1);
            //s.rapport.Add("test,", listje);

            //s.ShowRapport();
            ////einde Raport test;
        }
    }
}
