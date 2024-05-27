﻿namespace ECMS.Domain.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InventoryLevel { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        //public Category Category { get; set; }

        //public ICollection<Order> Orders { get; set; }
    }
}
