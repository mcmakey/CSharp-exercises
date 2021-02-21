// Введение в C#. Урок 2. Практическое задание 4.
//
// Для полного закрепления понимания простых типов найдите любой чек,
// либо фотографию этого чека в интернете и схематично нарисуйте его в консоли,
// только за место динамических, по вашему мнению, данных (это может быть дата,
// название магазина, сумма покупок) подставляйте переменные, 
// которые были заранее заготовлены до вывода на консоль.

using System;

namespace exercize_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string storeName = "Магазин Чикага";
            string storeInn = "232323232323";

            string productsOneName = "Мандарины";
            decimal productOneCost = 89;

            string productsTwoName = "Шампанское";
            decimal productTwoCost = 300;

            string total = "Итого";
            decimal totalCost = productOneCost + productTwoCost;

            string currency = "руб.";

            DateTime datePurchase = new DateTime(2021, 12, 31, 23, 30, 52);

            Console.WriteLine($"        {storeName}    ");
            Console.WriteLine($"       ИНН{storeInn}  ");
            Console.WriteLine(("").PadRight(30, '*'));
            Console.WriteLine($"{productsOneName}:\t{productOneCost,10} {currency}");
            Console.WriteLine($"{productsTwoName}:\t{productTwoCost,10} {currency}");
            Console.WriteLine(("").PadRight(30, '-'));
            Console.WriteLine($"{total}:\t{totalCost,18} {currency}");
            Console.WriteLine(("").PadRight(30, '*'));
            Console.WriteLine($"Дата:  {datePurchase}");
        }
    }
}
