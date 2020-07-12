using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Order_API_Core.CustomModels;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Serverces;

namespace User_Order_API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _service;
        public MemberController(IMemberService service)
        {
            this._service = service;
        }

        [HttpPost("Login")]
        public ResultViewModel CheckLogin(MemberViewModel memberVM)
        {
            return _service.CheckLogin(memberVM);
        }
    }
}
