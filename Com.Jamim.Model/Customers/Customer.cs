using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Model.BaseEntities;
using Com.Jamim.Model.Carts;
using Com.Jamim.Model.Orders;
using Com.Jamim.Model.ValueObjects;

namespace Com.Jamim.Model.Customers
{
    public class Customer : Person
    {
        public int AddressId { get; set; } 
        public virtual Address Address { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
