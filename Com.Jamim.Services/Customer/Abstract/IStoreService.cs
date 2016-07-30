using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.Messaging.StoreService;

namespace Com.Jamim.Services.Customer.Abstract
{
    public interface IStoreService
    {
        GetAllStoresInRegionResponse GetAllStoresInRegion(GetAllStroresInRegionRequest request);
    }
}
