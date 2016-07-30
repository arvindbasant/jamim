using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Jamim.Controllers.Customer
{
    public class CartController : Controller
    {
        // GET: Customer/Cart
        public ActionResult Index()
        {
            return View();
        }
    }
}