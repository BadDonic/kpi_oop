using System;

namespace lab8
{
    interface IPrototype
    {
        object Clone();
        object CloneWithMove(string path);
    }

    public class File : IPrototype
    {
        public string Name { get; set; }
        public string Dir { get; set; }

        public File(string name, string dir)
        {
            Name = name;
            Dir = dir + "/" + name;
        }

        public void ToDisplay()
        {
            Console.WriteLine($"File: {Dir}");
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
            Object clone = null;
            try
            {
                path = path + "/" + Name;
                if (!System.IO.File.Exists(path))
                    System.IO.File.Copy(Dir, path);
                clone = new File(Name, path.Substring(0, path.Length - Name.Length - 1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return clone;
        }
    }
}