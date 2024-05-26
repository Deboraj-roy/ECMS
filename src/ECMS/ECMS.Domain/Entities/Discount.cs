namespace ECMS.Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }

        public decimal DiscountPercentage { get; set; }

        //public ICollection<Order> Orders { get; set; }
    }
}
