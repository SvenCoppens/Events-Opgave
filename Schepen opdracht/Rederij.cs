using System;
using System.Collections.Generic;
using System.Text;

namespace Schepen_opdracht
{
    class Rederij
    {
        // misschien bij elk schip een property van Vloot zetten zodat ik zo makkelijker kan werken met ze te verschuiven
        public Rederij(string naam)
        {
            Naam = naam;
            VerzamelingHavens = new HashSet<string>();
            VerzamelingVloten = new Dictionary<string, Vloot>();
        }

        public string Naam { get; set; }
        public Dictionary<string,Vloot> VerzamelingVloten { get; set; }
        public HashSet<string> VerzamelingHavens { get; set; }
        //misschien eens laten overlopen?
        public void toonVloten()
        {
            Console.WriteLine("Verzameling vloten");
            foreach(KeyValuePair<string,Vloot>entry in VerzamelingVloten)
            {
                Console.WriteLine(entry.Key);
            }
        }
        public double cargoWaarde()
        {
            double cargoWaarde = 0;
            //kan ook foreach(Vloot v in VerzamelingVloten.Values)
            foreach(KeyValuePair<string,Vloot> vloot in VerzamelingVloten)
            {
                List<Schip> temp = vloot.Value.GeefSchepen();
                foreach(Schip schip in temp)
                {
                    if(schip is VrachtSchip)
                    {
                        cargoWaarde += (schip as VrachtSchip).cargoWaarde;
                    }
                }
            }
            return cargoWaarde;
        }
        public List<string> geefHavens()
        {
            List<string> havens = new List<string>();
            foreach(string haven in VerzamelingHavens)
                {
                havens.Add(haven);
                }
            havens.Sort();
            return havens;
        }
        public void voegVlootToe(Vloot vloot)
        {
            VerzamelingVloten.Add(vloot.Naam, vloot);
        }
        public void voegHavenToe(string naam)
        {
            VerzamelingHavens.Add(naam);
        }
        //hem eens laten overlopen
        public void plaatsSchipInAndereVloot(string naamSchip, string naamNieuweVloot)
        {
            foreach(KeyValuePair<string,Vloot> entry in VerzamelingVloten)
            {
                if (entry.Value.zoekSchip(naamSchip) != null)
                {
                    Schip temp = entry.Value.zoekSchip(naamSchip);
                    temp.ToebehorendeVloot.VerwijderSchip(entry.Value.zoekSchip(naamSchip));
                    VerzamelingVloten[naamNieuweVloot].voegSchipToe(temp);

                }
            }
        }
    }
}
