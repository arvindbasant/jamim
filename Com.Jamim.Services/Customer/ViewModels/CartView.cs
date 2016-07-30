using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Services.Customer.ViewModels
{
    public class CartView
    {
        public CartView()
        {
            Items = new List<CartItemView>();
        }
        public Guid Id { get; set; }
        public string ItemsTotal { get; set; }
        public int NumberOfItems { get; set; }
        public IEnumerable<CartItemView> Items { get; set; }

        public string BasketTotal { get; set; }
        public string DeliveryCost { get; set; }
        public string ShippingServiceDescription { get; set; }
        public int DeliveryOptionId { get; set; }

    }
}
