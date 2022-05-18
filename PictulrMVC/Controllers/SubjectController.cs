using Pictulr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PictulrMVC.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            var model = new ListSubjects[0];
            return View(model);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }
    }
}