﻿namespace InventoryService.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
