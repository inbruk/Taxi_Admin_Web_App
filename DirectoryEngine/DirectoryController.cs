namespace Rapport.BusinessTools.DirectoryEngine
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using Rapport.AuxiliaryTools.WabApiTools;
    using Rapport.BusinessTools.AuthenticationEngine;
    using Rapport.BusinessTools.WebApiRequestHelpers;
    using Rapport.BusinessTools.LanguageEngine;

    /// <summary>
    /// Загружает из веб апи содержимое 1 словаря с учетом языка
    /// </summary>
    internal class DirectoryController : _BaseWebApiController
    {
        private AuthenticationEngine _authEngine;

        public DirectoryController(String commonUrl)
            : base( new Uri(commonUrl), new HttpClient() )
        {
            _authEngine = AuthenticationEngineHandler.Get();
        }

        public async Task< JsonArray<DirectoryItem> > LoadDirectoryAsync(DirectoryIds dirId)
        {
            // получим последний кусок урла для заданного словаря
            String lastPartOfUrl = DirectoryDefinitionPool.GetLastPartOfUrlById( dirId );

            // текущий язык автоматически подставляется внутри заголовка
            var result = await RequestWithAuthAndResponseWithoutParams< JsonArray<DirectoryItem> >.Send
            (
                RequestType.GET,
                this,
                lastPartOfUrl,
                new Dictionary<string, object>()
            );

            return result;
        }
    }
}
