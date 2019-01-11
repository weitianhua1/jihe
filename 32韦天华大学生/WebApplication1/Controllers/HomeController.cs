using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.common;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = WeatherHelper.GetWeatherByCityName("柳州");
            return View(data);
        }

        public JsonResult getweather(string city)
        {
            var data = WeatherHelper.GetWeatherByCityName(city);
            var json = Json(data);
            return json;
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
}