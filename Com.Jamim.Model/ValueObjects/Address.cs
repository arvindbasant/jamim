using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace Com.Jamim.Model.ValueObjects
{
    public class Address
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Address")]
        public string AddressDetail { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Display(Name = "EMail Id")]
        public string EMail { get; set; }

        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }

        [Display(Name = "Customer Service No")]
        public string AlternateContactNo { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int? ParentAddrssID { get; set; }

        public Address ParentAddress { get; set; }

        public virtual ICollection<Address> ChildAddress { get; set; }
    }
}
