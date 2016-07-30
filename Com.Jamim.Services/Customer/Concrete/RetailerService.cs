using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.Messaging.RetailerService;
using Com.Jamim.Model.Retailers;
using Com.Jamim.Services.Customer.Mapping;
using Com.Jamim.Infrastructure.Querying;

namespace Com.Jamim.Services.Customer.Concrete
{
    public class RetailerService : IRetailerService
    {
        public readonly IRetailerRepository _retailerRepository;

        public RetailerService(IRetailerRepository repository)
        {
            this._retailerRepository = repository;
        }

        public GetRetailerResponse GetRetailer(GetRetailerRequest request)
        {
            GetRetailerResponse response = new GetRetailerResponse();
            Retailer retailer = _retailerRepository.FindBy(request.RetailerId);

            response.RetailerView = retailer.ConvertToRetailerView();
            return response;

        }

        public GetAllRetailerResponse GetAllRetailer(GetAllRetailerRequest request)
        {
            GetAllRetailerResponse response = new GetAllRetailerResponse();
            Query retailerQuery = new Query();
            retailerQuery.Add(Criterion.Create<Retailer>(r => r.RegionId, request.RegionId, CriteriaOperator.Equal,ConditionOperator.And));
            IEnumerable<Retailer> retailers = _retailerRepository.FindBy(retailerQuery);

            response.AllRetailers = retailers.ConvertToRetailerViewList();
            return response;
        }
    }
}
