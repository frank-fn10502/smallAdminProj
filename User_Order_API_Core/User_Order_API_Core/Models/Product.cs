using System;
using System.Collections.Generic;

namespace User_Order_API_Core.Models
{
    public partial class Product
    {
        public Product()
        {
            Order = new HashSet<Order>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
