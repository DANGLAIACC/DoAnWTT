using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiki.Controllers
{
    public class HomeController : Controller
    {
        private TIKIContext database = new TIKIContext();
        /// <summary>
        /// Return all book in database
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        { 
            return View("Index", database.BOOKs.ToList());
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

        public ActionResult Detail(int? id)
        {
            if (id == null) return Index();
            var record = (from b in database.BOOKs
                          where b.book_id == id
                          select b).First();
            return View("Detail",record);
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}