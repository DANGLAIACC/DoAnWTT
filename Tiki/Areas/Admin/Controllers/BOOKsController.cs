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
    public class BOOKsController : Controller
    {
        private TikiContext db = new TikiContext();

        // GET: Admin/BOOKs
        public ActionResult Index()
        {
            var bOOKs = db.BOOKs.Include(b => b.AUTHOR).Include(b => b.CATEGORY).Include(b => b.COMPANY).Include(b => b.PUBLISHER).Include(b => b.SHOP);
            return View(bOOKs.ToList());
        }

        // GET: Admin/BOOKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // GET: Admin/BOOKs/Create
        public ActionResult Create()
        {
            ViewBag.aut_id = new SelectList(db.AUTHORs, "aut_id", "aut_name");
            ViewBag.cat_id = new SelectList(db.CATEGORies, "cat_id", "cat_name");
            ViewBag.com_id = new SelectList(db.COMPANies, "com_id", "com_name");
            ViewBag.pub_id = new SelectList(db.PUBLISHERs, "pub_id", "pub_name");
            ViewBag.shop_id = new SelectList(db.SHOPs, "shop_id", "shop_name");
            return View();
        }

        // POST: Admin/BOOKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book_id,book_name,book_img,book_price,book_sale,public_date,width,height,page_number,cover_type,article,translator,aut_id,com_id,pub_id,cat_id,shop_id")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.BOOKs.Add(bOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aut_id = new SelectList(db.AUTHORs, "aut_id", "aut_name", bOOK.aut_id);
            ViewBag.cat_id = new SelectList(db.CATEGORies, "cat_id", "cat_name", bOOK.cat_id);
            ViewBag.com_id = new SelectList(db.COMPANies, "com_id", "com_name", bOOK.com_id);
            ViewBag.pub_id = new SelectList(db.PUBLISHERs, "pub_id", "pub_name", bOOK.pub_id);
            ViewBag.shop_id = new SelectList(db.SHOPs, "shop_id", "shop_name", bOOK.shop_id);
            return View(bOOK);
        }

        // GET: Admin/BOOKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.aut_id = new SelectList(db.AUTHORs, "aut_id", "aut_name", bOOK.aut_id);
            ViewBag.cat_id = new SelectList(db.CATEGORies, "cat_id", "cat_name", bOOK.cat_id);
            ViewBag.com_id = new SelectList(db.COMPANies, "com_id", "com_name", bOOK.com_id);
            ViewBag.pub_id = new SelectList(db.PUBLISHERs, "pub_id", "pub_name", bOOK.pub_id);
            ViewBag.shop_id = new SelectList(db.SHOPs, "shop_id", "shop_name", bOOK.shop_id);
            return View(bOOK);
        }

        // POST: Admin/BOOKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_id,book_name,book_img,book_price,book_sale,public_date,width,height,page_number,cover_type,article,translator,aut_id,com_id,pub_id,cat_id,shop_id")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aut_id = new SelectList(db.AUTHORs, "aut_id", "aut_name", bOOK.aut_id);
            ViewBag.cat_id = new SelectList(db.CATEGORies, "cat_id", "cat_name", bOOK.cat_id);
            ViewBag.com_id = new SelectList(db.COMPANies, "com_id", "com_name", bOOK.com_id);
            ViewBag.pub_id = new SelectList(db.PUBLISHERs, "pub_id", "pub_name", bOOK.pub_id);
            ViewBag.shop_id = new SelectList(db.SHOPs, "shop_id", "shop_name", bOOK.shop_id);
            return View(bOOK);
        }

        // GET: Admin/BOOKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: Admin/BOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK bOOK = db.BOOKs.Find(id);
            db.BOOKs.Remove(bOOK);
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
