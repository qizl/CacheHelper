using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheHelper.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CacheHelper.Initialize(HttpContext.Cache);

            CacheHelper.Insert("a", 1);
            CacheHelper.Insert("a", 2);
            CacheHelper.Insert("b", 3);
            CacheHelper.Insert("c", 4);
            CacheHelper.Insert("d", 5);

            object pi = CacheHelper.Get("a");
            List<string> keys = CacheHelper.GetKeys();
            CacheHelper.RemoveAll();

            return View();
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