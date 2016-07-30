using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Products;
using Com.Jamim.Model.Catalog;
using Com.Jamim.Services.Customer.ViewModels;
using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;
using AutoMapper;

namespace Com.Jamim.Services.Customer.Mapping
{
    public static class ProductMapper
    {
        public static IEnumerable<ProductView> ConvertToProductViews(
            this IEnumerable<Catalog> products)
        {
            return Mapper.Map<IEnumerable<Catalog>, IEnumerable<ProductView>>(products);
        }

        public static IEnumerable<ProductView> ConvertToProductViews(
           this IEnumerable<Product> products)
        {
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(products);
        }

        public static ProductDetailView ConvertToProductDetailView(
            this Product product)
        {
            return Mapper.Map<Product, ProductDetailView>(product);
        }

        public static GetProductByCategoryResponse CreateProductSearchResultFrom(
            this IEnumerable<Catalog> productMatchingRefinements, GetProductByCategoryRequest request)
        {
            GetProductByCategoryResponse productSearchResultView = new GetProductByCategoryResponse();

            IEnumerable<Product> productsFound = productMatchingRefinements.Select(p => p.Product).Distinct();

            productSearchResultView.SelectedCategory = request.CategoryId;
            productSearchResultView.NumberOfProductsFound = productsFound.Count();
            productSearchResultView.TotalNumberOfPages = NoOfResultPagesGiven(
                request.NumberOfResultsPerPage, productSearchResultView.NumberOfProductsFound);

            productSearchResultView.RefinementGroups = GenerateAvailableProductRefinementsFrom(productsFound);

            productSearchResultView.Products = CropProductListToSatisfyGivenIndex(
                request.Index, request.NumberOfResultsPerPage, productMatchingRefinements);


            return productSearchResultView;

        }

        private static IEnumerable<ProductView> CropProductListToSatisfyGivenIndex(int pageIndex,
            int numberOfResultsPerPage, IEnumerable<Catalog> productsFound)
        {
            if (pageIndex > 1)
            {
                int numToSkip = (pageIndex - 1) * numberOfResultsPerPage;
                return productsFound.Skip(numToSkip)
                    .Take(numberOfResultsPerPage).ConvertToProductViews();
            }
            else
                return productsFound.Take(numberOfResultsPerPage)
                    .ConvertToProductViews();
        }

        private static int NoOfResultPagesGiven(
            int numberOfResultsPerPage, int numberOfProductsFound)
        {
            if (numberOfProductsFound < numberOfResultsPerPage)
                return 1;
            else
                return (numberOfProductsFound / numberOfResultsPerPage) + (numberOfProductsFound % numberOfResultsPerPage);
        }

        private static IList<RefinementGroup> GenerateAvailableProductRefinementsFrom(
            IEnumerable<Product> productsFound)
        {

            var weightsRefinementGroup = productsFound.Select(p => p.Weight).Distinct().ToList()
                .ConvertAll<IProductAttribute>(w => (IProductAttribute)w)
                .convertToRefinementGroup(RefinementGroupings.Weight);

            var manufacturersRefinementGroup = productsFound.Select(p => p.Manufacturer).Distinct().ToList()
                .ConvertAll<IProductAttribute>(m => (IProductAttribute)m)
                .convertToRefinementGroup(RefinementGroupings.Manufacturer);


            IList<RefinementGroup> refinementGroups = new List<RefinementGroup>();

            refinementGroups.Add(weightsRefinementGroup);
            refinementGroups.Add(manufacturersRefinementGroup);

            return refinementGroups;
        }
    }
}
