namespace ECMS.Domain.Entities
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }

        //public ICollection<OrderItem> OrderItems { get; set; }
    }
}
