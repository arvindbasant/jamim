using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Controllers.Customer.ViewModels.Store;
using Com.Jamim.Services.Customer.ViewModels;
using Com.Jamim.Services.Customer.Messaging.StoreService;

namespace Com.Jamim.Controllers.Customer
{
    public class StoreController : StoreBaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(ICookieStorageService cookieStorageService, IStoreService storeService)
            : base(cookieStorageService, storeService)
        {
            this._storeService = storeService;
        }

        public ActionResult Index(int Id = 0)
        {
            StorePageView view = new StorePageView 
            {  
                Stores = base.GetStoresInRegion(Id)
            };
           
            return View("Index",view);
        }
    }
}
