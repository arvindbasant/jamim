using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Taxes
{
    public class TaxRate : EntityBase<int>, IAggregateRoot
    {
        public double Rate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public int TaxId { get; set; }
        public virtual Tax Tax { get; set; }
           
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
