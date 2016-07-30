using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Products;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Infrastructure.UnitOfWork;


namespace Com.Jamim.Repository.Repositories
{
    public  class CategoryAccessRepository : Repository<CategoryAccess,int>,ICategoryAccessRepository
    {
        public CategoryAccessRepository(IUnitOfWork uow) : base(uow) { }

        public override IQueryable<CategoryAccess> GetDbSet()
        {
            return DataContextFactory.GetDataContext().CategoryAccess;
        }

        public override string GetEntitySetName()
        {
            return "CategoryAccess";
        }

        public override CategoryAccess FindBy(int Id)
        {
            return GetDbSet().FirstOrDefault<CategoryAccess>(r => r.Id == Id);
        }
    }
}
