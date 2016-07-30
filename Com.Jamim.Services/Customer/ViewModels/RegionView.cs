using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Services.Customer.ViewModels
{
    public class RegionView
    {
        public int Id { get; set; }
        public string RegionDesc { get; set; }

        public string ZipCode { get; set; }

        public string CityShrtDesc { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
