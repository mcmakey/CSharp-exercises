namespace RestaurantReservationService.Domain
{
    public class Table
    {
        public TableState State { get; private set; }
        public int SeatsCount { get; }
        public int Id { get; }

        private readonly Random _rnd = new Random();

        public Table(int id)
        {
            Id = id;
            State = TableState.Free;
            SeatsCount = _rnd.Next(2, 5);
        }

        public bool SetState(TableState state)
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
