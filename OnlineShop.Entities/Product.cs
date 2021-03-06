using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductCode { get; set; }
        public int MinimumStock { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public HashSet<WarehouseItem> WarehouseItems { get; set; }

        public Product()
        {
            WarehouseItems = new HashSet<WarehouseItem>();
        }
    } 
}