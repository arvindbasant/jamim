using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Controllers.Customer.ViewModels;

namespace Com.Jamim.Controllers.Customer
{
    public class RetailerController : BaseController
    {
        private readonly ICookieStorageService _cookieStorageService;
        public RetailerController(ICookieStorageService cookieStorageService) 
            : base(cookieStorageService)
        {
            this._cookieStorageService = cookieStorageService;
        }


    }
}
