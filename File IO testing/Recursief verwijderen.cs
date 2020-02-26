using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace File_IO_testing
{
    class Recursief_verwijderen
    {
        public static void Main()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\coppe\Documents\wegwerpfolder");
            ClearFolder(dir);
        }
        public static void ClearFolder(DirectoryInfo dir)
        {
            foreach(FileInfo bestandje in dir.GetFiles())
            {
                bestandje.Delete();
            }
            foreach(DirectoryInfo folder in dir.GetDirectories())
            {
                ClearFolder(folder);
            }
                dir.Delete();
        }
    }
}
