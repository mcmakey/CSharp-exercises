using PumpClient.PumpServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpClient
{
    public class CallbackHandler : IPumpServiceCallback
    {
        public void UpdateStatistics(StatisticsService statisticsService)
        {
            Console.Clear();
            Console.WriteLine("Обновление по статистике выполнения скрипта");
            Console.WriteLine($"Всего     тактов: {statisticsService.AllTacts}");
            Console.WriteLine($"Успешных  тактов: {statisticsService.SuccessTacts}");
            Console.WriteLine($"Ошибочных тактов: {statisticsService.ErrorTacts}");
        }
    }
}
