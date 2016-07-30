using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Model.Locations;
using Com.Jamim.Services.Customer.ViewModels;

using AutoMapper;

namespace Com.Jamim.Services.Customer.Mapping
{
    public static class ServiceAreaMapper
    {
        public static IEnumerable<ServiceAreaView> ConvertToServiceAreaViewList(
            this IEnumerable<ServiceArea> serviceAreas)
        {
            return Mapper.Map<IEnumerable<ServiceArea>, IEnumerable<ServiceAreaView>>(serviceAreas);
        }
    }
}
