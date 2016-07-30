using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.ViewModels;

namespace Com.Jamim.Controllers.Customer.ViewModels.ProductCatalog
{
    public class CartDetailView
    {
        public CartView Cart { get; set; }
        public IEnumerable<ShippingOptionView> ShippingOptions { get; set; }
    }
}
