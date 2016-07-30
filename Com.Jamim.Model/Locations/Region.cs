using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Locations
{
    public class Region : EntityBase<int>, IAggregateRoot
    {
        public string RegionDesc { get; set; }

        public string ZipCode { get; set; }

        public string CityShrtDesc
        {
            get { return ServiceArea.CityShrtDesc; }
        }

        public string City
        {
            get { return ServiceArea.City; }
        }

        public string State
        {
            get { return ServiceArea.State; }
        }

        public int ServiceAreaId { get; set; } 

        public virtual ServiceArea ServiceArea { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
