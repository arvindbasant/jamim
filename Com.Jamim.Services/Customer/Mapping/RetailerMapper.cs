using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Retailers;
using Com.Jamim.Services.Customer.ViewModels;
using AutoMapper;

namespace Com.Jamim.Services.Customer.Mapping
{
    public static class RetailerMapper
    {
        public static RetailerView ConvertToRetailerView(
            this Retailer retailer)
        {
            return Mapper.Map<Retailer, RetailerView>(retailer);
        }

        public static IEnumerable<RetailerView> ConvertToRetailerViewList(
            this IEnumerable<Retailer> retailers)
        {
            return Mapper.Map<IEnumerable<Retailer>,IEnumerable<RetailerView>>(retailers);
        }
    }
}
