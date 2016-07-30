using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Model.Catalog;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Infrastructure.UnitOfWork;

namespace Com.Jamim.Repository.Repositories
{
    public class CatalogRepository : Repository<Catalog, int>, ICatalogRepository
    {
        public CatalogRepository(IUnitOfWork uow) : base(uow) { }
        public override IQueryable<Catalog> GetDbSet()
        {
            return DataContextFactory.GetDataContext().Catalogues;
        }

        public override string GetEntitySetName()
        {
            return "Catalogues";
        }

        public override Catalog FindBy(int Id)
        {
            return GetDbSet().FirstOrDefault<Catalog>(c => c.Id == Id);
        }
    }
}
