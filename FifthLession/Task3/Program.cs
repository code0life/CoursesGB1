using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task3
{
    class Program
    {
        //Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.

        static void Main()
        {
            string filename = @"task3.bin";
            string path = @"";
            string str = "";
            List<byte> list = new List<byte>();

            filename = GetFileName(filename);
            path = GetPath(path);

            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine($"\nВведите произвольный набор чисел (0...255) чтобы сохранить их в файл: '{filename}'. Цифры разделяйте пробелами.");
                str = Console.ReadLine();
                if (str.Length == 0)
                {
                    Console.WriteLine("Ошибка. Введенная строка пуста!");
                    continue;
                }
                if (str == "exit")
                {
                    Console.WriteLine("Осуществляется выход из программы.");
                    return;
                }

                list = GetArrayBytes(str);
                if (list.Count == 0)
                {
                    Console.WriteLine("Ошибка. В введенной строке не найдено ни одного подходящего числа, введите корректную строку.");
                    continue;
                }
                isLoop = false;
                string state = list.Count == 1 ? "необходимый элемент" : "необходимых элементов";
                Console.WriteLine($"\nВы ввели строку '{str}', в ней имеется {list.Count} {state}.");
            }

            string fullPatch = Path.Combine(path, filename);

            CreateFile(list, fullPatch);
            ReadFile(fullPatch);
        }

        static List<byte> GetArrayBytes(string line)
        {
            List<byte> list = new List<byte>();
            string[] string_array = line.Split(' ');
            for (int i = 0; i < string_array.Length; i++)
            {
                byte number;

                bool success = byte.TryParse(string_array[i], out number);
                if (success)
                {
                    Console.WriteLine($"Конвертируем строку '{string_array[i]}' в число {number}.");
                    list.Add(number);
                }
                else
                {
                    Console.WriteLine($"Строку '{string_array[i] ?? "<null>"}' нельзя конвертировать в число");
                }
            }

            Console.WriteLine($"Было найдено всего элементов: {string_array.Length}. Из них всего чисел: {list.Count}");

            return list;
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

        static public void CreateFile(List<byte> list, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            BinaryFormatter bin = new BinaryFormatter();

            try
            {
                using (FileStream fs = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bin.Serialize(fs, list);
                }
                Console.WriteLine($"\nСписок их {list.Count} элементов был записан в бинарный файл по пути: '{path}'");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }
        }
        static public void ReadFile(string path)
        {
            BinaryFormatter bin = new BinaryFormatter();
            List<byte> listDeserialize = new List<byte>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    listDeserialize = (List<byte>)bin.Deserialize(fs);
                }
                Console.WriteLine($"\n{listDeserialize.Count} элементов были десериализованы из бинарного файла, находящегося по пути: '{path}'");
                Console.Write("\nВостановленный список: ");
                foreach (byte num in listDeserialize)
                {
                    Console.Write("{0} ", num);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }
        }
    }
}
