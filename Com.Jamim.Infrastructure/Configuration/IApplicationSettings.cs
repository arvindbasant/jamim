using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string CustomerLoggerName { get; }
        string GatewayLoggerName { get; }
        string RetailerLoggerName { get; }
        string SupportLoggerName { get;}
        int NoOfRowsPerTable { get; }
        bool RegistrationAllowed { get; }
    }
}
