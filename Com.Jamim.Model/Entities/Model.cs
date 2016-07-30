using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Com.Jamim.Model.Entities
{

    public class MenuDetails
    {
        public string MenuId { get; set; }
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Area { get; set; }
        public bool Index { get; set; }
        public bool Execute { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Edit { get; set; }
        public bool Cancel { get; set; }
        public bool Delete { get; set; }
        public bool Print { get; set; }
        public bool Approve { get; set; }
        public bool Deactivate { get; set; }
        public bool Reactivate { get; set; }

    }

    public class UserMenuAccess
    {
        string UserId { get; set; }
        string MenuId { get; set; }
    }


    /*
     TaxCategory
 TaxCategoryID
 TaxCategory
 Description

Taxrate
 ID
 TaxCategoryID
Rate
 CreatedDate
 ModifiedDate


Region
 RegionID
 CityShrtDesc
 City
 State
 Country

product
 ShortDesc
 Desc
 ListPrice
 Weight
 Promotion
 ManufacturerID
 TaxCategoryID
 CreatedDate
 CreatedBy
 ModifiedDate
 ModifiedBy

Manufacturer
 ID
 Name
 ManufacturerURL
     
     */

    //public class Shipper : Address
    //{
    //    public int ID { get; set; }
    //    public string SupplierName { get; set; }
    //}

    //public class ShipperRegion
    //{
    //    public int ShipperID { get; set; }
    //    public int RegionID { get; set; }
    //}

    //public class Region
    //{
    //    public int ID { get; set; }
    //    public string RegionDescription { get; set; }
    //}




}