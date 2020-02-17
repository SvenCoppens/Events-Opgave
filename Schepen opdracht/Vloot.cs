using System;
using System.Collections.Generic;
using System.Text;

namespace Schepen_opdracht
{
    class Vloot
    {
        public Vloot(string naam)
        {
            VerzamelingSchepen = new Dictionary<string, Schip>();
            Naam = naam;
        }
        public string Naam { get; set; }
        private Dictionary<string,Schip> VerzamelingSchepen { get; set; }
        public void voegSchipToe(Schip schip)
        {
            if (!VerzamelingSchepen.ContainsKey(schip.Naam)){
                VerzamelingSchepen.Add(schip.Naam, schip);
                schip.ToebehorendeVloot = this;
            }
            else Console.WriteLine("Dit schip bevindt zich al in de vloot!");
        }
        public void VerwijderSchip(Schip schip)
        {
            if (!VerzamelingSchepen.ContainsValue(schip))
            {
                VerzamelingSchepen.Remove(schip.Naam);
                schip.ToebehorendeVloot = null;
            }
            else Console.WriteLine($"Dit schip bevond zich niet in de vloot!");
        }
        public Schip zoekSchip(string naam)
        {
            if (VerzamelingSchepen.ContainsKey(naam))
            {
                return VerzamelingSchepen[naam];
            }
            else return null;
        }
        public List<Schip> GeefSchepen()
        {
            List<Schip> schepen = new List<Schip>();
            foreach(KeyValuePair<string,Schip> entry in VerzamelingSchepen)
            {
                schepen.Add(entry.Value);
            }
            return schepen;
            // je kan dit ook zo doen:   return new List<Schip>(VerzamelingSchepen.Values);
        }
        public void toonSchepen()
        {
            Console.WriteLine($"Vloot {this.Naam}:");
            foreach(KeyValuePair<string,Schip> entry in VerzamelingSchepen)
            {
                Console.WriteLine(entry.Key);
            }
            Console.WriteLine();
        }
    }
}
