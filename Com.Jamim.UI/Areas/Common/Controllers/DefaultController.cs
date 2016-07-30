using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Jamim.UI.Areas.Common.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Common/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}