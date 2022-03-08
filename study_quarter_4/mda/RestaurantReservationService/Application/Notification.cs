namespace RestaurantReservationService.Application
{
    public class Notification
    {
        public void Send(string message)
        {
            var delay = 2000;

            Task.Run(async () => {

                await Task.Delay(delay);

                Console.WriteLine(message);
            });
        }
    }
}
