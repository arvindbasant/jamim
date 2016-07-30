using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Model.BaseEntities;
using Com.Jamim.Model.ValueObjects;
using Com.Jamim.Model.Locations;
using Com.Jamim.Model.Orders;
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Retailers
{
    public class Retailer : Person, IAggregateRoot
    {
        public RetailerCategory RetailerCategory { get; set; }
        public int? AddressId { get; set; } 

        [DisplayFormat(NullDisplayText = "Not Rated")]
        public Rating? Rating { get; set; }

        public int? RegionId { get; set; } 
        public Region Region { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<DeliveryPerson> DeliveryPersons { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
