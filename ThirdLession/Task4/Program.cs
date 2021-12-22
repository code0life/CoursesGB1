using System;

namespace Task4
{
    class Program
    {
        //* «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
        static void Main(string[] args)
        {
            int sizeBoard = 10;
            char[,] matrix = GenerateMatrix(sizeBoard, sizeBoard);

            int shipSize = 4;
            int shipCount = 1;
            int maxShipCount = 4;

            Console.WriteLine("Сгенерированное пустое поле:\n");
            ShowBoard(matrix);

            while(shipCount <= maxShipCount)
            {
                int count = 0;
                while(count < shipCount)
                {
                    Console.WriteLine($"\nУстанавливаем {shipSize} палубник №{count+1}\n");
                    SetShip(matrix, shipSize);
                    count = count + 1;
                }
                shipSize = shipSize - 1; //Уменьшаем размер следующего типа кораблей
                shipCount = shipCount + 1; // Увеличиваем счетчик кораблей на количество созданных кораблей
            }

            Console.WriteLine($"\nИгровое поле готово, корабли расставлены!\n");
            ChangeMatrix(matrix, 'Y', 'О');
            ShowBoard(matrix, true);
        }
        static char[,] SetShip(char[,] matrix, int shipSize)
        {
            bool isTruePlace = false;
            Random rnd = new Random();
            while (!isTruePlace)
            {
                int rndX = rnd.Next(0, matrix.GetLength(0));
                int rndY = rnd.Next(0, matrix.GetLength(1));
                if (!CheckSymbol(matrix, rndX, rndY))
                {
                    continue;
                }
                Direction dir = GetSide(matrix, shipSize, rndX, rndY);
                if (dir != Direction.None )
                {
                    isTruePlace = true;
                    FillShip(matrix, shipSize, rndX, rndY, dir);
                    ShowBoard(matrix, true);
                }
            }

            return matrix;
        }
        static void FillShip(char[,] matrix, int shipSize, int x, int y, Direction dir)
        {

            if (dir == Direction.Up)
            {
                for (int i = x; i > x - shipSize; i--)
                {
                    FillCell(matrix, i, y);
                }
            }
            else if (dir == Direction.Down)
            {
                for (int i = x; i < x + shipSize; i++)
                {
                    FillCell(matrix, i, y);
                }
            }
            else if (dir == Direction.Left)
            {
                for (int j = y; j > y - shipSize; j--)
                {
                    FillCell(matrix, x, j);
                }
            }
            else
            {
                for (int j = y; j < y + shipSize; j++)
                {
                    FillCell(matrix, x, j);
                }
            }
        }
        static void FillCell(char[,] matrix, int x, int y)
        {
            matrix[x, y] = 'X';
            if (x >= 1)
            {
                if(CheckSymbol(matrix, x - 1, y))
                {
                    matrix[x - 1, y] = 'Y';
                }
                if (y >= 1)
                {
                    if (CheckSymbol(matrix, x - 1, y - 1))
                    {
                        matrix[x - 1, y - 1] = 'Y';
                    }
                }
            }
            if (y >= 1)
            {
                if (CheckSymbol(matrix, x, y - 1))
                {
                    matrix[x, y - 1] = 'Y';
                }
                if (x < matrix.GetLength(0) - 1)
                {
                    if (CheckSymbol(matrix, x + 1, y - 1))
                    {
                        matrix[x + 1, y - 1] = 'Y';
                    }
                }
            }
            if (x < matrix.GetLength(0) - 1)
            {
                if (CheckSymbol(matrix, x + 1, y))
                {
                     matrix[x + 1, y] = 'Y';
                }
                if (y < matrix.GetLength(0) - 1)
                {
                    if (CheckSymbol(matrix, x + 1, y + 1))
                    {
                        matrix[x + 1, y + 1] = 'Y';
                    }
                }
            }
            if (y < matrix.GetLength(1) - 1)
            {
                if (CheckSymbol(matrix, x, y + 1))
                {
                    matrix[x, y + 1] = 'Y';
                }
                if (x >= 1)
                {
                    if (CheckSymbol(matrix, x - 1, y + 1))
                    {
                        matrix[x - 1, y + 1] = 'Y';
                    }
                }
            }
        }
        static void ChangeMatrix(char[,] matrix, char a, char b)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == a)
                    {
                        matrix[i, j] = b;
                    }
                }
            }
        }

        static Direction GetSide(char[,] matrix, int shipSize, int x, int y)
        {
            int len = Enum.GetNames(typeof(Direction)).Length;

            int[] arr = { 1, 2, 3, 4 };
            Shuffle(arr); // Мешаем массив сторон, чтобы брыть разные стороны

            for (int i = 1; i < arr.Length; i++)
            {
                Direction dir = (Direction)arr[i];
                if (CheckDirection(matrix, shipSize, x, y, dir))
                {
                    return dir;
                }
            }
            return (Direction)0;
        }
        public static void Shuffle(int[] arr)
        {
            Random rand = new Random();

            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }
        }
        static bool CheckFreeLine(char[,] matrix, int shipSize, int x, int y, Direction dir)
        {
            if (dir == Direction.Up)
            {
                for (int i = x; i > x - shipSize; i--)
                {
                    i = i < 0 ? 0 : i;
                    if (!CheckSymbol(matrix, i, y))
                    {
                        return false;
                    }
                }
            }
            else if (dir == Direction.Down)
            {
                for (int i = x; i < x + shipSize; i++)
                {
                    i = i > matrix.GetLength(0) - 1 ? matrix.GetLength(0) - 1 : i;
                    if (!CheckSymbol(matrix, i, y))
                    {
                        return false;
                    }
                }
            }
            else if (dir == Direction.Left)
            {
                for (int j = y; j > y - shipSize; j--)
                {
                    j = j < 0 ? 0 : j;
                    if (!CheckSymbol(matrix, x, j))
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = y; j < y + shipSize; j++)
                {
                    j = j > matrix.GetLength(0) - 1 ? matrix.GetLength(1) - 1 : j;
                    if (!CheckSymbol(matrix, x, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool CheckDirection(char[,] matrix, int shipSize, int x, int y, Direction dir)
        {
            if (dir == Direction.Up)
            {
                if (CheckSize(matrix, x - shipSize))
                {
                    if (CheckFreeLine(matrix, shipSize, x, y, dir))
                    {
                        return true;
                    }
                }
            }else if(dir == Direction.Down)
            {
                if (CheckSize(matrix, x + shipSize))
                {
                    if (CheckFreeLine(matrix, shipSize, x, y, dir))
                    {
                        return true;
                    }
                }
            }
            else if (dir == Direction.Left)
            {
                if (CheckSize(matrix, y - shipSize))
                {
                    if (CheckFreeLine(matrix, shipSize, x, y, dir))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (CheckSize(matrix, y + shipSize))
                {
                    if (CheckFreeLine(matrix, shipSize, x, y, dir))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool CheckSymbol(char[,] matrix, int x, int y)
        {
            if(matrix[x,y] == 'О')
            {
                return true;
            }
            return false;
        }
        static bool CheckSize(char[,] matrix, int x)
        {
            if(x+1 >= 0 && x<= matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }
        static char[,] GenerateMatrix(int a, int b)
        {
            char[,] matrix = new char[a, b];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 'О';
                }
            }
            return matrix;
        }

        static void ShowBoard(char[,] matrix, bool is_color = false)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'Y' && is_color)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; // устанавливаем цвет
                        Console.Write($"{matrix[i, j]} ");
                        Console.ResetColor(); // сбрасываем в стандартный

                    }else if(matrix[i, j] == 'X' && is_color)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // устанавливаем цвет
                        Console.Write($"{matrix[i, j]} ");
                        Console.ResetColor(); // сбрасываем в стандартный

                    }
                    else
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                }
                Console.WriteLine();
            }
        }
        enum Direction
        {
            None,
            Up,
            Down,
            Left,
            Right
        }
    }

}
