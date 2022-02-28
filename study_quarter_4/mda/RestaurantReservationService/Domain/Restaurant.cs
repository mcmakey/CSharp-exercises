using RestaurantReservationService.Application;

namespace RestaurantReservationService
{
    internal class Restaurant
    {
        private readonly List<Table> _tables = new();
        private readonly Notification _notification = new Notification();

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

                await Task.Delay(1000 * 5); // Задержка

                table?.setState(TableState.Booked);

                var messageBookingResult = table is null
                    ? "Уведомление: К сожалению все столики заняты"
                    : $"Уведомление: Готово! Ваш столик номер {table.Id}";

                _notification.Send(messageBookingResult);
            });
        }

        public void CancelBookingTable(int tableId)
        {
            var table = GetTableById(tableId);

            Thread.Sleep(1000 * 5); // Задержка

            table?.setState(TableState.Free);

            Console.WriteLine($"Бронь со столика {table?.Id} снята");
        }

        public void CancelBookingTableAsync(int tableId)
        {
            Task.Run( async () =>
            {
                var table = GetTableById(tableId);

                await Task.Delay(1000 * 5); // Задержка

                table?.setState(TableState.Free);

                var messageCancelBookingResult = $"Бронь со столика {table?.Id} снята";

                _notification.Send(messageCancelBookingResult);
            });
        }

        private Table GetTableById(int id)
        {
            return _tables.FirstOrDefault(t => t.Id == id); // TODO: handle null
        }
    }
}
