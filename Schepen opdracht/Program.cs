using System;

namespace Schepen_opdracht
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Schip s1 = new ContainerShip(10000, 120, 25, "Container 1");
            Schip s2 = new CruiseSchip(1500, 200, 35, "Cruiser 1");
            RoRoSchip s3 = new RoRoSchip(180, 22, "RoRo 1");
            VrachtSchip s4 = new ContainerShip(150000, 250, 40, "Container 3");
            s4.cargoWaarde = 100000;
            s3.cargoWaarde = 120000;
            ((VrachtSchip)s1).cargoWaarde = 75000;

            Schip s5 = new ContainerShip(10000, 120, 25, "Container x1");
            Schip s6 = new CruiseSchip(1500, 200, 35, "Cruiser x1");
            RoRoSchip s7 = new RoRoSchip(180, 22, "RoRo x1");
            VrachtSchip s8 = new ContainerShip(150000, 250, 40, "Container x3");
            s7.cargoWaarde = 10000;
            s8.cargoWaarde = 150000;
            ((VrachtSchip)s5).cargoWaarde = 85000;

            Vloot v1 = new Vloot("Noordzee vloot");
            v1.voegSchipToe(s1);
            v1.voegSchipToe(s2);
            v1.voegSchipToe(s3);
            v1.voegSchipToe(s4);

            v1.voegSchipToe(s4);
            v1.toonSchepen();

            Vloot v2 = new Vloot("Atlantische vloot");
            v2.voegSchipToe(s5);
            v2.voegSchipToe(s6);
            v2.voegSchipToe(s7);
            v2.voegSchipToe(s8);
            v2.toonSchepen();

            Schip x = v1.zoekSchip("RoRo 1");
            Console.WriteLine($"zoek :{x}");

            Rederij r = new Rederij("MyCompany");
            r.voegVlootToe(v1);
            r.voegVlootToe(v2);
            double w = r.cargoWaarde();
            Console.WriteLine(w);
            r.voegHavenToe("Gent");
            r.voegHavenToe("Antwerpen");
            r.voegHavenToe("Hamburg");
            r.voegHavenToe("Gent");
            foreach (string h in r.geefHavens())
            {
                Console.WriteLine($"Haven = {h}");
            }

            r.plaatsSchipInAndereVloot("RoRo 1", "Atlantische vloot");
            Console.WriteLine($"{s3.ToebehorendeVloot.Naam}");
            foreach (Schip ship in v1.GeefSchepen())
            {
                Console.WriteLine(ship.Naam);
            }
            r.toonVloten();
        }
    }
}
