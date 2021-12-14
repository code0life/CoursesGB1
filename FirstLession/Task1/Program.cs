using System;

namespace Task1
{
    class Program
    {
        //Написать программу, выводящую в консоль текст: «Привет, %имя пользователя%,
        //сегодня %дата%». Имя пользователя сохранить из консоли в промежуточную переменную.

        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите ввести своё имя? (Y-да, N-нет) ");
            string choice = Console.ReadLine();

            string name = Environment.UserName;
            DateTime thisDay = DateTime.Now;

            if (choice == "Y" || choice == "Yes" || choice == "Да")
            {
                Console.WriteLine("Введите свое имя: ");
                name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Вы не захотели вводить свое имя.\nБерем имя пользователя: {name}");
            }

            string text = $"\nПривет, {name}, сегодня {thisDay}\n";

            Console.Write($"{text}\nНажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}
