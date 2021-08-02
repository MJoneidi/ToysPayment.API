namespace ToysPayment.API.Models
{
    public class CustomerMembership
    {
        public decimal DiscountPercentage { get; set; }
        public BuyPoint BuyPoint { get; set; }
    }


    public class BuyPoint
    {
        public decimal Point { get; set; }
        public decimal Amount { get; set; }
    }
}
