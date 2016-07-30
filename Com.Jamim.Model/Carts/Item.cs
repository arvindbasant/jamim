using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Model.Products;

namespace Com.Jamim.Model.Carts
{
    public class Item
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; } 
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
