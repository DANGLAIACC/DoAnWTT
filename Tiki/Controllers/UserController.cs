using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiki.Controllers
{
    public class UserController : Controller
    {
        private TikiContext _db = new TikiContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(CUSTOMER d)
        {
            var record = (from c in _db.CUSTOMERs
                          where c.cus_usr == d.cus_usr && c.cus_pwd == d.cus_pwd
                          select c).FirstOrDefault();
            if (record != null)
                Session["userinfo"] = record;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Logout()
        {
            Session["userinfo"] = null;
            return Redirect("/");
        }
    }
}