﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tiki.Models;

namespace Tiki.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        private TikiContext _db = new TikiContext();

        /// <summary>
        /// Add to cart
        /// </summary>
        /// <param name="book_id"></param>
        /// <returns></returns>
        public ActionResult Add(int book_id)
        {
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel(_db.BOOKs.Find(book_id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                int index = findBookId(book_id);
                // chưa tồn tại trong giỏ hàng
                if (index == -1)
                    cart.Add(new CartModel(_db.BOOKs.Find(book_id), 1));
                else
                    cart[index].Quantity++;
                Session["cart"] = cart;
            }
            return View("Index");
        }
        public ActionResult Remove(int book_id)
        {
            int index = findBookId(book_id);
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            if (index != -1)
                cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Index");
        }
        /// <summary>
        /// Tìm mã sách trong danh sách giỏ hàng ở session
        /// </summary>
        /// <param name="book_id">mã sách cần tìm</param>
        /// <returns>-1 nếu ko thấy</returns>
        private int findBookId(int book_id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].b.book_id == book_id)
                    return i;
            }
            return -1;
        } 
        /// <summary>
        /// Giảm sách 1 đơn vị
        /// </summary>
        /// <param name="book_id"></param>
        /// <returns></returns>
        public ActionResult Abate(int book_id)
        {
            int index = findBookId(book_id);
            if (index != -1)
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                cart[index].Quantity--;
                Session["cart"] = cart;
            }
            return RedirectToAction("Index", "Cart");
        }
        /// <summary>
        /// Tăng sách 1 đơn vị
        /// </summary>
        /// <param name="book_id"></param>
        /// <returns></returns>
        public ActionResult Augment(int book_id)
        {
            int index = findBookId(book_id);
            if (index != -1)
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                cart[index].Quantity++;
                Session["cart"] = cart;
            }
            return RedirectToAction("Index","Cart");
        }

        public ActionResult Shipping()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Shipping(ORDER o)
        {
            ORDER o1 = new ORDER()
            {
                cus_urs = o.cus_urs,
                ord_timeup = DateTime.Now,
                ord_timedown = DateTime.Now,
                ord_phone = o.ord_phone,
                ord_address = o.ord_address,
                ord_require = o.ord_require
            };

            _db.ORDERS.Add(o1);
            _db.SaveChanges();
            
            int ord_id1 = o1.ord_id;

            List<CartModel> cart = (List<CartModel>)Session["cart"];
            foreach (var c in cart)
            {
                _db.ORDER_DETAIL.Add(new ORDER_DETAIL()
                {
                    ord_id = ord_id1,
                    book_id = c.b.book_id,
                    ord_price = c.b.book_sale,
                    ord_quantity = c.Quantity,
                });
            }
            _db.SaveChanges();
            Session["cart"] = null;
            return RedirectToAction("Index", "Book");
        }
    }
}