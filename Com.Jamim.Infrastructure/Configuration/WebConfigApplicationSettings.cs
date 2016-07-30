using System.Configuration;

namespace Com.Jamim.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public int NoOfRowsPerTable
        {
            get { return int.Parse(ConfigurationManager.AppSettings["NoOfRowsPerTable"]); }
        }

        public bool RegistrationAllowed
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["RegistrationAllowed"]); }
        }

        public string CustomerLoggerName
        {
            get { return ConfigurationManager.AppSettings["CustomerLoggerName"]; }
        }

        public string GatewayLoggerName
        {
            get { return ConfigurationManager.AppSettings["GatewayLoggerName"]; }
        }

        public string RetailerLoggerName
        {
            get { return ConfigurationManager.AppSettings["RetailerLoggerName"]; }
        }

        public string SupportLoggerName
        {
            get { return ConfigurationManager.AppSettings["SupportLoggerName"]; }
        }
    }
}
