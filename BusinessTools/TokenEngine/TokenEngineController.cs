namespace Rapport.BusinessTools.TokenEngine
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using Rapport.AuxiliaryTools.WabApiTools;
    using Rapport.AuxiliaryTools.GenericsAndTemplates;
    using Rapport.AuxiliaryTools.AspNetStoragesInClassLib;

    // Access Token Expiration Time пока не используется никак
    public class TokenEngineController : _BaseWebApiController
    {
        private const String LogInGrantType   = "password";
        private const String RefreshGrantType = "refresh_token";

        private const String AccessTokenName  = "accessToken";
        private const String RefreshTokenName = "refreshToken";
        private const String ExpiresInName    = "accessTokenExpiresIn";

        private const String AuthHeaderName = "Authorization";
        private const String AuthPrefixName = "bearer ";
        
        private String _authRefreshURLPart;
        private String _logOutURLPart;
        
        public TokenEngineController(String waUrl, String auURLPart, String loURLPart)
            : base( new Uri( waUrl ), new HttpClient() )
        {
            _authRefreshURLPart = auURLPart;
            _logOutURLPart = loURLPart;
        }

        public async Task<Boolean> LogInAsync(String log, String pwd)
        {
            Boolean result = false;
            SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;

            AccessTokenRequest request = new AccessTokenRequest()
            {
                grant_type = LogInGrantType,
                username = log,
                password = pwd
            };
            try
            {
                AccessTokenResponse response = await HttpClient.ThrowablePostAsync<AccessTokenResponse>
                (
                    Uri( FormattableStringFactory.Create(_authRefreshURLPart), new Dictionary<string, object>() ),
                    request
                );

                if (response != null)
                {

                    String accessToken = response.access_token;
                    String refreshToken = response.refresh_token;
                    String accessTokenExpiresIn = response.expires_in.ToString();

                    sessWrap[AccessTokenName] = accessToken;
                    sessWrap[RefreshTokenName] = refreshToken;
                    sessWrap[ExpiresInName] = accessTokenExpiresIn;

                    result = true;
                }
            }
            catch( Exception ex ) // сюда попадаем, если ответ не содержит AccessTokenResponse, 
            {                     // соответственно предполагаем, что логин не удался и очищаем хранилища 

                sessWrap.Remove(AccessTokenName);
                sessWrap.Remove(RefreshTokenName);
                sessWrap.Remove(ExpiresInName);

                result = false;
            }

            return result;
        }

        public async Task<Boolean> UpdateTokensAsync()
        {
            Boolean result = false;

            SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
            String oldRefreshToken = (String) sessWrap[RefreshTokenName];
            if (oldRefreshToken != null )
            {
                AccessTokenRequest request = new AccessTokenRequest()
                {
                    grant_type = RefreshGrantType,
                    refresh_token = oldRefreshToken
                };

                try
                {
                    AccessTokenResponse response = await (Task<AccessTokenResponse>)HttpClient.ThrowablePutAsync<AccessTokenResponse>
                    (
                        Uri( FormattableStringFactory.Create(_authRefreshURLPart), new Dictionary<string, object>() ),
                        request
                    );

                    if (response != null)
                    {
                        String accessToken = response.access_token;
                        String refreshToken = response.refresh_token;
                        String accessTokenExpiresIn = response.expires_in.ToString();

                        sessWrap = SessionStateWrapperLazy.Instance;
                        sessWrap[AccessTokenName] = accessToken;
                        sessWrap[RefreshTokenName] = refreshToken;
                        sessWrap[ExpiresInName] = accessTokenExpiresIn;

                        result = true;
                    }
                }
                catch (Exception ex) // сюда попадаем, если ответ не содержит AccessTokenResponse, 
                {     // соответственно предполагаем, что рефреш не удался и очищаем хранилища 

                    sessWrap.Remove(AccessTokenName);
                    sessWrap.Remove(RefreshTokenName);
                    sessWrap.Remove(ExpiresInName);

                    result = false;
                }
            }

            return result;
        }

        public async Task LogOutAsync()
        {
            SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
            String accessToken = (String) sessWrap[AccessTokenName];
            sessWrap.Remove(AccessTokenName);
            sessWrap.Remove(RefreshTokenName);
            sessWrap.Remove(ExpiresInName);

            if (accessToken != null)
            {
                HttpClient webCli = new HttpClient();
                webCli.DefaultRequestHeaders.Accept.Clear();
                webCli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                webCli.DefaultRequestHeaders.Add(AuthHeaderName, AuthPrefixName + accessToken);

                try
                {
                    await webCli.ThrowableDeleteAsync
                    (
                        Uri( FormattableStringFactory.Create(_logOutURLPart), new Dictionary<string, object>() )
                    );
                }
                catch (Exception ex) // сюда попадаем, если ответ не содержит AccessTokenResponse, 
                {
                    var s = ex.Message;
                }
            }
        }

        public Boolean CheckLoggedInLightVersion()
        {
            return SessionStateWrapperLazy.Instance.IsSet(AccessTokenName);
        }

        public async Task<Boolean> CheckLoggedInHeavyVersionAsync()
        {
            return await UpdateTokensAsync();
        }

        public String GetCurrentAccessToken()
        {
            SessionStateWrapperLazy sessWrap = SessionStateWrapperLazy.Instance;
            String accessToken = (String) sessWrap[AccessTokenName];
            return accessToken;
        }
    }
}
