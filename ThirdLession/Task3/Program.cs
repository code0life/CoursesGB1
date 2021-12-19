using System;

namespace Task3
{
    class Program
    {
        //Написать программу, выводящую введенную пользователем строку в обратном порядке (olleH вместо Hello).
        static void Main(string[] args)
        {
            string std = "Hello";
            Console.WriteLine($"Введите любую строку. Если вы ничего не введете, будет использована строка '{std}'\n");
            string str = Console.ReadLine();
            string finalStr;
            if (str.Length > 0)
            {
                finalStr = str;
                Console.WriteLine($"Вы ввели строку: '{str}'\n");
            }
            else
            {
                finalStr = std;
            }

            Console.WriteLine($"Строка: '{finalStr}' инвертируется в строку:");
            ShowRevertString(finalStr);

        }

        static void ShowRevertString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[str.Length - 1 - i]);
            }
        }
    }
}
