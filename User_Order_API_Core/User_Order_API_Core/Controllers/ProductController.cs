using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User_Order_API_Core.CustomModels;
using User_Order_API_Core.Serverces;

namespace User_Order_API_Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id?}")]
        public ResultViewModel Get(string id)
        {
            return _service.GetProductById(id);
        }
    }
}
