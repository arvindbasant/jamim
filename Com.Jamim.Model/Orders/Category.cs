using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Model.Retailers;


namespace Com.Jamim.Model.Products
{
    public class Category : EntityBase<int>, IAggregateRoot
    {
        public int RetailerId { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsActive { get; set; }

        public string ProductTypeName
        {
            get
            {
                return ProductCategory.ProductType.Name;
            }
        }
        public string ProductCategoryName
        {
            get { return ProductCategory.Name; }
        }
        public string ProductTypeImage
        {
            get { return ProductCategory.ProductType.Image; }
        }
        public string ProductCategoryImage
        {
            get { return ProductCategory.Image; }
        }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual Retailer Retailer { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
