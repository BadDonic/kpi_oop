using System;
using System.Collections.Generic;
using System.IO;

namespace lab8
{
    interface IPrototype
    {
        object Clone();
        object CloneWithMove(string path);
    }

    public class FileList : IPrototype
    {
        public string[] List { get; set; }
        public FileList(string path)
        {
            try
            {
                List = Directory.GetFiles(path);   
            } 
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e);
            }
        }

        public void ToDisplay()
        {
            foreach (string it in List)
                Console.WriteLine($"File: {it}");
        }

        public object Clone()
        {
            Object clone = null;
            try
            {
                clone = MemberwiseClone();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return clone;
        }

        public object CloneWithMove(string path)
        {
            var paths = new List<string>();
            object clone = null;
            try
            {
                foreach (var it in List)
                {
                    try
                    {
                        var fi = new FileInfo(it);
                        var outPath = path + "/" + fi.Name;
                        if (!File.Exists(outPath))
                            File.Copy(fi.FullName, outPath);
                        paths.Add(outPath);
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                List = paths.ToArray();
                clone = MemberwiseClone();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return clone;
        }
    }
}