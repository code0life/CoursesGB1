using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task4
{
    public class Program
    {
        //Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
        static void Main()
        {
            string filename = @"task4.xml";
            string path = @"";
            bool isLoop = true;
            string str = "";

            filename = GetFileName(filename);
            path = GetPath(path);

            while (isLoop)
            {
                Console.WriteLine($"\nВведите 's' чтобы сохранить дерево каталогов и файлов в текстовый файл или введите 'r' чтобы сделать это с помощью рекурсии");
                str = Console.ReadLine();
                if ((str != "s" && str != "r") || string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Ошибка. Вы ввели некорректную строку!");
                    continue;
                }
                isLoop = false;
            }

            SaveTree(str, path, filename);
            ShowTree(path, filename);
        }
        public static string GetPath(string stdPath)
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
        public static string GetFileName(string stdName)
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

        public static void ShowTree(string path, string filename)
        {
            path = path == "" ? Directory.GetCurrentDirectory() : path;
            XmlSerializer serializer = new XmlSerializer(typeof(DirectoryTest));
            try
            {
                string xmlText = File.ReadAllText(filename);
                using (FileStream file = File.OpenRead(Path.Combine(path, filename)))
                {
                    DirectoryTest tree = (DirectoryTest)serializer.Deserialize(file);
                    DrawDirectory(tree, true, 0, true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }
        }
        public static void DrawDirectory(DirectoryTest dir, bool is_first = false, int count = 0, bool is_head = false)
        {
            if (is_head)
            {
                Console.WriteLine($"{dir.name}");
            }
            else
            {
                if (!is_first)
                {
                    Console.WriteLine($"{GetLengthLine(count)}|->{GetShortName(dir.name)}");
                }
                else
                {
                    Console.WriteLine($"{GetLengthLine(count - 1)}|->{GetShortName(dir.name)}");
                }
            }
            DrawFiles(dir, count);
            if (dir.listDirectories.Count > 0)
            {
                count = count + 1;
                for (int i = 0; i < dir.listDirectories.Count; i++)
                {
                    DrawDirectory(dir.listDirectories[i], is_first, count);
                }
            }
        }
        public static string GetShortName(string name, string symbol = "\\")
        {
            string[] subs = name.Split(symbol);
            return subs[subs.Length-1];
        }
        public static void DrawFiles(DirectoryTest dir, int count = 1)
        {
            if (dir.listFiles.Count > 0)
            {
                for (int i = 0; i < dir.listFiles.Count; i++)
                {
                    Console.WriteLine($"{GetLengthLine(count)}|->{GetShortName(dir.listFiles[i].name)}");
                }
            }
        }
        public static string GetLengthLine(int count = 0, string symbol = "   ")
        {
            string finalLine = "";
            for (int i = 0; i < count; i++)
            {
                finalLine = finalLine + symbol;
            }

            return finalLine;
        }

        public static void SaveTree(string str, string path, string filename)
        {
            path = path == "" ? Directory.GetCurrentDirectory() : path;
            XmlSerializer serializer = new XmlSerializer(typeof(DirectoryTest));

            if (str == "s")
            {
                Console.WriteLine("Вы выбрали вариант: 'Cохранить дерево каталогов и файлов в текстовый файл без использования рекурсии.'");

                DirectoryTest d = GetFillDirectory(path);
                try
                {
                    using (FileStream file = File.Create(Path.Combine(path, filename)))
                    {
                        serializer.Serialize(file, d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Вы выбрали вариант: 'Cохранить дерево каталогов и файлов в текстовый файл используя рекурсию.'");
                List<FileTest> flist = GetListFiles(path);
                List<DirectoryTest> dlist = GetListDirectories(path);

                try
                {
                    using (FileStream file = File.Create(Path.Combine(path, filename)))
                    {
                        DirectoryTest d = new DirectoryTest(Directory.GetCurrentDirectory(), flist, dlist);
                        serializer.Serialize(file, d);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}");
                }
            }

        }
        public static DirectoryTest GetFillDirectory(string path)
        {
            DirectoryTest d = new DirectoryTest();
            d.name = Path.GetFileNameWithoutExtension(path);

            string[] all = Directory.GetFileSystemEntries(path);
            for (int i = 0; i < all.Length; i++)
            {
                if (File.Exists(Path.Combine(path, all[i])))
                {
                    d.listFiles.Add(new FileTest(all[i]));
                }
                else if (Directory.Exists(Path.Combine(path, all[i])))
                {
                    d.listDirectories.Add(new DirectoryTest(all[i]));
                    //Console.WriteLine("d.listDirectories[^] = " + d.listDirectories[^1].name);
                    //d.listDirectories[^1] = GetFillDirectory(d.listDirectories[^1].name);
                    //d.listDirectories[^1].name = GetShortName(name: d.listDirectories[^1].name, symbol: "\\");

                    //string result = Path.GetFileNameWithoutExtension(d.listDirectories[^1].name);
                    //Console.WriteLine("result = " + result);

                }
            }

            return d;
        }

        //Console.WriteLine("d.listDirectories.Count = " + d.listDirectories.Count);

                //for (int i = 0; i<d.listDirectories.Count; i++)
                //{
               //     Console.WriteLine("d.listDirectories[i].name = " + d.listDirectories[i].name);
               //     //d.listDirectories[i] = GetFillDirectory(d.listDirectories[i].name);
               // }

    public static List<FileTest> GetListFiles(string path)
        {
            string[] allfiles = Directory.GetFiles(path);
            List<FileTest> flist = new List<FileTest>();
            foreach (string directory in allfiles)
            {
                FileTest f = new FileTest(directory);
                flist.Add(f);
            }

            return flist;
        }
        public static List<DirectoryTest> GetListDirectories(string path, bool is_recursive = true)
        {
            string[] alldirect = Directory.GetDirectories(path);
            List<DirectoryTest> dlist = new List<DirectoryTest>();
            foreach (string directory in alldirect)
            {
                DirectoryTest d = new DirectoryTest();
                if (is_recursive)
                {
                    d = new DirectoryTest(directory, GetListFiles(Path.Combine(path, directory)), GetListDirectories(Path.Combine(path, directory)));

                }

                dlist.Add(d);
            }

            return dlist;
        }
    }
}
