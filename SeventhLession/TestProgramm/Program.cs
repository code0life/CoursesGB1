using System;

namespace TestProgramm
{
    class Program
    {

        //1. Написать любое приложение, произвести его сборку с помощью MSBuild - Done
        //осуществить декомпиляцию с помощью dotPeek - Done
        //внести правки в программный код и пересобрать приложение - Done.
        //Итог: DecompileDotPeek

        //2. (*) выполнить задание 1, используя вместо dotPeek инструменты ildasm/ilasm.
        //ildasm - Done (отредактированный файл Dump в папке Release)
        //ilasm - UnDone (отредактированный файл Dump.exe в папке Release. Вот только не работает, не пойму почему. Ошибок при компиляции из .il в консоле нет. Что-то с версиями System.Runtime)

        static void Main(string[] args)
        {
            string answer = "admin";
            Console.WriteLine("Enter login:");
            string input = Console.ReadLine();
            if (input == answer)
            {
                Console.WriteLine($"\nWELCOME TO HELL, {input}!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"\nERROR! login {input} not found!");
                Console.ReadLine();
            }
        }
    }
}
