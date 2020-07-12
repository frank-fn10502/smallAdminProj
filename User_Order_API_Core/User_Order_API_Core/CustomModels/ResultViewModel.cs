using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Order_API_Core.CustomModels
{
    public class ResultViewModel
    {
        public bool isSuccess { get; set; }
        public object Data { get; set; }
        public string Exception { get; set; }
    }
}
