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
        const string APP_SETTING_GREETING_KEY = "greeting";
        const string APP_SETTING_USER_NAME_KEY = "userName";
        const string APP_SETTING_USER_AGE_KEY = "userAge";
        const string APP_SETTING_USER_ACTIVITIES_KEY = "userActivities";

        static void Main(string[] args)
        {

            Greeting();

            DisplayAppSettings();

            (string name, string age, string activities) user = GetPersonInfo();
            
            UpdateAppSettings(APP_SETTING_USER_NAME_KEY, user.name);
            UpdateAppSettings(APP_SETTING_USER_AGE_KEY, user.age);
            UpdateAppSettings(APP_SETTING_USER_ACTIVITIES_KEY, user.activities);
        }

        static void Greeting()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                Console.WriteLine(appSettings[APP_SETTING_GREETING_KEY]);
                Console.WriteLine();
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine($"Произошла ошибка чтения настроек");
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

        static void UpdateAppSettings (string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine($"Произошла ошибка записи настроек");
            }
        }

        static void DisplayAppSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                foreach (var key in appSettings.AllKeys)
                {
                    if ( key != APP_SETTING_GREETING_KEY)
                    {
                        Console.Write($"{appSettings[key]} ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine($"Произошла ошибка чтения настроек");
            }
        }
    }
}
