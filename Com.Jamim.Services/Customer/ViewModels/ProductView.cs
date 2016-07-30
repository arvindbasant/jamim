using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Services.Customer.ViewModels
{
    public class ProductView
    {
        public int ProductId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Manufacturer { get; set; }

        public string ImageSrc { get; set; }

        public string Weight { get; set; }

        public int Rank { get; set; }

        public int CategoryId { get; set; }

    }
}
