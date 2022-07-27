using Jose;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var sso = new SsoUtil.WinSsoUtil();
            var test = sso.GetUserInfo("http://hisweb.hosp.ncku/WebSiteSSO"
                , "exentric", "Exnckuh@4767");
            var test2 = sso.GetRoleList("http://hisweb.hosp.ncku/WebSiteSSO"
                , "exentric", "Exnckuh@4767");
            return View();
        }

        public object Test(string Username, string Password)
        {
            var secret = "wellwindJtwDemo";

            // TODO: 真實世界檢查帳號密碼
            if (Username == "wellwind123" && Password == "12345")
            {
                var payload = new JwtAuthObject()
                {
                    Id = "wellwind"
                };

                return new
                {
                    Result = true,
                    token = JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS256)
                };
            }
            else
            {
                throw new UnauthorizedAccessException("帳號密碼錯誤");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class JwtAuthObject
    {
        public JwtAuthObject()
        {
        }

        public string Id { get; set; }
    }
}