using System;
using System.Configuration;

namespace Task
{
    class Program
    {
        //Создать консольное приложение, которое при старте выводит приветствие, записанное в настройках приложения (application-scope).
        //Запросить у пользователя имя, возраст и род деятельности, а затем сохранить данные в настройках.
        //При следующем запуске отобразить эти сведения.
        //Задать приложению версию и описание.
        static void Main(string[] args)
        {
            ShowTitle();
            LoadSettings();
        }
        static void LoadSettings()
        {
            try
            {
                Properties.Settings s = Properties.Settings.Default;
                if (string.IsNullOrEmpty(s.UserName))
                {
                    Console.WriteLine("\nВведите имя пользователя: ");
                    s.UserName = Console.ReadLine();
                    Console.WriteLine("\nВведите возраст пользователя: ");
                    s.Age = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("\nВведите род деятельности пользователя: ");
                    s.Occupation = Console.ReadLine();
                    s.Save();
                }
                else
                {
                    Console.WriteLine("\nХотите задать новые данные? (Y - ДА | N - НЕТ)");
                    string answer = Console.ReadLine();
                    if(answer == "Y")
                    {
                        s.Reset();
                        s.Count++;
                        s.Save();
                        LoadSettings();
                    }

                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("\nОшибка загрузки настроек");
            }
        }
        static void ShowTitle()
        {
            try
            {
                Properties.Settings s = Properties.Settings.Default;
                Console.WriteLine(s.SayHello);
                Console.WriteLine($"\nЭто {GetStartCount()} запуск приложения");
                if (!string.IsNullOrEmpty(s.UserName))
                {
                    Console.WriteLine($"\nВ последний раз запускал приложение пользователь: \nЛогин: {s.UserName} \nВозраст: {s.Age} \nРод деятельности: {s.Occupation}");
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("\nОшибка загрузки настроек");
            }
        }

        static int GetStartCount()
        {
            Properties.Settings s = Properties.Settings.Default;
            s.Count++;
            s.Save();

            return s.Count;
        }

    }
}
