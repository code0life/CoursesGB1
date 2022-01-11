using System;
using System.IO;

namespace Task1
{
    class Program
    {
        //Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.

        static void Main()
        {
            string filename = @"task1.txt";
            string path = @"";

            filename = GetFileName(filename);
            path = GetPath(path);

            Console.WriteLine($"\nВведите любые символы чтобы сохранить их в файл: '{filename}'");
            string str = Console.ReadLine();

            string fullPatch = Path.Combine(path, filename);

            CreateFile(str, fullPatch);
        }
        static public string GetPath(string stdPath)
        {
            string path = stdPath;
            Console.WriteLine("\nХотите задать путь для файла? (Y - Да, N - Нет)");
            string question2 = Console.ReadLine();
            if (question2 == "Y")
            {
                Console.WriteLine("\nВведите путь для файла:");
                string tempPath = Console.ReadLine();
                if (string.IsNullOrEmpty(tempPath) || string.IsNullOrWhiteSpace(tempPath))
                {
                    Console.WriteLine($"\nНекорректный путь, файл будет по стандартному пути: {path}");
                }
                else
                {
                    path = tempPath;
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("\nТакой директории не существует, создать? (Y - Да, N - Нет)");
                    string question3 = Console.ReadLine();
                    if (question3 == "Y")
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                        Console.WriteLine("\nДиректория создана в {0}.", Directory.GetCreationTime(path));

                    }
                }
            }

            return path;
        }
        static public string GetFileName(string stdName)
        {
            string str = stdName;
            Console.WriteLine("Хотите задать имя и формат файла для записи? (Y - Да, N - Нет)");
            string question = Console.ReadLine();
            if (question == "Y")
            {
                Console.WriteLine("\nВведите название файла:");
                string name = Console.ReadLine();
                Console.WriteLine("\nВведите формат:");
                string format = Console.ReadLine();
                str = $"{name}.{format}";
            }
            return str;
        }

        static public void CreateFile(string str, string path)
        {
            try
            {
                using FileStream fs = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(str);
                }
                Console.WriteLine($"\nТекст: '{str}' был записан в файл по пути: '{path}'");
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
