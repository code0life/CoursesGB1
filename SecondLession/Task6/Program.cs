using System;

namespace Task6
{
    enum DayOfWeek
    {
        Monday = 0b0000001,
        Tuesday = 0b0000010,
        Wednesday = 0b0000100,
        Thursday = 0b0001000,
        Friday = 0b0010000,
        Saturday = 0b0100000,
        Sunday = 0b1000000
    }
    class Program
    {
        //(*) Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру,
        //чтобы описать работу какого либо офиса. Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает
        //с понедельника до воскресенья и выведите его на экран консоли.
        static void Main(string[] args)
        {
            DayOfWeek office1Mask = DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday;
            DayOfWeek office2Mask = DayOfWeek.Monday | DayOfWeek.Tuesday | DayOfWeek.Wednesday | DayOfWeek.Thursday | DayOfWeek.Friday | 
                DayOfWeek.Saturday | DayOfWeek.Sunday;

            Console.WriteLine("Введите через запятую дни недели на английском. Мы подберём вам подходящий офис.");
            foreach (string dayName in Enum.GetNames(typeof(DayOfWeek)))
            {
                Console.Write("{0} ", dayName, Enum.Parse(typeof(DayOfWeek), dayName));
            }
            Console.WriteLine("\n");
            string input = Console.ReadLine();

            DayOfWeek work1Office = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input);
            DayOfWeek work2Office = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input);

            DayOfWeek personForOffice1 = work1Office & office1Mask;
            DayOfWeek personForOffice2 = work2Office & office2Mask;

            if(personForOffice1 == work1Office)
            {
                Console.WriteLine("Ты можешь работать у нас в 1 офисе!");
            }
            else if (personForOffice2 == work2Office)
            {
                Console.WriteLine("Ты можешь работать у нас во 2 офисе!");
            }
            else
            {
                Console.WriteLine("Извините, у нас нет подходящего для вас офиса.");
            }
        }
    }
}
