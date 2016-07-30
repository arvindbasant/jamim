using System;
using System.Collections.Generic;
using System.Linq;
using Com.Jamim.Services.Customer.ViewModels;

namespace Com.Jamim.Controllers.Customer.ViewModels.ProductCatalog
{
    public class ProductSearchResultView : BaseProductCatalogPageView
    {
        public ProductSearchResultView()
        {
            RefinementGroups = new List<RefinementGroup>();
        }

        public int RetailerId { get; set; }

        public string SelectedCategoryName { get; set; }
        public int SelectedCategory { get; set; }

        public IEnumerable<RefinementGroup> RefinementGroups { get; set; }

        public int NumberOfProductsFound { get; set; }
        public int TotalNoOfPages { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<ProductView> Products { get; set; }

    }
}
