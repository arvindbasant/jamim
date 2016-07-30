using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Com.Jamim.Model.Products;
using Com.Jamim.Model.Catalog;
using Com.Jamim.Model.Locations;
using Com.Jamim.Model.Stores;
using Com.Jamim.Services.Customer.ViewModels;

using AutoMapper;

namespace Com.Jamim.Services.Customer
{
    public class AutoMapperConfig
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Category, CategoryView>();
            Mapper.CreateMap<Region, RegionView>();
            Mapper.CreateMap<ServiceArea, ServiceAreaView>();
            Mapper.CreateMap<Store, StoreView>();
            Mapper.CreateMap<Catalog, ProductView>();
            Mapper.CreateMap<Product, ProductView>();
            Mapper.CreateMap<Product, ProductDetailView>();
            Mapper.CreateMap<CategoryAccess, CategoryView>();

            Mapper.CreateMap<IProductAttribute, Refinement>();

        }
    }
}
