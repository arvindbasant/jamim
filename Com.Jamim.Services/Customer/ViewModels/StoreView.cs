using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Services.Customer.ViewModels
{
    public class StoreView
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public string StoreType { get; set; }

        public string Status { get; set; }

        public int RetailerId { get; set; }
        public int RegionId { get; set; }
    }
}
