namespace ToysPayment.API.Models.Entities
{
    public class CardInfo : BaseEntity
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public string CardHolder { get; set; }
    }
}
