using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Products;
using Com.Jamim.Model.Retailers;
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Catalog
{
    public class Catalog : EntityBase<int>, IAggregateRoot
    {
        public int ProductId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }


        public string Name
        {
            get { return Product.Name.ToString(); }
        }

        public string ShortDescription
        {
            get { return Product.ShortDescription.ToString(); }
        }

        public string Manufacturer
        {
            get { return Product.Manufacturer.NameShrtDesc; }
        }

        public string ImageSrc
        {
            get
            {
                return string.Format("~/Images/{0}/{1}.{2}",
                Product.Image.ImagePath.Path,
                Product.Image.Name,
                Product.Image.ImageType.Type);
            }
        }

        public string Weight
        {
            get
            {
                return string.Format("{0} {1}", Product.Weight.Name.ToString(), Product.Unit.Notation.ToString());
            }
        }

        public int Rank
        {
            get { return Product.Rank; }
        }

        public int CategoryId
        {
            get { return Product.CategoryId; }
        }
        public int RetailerId { get; set; }

        public virtual Retailer Retailer { get; set; }

        public virtual Product Product { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
