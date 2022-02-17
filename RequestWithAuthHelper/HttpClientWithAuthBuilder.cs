namespace Rapport.BusinessTools.WebApiRequestHelpers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Rapport.BusinessTools.AuthenticationEngine;
    using Rapport.BusinessTools.LanguageEngine;

    public static class HttpClientWithAuthBuilder
    {
        private const String AuthHeaderName = "Authorization";
        private const String AuthPrefixName = "bearer ";
        private const String LanguageHeaderName = "Accept-Language";

        public static HttpClient Build()
        {
            String LanguageHeaderValue = LanguageEngine.GetAcceptLanguageHeaderValueById(); // получим заголовок для текущего языка

            AuthenticationEngine ae = AuthenticationEngineHandler.Get();
            String currentAccessToken = ae.GetCurrentAccessToken();
            if (currentAccessToken == null) return null;

            HttpClient webCli = new HttpClient();
            webCli.DefaultRequestHeaders.Accept.Clear();
            webCli.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json") );
            webCli.DefaultRequestHeaders.Add( AuthHeaderName, AuthPrefixName + currentAccessToken );
            webCli.DefaultRequestHeaders.Add( LanguageHeaderName, LanguageHeaderValue );

            return webCli;
        }
    }
}
