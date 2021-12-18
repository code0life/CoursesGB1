using System;

namespace Task3
{
    //Определить, является ли введённое пользователем число чётным.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            int a = GetNumber();
            string state = (a % 2) == 0 ? "четное" : "нечетное";
            Console.WriteLine($"\nВаше число: {a} - {state}");
        }
        static int GetNumber()
        {
            string str = Console.ReadLine();
            int number = str.Length > 0 ? int.Parse(str) : 0;
            return number;
        }

    }
}
