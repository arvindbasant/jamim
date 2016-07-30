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
    public class RegionRepository : Repository<Region,int>,IRegionRepository
    {
        public RegionRepository(IUnitOfWork uow) : base(uow) { }


        public override IQueryable<Region> GetDbSet()
        {
            return DataContextFactory.GetDataContext().Regions;
        }

        public override string GetEntitySetName()
        {
            return "Regions";
        }

        public override Region FindBy(int Id)
        {
            return GetDbSet().FirstOrDefault<Region>(r => r.Id == Id);
        }
    }
}
