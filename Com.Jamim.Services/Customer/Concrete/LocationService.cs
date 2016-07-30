using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.Messaging.LocationService;
using Com.Jamim.Model.Locations;
using Com.Jamim.Infrastructure.Querying;

using Com.Jamim.Services.Customer.Mapping;

namespace Com.Jamim.Services.Customer.Concrete
{
    public class LocationService : ILocationService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IServiceAreaRepository _serviceAreaRepository;

        public LocationService(IRegionRepository regionRepository, IServiceAreaRepository serviceAreaRepository)
        {
            this._regionRepository = regionRepository;
            this._serviceAreaRepository = serviceAreaRepository;
        }

        public GetRegionResponse GetRegionDetails(GetRegionRequest request)
        {
            GetRegionResponse response = new GetRegionResponse();
            Region region = _regionRepository.FindBy(request.RegionId);
            response.RegionView = region.ConvertToRegionView();

            return response;

        }

        public GetAllRegionResponse GetAllRegionsByServiceArea(GetAllRegionRequest request)
        {
            GetAllRegionResponse response = new GetAllRegionResponse();

            Query regionQuery = new Query();
            regionQuery.Add(Criterion.Create<Region>(r => r.ServiceArea.Id, request.ServiceAreaFk, CriteriaOperator.Equal,ConditionOperator.And));

            IEnumerable<Region> regions = _regionRepository.FindBy(regionQuery);
            response.RegionViews = regions.ConvertToRegionViewList();

            return response;
        }

        public GetAllServiceAreaResponse GetAllServiceArea()
        {
            GetAllServiceAreaResponse response = new GetAllServiceAreaResponse();

            IEnumerable<ServiceArea> serviceAreas = _serviceAreaRepository.FindAll();
            response.ServiceAreaViews = serviceAreas.ConvertToServiceAreaViewList();

            return response;
        }
    }
}
