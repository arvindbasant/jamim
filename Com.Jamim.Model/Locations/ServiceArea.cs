using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Locations
{
    public class ServiceArea : EntityBase<int>, IAggregateRoot
    { 
        public string CityShrtDesc { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
