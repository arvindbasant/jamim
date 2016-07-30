using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;

namespace Com.Jamim.Services.Customer.Abstract
{
    public interface IProductCatalogueService
    {
        GetCategoryResponse GetAllCategories(GetCategoryRequest request);
        GetFeaturedProductResponse GetFeaturedProducts(GetFeaturedProductRequest request);
        GetProductByCategoryResponse GetProductsByCategory(GetProductByCategoryRequest request);
        GetProductResponse GetProduct(GetProductRequest request);
    }
}
