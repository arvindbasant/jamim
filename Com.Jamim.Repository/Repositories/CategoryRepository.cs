using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Infrastructure.UnitOfWork;
using Com.Jamim.Model.Products;

namespace Com.Jamim.Repository.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork uow) : base(uow) { }

        public override IQueryable<Category> GetDbSet()
        {
            return DataContextFactory.GetDataContext().Categories;
        }

        public override string GetEntitySetName()
        {
            return "Categories";
        }

        public override Category FindBy(int Id)
        {
            return GetDbSet().FirstOrDefault<Category>(c => c.Id == Id);
        }

       
    }
}
