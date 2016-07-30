using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.Messaging.StoreService;
using Com.Jamim.Model.Stores;
using Com.Jamim.Infrastructure.Querying;
using Com.Jamim.Services.Customer.Mapping;

namespace Com.Jamim.Services.Customer.Concrete
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository; 

        public StoreService(IStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }

        public GetAllStoresInRegionResponse GetAllStoresInRegion(GetAllStroresInRegionRequest request)
        {
            GetAllStoresInRegionResponse response = new GetAllStoresInRegionResponse();

            Query storeQuery = new Query();
            storeQuery.Add(Criterion.Create<Store>(s=>s.Region.Id, request.RegionId, CriteriaOperator.Equal));
            IEnumerable<Store> stores = _storeRepository.FindBy(storeQuery);
            response.Stores = stores.ConvertToStoreView();
            return response;
        }
    }
}
