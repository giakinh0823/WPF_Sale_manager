using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleWPFApp
{
    internal class Session
    {
        public static string? Username { get; set; } = null;
        public static List<OrderDetail> carts { get; set; } = null;
    }
}
