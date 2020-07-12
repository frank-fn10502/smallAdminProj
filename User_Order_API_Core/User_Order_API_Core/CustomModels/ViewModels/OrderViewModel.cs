using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Order_API_Core.Models;

namespace User_Order_API_Core.CustomModels.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Pname { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public short Status { get; set; }
    }
}
