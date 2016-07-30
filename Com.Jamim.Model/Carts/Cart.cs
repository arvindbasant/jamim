using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Model.Customers;
using Com.Jamim.Model.Retailers;

namespace Com.Jamim.Model.Carts
{
    public class Cart
    {
        public int Id { get; set; }
        public int RetailerId { get; set; }
        public int CustomerId { get; set; } 
        public decimal Sum { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Item> Items { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Retailer Retailer { get; set; }
    }
}
