using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public HashSet<Product> Products { get; set; }

        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
    }
}