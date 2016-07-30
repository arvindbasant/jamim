using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;

namespace Com.Jamim.Repository.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable _jamimDataContexts = new Hashtable();

        public JamimDataContext GetDataContext()
        {
            JamimDataContext libraryDataContext = null;

            if (_jamimDataContexts.Contains(GetThreadName()))
                libraryDataContext = (JamimDataContext)_jamimDataContexts[GetThreadName()];

            return libraryDataContext;
        }

        public void Store(JamimDataContext jamimDataContext)
        {
            if (_jamimDataContexts.Contains(GetThreadName()))
                _jamimDataContexts[GetThreadName()] = jamimDataContext;
            else
                _jamimDataContexts.Add(GetThreadName(), jamimDataContext);  
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }    
    }
}
