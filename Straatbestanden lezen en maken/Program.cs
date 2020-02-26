using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace Straatbestanden_lezen_en_maken
{
    class Program
    {
        static void Main()
        {
            #region ZipExtraction
            Console.WriteLine("Extract or not? Y/N?");
            if(Console.ReadLine()=="Y")
            Unzipper.Unzip();
            #endregion
            List<string> provincieIDs = DataExtraction.ProvincieExtraction();

            Dictionary<string, List<string>> provincieGemeenteLink = new Dictionary<string, List<string>>();
            Dictionary<string, string> provincieNamen = new Dictionary<string, string>();
            Dictionary<string, string> gemeenteNamen = new Dictionary<string, string>();
            //dit stuk kan ik waarschijnlijk ergens anders schrijven zodat ik de ProvincieID list kan weggooien.
            foreach(string id in provincieIDs)
            {
                provincieGemeenteLink.Add(id, new List<string>());
                provincieNamen.Add(id, "");
            }

            using (StreamReader sr = File.OpenText(@"C:\Users\coppe\Documents\School\Programmeren 3\Opdrachten lezen en schrijven\extracted\ProvincieInfo.csv"))
            {
                string line;
                sr.ReadLine();
                while((line = sr.ReadLine() )!= null)
                {
                    string[] splitLine = line.Split(";");
                    if (splitLine[2] == "nl")
                    {
                        //controle op of het wel een van de gemeentes is die ik wil beschrijven.
                        if (provincieGemeenteLink.ContainsKey(splitLine[1]))
                        {
                        // hier voeg ik de gemeenteID's toe aan de de lijst gekoppeld aan de provincieIDs
                            provincieGemeenteLink[splitLine[1]].Add(splitLine[0]);
                            //hier link ik de naam van de provincie aan de ID.
                            if (provincieNamen[splitLine[1]] == "")
                            {
                                provincieNamen[splitLine[1]] = splitLine[3];
                            }
                            gemeenteNamen.Add(splitLine[0], "");
                        }

                    }
                }
            }

            using (StreamReader sr = File.OpenText(@"C:\Users\coppe\Documents\School\Programmeren 3\Opdrachten lezen en schrijven\extracted\WRGemeentenaam.csv"))
            {
                
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitLine = line.Split(";");
                    if (splitLine[2] == "nl")
                    {
                        gemeenteNamen[splitLine[1]] = splitLine[3];
                    }
                }

            }
            //stratenbullshit, hooray \o/
            Dictionary<string, string> StratenVerzameling = new Dictionary<string, string>();
            using (StreamReader sr = File.OpenText(@"C:\Users\coppe\Documents\School\Programmeren 3\Opdrachten lezen en schrijven\extracted\WRstraatnamen.csv"))
            {
                string line = sr.ReadLine();
                while((line=sr.ReadLine()) != null)
                {
                    string[] lineSplit = line.Split(";");
                    StratenVerzameling.Add(lineSplit[0], lineSplit[1]);

                }
            }

            Dictionary<string, List<string>> gemeenteStraatNaamLink = new Dictionary<string, List<string>>();
            //gemeentenaam gelinkt aan alle straten erin
            //gemeenteStraatIDLink opvullen met alle gemeenteIs als keys
            Dictionary<string, List<string>> GemeenteStraatIDLinks = new Dictionary<string, List<string>>();
            foreach(string gemeente in gemeenteNamen.Keys)
            {
                gemeenteStraatNaamLink.Add(gemeente,new List<string>());
                GemeenteStraatIDLinks.Add(gemeente, new List<string>());
            }

            using (StreamReader sr = File.OpenText(@"C:\Users\coppe\Documents\School\Programmeren 3\Opdrachten lezen en schrijven\extracted\StraatnaamID_gemeenteID.csv"))
            {
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lineSplit = line.Split(";");
                    if (gemeenteNamen.ContainsKey(lineSplit[1]))
                        GemeenteStraatIDLinks[lineSplit[1]].Add(lineSplit[0]);
                }
            }
            //Hier koppel ik gemeenteNamen aan straatnamen;
            foreach(KeyValuePair<string,List<string>> entry in GemeenteStraatIDLinks)
            {
                foreach(string straatID in entry.Value)
                {
                    if(StratenVerzameling.ContainsKey(straatID))
                    gemeenteStraatNaamLink[entry.Key].Add(StratenVerzameling[straatID]);
                }
            }
            
            List<DirectoryInfo> provincieMappen = new List<DirectoryInfo>();
            List<FileInfo> straatBestanden = new List<FileInfo>();
            foreach(KeyValuePair<string,List<string>> entry in gemeenteStraatNaamLink)
            {
                entry.Value.Sort();
            }
            foreach(KeyValuePair<string,string> provincie in provincieNamen)
            {
                DirectoryInfo tempProvincie = new DirectoryInfo($"C:\\Users\\coppe\\Documents\\School\\Programmeren 3\\Opdrachten lezen en schrijven\\extracted\\{provincie.Value}");
                tempProvincie.Create();
                foreach(KeyValuePair<string,string> gemeente in gemeenteNamen)
                {
                    //dit is gewoon waar ik het bestand schrijf
                    //FileInfo tempGemeente = new FileInfo($"C:\\Users\\coppe\\Documents\\School\\Programmeren 3\\Opdrachten lezen en schrijven\\extracted\\{provincie.Value}\\{gemeente.Value}.txt");
                    using (StreamWriter sw = File.CreateText($"C:\\Users\\coppe\\Documents\\School\\Programmeren 3\\Opdrachten lezen en schrijven\\extracted\\{provincie.Value}\\{gemeente.Value}.txt"))
                    {
                    foreach(string straat in gemeenteStraatNaamLink[gemeente.Key])
                    {
                            sw.WriteLine(straat);
                    }

                    }
                }
               }
        }
        
    }
}
