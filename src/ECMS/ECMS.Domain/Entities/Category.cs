namespace ECMS.Domain.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
