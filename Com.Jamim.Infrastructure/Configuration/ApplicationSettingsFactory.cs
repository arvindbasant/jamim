using Com.Jamim.Infrastructure.Configuration;

namespace Com.Jamim.Infrastructure.Configuration
{
    public class ApplicationSettingsFactory
    {
        public static IApplicationSettings _applicationSettings;

        public static void InitializeApplicationSettingFactory(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return _applicationSettings;
        }
    }
}
