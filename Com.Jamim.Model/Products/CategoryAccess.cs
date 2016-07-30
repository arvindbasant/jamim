using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Products
{
    public class CategoryAccess : EntityBase<int>, IAggregateRoot
    {
        public int RetailerId { get; set; }

        public int GroupId
        {
            get { return Category.Group.Id; }
        }
        public int CategoryId { get; set; }

        public string CategoryName
        {
            get { return Category.Name.ToString(); }
        }

        public string CategoryDescription
        {
            get { return Category.Description.ToString(); }
        }

        public string GroupName
        {
            get { return Category.Group.Name.ToString(); }
        }
        public string GroupDescription
        {
            get { return Category.Group.Description.ToString(); }
        }

        public virtual Category Category { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
