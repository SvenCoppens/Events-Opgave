using System;
using System.IO;
using System.Collections.Generic;

namespace File_IO_testing
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Fun with Directory(info)*****/n");
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            foreach(DriveInfo d in myDrives)
            {
                Console.WriteLine($"naam: {d.Name}");
                Console.WriteLine($"type: {d.DriveType}");

                if (d.IsReady)
                {
                    Console.WriteLine($"Free space: {d.TotalFreeSpace}");
                    Console.WriteLine($"format: {d.DriveFormat}");
                    Console.WriteLine($"label: {d.VolumeLabel}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("**** Directory Info *****");
            Console.WriteLine("FullName: {0}",dir.FullName);
            Console.WriteLine("Name: {0}",dir.Name);
            Console.WriteLine("Parent: {0}",dir.Parent);
            Console.WriteLine("Creation: {0}",dir.CreationTime);
            Console.WriteLine("Attributes: {0}",dir.Root);
            Console.WriteLine("**********************************");
            Console.WriteLine();


        }
        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\coppe\Pictures\Saved Pictures");
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            Console.WriteLine($"Found {imageFiles.Length} .jpg files");
            Console.WriteLine();

            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("*****************************");
                Console.WriteLine($"File name: {f.Name}");
                Console.WriteLine($"file size: {f.Length}");
                Console.WriteLine($"Creation: {f.CreationTime}");
                Console.WriteLine($"Attributes: {f.Attributes}");
                Console.WriteLine("**************************");
            }
        }
        static void GrootsteFiles()
        {
            //// dit kan ook perfect via sorted list:
            //SortedList<long, List<FileInfo>> slf = new SortedList<long, List<FileInfo>>();//de eerste file hier is volgens welke waarde je wilt zoeken.
               //sorted list werkt eigenlijk eerder als een dictionary
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\coppe\source\repos");
            FileInfo[] bestanden = dir.GetFiles("*.cs", SearchOption.AllDirectories);

            Console.WriteLine($"Found {bestanden.Length} bestanden aan slechte code");

            for(int i =0; i<bestanden.Length-1;i++)
            {
                int wisselIndex = i;
                FileInfo toSort = bestanden[i];
                for(int index = i+1; index < bestanden.Length; index++)
                {
                    if(bestanden[index].Length> bestanden[wisselIndex].Length)
                    {
                        wisselIndex = index;
                    }
                }
                FileInfo tussenWaarde = bestanden[i];
                bestanden[i] = bestanden[wisselIndex];
                bestanden[wisselIndex] = tussenWaarde;
                //if (bestanden[i].Length > bestanden[i - 1].Length)
                //{
                //    FileInfo tussenbestand = bestanden[i - 1];
                //    bestanden[i - 1] = bestanden[i];
                //    bestanden[i] = tussenbestand;
                //}
                //beginwaarde++;
            }
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(bestanden[i].Name);
                Console.WriteLine($"size: {bestanden[i].Length}");
                Console.WriteLine($"Attributes: {bestanden[i].Attributes}");
                Console.WriteLine($"Path: {bestanden[i].FullName}");
                Console.WriteLine();
            }
        }
        static void CreateSubdirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\coppe\Pictures\Saved Pictures");
            dir.CreateSubdirectory("folder1");

            DirectoryInfo test = dir.CreateSubdirectory(@"foldere2/testing"); 
        }
    }
}
