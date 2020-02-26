using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace File_IO_testing
{
    class Binair_Schrijven
    {
        static void Main()
        {
            FileInfo f = new FileInfo(@"C:\Users\coppe\Pictures\Saved Pictures\binaire tekst.txt");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                Console.WriteLine($"Base stream is {bw.BaseStream}");

                double aDouble = 1321.56151;
                int aInt = 12;
                string aString = "testing";

                bw.Write(aDouble);
                bw.Write(aInt);
                bw.Write(aString);
            }
            // nu eens proberen lezen.
            using(BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadInt64());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
        }
    }
}
