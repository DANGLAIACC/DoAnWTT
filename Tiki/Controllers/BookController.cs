using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiki.Controllers
{
    public class BookController : Controller
    {
        private TikiContext database = new TikiContext();
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
            ViewBag.Title = "Nhà sách Tiki";
            return View(database.BOOKs.Include("EVALUATEs").ToList());
        }
        public ActionResult GetBooksByCompany(int com_id)
        {
            var record = database.COMPANies.Where(c => c.com_id == com_id).FirstOrDefault();
            ViewBag.Title = "Sách của công ty "+record.com_name;

            return View("Index", database.BOOKs.Include("EVALUATEs").Where(b => b.com_id == com_id).ToList());
        }
        public ActionResult GetBooksByAuthor(int aut_id)
        {
            var record = database.AUTHORs.Where(c => c.aut_id== aut_id).FirstOrDefault();
            ViewBag.Title = "Sách của tác giả " + record.aut_name;

            return View("Index", database.BOOKs.Include("EVALUATEs").Where(b => b.aut_id == aut_id).ToList());
        }
        public ActionResult GetCompanies()
        {
            return PartialView("_Companies", database.COMPANies.OrderBy(x => x.com_name));
        }
        public ActionResult GetAuthors()
        {
            return PartialView("_Authors", database.AUTHORs.OrderBy(x => x.aut_name));
        }

        public ActionResult Detail(int? book_id)
        {
            if (book_id == null) return RedirectToAction("Index", "Book");

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