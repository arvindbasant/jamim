using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Services.Customer.Abstract;
using System.Web.Mvc;
using Com.Jamim.Controllers.Customer.ViewModels.Location;
using Com.Jamim.Services.Customer.ViewModels;

namespace Com.Jamim.Controllers.Customer
{
    public class LocationController : LocationBaseController
    {
        public LocationController(ICookieStorageService cookieStorageService,
            ILocationService locationService)
            : base(cookieStorageService, locationService) { }

        public ActionResult Index()
        {
            //  base.GetAllRegionByServiceArea(1);

            LocationPageView locationPageView = new LocationPageView
            {
                ServiceAreas = base.GetAllServiceArea(),
                LastRegion = base.GetLastRegion(),
            };
            return View("Index", locationPageView);
        }

        [HttpPost]
        public RedirectToRouteResult Index(LocationPageView view)
        {
            string regionId = Request.Form["hdnRegionId"];
            return RedirectToAction("Index", "Store", new { area = "Customer", id = regionId });
        }

        public JsonResult GetRegions(int id = 0)
        {
            IEnumerable<RegionView> regions = base.GetAllRegionByServiceArea(id);
            // StringBuilder sb = new StringBuilder();
            //  Array arr[] = new Array();
            //int  i =0;
            //foreach (RegionView v in regions)
            //{
            //    String temp = String.Format("{0}-{1}", v.RegionDesc, v.ZipCode);
            //  //  arr.SetValue(temp, i);
            //}
            return Json(regions, JsonRequestBehavior.AllowGet);
        }





    }
}
