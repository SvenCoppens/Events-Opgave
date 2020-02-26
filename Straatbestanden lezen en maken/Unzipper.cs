using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;

namespace Straatbestanden_lezen_en_maken
{
    class Unzipper
    {
        public static void Unzip()
        {
            string zipSource = @"C:\Users\coppe\Documents\School\Programmeren 3\Opdrachten lezen en schrijven\DirFileOefening.zip";
            string zipGoal = @"C:\Users\coppe\Documents\School\Programmeren 3\Opdrachten lezen en schrijven\extracted";
            ZipFile.ExtractToDirectory(zipSource, zipGoal);
        }
    }
}
