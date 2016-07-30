using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Model.BaseEntities;

namespace Com.Jamim.Model.Retailers
{
    public class DeliveryPerson : Person
    {
        public int RetailerId { get; set; } 
        public virtual Retailer Retailer { get; set; }
    }

}
