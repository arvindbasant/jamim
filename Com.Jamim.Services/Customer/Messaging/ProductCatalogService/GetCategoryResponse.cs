using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.ViewModels;

namespace Com.Jamim.Services.Customer.Messaging.ProductCatalogService
{
    public class GetCategoryResponse
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
