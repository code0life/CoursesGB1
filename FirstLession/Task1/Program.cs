using System;

namespace Task1
{
    class Program
    {
        //Написать программу, выводящую в консоль текст: «Привет, %имя пользователя%,
        //сегодня %дата%». Имя пользователя сохранить из консоли в промежуточную переменную.

        static void Main(string[] args)
        {
            string name = Environment.UserName;
            DateTime thisDay = DateTime.Today;

            string text = $"Привет, {name}, сегодня {thisDay.ToString("D")}\n";

            Console.Write(text + "\nНажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}
