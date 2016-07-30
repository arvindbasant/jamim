using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.ViewModels;

namespace Com.Jamim.Controllers.Customer.ViewModels.Store
{
    public class StorePageView
    {
        public IEnumerable<StoreView> Stores { get; set; }
    }
}
