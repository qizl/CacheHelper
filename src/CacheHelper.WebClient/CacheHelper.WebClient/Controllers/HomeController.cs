using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.EnjoyCodes.CacheHelper.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CacheHelper.InsertAbsoluteExpiration("a", 1);
            CacheHelper.InsertAbsoluteExpiration("a", 2);
            CacheHelper.InsertAbsoluteExpiration("b", 3);
            CacheHelper.InsertAbsoluteExpiration("c", 4);
            CacheHelper.InsertAbsoluteExpiration("d", 5);
            object a = CacheHelper.Get("a");

            CacheHelper.InsertSlidingExpiration("e", 6, 5);
            object e = CacheHelper.Get("e");

            string key = User.Identity.Name + "_" + "f";
            CacheHelper.Insert(key, new List<int>() { 1, 2, 3 });
            object keyF = CacheHelper.Get(key);

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