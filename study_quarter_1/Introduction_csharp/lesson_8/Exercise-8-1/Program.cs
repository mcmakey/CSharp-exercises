// Введение в C#. Урок 8. Практическое задание 1.
// Создать консольное приложение, которое при старте выводит приветствие,
// записанное в настройках приложения (application-scope).
// Запросить у пользователя имя, возраст и род деятельности, а затем сохранить данные в настройках.
// При следующем запуске отобразить эти сведения. Задать приложению версию и описание.


using System;
using System.Configuration;

namespace Exercise_8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeting();

            var user = GetPersonInfo();
        }

        static void Greeting()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                Console.WriteLine(appSettings["greeting"]);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine($"Произошла ошибка чтения настроек");
                Console.WriteLine($"Но все равно, привет, пользователь");
            }
        }

        static (string name, string age, string activities) GetPersonInfo()
        {
            Console.WriteLine("Ваше имя:");
            var userName = Console.ReadLine();

            Console.WriteLine("Ваш возраст:");
            var userAge = Console.ReadLine();

            Console.WriteLine("Ваш род деятельности:");
            var userActivities = Console.ReadLine();

            return (name: userName, age: userAge, activities: userActivities);
        }
    }
}
