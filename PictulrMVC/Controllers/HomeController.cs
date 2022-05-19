using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictulrMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Learn More about how to use Pictulr";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "plz dont contact me lul";

            return View();
        }
    }
}