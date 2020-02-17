using System;
using System.Collections.Generic;
using System.Text;

namespace Schepen_opdracht
{
    class Schip
    {
        public Schip(int lengte, int breedte, string naam)
        {
            Lengte = lengte;
            Breedte = breedte;
            Naam = naam;
        }
        public Vloot ToebehorendeVloot { get; set; }
        public int Breedte { get; set; }
        public string Naam { get; set; }
        public int Lengte { get; set; }
        public override int GetHashCode()
        {
            return Naam.GetHashCode()^Lengte.GetHashCode()^Breedte.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Schip)
            {
                 Schip T = obj as Schip;
                return (Naam == T.Naam && Breedte == T.Breedte && Lengte == T.Lengte); 
            }
            else return false;
        }
        public override string ToString()
        {
            return($"{this.GetType().Name}: {Naam}, b:{Breedte}, m:{Lengte}");
        }
    }
}
