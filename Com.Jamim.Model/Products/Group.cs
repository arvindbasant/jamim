using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Model.Images;

namespace Com.Jamim.Model.Products
{
    public class Group : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
