using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Model.Locations;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Infrastructure.UnitOfWork;

namespace Com.Jamim.Repository.Repositories
{
    public class ServiceAreaRepository : Repository<ServiceArea,int>, IServiceAreaRepository
    {
        public ServiceAreaRepository(IUnitOfWork uow) : base(uow) { }

        public override IQueryable<ServiceArea> GetDbSet()
        {
            return DataContextFactory.GetDataContext().ServiceAreas;
        }

        public override string GetEntitySetName()
        {
            return "ServiceAreas";
        }

        public override ServiceArea FindBy(int Id)
        {
            return GetDbSet().FirstOrDefault<ServiceArea>(s => s.Id == Id);
        }
    }
}
