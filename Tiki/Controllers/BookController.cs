using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiki.Controllers
{
    public class BookController : Controller
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
            return View(database.BOOKs.Include("EVALUATEs").ToList());
        }

        public ActionResult Detail(int? book_id)
        {
            if (book_id == null) return Index();

            var query = database.BOOKs
                .Include("AUTHOR")
                .Include("CATEGORY")
                .Include("SHOP")
                .Include("PUBLISHER")
                .Include("EVALUATEs")
                .Where(b => b.book_id == book_id)
                .FirstOrDefault();

            return View("Detail", query);
        }
    }
}