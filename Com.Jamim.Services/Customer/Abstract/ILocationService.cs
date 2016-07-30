using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Services.Customer.Messaging.LocationService;

namespace Com.Jamim.Services.Customer.Abstract
{
    public interface ILocationService
    {
        GetRegionResponse GetRegionDetails(GetRegionRequest request);

        GetAllRegionResponse GetAllRegionsByServiceArea(GetAllRegionRequest request);

        GetAllServiceAreaResponse GetAllServiceArea();
      
    }
}
