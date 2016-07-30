using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Stores;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Infrastructure.UnitOfWork;

namespace Com.Jamim.Repository.Repositories
{
    public class StoreRepository : Repository<Store, int>, IStoreRepository
    {
        public StoreRepository(IUnitOfWork uow) : base(uow) { }

        public override IQueryable<Store> GetDbSet()
        {
            return DataContextFactory.GetDataContext().Stores;
        }

        public override string GetEntitySetName()
        {
            return "Stores";
        }

        public override Store FindBy(int Id)
        {
            return GetDbSet().FirstOrDefault<Store>(s => s.Id == Id);
        }
    }
}
