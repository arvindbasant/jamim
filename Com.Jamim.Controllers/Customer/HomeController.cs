using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Controllers.Customer.ViewModels.ProductCatalog;
using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;
using System.Web.Mvc;

namespace Com.Jamim.Controllers.Customer
{
    public class HomeController : ProductCatalogBaseController
    {
        private readonly IProductCatalogueService _productCatalogService;

        public HomeController(IProductCatalogueService productCatalogService)
            :base(productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        public ActionResult Index(int Id = 0)
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetAllCategoriesHavingAccess(Id);
            GetFeaturedProductResponse response = new GetFeaturedProductResponse();
            response = _productCatalogService.GetFeaturedProducts(new GetFeaturedProductRequest { RetailerId = Id });
            homePageView.Products = response.Products;
            return View("Index", homePageView);
        }

    }
}
