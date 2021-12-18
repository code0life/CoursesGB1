using System;

namespace Task2
{
    //Запросить у пользователя порядковый номер текущего месяца и вывести его название.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядковый номер текущего месяца.\nНумерация начинается с 0\nЕсли вы введете пустую строку, месяц определиться сам.");
            int m = GetNumber();
            string month = GetMonth(m);
            //Можно конечно и так достать, так короче и быстрее, но придется вводить начиная с 1
            //DateTime date = new DateTime(2021, m, 1);
            //string month = date.ToString("MMMM");
            if (month != "")
            {
                Console.WriteLine($"Вы выбрали: {month}");
            }
            else
            {
                Console.WriteLine($"Ошибка. Месяц под таким порядковым номером({m}) не найден.");
            }
        }
        static string GetMonth(int num)
        {
            string month = "";
            switch (num)
            {
                case 0:
                    month = "Январь";
                    break;
                case 1:
                    month = "Февраль";
                    break;
                case 2:
                    month = "Март";
                    break;
                case 3:
                    month = "Апрель";
                    break;
                case 4:
                    month = "Май";
                    break;
                case 5:
                    month = "Июнь";
                    break;
                case 6:
                    month = "Июль";
                    break;
                case 7:
                    month = "Август";
                    break;
                case 8:
                    month = "Сентябрь";
                    break;
                case 9:
                    month = "Октябрь";
                    break;
                case 10:
                    month = "Ноябрь";
                    break;
                case 11:
                    month = "Декабрь";
                    break;

            }

            return month;

        }
        static int GetNumber()
        {
            string str = Console.ReadLine();
            int number = str.Length > 0 ? int.Parse(str) : DateTime.Today.Month - 1;
            return number;
        }

    }
}
