using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Repository.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        JamimDataContext GetDataContext();
        void Store(JamimDataContext jamimDataContext);
    }
}
