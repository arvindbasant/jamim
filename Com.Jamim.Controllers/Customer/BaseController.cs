using System;
using System.Web.Mvc;
using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Controllers.Customer.ViewModels;
using System.Collections.Generic;

namespace Com.Jamim.Controllers.Customer
{
    public class BaseController : Controller
    {
        private readonly ICookieStorageService _cookieStorageService;
      
        public BaseController(ICookieStorageService cookieStorageService) 
        {
            this._cookieStorageService = cookieStorageService;
        }

        public CartSummaryView GetCartSummaryView()
        {
            string cartTotal = "";
            int numberOfItems = 0;

            if (!string.IsNullOrEmpty(_cookieStorageService.Retrieve(CookieDataKeys.CartTotal.ToString())))
                cartTotal = _cookieStorageService.Retrieve(CookieDataKeys.CartTotal.ToString());

            if (!string.IsNullOrEmpty(_cookieStorageService.Retrieve(CookieDataKeys.CartItems.ToString())))
                numberOfItems = int.Parse(_cookieStorageService.Retrieve(CookieDataKeys.CartItems.ToString()));

            return new CartSummaryView
            {
                CartTotal = cartTotal,
                NumberOfItems = numberOfItems
            };
        }

        public Guid GetCartId()
        {
            string sCartId = _cookieStorageService
                .Retrieve(CookieDataKeys.CartId.ToString());

            Guid cartId = Guid.Empty;
            if (!string.IsNullOrEmpty(sCartId))
            {
                cartId = new Guid(sCartId);
            }
            return cartId;
        }

        public int GetRegionId()
        {
            int regionId = 0;
            if(!string.IsNullOrEmpty(_cookieStorageService.Retrieve(CookieDataKeys.RegionId.ToString())))
                regionId = int.Parse(_cookieStorageService.Retrieve(CookieDataKeys.RegionId.ToString()));
            return regionId;
        }

        public int GetRetailerId()
        {
            int retailerId = 0;
            if (!string.IsNullOrEmpty(_cookieStorageService.Retrieve(CookieDataKeys.RetailerId.ToString())))
                retailerId = int.Parse(_cookieStorageService.Retrieve(CookieDataKeys.RetailerId.ToString()));
            return retailerId;
        }

        public int GetStoreId()
        {
            int storeId = 0;
            if (string.IsNullOrEmpty(_cookieStorageService.Retrieve(CookieDataKeys.StoreId.ToString())))
                storeId = int.Parse(_cookieStorageService.Retrieve(CookieDataKeys.StoreId.ToString()));
            return storeId;
        }
    }
}
