using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Services.Customer.Messaging.ProductCatalogService
{
    public class GetProductByCategoryRequest
    {
        public GetProductByCategoryRequest()
        {
            ManufacturerIds = new int[0];
            WeightIds = new int[0];
        }

        public int CategoryId { get; set; }

        public int RetailerId { get; set; }

        public int[] ManufacturerIds { get; set; }
        public int[] WeightIds { get; set; }

        public ProductsSortBy SortBy { get; set; }
        public int Index { get; set; }
        public int NumberOfResultsPerPage { get; set; }

    }
}
