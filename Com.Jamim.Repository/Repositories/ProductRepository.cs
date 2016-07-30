using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Infrastructure.UnitOfWork;
using Com.Jamim.Model.Entities;
using Com.Jamim.Model.Products;

namespace Com.Jamim.Repository.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IUnitOfWork uow) : base(uow) { }

        public override Product FindBy(int Id)
        {
            return GetDbSet().FirstOrDefault<Product>(b => b.Id == Id);
        }

        public override IQueryable<Product> GetDbSet()
        {
            return DataContextFactory.GetDataContext().Products;
        }

        public override string GetEntitySetName()
        {
            return "Products";
        }


        public IQueryable<Product> GetProductByRetailerId(int id)
        {
            IQueryable<Product> products = (from p in DataContextFactory.GetDataContext().Products
                                            join c in DataContextFactory.GetDataContext().Catalogues
                                            on p.Id equals c.ProductId
                                            where c.RetailerId == id
                                            select new Product
                                            {
                                                Id = p.Id,
                                                Name = p.Name,
                                                ShortDescription = p.ShortDescription,
                                                Description = p.Description,
                                                MRP = p.MRP,
                                                ListPrice = c.ListPrice,
                                                SellingPrice = c.SellingPrice,
                                                ItemsPerUnit = p.ItemsPerUnit,
                                                Notation = p.Notation,
                                                IsActive = p.IsActive,
                                                CategoryId = p.CategoryId,
                                                ManufacturerId = p.ManufacturerId,
                                                TaxId = p.TaxId,
                                                Tax = p.Tax,
                                                Rank = p.Rank,
                                                CreatedOrModifiedOn = p.CreatedOrModifiedOn,
                                                CreatedOrModifiedBy = p.CreatedOrModifiedBy,
                                                ApprovedOrCancelledOn = p.ApprovedOrCancelledOn,
                                                ApprovedOrCancelledBy = p.ApprovedOrCancelledBy,
                                                ApprovalStatus = p.ApprovalStatus,
                                                ImageId = p.ImageId,
                                                WeightId = p.WeightId,
                                                Manufacturer = p.Manufacturer,
                                                Category = p.Category,
                                                Unit = p.Unit,
                                                Weight = p.Weight,
                                                Image = p.Image

                                            }).ToList().AsQueryable();

            return products;

        }

    }
}
