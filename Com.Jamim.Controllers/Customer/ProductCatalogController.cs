using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Com.Jamim.Infrastructure.CookieStorage;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;
using Com.Jamim.Controllers.Customer.ViewModels.ProductCatalog;

namespace Com.Jamim.Controllers.Customer
{
    public class ProductCatalogController : ProductCatalogBaseController
    {
        private readonly IProductCatalogueService _productCatalogService;

        public ProductCatalogController(IProductCatalogueService productCatalogService)
            : base(productCatalogService)
        {
            this._productCatalogService = productCatalogService;
        }

        public ActionResult GetProductsByCategory(int categoryId)
        {
            GetProductByCategoryRequest request = GenerateInitialProductSearchRequestFrom(categoryId);

            GetProductByCategoryResponse response = _productCatalogService.GetProductsByCategory(request);

            ProductSearchResultView productSearchResultView = GetProductSearchResultViewFrom(response);

            return View("ProductSearchResultView", productSearchResultView);
        }

        private ProductSearchResultView GetProductSearchResultViewFrom(GetProductByCategoryResponse response)
        {
            ProductSearchResultView productSearchResultView = new ProductSearchResultView();
            productSearchResultView.Categories = base.GetAllCategoriesHavingAccess(1);
            productSearchResultView.CurrentPage = response.CurrentPage;
            productSearchResultView.NumberOfProductsFound = response.NumberOfProductsFound;
            productSearchResultView.Products = response.Products;
            productSearchResultView.RefinementGroups = response.RefinementGroups;
            productSearchResultView.SelectedCategory = response.SelectedCategory;
            productSearchResultView.SelectedCategoryName = response.SelectedCategoryName;
            productSearchResultView.TotalNoOfPages = response.TotalNumberOfPages;
            productSearchResultView.RetailerId = 1;

            return productSearchResultView;
        }

        private static GetProductByCategoryRequest GenerateInitialProductSearchRequestFrom
            (int categoryId)
        {
            GetProductByCategoryRequest productSearchRequest = new GetProductByCategoryRequest();
            productSearchRequest.NumberOfResultsPerPage = 6;
            productSearchRequest.CategoryId = categoryId;
            productSearchRequest.Index = 1;
            productSearchRequest.SortBy = ProductsSortBy.PriceHighToLow;
            
            //TODO::
            productSearchRequest.RetailerId = 1;

            return productSearchRequest;
        }


        public JsonResult GetProductsByAjax(GetProductByCategoryRequest request)
        {
            GetProductByCategoryResponse response = new GetProductByCategoryResponse();

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}