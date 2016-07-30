using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;
using Com.Jamim.Services.Customer.ViewModels;
using Com.Jamim.Model.Catalog;
using Com.Jamim.Model.Products;
using Com.Jamim.Infrastructure.Querying;
using Com.Jamim.Services.Customer.Mapping;

namespace Com.Jamim.Services.Customer.Concrete
{
    public class ProductCatalogueService : IProductCatalogueService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICatalogRepository _catalogRepository;
        private readonly ICategoryAccessRepository _categoryAccessRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCatalogueService(IProductRepository productRepository,
            ICatalogRepository catalogRepository,
            ICategoryAccessRepository categoryAccessRepository, ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._catalogRepository = catalogRepository;
            this._categoryAccessRepository = categoryAccessRepository;
            this._categoryRepository = categoryRepository;
        }

        private IEnumerable<Catalog> GetAllProductsMatchingQueryAndSort(
            GetProductByCategoryRequest request, Query productQuery)
        {
            IEnumerable<Catalog> productsMatchingRefinement = _catalogRepository.FindBy(productQuery);

            switch (request.SortBy)
            {
                case ProductsSortBy.PriceLowToHigh:
                    productsMatchingRefinement = productsMatchingRefinement
                                                    .OrderBy(p => p.SellingPrice);
                    break;
                case ProductsSortBy.PriceHighToLow:
                    productsMatchingRefinement = productsMatchingRefinement
                                                    .OrderByDescending(p => p.SellingPrice);
                    break;
            }
            return productsMatchingRefinement;
        }

        public GetCategoryResponse GetAllCategories(GetCategoryRequest request)
        {
            GetCategoryResponse response = new GetCategoryResponse();
            Query categoryQuery = new Query();
            categoryQuery.Add(Criterion.Create<CategoryAccess>(r => r.RetailerId, request.RetailerId, CriteriaOperator.Equal));
            IEnumerable<CategoryAccess> categories = _categoryAccessRepository.FindBy(categoryQuery);
            response.Categories = categories.convertToCategoryViews();
            return response;
        }

        public GetFeaturedProductResponse GetFeaturedProducts(GetFeaturedProductRequest request)
        {
            GetFeaturedProductResponse response = new GetFeaturedProductResponse();
            Query featuredCatalogquery = new Query();
            featuredCatalogquery.Add(Criterion.Create<Catalog>(p => p.RetailerId, request.RetailerId, CriteriaOperator.Equal, ConditionOperator.Or));
            featuredCatalogquery.Add(Criterion.Create<Catalog>(p => p.Product.Rank, 100, CriteriaOperator.GreaterThanOrEqual));

            featuredCatalogquery.OrderByProperty = new OrderByClause { PropertyName = "SellingPrice", Desc = true };

            IEnumerable<Catalog> products = _catalogRepository.FindBy(featuredCatalogquery);
            response.Products = products.ConvertToProductViews();
            return response;
        }

        public GetProductByCategoryResponse GetProductsByCategory(GetProductByCategoryRequest request)
        {
            GetProductByCategoryResponse response;
            Query productQuery = ProductSearchRequestQueryGenerator.CreateQueryFor(request);

            IEnumerable<Catalog> productMatchingRefinement = GetAllProductsMatchingQueryAndSort(request, productQuery);

            response = productMatchingRefinement.CreateProductSearchResultFrom(request);

            response.SelectedCategoryName = _categoryRepository.FindBy(request.CategoryId).Name;

            return response;
                
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
            GetProductResponse response = new GetProductResponse();

            Product product = _productRepository.FindBy(request.ProductId);

            response.Product = product.ConvertToProductDetailView();
            return response;
        }
    }
}
