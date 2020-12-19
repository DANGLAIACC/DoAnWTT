using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tiki;

namespace Tiki.Areas.Admin.Controllers
{
    public class ORDERsController : Controller
    {
        private TikiContext db = new TikiContext();

        // GET: Admin/ORDERs
        public ActionResult Index()
        {
            var oRDERS = db.ORDERS.Include(o => o.CUSTOMER);
            return View(oRDERS.ToList());
        }
        // GET: Admin/ORDERs/pending
        // 0 là đang đợi duyệt
        public ActionResult Pending()
        {
            var oRDERS = db.ORDERS.Include(o => o.CUSTOMER).Where(m=> m.ord_status==0);
            return View("Index",oRDERS.ToList());
        }


        // GET: Admin/ORDERs/pending
        // 1 là đã xong
        public ActionResult Success()
        {
            var oRDERS = db.ORDERS.Include(o => o.CUSTOMER).Where(m => m.ord_status == 1);
            return View("Index", oRDERS.ToList());
        }

        // GET: Admin/ORDERs/pending
        // 2 là đã hủy
        public ActionResult Cancel()
        {
            var oRDERS = db.ORDERS.Include(o => o.CUSTOMER).Where(m => m.ord_status == 2);
            return View("Index", oRDERS.ToList());
        }

        // GET: Admin/ORDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDERS.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // GET: Admin/ORDERs/Create
        public ActionResult Create()
        {
            ViewBag.cus_urs = new SelectList(db.CUSTOMERs, "cus_usr", "cus_pwd");
            return View();
        }

        // POST: Admin/ORDERs/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ord_id,cus_urs,ord_timeup,ord_timedown,ord_address,ord_phone,ord_require")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.ORDERS.Add(oRDER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cus_urs = new SelectList(db.CUSTOMERs, "cus_usr", "cus_pwd", oRDER.cus_urs);
            return View(oRDER);
        }

        // GET: Admin/ORDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDERS.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.cus_urs = new SelectList(db.CUSTOMERs, "cus_usr", "cus_pwd", oRDER.cus_urs);
            return View(oRDER);
        }

        // POST: Admin/ORDERs/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ord_id,cus_urs,ord_timeup,ord_timedown,ord_address,ord_phone,ord_require")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cus_urs = new SelectList(db.CUSTOMERs, "cus_usr", "cus_pwd", oRDER.cus_urs);
            return View(oRDER);
        }

        // GET: Admin/ORDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDERS.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // POST: Admin/ORDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDER oRDER = db.ORDERS.Find(id);
            db.ORDERS.Remove(oRDER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
