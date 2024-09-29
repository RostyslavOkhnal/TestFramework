using Domain.Web;

namespace Core.Web.Settings
{
    public class DriverSettings
    {
        public string SettingsPath = "DriverSettings.json";

        public DriverType Type { get; set; }

        public bool Headless { get; set; }
    }
}
