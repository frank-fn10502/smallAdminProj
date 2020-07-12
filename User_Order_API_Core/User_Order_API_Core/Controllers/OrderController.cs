using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using User_Order_API_Core.CustomModels;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Serverces;

namespace User_Order_API_Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ResultViewModel Get()
        {
            return _service.GetAllFullOrder();
        }

        [HttpPost]
        public ResultViewModel Post(IEnumerable<OrderViewModel> vms)
        {
            return _service.UpdateOrder(vms);
        }
    }
}
