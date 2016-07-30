using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.Messaging.RetailerService;

namespace Com.Jamim.Services.Customer.Abstract
{
    public interface IRetailerService
    {
        GetRetailerResponse GetRetailer(GetRetailerRequest request);
        GetAllRetailerResponse GetAllRetailer(GetAllRetailerRequest request);
    }
}
