using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Com.Jamim.Repository.DataContextStorage
{
    public class DataContextStorageFactory
    {
        public static IDataContextStorageContainer _dataContextStorageContainer;


        public static IDataContextStorageContainer CreateStorageContainer()
        {
            if(_dataContextStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _dataContextStorageContainer = new ThreadDataContextStorageContainer();
                else
                    _dataContextStorageContainer = new HttpDataContextStorageContainer();
            }
            return _dataContextStorageContainer;
        }
    }
}
