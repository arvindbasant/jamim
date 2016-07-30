using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Model.Stores;

namespace Com.Jamim.Model.Stores
{
    public interface IStoreRepository : IRepository<Store, int> { }
   
}
