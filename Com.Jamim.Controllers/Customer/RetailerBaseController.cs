using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Services.Customer.Abstract;
using System.Web.Mvc;


namespace Com.Jamim.Controllers.Customer
{
    public class RetailerBaseController : BaseController
    {
        public RetailerBaseController(ICookieStorageService cookieStorageService)
            : base(cookieStorageService) { }


         
    }
}
