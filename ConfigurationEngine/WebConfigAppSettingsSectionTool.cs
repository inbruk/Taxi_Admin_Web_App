namespace Rapport.AuxiliaryTools.ConfigurationEngine
{
    using System;
    using System.Threading.Tasks;
    using System.Configuration;

    public static class WebConfigAppSettingsSectionTool
    {
        public static String ReadSettingValue( String key )
        {
            String value = null;

            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count != 0)
                value = appSettings[key];

            return value;
        }
    }
}
