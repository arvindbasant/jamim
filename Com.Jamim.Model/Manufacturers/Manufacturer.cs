using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Model.Products;

using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Manufacturers
{
    public class Manufacturer : EntityBase<int>, IAggregateRoot,IProductAttribute
    {
        public string Name { get; set; }
        public string NameShrtDesc { get; set; }
        public string ManufacturerURL { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
