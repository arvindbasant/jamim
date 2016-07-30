using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Images
{
    public class Image : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }

        public int ImagePathId { get; set; }

        public int ImageTypeId { get; set; }


        public virtual ImageType ImageType { get; set; }

        public virtual ImagePath ImagePath { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
