namespace ECMS.Domain.Entities
{
    public class Promotion { 
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal DiscountAmount { get; set; }

    //public ICollection<Order> Orders { get; set; }
}
}
