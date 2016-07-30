using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Retailers;
using Com.Jamim.Model.Locations;
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Stores
{
    public class Store : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public StoreType StoreType { get; set; }

        public Status Status { get; set; }

        public int RetailerId { get; set; }

        public int RegionId { get; set; }
        public virtual Retailer Retailer { get; set; }
     
        public virtual Region Region { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
