using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Com.Jamim.Repository.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private string _dataContextKey = "DataContext";

        public JamimDataContext GetDataContext()
        {
            JamimDataContext dataContext = null;
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                dataContext = (JamimDataContext)HttpContext.Current.Items[_dataContextKey];

            return dataContext;
        }

        public void Store(JamimDataContext jamimDataContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                HttpContext.Current.Items[_dataContextKey] = jamimDataContext;
            else
                HttpContext.Current.Items.Add(_dataContextKey, jamimDataContext);
        }
    }
}
