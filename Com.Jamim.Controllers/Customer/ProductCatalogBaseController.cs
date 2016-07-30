using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.ViewModels;
using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;

namespace Com.Jamim.Controllers.Customer
{
    public class ProductCatalogBaseController : Controller
    {
        private readonly IProductCatalogueService _productCatalogService;

        public ProductCatalogBaseController(IProductCatalogueService productCatalogService)
        {
            this._productCatalogService = productCatalogService;
        }

        public IEnumerable<CategoryView> GetAllCategoriesHavingAccess(int Id = 0)
        {
            GetCategoryResponse response = new GetCategoryResponse();

            response = _productCatalogService.GetAllCategories(
               new GetCategoryRequest { RetailerId = Id });

            return response.Categories;
        }
    }
}