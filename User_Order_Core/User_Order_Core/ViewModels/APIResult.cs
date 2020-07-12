using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Order_Core.ViewModels
{
    public class APIResult
    {
        public bool isSuccess { get; set; }
        public string Exception { get; set; }
        public object Data { get; set; }
    }
}
