using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.ViewModels;
using Com.Jamim.Services.Customer.Messaging.LocationService;

namespace Com.Jamim.Controllers.Customer
{
    public class LocationBaseController : BaseController
    {
        private readonly ILocationService _locationService;

        public LocationBaseController(ICookieStorageService cookieStorageService, ILocationService locationService) : base(cookieStorageService) 
        {
            this._locationService = locationService;
        }

        public RegionView GetLastRegion()
        {
            int regionId;
            if (base.GetRegionId() != 0)
            {
                regionId = base.GetRegionId();
                GetRegionRequest request = new GetRegionRequest { RegionId = regionId };
                GetRegionResponse response = _locationService.GetRegionDetails(request);
                return response.RegionView;
            }
            return null;
        }

        public IEnumerable<ServiceAreaView> GetAllServiceArea()
        {
            GetAllServiceAreaResponse response = new GetAllServiceAreaResponse();
            response = _locationService.GetAllServiceArea();
            return response.ServiceAreaViews;
        }

        public IEnumerable<RegionView> GetAllRegionByServiceArea(int fk)
        {
            GetAllRegionResponse response = new GetAllRegionResponse();
            GetAllRegionRequest request = new GetAllRegionRequest { ServiceAreaFk = fk };
            response = _locationService.GetAllRegionsByServiceArea(request);
            return response.RegionViews;
        }
    }
}
