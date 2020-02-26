using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace File_IO_testing
{
    class Schrijven_naar_een_tekst_file
    {
        static void Main()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\coppe\Pictures\Saved Pictures\testbestand.txt")) 
            {
                string input = null;
                while((input= sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
                Console.ReadLine();
            }
            //using (StreamWriter writer = File.CreateText(@"C:\Users\coppe\Pictures\Saved Pictures\Testbestand.txt"))
            //{
            //    writer.WriteLine("Delete this shit");
            //    writer.WriteLine("Life sucks");

            //    for(int i = 0; i < 10; i++)
            //    {
            //        writer.Write(i + " ");
            //    }
            //    writer.Write(writer.NewLine);
            //}

        }
    }
}
