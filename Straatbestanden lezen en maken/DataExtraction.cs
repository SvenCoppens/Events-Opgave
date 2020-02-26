using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Straatbestanden_lezen_en_maken
{
    class DataExtraction
    {
        public static List<String> ProvincieExtraction()
        {
            List<string> provincieIDs = new List<string>();

            using (StreamReader sr = File.OpenText(@"C:\Users\coppe\Documents\School\Programmeren 3\Opdrachten lezen en schrijven\extracted\ProvincieIDsVlaanderen.csv"))
            {
                string ziever = sr.ReadLine();
                string[] temp = ziever.Split(",");
                foreach (string id in temp)
                {
                    provincieIDs.Add(id);
                }
            }
            return provincieIDs;
        }
    }
}
