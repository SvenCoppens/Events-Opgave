using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace File_IO_testing
{
    class Zip_file_voorbeeld
    {
        static void Main()
        {
            string path = @"C:\Users\coppe\Documents\Test";
            string extractPath = @"C:\Users\coppe\Documents\Test\copy";
            string zipPath = @"C:\Users\coppe\Documents\Test\zippie.zip";

            CreateZipFile(zipPath, Directory.EnumerateFiles(path,"*.txt"));
            File.Copy(zipPath, Path.Combine(path, @"zip2.zip"));
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
        public static void CreateZipFile(string filepath, IEnumerable<string> files)
        {
            var zip = ZipFile.Open(filepath, ZipArchiveMode.Create);
            foreach(string file in files)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            zip.Dispose();
        }
    }
}
