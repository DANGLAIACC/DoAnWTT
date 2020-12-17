using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tiki.Models
{
    public class CartModel
    {
        public BOOK b = new BOOK();
        public int Quantity { get; set; }

        public CartModel(BOOK b, int quantity)
        {
            this.b = b;
            this.Quantity = quantity;
        }
        public CartModel() { }

    }
}