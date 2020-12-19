using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tiki.App_Code
{
    public class GlobalFunction
    {
        /// <summary>
        /// Định dạng tiền tệ
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string FormatPrice(int? price)
        {
            return string.Format("{0:#,##0}đ", price).Replace(",", ".");
        }
        /// <summary>
        /// tạo chuỗi ngôi sao đánh giá từ danh sách bình luận
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static string RenderStarByListEva(ICollection<EVALUATE> lst)
        {
            int tong = 0;
            foreach (var e in lst)
                tong += e.eva_rate;

            return RenderStarByCount((int)Math.Floor(tong * 1.0 / lst.Count));
        }
        /// <summary>
        /// Tạo chuỗi đánh giá từ số lượng
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string RenderStarByCount(int count)
        {

            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += "<i class='icomoon icomoon-star'></i>";
            }
            for (int i = 0; i < 5 - count; i++)
            {
                result += "<i class='icomoon icomoon-star dark'></i>";
            }
            return result;
        }
        /// <summary>
        /// Tách tên từ chuỗi họ tên
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public static string getOnlyName(string fullname)
        {
            int i = fullname.LastIndexOf(' ');
            return (i == -1) ? fullname : fullname.Substring(i + 1);
        }
        /// <summary>
        /// Kiểm tra controller, action set active
        /// </summary>
        /// <param name="text">controller hoặc action</param>
        /// <param name="value">giá trị đem so sánh</param>
        /// <returns>active</returns>
        public static string CheckActive(string text, string value)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var routeData = System.Web.Routing.RouteTable.Routes.GetRouteData(httpContext);

            return routeData.Values[text].ToString().ToLower() == value
                ? " active"
                : "";
        }
    }
}