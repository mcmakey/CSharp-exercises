
namespace RestaurantReservationService
{
    internal class Restaurant
    {
        private readonly List<Table> _tables = new();

        public Restaurant()
        {
            for (ushort i = 1; i <= 10; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секундочку я подберу столик и подвержду вашу бронь, оставайтесь на линии");

            var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == TableState.Free);

            Thread.Sleep(1000 * 5); // Задержка

            Console.WriteLine(table is null
                ? "К сожалению все столики заняты"
                : $"Готово! Ваш столик номер {table.Id}");
        }

        public void BookFreeTableAsync(int countOfPersons)
        {
            Console.WriteLine("Добрый день! Подождите секундочку я подберу столик и подвержду вашу бронь. Вам придет сообщение");

            Task.Run( async () => 
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > countOfPersons && t.State == TableState.Free);

                await Task.Delay(1000 * 5);

                table?.setState(TableState.Booked);

                Console.WriteLine(table is null
                    ? "Уведомление: К сожалению все столики заняты"
                    : $"Уведомление: Готово! Ваш столик номер {table.Id}");
            });
        }
    }
}
