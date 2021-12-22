using System;

namespace Task2
{
    //Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом,
    //и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран.
    class Program
    {
        static void Main(string[] args)
        {
            bool isLoop = true;
            float sum = 0;

            while (isLoop)
            {
                Console.WriteLine("Введите числа, разделяя пробелом. \nЕсли вы хотите указать float число, пишите его через '.'\nЕсли вы хотите выйти из программы, напишите 'exit'");
                string str = Console.ReadLine();
                if(str.Length == 0)
                {
                    Console.WriteLine("Ошибка. Введенная строка пуста!");
                    continue;
                }
                Console.WriteLine($"\nВы ввели строку '{str}'");
                if (str == "exit")
                {
                    Console.WriteLine("Осуществляется выход из программы.");
                    return;
                }

                isLoop = false;

                sum = GetSum(str);

            }

            Console.WriteLine($"\nCумма всех чисел: {sum}");

        }
        static float GetSum(string line)
        {
            float sum = 0;
            int count = 0;
            string[] string_array = line.Split(' ');
            for (int i = 0; i < string_array.Length; i++)
            {
                float number;

                bool success = float.TryParse(string_array[i], out number);
                if (success)
                {
                    Console.WriteLine($"Конвертируем строку '{string_array[i]}' в число {number}.");
                    sum = sum + number;
                    count++;
                }
                else
                {
                    Console.WriteLine($"Строку '{string_array[i] ?? "<null>"}' нельзя конвертировать в число");
                }
            }

            Console.WriteLine($"Было найдено всего элементов: {string_array.Length}. Из них всего чисел: {count}");

            return sum;
        }
    }
}
