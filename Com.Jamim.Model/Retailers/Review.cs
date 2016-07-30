using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Com.Jamim.Model.Retailers
{
    public class Review
    {
        public int Id { get; set; }
        public int RetailerId { get; set; }
        public Rating Rating { get; set; }
        public string Comment { get; set; }
        public int ReviewerId { get; set; } 
        public string ReviewedBy { get; set; }
        public DateTime ReviewedOn { get; set; }
        public DateTime LastModify { get; set; }

        public virtual Review Reviewer { get; set; }
        public virtual Retailer Retailer { get; set; }
    }
}
