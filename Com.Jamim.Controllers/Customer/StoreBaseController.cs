using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.ViewModels;
using Com.Jamim.Services.Customer.Messaging.StoreService;

namespace Com.Jamim.Controllers.Customer
{
    public class StoreBaseController : BaseController
    {
        private readonly IStoreService _storeService;

        public StoreBaseController(ICookieStorageService cookieStorageService, IStoreService storeServics)
            : base(cookieStorageService)
        {
            this._storeService = storeServics;
        }

        public IEnumerable<StoreView> GetStoresInRegion(int Id)
        {
            GetAllStoresInRegionResponse response = new GetAllStoresInRegionResponse();
            response = _storeService.GetAllStoresInRegion(new GetAllStroresInRegionRequest { RegionId = Id });
            return response.Stores;
                
        }
    }
}
