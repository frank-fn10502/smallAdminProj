using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Order_API_Core.CustomModels.ViewModels
{
    public class UpdateOrderViewModel
    {
        public string Id { get; set; }
        public short Status { get; set; }
    }
}
