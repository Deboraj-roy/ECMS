namespace ECMS.Domain.Entities
{
    public class Inventory : IEntity<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //public Product Product { get; set; }
    }
}
