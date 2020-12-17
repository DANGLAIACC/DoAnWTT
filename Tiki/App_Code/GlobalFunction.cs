using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tiki.App_Code
{
    public class GlobalFunction
    {
        public static string FormatPrice(int? price)
        {
            return string.Format("{0:#,##0}đ", price).Replace(",", ".");
        }
        public static string RenderStar(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += "<i class='icomoon icomoon-star'></i>";
            }
            for (int i = 0; i < 5 - count; i++)
            {
                result += "<i class='icomoon icomoon-star-2'></i>";
            }
            return result;
        }
    }
}