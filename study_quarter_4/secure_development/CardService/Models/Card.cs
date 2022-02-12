namespace CardService.Models
{
    public class Card
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public string PaymentSystem { get; set; } = String.Empty;
        public string Bank { get; set; } = String.Empty;
        public DateTime ValidThru { get; set; }
        public string CardOwner { get; set; } = String.Empty;
    }
}
