using Jose;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Order_Core.Services
{
    public class JwtService
    {
        public static int JwtExp { get; } = 45;

        public static string secret = "91appProjectOneJwtAuth";//加解密的key,如果不一樣會無法成功解密
        public static bool IsTokenExpired(string dateTime)
        {
            return Convert.ToDateTime(dateTime) < DateTime.Now;
        }
        public static string ReGenerateToken(string dateTime, string id)
        {
            if ((Convert.ToDateTime(dateTime) - DateTime.Now).TotalMinutes <= (JwtExp * 1 / 3.0))
            {
                return GenerateToken(id);
            }
            return null;
        }
        public static string GenerateToken(string memID)
        {
            Dictionary<string, Object> claim = new Dictionary<string, Object>();//payload 需透過token傳遞的資料
            claim.Add("MemID", memID);
            claim.Add("Exp", DateTime.Now.AddMinutes(Convert.ToInt32(JwtExp.ToString())).ToString());//Token 時效設定
            var payload = claim;
            var token = JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);//產生token
            return token;
        }
        public static void CreateJwtCookie(HttpResponse Response ,string jwtToken)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(JwtExp);
            Response.Cookies.Append("authentication", jwtToken, option);
        }
    }
}
