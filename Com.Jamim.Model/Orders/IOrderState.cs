using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Model.Orders
{
    public interface IOrderState
    {
        bool Canship(Order order);
        void Ship(Order order);

        bool CanCancel(Order order);
        void Cancel(Order order);

        OrderStatus Status { get; }
    }
}
