using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Products;
using Com.Jamim.Services.Customer.ViewModels;
using AutoMapper;

namespace Com.Jamim.Services.Customer.Mapping
{
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> convertToCategoryViews(
            this IEnumerable<Category> categories)
        {
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryView>>(categories);
        }

        public static IEnumerable<CategoryView> convertToCategoryViews(
           this IEnumerable<CategoryAccess> categories)
        {
            return Mapper.Map<IEnumerable<CategoryAccess>, IEnumerable<CategoryView>>(categories);
        }
    }
}
