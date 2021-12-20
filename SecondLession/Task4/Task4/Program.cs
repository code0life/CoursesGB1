using System;
using System.Collections.Generic;
using System.Threading;

namespace Task4
{
    //Для полного закрепления понимания простых типов найдите любой чек, либо фотографию этого чека в интернете и схематично нарисуйте его в консоли,
    //только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок) подставляйте переменные, которые
    //были заранее заготовлены до вывода на консоль.
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Идет печать чека...");
            Thread.Sleep(1000);
            Console.WriteLine("ТЫР ТЫР ТЫР ТЫР....\n");
            Thread.Sleep(1000);
            Paper p = new Paper();
            p.nameCompany = $"ООО {"СПАР"} Миддл Волга";
            p.adressShop = "г. Пенза, ул. Кижеватова, д.8";
            p.nameShop = "SPAR";
            p.postCode = 440031;
            p.numberPaper = "5127 0501/004/029";
            p.paperDateTime = new DateTime(2021, 12, 16, 21, 45, 15);
            p.productList.Add(new Product(916, "Конфеты ассорти ШОКО", 0.12F, 429.00F));
            p.productList.Add(new Product(1243, "Булочка чесночная", 1, 17.90F));
            p.productList.Add(new Product(1308, "Слойка с ванильным кремом", 3, 21.23F));

            p.rnKKT = 0001526858005452;
            p.znKKT = 5736185049272649;
            p.fn = 387593030958749;
            p.fd = 155930;
            p.fp = 2422385856;

            p.Show(p.nameCompany, p.adressShop, p.nameShop, p.postCode, p.numberPaper, p.paperDateTime, p.productList, p.rnKKT, p.znKKT, p.fn, p.fd, p.fp);
        }
    }

    class Paper
    {
        public string nameCompany, adressShop, nameShop, numberPaper;
        public int postCode;
        public long rnKKT, znKKT, fn, fd, fp;
        public DateTime paperDateTime;
        public List<Product> productList = new List<Product>();

        public void Show(string nameCompany, string adressShop, string nameShop, int postCode, string numberPaper, DateTime paperDateTime, 
            List<Product> productList, long rnKKT, long znKKT, long fn, long fd, long fp)
        {
            Line();
            Console.WriteLine($"{nameCompany}\n{adressShop}\n{nameShop} {postCode}\nКассовый чек {numberPaper} {paperDateTime}");
            Line();
            float sum = 0;
            if(productList.Count > 0)
            {
                int c = 0;
                while (c < productList.Count)
                {
                    productList[c].Show(productList[c]);
                    sum = sum + productList[c].count * productList[c].price;
                    c = c + 1;
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Список продуктов пуст!");
            }
            Line();
            Console.WriteLine($"ИТОГ: {Math.Round(sum, 2)}");
            Line();
            Console.WriteLine($"СУММА НДС 20%      {Math.Round((sum / 100) * 20, 2)}");
            Line();
            Console.WriteLine($"РН ККТ:{rnKKT}");
            Console.WriteLine($"ЗН ККТ:{znKKT}");
            Console.WriteLine($"ФН:{fn}");
            Console.WriteLine($"ПРИХОД {paperDateTime}");
            Console.WriteLine($"ИНН: 5258056944");
            Console.WriteLine($"Сайт ФНС: www.nalog.ru");
            Console.WriteLine($"СНО:ОСН");
            Console.WriteLine($"ФД:{fd}    ФП:{fp}");
        }

        public void Line()
        {
            Console.WriteLine("----------------------------------------------");
        }
    }

    class Product
    {
        public string name;
        public float count, price, finalPrice;
        public int code;
        public Product(int _code, string _name, float _count, float _price)
        {
            code = _code;
            name = _name;
            count = _count;
            price = _price;
            finalPrice = count*price;
        }

        public void Show(Product p)
        {
            Console.WriteLine($"{p.code} {p.name}\n{p.count} X {p.price} = {finalPrice}");
        }



    }

}
