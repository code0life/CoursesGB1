using System;

namespace Task3
{
    //Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца.
    //На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn.
    //Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень).
    //Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.
    //Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
    class Program
    {
        static void Main(string[] args)
        {
            bool isLoop = true;

            while (isLoop)
            {
                Console.WriteLine("Введите номер месяца в диапазоне от 1 до 12");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Вы ввели не число! Повторите попытку.");
                    continue;
                }

                if (number < 1 || number > 12)
                {
                    Console.WriteLine("Вы ввели некорректное число, введите правильнео числов в диапазоне от 1 до 12.");
                    continue;
                }
                isLoop = false;
                GetSeason(number, out Season s1, out SeasonRus s2);
                Console.WriteLine($"Вы ввели месяц с порядковым номером: {number}, \nкоторый находится в сезоне: {s1}({s2})");
            }
        }
        public static void GetSeason(int mounth, out Season s1, out SeasonRus s2)
        {
            if (mounth < 3 || mounth == 12)
            {
                s1 = Season.Winter;
                s2 = SeasonRus.Зима;
                return;
            }
            else if (mounth >= 2 && mounth < 6)
            {
                s1 = Season.Spring;
                s2 = SeasonRus.Весна;
                return;
            }
            else if (mounth <= 8)
            {
                s1 = Season.Summer;
                s2 = SeasonRus.Лето;
                return;
            }
            s1 = Season.Autumn;
            s2 = SeasonRus.Осень;
        }
        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        public enum SeasonRus
        {
            Весна,
            Лето,
            Осень,
            Зима
        }
    }
}
