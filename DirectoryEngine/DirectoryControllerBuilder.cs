namespace Rapport.BusinessTools.DirectoryEngine
{
    using System;
    using Rapport.AuxiliaryTools.GenericsAndTemplates;
    using Rapport.AuxiliaryTools.ConfigurationEngine;

    // рефакторить позже так, чтобы все контроллеры грузились как-нибудь одинаково, например 
    internal class DirectoryControllerBuilder : AbstractBuilder<DirectoryController>
    {
        private const String CommonUrlName = "CommonUrl";

        public override DirectoryController GetResult()
        {
            String commonUrl = WebConfigAppSettingsSectionTool.ReadSettingValue(CommonUrlName);
            DirectoryController dc = new DirectoryController(commonUrl);
            return dc;
        }
    }
}
