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

    public class RequestWithAuthResponseAndParams <TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        public static async Task<TResponse> Send ( 
            RequestType reqType, _BaseWebApiController ctrl, String lastUrlPart, Dictionary<string, object> uriParams, TRequest requestObject 
        )
        {
            HttpClient webCli = HttpClientWithAuthBuilder.Build();
            if (webCli == null) return null;

            Uri currUri = ctrl.Uri( FormattableStringFactory.Create(lastUrlPart), uriParams );

            Boolean flag = true;
            int counter = 0;
            while (flag == true)
            {
                try
                {
                    flag = false;
                    switch (reqType)
                    {
                        case RequestType.POST:
                            return await webCli.ThrowablePostAsync<TResponse>(currUri, requestObject);
                        case RequestType.PUT:
                            return await webCli.ThrowablePutAsync<TResponse>(currUri, requestObject);
                        default:
                            throw new Exception("Bad request type !");
                    }
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
                    break; // произошла какая-то другая ошибка 
                }

                if (counter > 2) break; // после 3-х попыток не удалось выполнить операцию без ошибок
                counter++;
            }

            return null; // операция завершена успешно
        }
    }
}
