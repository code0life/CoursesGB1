using System;

namespace Task1
{
    //Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите минимальную и максимальную температуру за сутки.");
            float t1 = GetNumber();
            float t2 = GetNumber(false);

            float average = (t1 + t2)/2;
            string state = average > 0 ? "Тепло" : "Холодно";

            Console.WriteLine($"Минимальная температура: {t1}\nМаксимальная температура: {t2}\nСреднесуточная температура: {average} °C. {state}." );
        }

        static float GetNumber(bool flag = true)
        {
            string state = flag == true ? "минимальную" : "максимальную";
            Console.WriteLine($"Введите {state} температуру за сутки:");
            string str = Console.ReadLine();
            float number = str.Length > 0 ? float.Parse(str) : 0;
            return number;
        }

    }
}
