using System;

namespace Task2
{
    class Program
    {
        //Написать программу — телефонный справочник — создать двумерный массив 5*2, хранящий список телефонных контактов: первый элемент хранит имя контакта,
        //второй — номер телефона/e-mail.
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько записей вы хотите создать?\n");

            int s = GetNumber();
            if (s == 0)
            {
                Console.WriteLine($"\nВы выбрали создать {0} записей. Программа завершает работу.");
                return;
            }
            string[,] matrix = new string[s, 2];

            FillMatrix(matrix);
            ShowMatrix(matrix);
        }


        static void FillMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    string state = j == 0 ? "имя контакта" : "номер телефона/e-mail";
                    Console.WriteLine($"\nВведите {state} для {i} записи\n");
                    matrix[i, j] = Console.ReadLine();
                }
            }
        }

        static void ShowMatrix(string[,] matrix)
        {
            Console.WriteLine("\nПолучился массив:\n");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                     Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static int GetNumber()
        {
            string str = Console.ReadLine();
            int number = str.Length > 0 ? int.Parse(str) : 0;
            return number;
        }
    }
}
