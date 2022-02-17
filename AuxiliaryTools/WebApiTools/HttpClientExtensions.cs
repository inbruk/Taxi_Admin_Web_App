namespace Rapport.AuxiliaryTools.WabApiTools
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using System.Net.Http.Formatting;
    using Newtonsoft.Json;

    /// <summary>
    /// Предоставляет методы для простых запросов к микросервисам по протоколу HTTP.
    /// </summary>
    public static class HttpClientExtensions
    {
        private static readonly MediaTypeFormatter[] SupportedFormatters =
        {
            new JsonMediaTypeFormatter(),
            new XmlMediaTypeFormatter(),
        };

        private static HttpContent CreateJsonContent(object value)
        {
            var jsonContent = JsonConvert.SerializeObject(value);
            return new StringContent(jsonContent, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Асинхронно генерирует исключительную ситуацию.
        /// </summary>
        /// <param name="responseMessageTask"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseMessageException"></exception>
        public static async Task<HttpResponseMessage> ThrowIfInvalidStatusAsync(this Task<HttpResponseMessage> responseMessageTask)
        {
            var responseMessage = await responseMessageTask.ConfigureAwait(false);

            if (responseMessage.IsSuccessStatusCode)
                return responseMessage;

            var statusCode = responseMessage.StatusCode;
            var content = await responseMessage.Content.ReadAsAsync<HttpErrorResponseContent>(SupportedFormatters)
                                               .ConfigureAwait(false);

            throw new HttpResponseMessageException(statusCode, content);
        }

        /// <summary>
        /// Асинхронно получает содержимое из ответа на запрос. 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="responseMessageTask"></param>
        /// <returns></returns>
        public static async Task<TResult> ReadContentAsync<TResult>(this Task<HttpResponseMessage> responseMessageTask)
        {
            var responseMessage = await responseMessageTask;

            return await responseMessage.Content.ReadAsAsync<TResult>()
                                        .ConfigureAwait(false);
        }

        /// <summary>
        /// Асинхронно посылает POST запрос без параметров по указанному адресу и возвращает полученный объект.
        /// </summary>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        /// <returns>Результат запроса.</returns>
        public static async Task ThrowablePostAsync(this HttpClient client, Uri uri)
        {
            await client.PostAsync(uri, null)
                        .ThrowIfInvalidStatusAsync();
        }

        /// <summary>
        /// Асинхронно посылает POST запрос, передавая указанный объект в качестве параметра в содержимом и возвращает полученный объект.
        /// </summary>        
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        /// <param name="value">Значение для передачи.</param>
        /// <returns>Результат запроса.</returns>
        public static async Task ThrowablePostAsync(this HttpClient client, Uri uri, object value)
        {
            var content = CreateJsonContent(value);

            await client.PostAsync(uri, content)
                        .ThrowIfInvalidStatusAsync();
        }

        /// <summary>
        /// Асинхронно посылает POST запрос без параметров по указанному адресу и возвращает полученный объект.
        /// </summary>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        /// <returns>Результат запроса.</returns>
        public static async Task<TResult> ThrowablePostAsync<TResult>(this HttpClient client, Uri uri)
        {
            return await client.PostAsync(uri, null)
                               .ThrowIfInvalidStatusAsync()
                               .ReadContentAsync<TResult>();
        }

        /// <summary>
        /// Асинхронно посылает POST запрос, передавая указанный объект в качестве параметра в содержимом и возвращает полученный объект.
        /// </summary>
        /// <typeparam name="TResult">Тип передаваемого объекта.</typeparam>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        /// <param name="value">Значение для передачи.</param>
        /// <returns>Результат запроса.</returns>
        public static async Task<TResult> ThrowablePostAsync<TResult>(this HttpClient client, Uri uri, object value)
        {
            var content = CreateJsonContent(value);

            return await client.PostAsync(uri, content)
                               .ThrowIfInvalidStatusAsync()
                               .ReadContentAsync<TResult>();
        }

        /// <summary>
        /// Асинхронно посылает запрос PUT запрос, передавая указанный объект в качестве параметра в содержимом.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="uri"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task ThrowablePutAsync(this HttpClient client, Uri uri, object value)
        {
            var content = CreateJsonContent(value);

            await client.PutAsync(uri, content)
                        .ThrowIfInvalidStatusAsync();
        }

        /// <summary>
        /// Асинхронно посылает PUT запрос без параметров по указанному адресу.
        /// </summary>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        public static async Task ThrowablePutAsync(this HttpClient client, Uri uri)
        {
            await client.PutAsync(uri, null)
                        .ThrowIfInvalidStatusAsync();
        }

        /// <summary>
        /// Асинхронно посылает PUT запрос, передавая указанный объект в качестве параметра в содержимом и возвращает полученный объект.
        /// </summary>
        /// <typeparam name="TResult">Тип передаваемого объекта.</typeparam>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        /// <param name="value">Значение для передачи.</param>
        /// <returns>Результат запроса.</returns>
        public static async Task<TResult> ThrowablePutAsync<TResult>(this HttpClient client, Uri uri, object value)
        {
            var content = CreateJsonContent(value);

            return await client.PutAsync(uri, content)
                               .ThrowIfInvalidStatusAsync()
                               .ReadContentAsync<TResult>();
        }

        /// <summary>
        /// Асинхронно посылает PUT запрос без параметров по указанному адресу и возвращает полученный объект.
        /// </summary>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        /// <returns>Результат запроса.</returns>
        public static async Task<TResult> ThrowablePutAsync<TResult>(this HttpClient client, Uri uri)
        {
            return await client.PutAsync(uri, null)
                               .ThrowIfInvalidStatusAsync()
                               .ReadContentAsync<TResult>();
        }

        /// <summary>
        /// Асинхронно посылает GET запрос по указанному адресу и возвращает пришедший в ответе объект.
        /// </summary>
        /// <typeparam name="TResult">Тип возвращаемого объекта.</typeparam>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        /// <returns>Результат запроса.</returns>
        public static async Task<TResult> ThrowableGetAsync<TResult>(this HttpClient client, Uri uri)
        {
            return await client.GetAsync(uri)
                               .ThrowIfInvalidStatusAsync()
                               .ReadContentAsync<TResult>();
        }

        /// <summary>
        /// Асинхронно посылает DELETE запрос без параметров по указанному адресу.
        /// </summary>
        /// <param name="client">HTTP клиент.</param>
        /// <param name="uri">URI.</param>
        public static async Task ThrowableDeleteAsync(this HttpClient client, Uri uri)
        {
            await client.DeleteAsync(uri)
                        .ThrowIfInvalidStatusAsync();
        }
    }
}
