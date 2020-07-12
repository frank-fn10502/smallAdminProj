using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Order_API_Core.CustomModels.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
