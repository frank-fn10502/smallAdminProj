using System;
using System.Collections.Generic;

namespace User_Order_API_Core.Models
{
    public partial class ShippingOrder
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDateTime { get; set; }

        public virtual Order Order { get; set; }
    }
}
