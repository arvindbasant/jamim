using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Model.Orders
{
    public enum OrderStatus { New, InQueue, Shipped, Canceled, Delivered, Returned, ToBeReplaced, ShippedForReplacing, Replaced }
}
