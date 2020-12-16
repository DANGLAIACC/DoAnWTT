using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiki.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Notifications()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult Docs()
        {
            return View();
        }
        public ActionResult Chart()
        {
            return View();
        }
        public ActionResult Setting()
        {
            return View();
        }

        public ActionResult Account()
        {
            return View();
        }
    }
}