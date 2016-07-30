using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Services.Customer.ViewModels;

namespace Com.Jamim.Controllers.Customer.ViewModels.Location
{
    public class LocationPageView
    {
        public IEnumerable<ServiceAreaView> ServiceAreas { get; set; }
        public IEnumerable<RegionView> Regions { get; set; }

        public RegionView LastRegion { get; set; }
    }
}
