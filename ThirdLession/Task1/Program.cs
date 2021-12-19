using System;

namespace Task1
{
    class Program
    {
        //Написать программу, выводящую элементы двухмерного массива по диагонали.
        static void Main(string[] args)
        {
            int[,] matrix = GetRandomMatrix(5, 5);
            Console.WriteLine("Сгенерированный массив:\n");
            ShowMatrix(matrix);

            Console.WriteLine("\nПоказываем диагональ массива:\n");
            ShowMatrix(matrix, true);

            Console.WriteLine("\nПоказываем только диагональ массива:\n");
            ShowMatrix(matrix, true, true);

            Console.WriteLine("\nВыводим строчкой диагональ массива:\n");
            ShowMatrix(matrix, true, true, true);
        }


        static int[,] GetRandomMatrix(int a, int b)
        {
            Random rnd = new Random();
            int[,] matrix = new int[a, b];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                }
            }
            return matrix;
        }

        static void ShowMatrix(int[,] matrix, bool show_diagonal = false, bool hide_other = false, bool is_line = false)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j && show_diagonal)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                        Console.Write($"{matrix[i, j]} ");
                        Console.ResetColor(); // сбрасываем в стандартный
                    }
                    else
                    {
                        if (!is_line)
                        {
                            if (!hide_other)
                            {
                                Console.Write($"{matrix[i, j]} ");
                            }
                            else
                            {
                                Console.Write($"  ");
                            }
                        }
                    }
                }
                if (!is_line)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
