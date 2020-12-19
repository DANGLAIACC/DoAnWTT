using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiki.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        TikiContext db = new TikiContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(EMPLOYEE e)
        {
            var record = (from c in db.EMPLOYEEs
                          where c.emp_usr == e.emp_usr && c.emp_pwd== e.emp_pwd
                          select c).FirstOrDefault();
            if (record != null)
            {
                Session["admininfo"] = record;
                return RedirectToAction("Index", "User",
                        new { Area = "Admin" });
            }
            else 
                return Redirect(Request.UrlReferrer.ToString()); 
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