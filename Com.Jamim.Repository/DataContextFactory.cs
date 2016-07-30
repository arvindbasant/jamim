using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Repository.DataContextStorage;

namespace Com.Jamim.Repository
{
    public class DataContextFactory
    {
        public static JamimDataContext GetDataContext()
        {
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();

            JamimDataContext jamimDataContext = _dataContextStorageContainer.GetDataContext();
            if (jamimDataContext == null)
            {
                jamimDataContext = new JamimDataContext();
                _dataContextStorageContainer.Store(jamimDataContext);
            }
            return jamimDataContext;
        }
    }
}
