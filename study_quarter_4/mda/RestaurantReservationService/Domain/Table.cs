namespace RestaurantReservationService.Domain
{
    public class Table
    {
        public TableState State { get; private set; }
        public int SeatsCount { get; }
        public int Id { get; }

        Random rnd = new Random();

        public Table(int id)
        {
            Id = id;
            State = TableState.Free;
            SeatsCount = rnd.Next(2, 5);
        }

        public bool setState(TableState state)
        {
            if (state == State)
            {
                return false;
            }

            State = state;
            return true;
        } 
    }
}
