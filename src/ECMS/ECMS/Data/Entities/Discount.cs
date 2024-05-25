namespace ECMS.Data.Entites
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountPercentage { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
