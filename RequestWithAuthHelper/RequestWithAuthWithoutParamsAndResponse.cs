namespace Rapport.BusinessTools.WebApiRequestHelpers
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.CompilerServices;

    using Rapport.AuxiliaryTools.WabApiTools;
    using Rapport.BusinessTools.AuthenticationEngine;

    public static class RequestWithAuthWithoutParamsAndResponse
    {
        public static async Task<Boolean> Send(RequestType reqType, _BaseWebApiController ctrl, String lastUrlPart, Dictionary<string, object> uriParams)
        {
            HttpClient webCli = HttpClientWithAuthBuilder.Build();
            if (webCli == null) return false;
            
            Uri currUri = ctrl.Uri( FormattableStringFactory.Create(lastUrlPart), uriParams );

            Boolean flag = true;
            int counter = 0;
            while( flag==true )
            {
                try
                {
                    flag = false;
                    switch (reqType)
                    {
                        case RequestType.POST:
                            await webCli.ThrowablePostAsync(currUri);
                        break;
                        case RequestType.PUT:
                            await webCli.ThrowablePutAsync(currUri);
                        break;
                        case RequestType.DELETE:
                            await webCli.ThrowableDeleteAsync(currUri);
                        break;
                        default:
                            throw new Exception("Bad request type !");
                    }
                    await webCli.ThrowableDeleteAsync(currUri);
                }
                catch (HttpResponseMessageException ex)
                {
                    if (ex.StatusCode == HttpStatusCode.Unauthorized) // возможно, прокис токен, надо его пересоздать
                    {
                        AuthenticationEngine ae = AuthenticationEngineHandler.Get();
                        Boolean loginResult = await ae.UpdateTokensAsync();
                        flag = loginResult;
                    }
                }
                catch
                { 
                    return false; // произошла какая-то другая ошибка 
                }

                if (counter > 2) return false; // после 3-х попыток не удалось выполнить операцию без ошибок
                counter++;
            }

            return true; // операция завершена успешно
        }
    }
}
