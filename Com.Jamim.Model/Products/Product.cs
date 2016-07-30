using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Model.Taxes;
using Com.Jamim.Model.Manufacturers;
using Com.Jamim.Model.Images;

namespace Com.Jamim.Model.Products
{
    public class Product : EntityBase<int>, IAggregateRoot
    {

        [Required(ErrorMessage = "Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public decimal MRP { get; set; }

        [NotMapped]
        public decimal ListPrice { get; set; }

        [NotMapped]
        public decimal SellingPrice { get; set; }


        public int? ItemsPerUnit { get; set; }

        [ForeignKey("Unit")]
        public string Notation { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }

        public int? ManufacturerId { get; set; }
        public int? TaxId { get; set; }

        public virtual Tax Tax { get; set; }

        public int Rank { get; set; }

        public DateTime CreatedOrModifiedOn { get; set; }
        public string CreatedOrModifiedBy { get; set; }

        public DateTime? ApprovedOrCancelledOn { get; set; }
        public string ApprovedOrCancelledBy { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
        public string WeightName
        {
            get { return Weight.Name.ToString(); }
        }

        public string ManufacturerName
        {
            get { return Manufacturer.Name.ToString(); }
        }

        public int ImageId { get; set; }

        public int WeightId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Category Category { get; set; }

        public virtual Unit Unit { get; set; }

        public virtual Weight Weight { get; set; }

        public virtual Image Image { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
