using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tiki.ViewModel;
namespace Tiki.Controllers
{
    public class HomeController : Controller
    {
        private TIKIContext database = new TIKIContext(); 
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

        public ActionResult Index()
        { 
            return View("Index", database.BOOKs.Include("EVALUATEs").ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) return Index(); 

            var query = database.BOOKs
                .Include("AUTHOR")
                .Include("CATEGORY")
                .Include("SHOP")
                .Include("PUBLISHER")
                .Include("EVALUATEs")
                .Where(b=>b.book_id==id)
                .FirstOrDefault();

            return View("Detail",query);
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}