namespace CardService.Models
{
    public class CardDTO
    {
        public long Id { get; set; }
        public string Number { get; set; } = String.Empty;
        public PaymentSystem PaymentSystem { get; set; }
        public string Bank { get; set; } = String.Empty;
        public DateTime ValidThru { get; set; }
        public string CardOwnerFirstName { get; set; } = string.Empty;
        public string CardOwnerLastName { get; set; } = string.Empty;
    }
}
