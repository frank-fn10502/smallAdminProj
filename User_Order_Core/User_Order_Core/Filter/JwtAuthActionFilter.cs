using Jose;
using Microsoft.AspNetCore.Http;
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
        private void SetRedirect(ActionExecutingContext context)
        {
            context.Result = new RedirectToRouteResult(
            new RouteValueDictionary
            {
                    { "controller", "Home" },
                    { "action", "Login" }
            });
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var secret = JwtService.secret;
            var request = context.HttpContext.Request;
            string auth;
            if (!request.Cookies.TryGetValue("authentication", out auth))
            {
                SetRedirect(context);
            }
            else
            {
                try
                {
                    var jwtObject = Jose.JWT.Decode<Dictionary<string, Object>>(
                        auth, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);
                    if (JwtService.IsTokenExpired(jwtObject["Exp"].ToString()))
                    {
                        SetRedirect(context);
                    }
                    else
                    {
                        string jwtToken = JwtService.ReGenerateToken(jwtObject["Exp"].ToString() , jwtObject["MemID"].ToString());
                        if(jwtToken != null)
                        {
                            JwtService.CreateJwtCookie(context.HttpContext.Response, jwtToken);
                        }
                    }
                }
                catch(Exception e)
                {
                    SetRedirect(context);
                }
            }
        }
    }
}
