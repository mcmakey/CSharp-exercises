// ASP.NET Core Web API микросервисы
// Урок 1

// Написать свой контроллер и методы в нем, которые бы предоставляли следующую функциональность
// 1. Возможность сохранить температуру в указанное время
// 2. Возможность отредактировать показатель температуры в указанное время
// 3. Возможность удалить показатель температуры в указанный промежуток времени
// 4. Возможность прочитать список показателей температуры за указанный промежуток времени

// Валидные данные для температуры - строка вида "число"
// Валидные данные для времени - строка вида "чч:мм:сс"


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Exercise_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
