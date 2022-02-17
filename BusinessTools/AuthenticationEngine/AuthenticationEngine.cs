using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rapport.AuxiliaryTools.AsyncHelper;
using Rapport.AuxiliaryTools.AspNetStoragesInClassLib;
using Rapport.BusinessTools.TokenEngine;
using Rapport.AuxiliaryTools.ConfigurationEngine;

namespace Rapport.BusinessTools.AuthenticationEngine
{
    public class AuthenticationEngine
    {
        private const String CommonUrlName = "CommonUrl";
        private const String LogInURLPartName = "LogInURLPart";
        private const String LogOutURLPartName = "LogOutURLPart";

        private TokenEngine.TokenEngineController _te = null;

        public AuthenticationEngine()
        {           
            String CommonUrl = WebConfigAppSettingsSectionTool.ReadSettingValue(CommonUrlName);
            String LogInURLPart = WebConfigAppSettingsSectionTool.ReadSettingValue(LogInURLPartName);
            String LogOutURLPart = WebConfigAppSettingsSectionTool.ReadSettingValue(LogOutURLPartName);

            _te = TokenEngineHandler.Get( CommonUrl, LogInURLPart, LogOutURLPart );            
        }

        public Boolean IsLoggedIn()
        {
            return _te.CheckLoggedInLightVersion();
        }

        public async Task<Boolean> LogInAsync(String log, String pwd)
        {
            return await _te.LogInAsync(log, pwd);
        }

        public Boolean LogIn(String log, String pwd)
        {
            Boolean result =
                AsyncHelper.RunSync<Boolean>
                (
                    () => _te.LogInAsync(log, pwd)
                );

            return result;
        }

        public async Task<Boolean> UpdateTokensAsync()
        {
            return await _te.UpdateTokensAsync();
        }

        public Boolean UpdateTokens()
        {
            Boolean result =
                AsyncHelper.RunSync
                (
                    () => _te.UpdateTokensAsync()
                );

            return result;
        }

        public async Task LogOutAsync()
        {
            await _te.LogOutAsync();
        }

        public void LogOut()
        {
            AsyncHelper.RunSync
            (
                () => _te.LogOutAsync()
            );
        }

        public String GetCurrentAccessToken()
        {
            return _te.GetCurrentAccessToken();
        }
    }
}
