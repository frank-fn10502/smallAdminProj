using System;
using System.Collections.Generic;

namespace User_Order_API_Core.Models
{
    public partial class Order
    {
        public Order()
        {
            ShippingOrder = new HashSet<ShippingOrder>();
        }

        public string Id { get; set; }
        public string Pid { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public short Status { get; set; }

        public virtual Product P { get; set; }
        public virtual ICollection<ShippingOrder> ShippingOrder { get; set; }
    }
}
