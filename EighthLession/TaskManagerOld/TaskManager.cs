using System;
using System.Diagnostics;

namespace TaskManagerOld
{
    public class TaskManager
    {
        //Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс.
        //Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса.
        //В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.
        static void Main(string[] args)
        {
            //Сначало я думал создать класс или словарь, чтобы отображать процессы, но они так изменчивы, что проще напрямую сразу их показывать.
            bool isLoop = true;

            try
            {
                Process[] allProcesses = Process.GetProcesses();
                Console.WriteLine($"Всего найдено запущенных процессов: {allProcesses.Length}");
            }
            catch
            {
                Console.WriteLine($"\nОШИБКА! Невозможно получить список процессов.");
            }

            while (isLoop)
            {
                ShowMenu();
                CommandAction(ReadInput(), ref isLoop, out _);
            }
            Console.WriteLine($"Нажмите любую клавишу для выхода из программы.");

        }
        public static void ShowMenu()
        {
            Console.WriteLine("\n--------------------------Меню--------------------------");
            Console.WriteLine("1. Введите 1, если хотите вывести список всех процессов");
            Console.WriteLine("2. Введите 2, если хотите найти процесс");
            Console.WriteLine("3. Введите 3, если хотите остановить процесс");
            Console.WriteLine("4. Введите 4, если хотите выйти из программы");
            Console.WriteLine("--------------------------------------------------------");
        }
        public static void CommandAction(int value, ref bool isLoop, out string processName)
        {
            processName = "";

            switch (value)
            {
                case 1:
                    ShowProcesses();
                    break;
                case 2:
                    Console.WriteLine("\nДля поиска процесса введите его ID или имя процесса");
                    FindProcesses();
                    break;
                case 3:
                    Console.WriteLine("\nДля остановки процесса введите его ID или имя процесса");
                    Process[] p = FindProcesses();
                    processName = p[0].ProcessName;
                    StopProcesses(p);
                    break;
                case 4:
                    isLoop = false;
                    break;
            }
        }

        public static int ReadInput()
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("\nОШИБКА! Вы ввели не число! Повторите попытку.");
                return 0;
            }

            if (number < 0 || number > 5)
            {
                Console.WriteLine("\nОШИБКА! Введите число из диапазона [1..5]");
                return 0;
            }

            return number;
        }
        private static void StopProcesses(Process[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == null)
                    continue;

                try
                {
                    Console.WriteLine($"Идет попытка закрытия процесса {p[i].ProcessName}.");
                    p[i].Kill();
                    p[i].WaitForExit();
                    Console.WriteLine($"Процесс {p[i].ProcessName} закрыт успешно.");
                }
                catch
                {
                    Console.WriteLine($"ОШИБКА! Процесс {p[i].ProcessName} нельзя остановить.");
                }
            }
        }

        private static void ShowProcesses(int maxShow = 0)
        {
            Process[] allProcesses = Process.GetProcesses();

            for (int i = 0; i < (maxShow > 0 ? maxShow : allProcesses.Length); i++)
            {
                Process p = allProcesses[i];
                Console.WriteLine($"ID = {p.Id}, Name = {p.ProcessName}");
            }
        }
        private static Process[] FindProcesses()
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                Process[] allProcesses = new Process[1];
                try
                {
                    allProcesses[0] = Process.GetProcessById(number);
                    Console.WriteLine($"Найденный процесс: ID = {allProcesses[0].Id}, Name = {allProcesses[0].ProcessName}");
                }
                catch
                {
                    Console.WriteLine($"ОШИБКА! Процесс ID = {number} не найден.");
                }
                return allProcesses;
            }
            else
            {

                Process[] allProcesses = Process.GetProcessesByName(input);
                foreach (Process p in allProcesses)
                {
                    Console.WriteLine($"Найденный процесс: ID = {p.Id}, Name = {p.ProcessName}");
                }
                if (allProcesses.Length > 0)
                    return allProcesses;
                Console.WriteLine($"ОШИБКА! Процесс Name = {input} не найден.");
                return null;
            }
        }
    }
}
