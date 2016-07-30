using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;

namespace Com.Jamim.Services.Customer.Abstract
{
    public interface ICartService
    {
        GetCartResponse GetCart(GetCartRequest request);
        CreateCartResponse CreateCart(CreateCartRequest request);
        ModifyCartResponse ModufyCart(ModifyCartRequest request);
    }
}
