using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Order_Core.Services;

namespace User_Order_Core.Filter
{
    public class JwtAuthActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
            var secret = JwtService.secret;
            var request = context.HttpContext.Request;
            string auth;
            if (!request.Cookies.TryGetValue("authentication", out auth))
            {
                context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Home" },
                    { "action", "Login" }
                });
            }
            else
            {
                try
                {
                    var jwtObject = Jose.JWT.Decode<Dictionary<string, Object>>(
                        auth, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);
                    if (new JwtService().IsTokenExpired(jwtObject["Exp"].ToString()))
                    {
                        context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                        { "controller", "Home" },
                        { "action", "Login" }
                        });
                        //redirect
                    }
                }
                catch(Exception e)
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                            { "controller", "Home" },
                            { "action", "Login" }
                        });
                }
            }
        }
    }
}
