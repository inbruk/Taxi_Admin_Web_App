namespace Rapport.Support.WebApiClient
{
    using System;

    using Rapport.AuxiliaryTools.ConfigurationEngine;

    public static class WebApiClientBuilder // рефакторить позже так, чтобы все контроллеры грузились как-нибудь одинаково, например 
    {
        private const String CommonUrlName = "CommonUrl";

        public static WebApiClient Build()
        {
            String commonUrl = WebConfigAppSettingsSectionTool.ReadSettingValue(CommonUrlName);
            WebApiClient wc = new WebApiClient(commonUrl);
            return wc;
        }
    }
}
