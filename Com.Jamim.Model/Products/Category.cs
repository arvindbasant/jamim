using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Model.Images;

namespace Com.Jamim.Model.Products
{
    public class Category : EntityBase<int>, IAggregateRoot, IProductAttribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public virtual Image Image { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
