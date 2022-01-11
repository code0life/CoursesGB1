using System;
using System.IO;

namespace Task2
{
    class Program
    {
        //Написать программу, которая при старте дописывает текущее время в файл «startup.txt».

        static void Main()
        {
            string filename = @"startup.txt";
            string path = @"";

            string fullPatch = Path.Combine(path, filename);

            CreateFile(DateTime.Now, fullPatch);
        }

        static public void CreateFile(DateTime dt, string path)
        {
            try
            {
                using FileStream fs = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(dt);
                }
                Console.WriteLine($"\nТекст: '{dt}' был записан в файл по пути: '{path}'");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }

            //По методичке я бы сделал так, и всё)
            //File.WriteAllText(filename, str);
            //Console.WriteLine($"\nТекст: '{str}' был записан в файл: '{filename}'");
        }
    }
}
