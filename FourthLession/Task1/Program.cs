using System;

namespace Task1
{
    //Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и
    //возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
    class Program
    {
        static void Main(string[] args)
        {
            //Это все же одномерный массив или же это массив содержащий несколько подмассивов, вопрос.
            (string firstName, string lastName, string patronimic)[] array = {
                ("Иван"     ,"Иванов"     ,"Иванович"),
                ("Александр","Александров","Александрович"),
                ("Николай"  ,"Николаев"   ,"Николаевич"),
                ("Евгений"  ,"Евгениев"   ,"Евгеевич")
            };
            Console.WriteLine($"Программа выведет {array.Length} строчки.\n");
            for (var i = 0; i < array.Length; i++)
                Console.WriteLine($"ФИО №{i + 1} : {GetFullName(array[i].firstName, array[i].lastName, array[i].patronimic)}");
        }
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} {lastName} {patronymic}";
        }

        //Если жестко знать сколько придет параметров и не заморачиваться с рповеркой кол-ва параметров, можно так
        //static string GetFullName(params string[] str)
        //{
        //    return $"{str[0]} {str[1]} {str[2]}";
        //}
    }
}
