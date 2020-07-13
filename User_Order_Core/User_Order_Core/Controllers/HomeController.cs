using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using User_Order_Core.Models;
using User_Order_Core.Services;
using User_Order_Core.ViewModels;
using User_Order_Core.Filter;

namespace User_Order_Core.Controllers
{
    public class HomeController : Controller
    {
        private static string endpoint = "https://localhost:44364/api";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        [TypeFilter(typeof(JwtAuthActionFilter))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TryLogin([FromBody] LoginViewModel vm)
        {
            vm.account = HttpUtility.HtmlEncode(vm.account);
            vm.password = HttpUtility.HtmlEncode(vm.password);

            var client = new HttpClient();
            var endpointurl = endpoint + "/Member/Login";
            var json = JsonConvert.SerializeObject(vm);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync(endpointurl, content).Result;

            var resultJSON = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<APIResult>(resultJSON);

            //create cookie
            if(result.isSuccess)
            {
                var jwtToken = JwtService.GenerateToken((string)result.Data);

                JwtService.CreateJwtCookie(Response ,jwtToken);
            }

            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
