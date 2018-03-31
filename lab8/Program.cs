using System;
using System.Collections.Generic;
using System.IO;

namespace lab8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("///////////////// Task1 /////////////////");
            try
            {
                List<File> list = new List<File>();
                List<File> cloneList = new List<File>();
                string[] files = Directory.GetFiles("/home/daniel/Programming/kpi_oop/lab8/");
                foreach (string s in files)
                {
                    FileInfo fi;
                    try
                    {
                        fi = new FileInfo(s);
                        list.Add(new File(fi.Name, fi.DirectoryName));
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    Console.WriteLine($"File: {fi.Name} in {fi.DirectoryName}");
                }

                foreach (var it in list) cloneList.Add((File) it.Clone());
                Console.WriteLine("--------------------------- CLONED ---------------------------");
                foreach (var it in cloneList) it.ToDisplay();
                Console.WriteLine("--------------------------- CLONED WITH MOVE ---------------------------");
                string path = "/home/daniel/Programming/kpi_oop/lab8/bin";
                foreach (var it in list) cloneList.Add((File) it.CloneWithMove(path));
                foreach (var it in cloneList) it.ToDisplay();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            Console.WriteLine("///////////////// Task2 /////////////////");
        }
    }
}