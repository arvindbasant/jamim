using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Stores;
using Com.Jamim.Services.Customer.ViewModels;

using AutoMapper;

namespace Com.Jamim.Services.Customer.Mapping
{
    public static class StoreMapper
    {
        public static IEnumerable<StoreView> ConvertToStoreView(
            this IEnumerable<Store> stores)
        {
            return Mapper.Map<IEnumerable<Store>, IEnumerable<StoreView>>(stores);
        }
    }
}
