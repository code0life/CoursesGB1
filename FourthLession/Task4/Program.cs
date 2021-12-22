using System;

namespace Task4
{
    //(*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом. 
    class Program
    {
        static void Main(string[] args)
        {
            bool isLoop = true;
            while (isLoop)
            {
                Console.WriteLine("Введите N для числа Фибоначчи:");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Вы ввели не число! Повторите попытку.");
                    continue;
                }

                isLoop = false;
                Console.WriteLine($"N = {number}");
                Console.WriteLine($"Число Фибоначчи для N = {number} будет {Fibonacci(number)}");
                Console.WriteLine($"Получившийся рад:");
                ShowLine(number);
            }
        }

        static public int Fibonacci(int n)
        {
            return n > 1 ? Fibonacci(n - 1) + Fibonacci(n-2) : n;
        }
        static public void ShowLine(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"{Fibonacci(i)} ");
            }
        }
    }
}
