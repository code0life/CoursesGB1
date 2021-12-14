using System;

namespace Task5
{
    //(*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите минимальную и максимальную температуру за сутки.");
            float t1 = GetTemperature();
            float t2 = GetTemperature(false);

            float average = (t1 + t2) / 2;
            string stateTemperature = average > 0 ? "Тепло" : "Холодно";

            Console.WriteLine("Введите порядковый номер текущего месяца.\nНумерация начинается с 0\nЕсли вы введете пустую строку, месяц определиться сам.");
            int m = GetNumber();
            string month = GetMonth(m);
            if (month != "")
            {

                string stateWinter = (stateTemperature == "Тепло") && (m == 0 || m == 1 || m == 11) ? "Дождливая зима." : "";

                Console.WriteLine($"Вы выбрали: {month}");
                Console.WriteLine($"Минимальная температура: {t1}\nМаксимальная температура: {t2}\nСреднесуточная температура: {average} °C. {stateTemperature}. {stateWinter}");
            }
            else
            {
                Console.WriteLine($"Ошибка. Месяц под таким порядковым номером({m}) не найден.");
            }
        }
        static float GetTemperature(bool flag = true)
        {
            string state = flag == true ? "минимальную" : "максимальную";
            Console.WriteLine($"Введите {state} температуру за сутки:");
            string str = Console.ReadLine();
            float number = str.Length > 0 ? float.Parse(str) : 0;
            return number;
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
