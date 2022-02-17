#pragma warning disable 1591
namespace Rapport.AuxiliaryTools.WabApiTools
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// Предоставляет базовый класс для оберток контроллеров микросервисов.
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class _BaseWebApiController
    {
        private readonly Uri baseUriWithSlash;
        private readonly Uri baseUri;

        protected HttpClient HttpClient { get; }

        /// <summary>
        /// Инициализирует новый экземпляр типа <see cref="_BaseController"/> с указанным базовым URI.
        /// </summary>
        /// <param name="baseUri">Базовый URI.</param>
        /// <param name="httpClient">Клиент HTTP.</param>
        protected _BaseWebApiController(Uri baseUri, HttpClient httpClient)
        {
            if (baseUri.ToString().EndsWith("/"))
            {
                baseUriWithSlash = baseUri;
                this.baseUri = baseUri;
            }
            else
            {
                baseUriWithSlash = new Uri(baseUri.ToString() + '/');
                this.baseUri = baseUri;
            }

            HttpClient = httpClient;
        }

        /// <summary>
        /// Строит URI из базового URI и строки форматирования, содержащей дополнительные параметры.
        /// </summary>
        /// <remarks>
        /// Значения параметров кодируются безопасным для передачи через HTTP способом (URL encoding).
        /// </remarks>
        /// <example>
        /// <code>
        /// var uri = Uri($"{id}?date={date}");
        /// </code>
        /// </example>
        /// <param name="formattableString"></param>
        /// <returns>URI.</returns>
        private Uri Uri(FormattableString formattableString)
        {
            var suffix = formattableString.ToString(new UrlFormatProvider());

            if (suffix == string.Empty)
                return baseUri;

            return new Uri(baseUriWithSlash, suffix);
        }

        /// <summary>
        /// Строит URI из базового URI, строки подключения, и словаря Query-string параметров.
        /// </summary>
        /// Используется в RequestWithAuthHelper, поэтому public !!! 
        /// <param name="formattableString">Строка подключения.</param>
        /// <param name="parameters">Словарь Query-string параметров.</param>
        /// <returns>URI.</returns>
        [SuppressMessage("ReSharper", "SpecifyACultureInStringConversionExplicitly")]
        [SuppressMessage("ReSharper", "MergeConditionalExpression")]
        public Uri Uri(FormattableString formattableString, Dictionary<string, object> parameters)
        {
            var parameterPairs = new List<(string name, string value)>();
            foreach (var parameter in parameters)
            {
                if (parameter.Value == null)
                    continue;

                var name = parameter.Key;

                if (parameter.Value is DateTimeOffset)
                    AddParameter(parameterPairs, name, (DateTimeOffset)parameter.Value);
                else if (parameter.Value is DateTime)
                    AddParameter(parameterPairs, name, (DateTime)parameter.Value);
                else if (parameter.Value is TimeSpan)
                    AddParameter(parameterPairs, name, (TimeSpan)parameter.Value);
                else if (parameter.Value is IEnumerable)
                {
                    foreach (var value in (IEnumerable)parameter.Value)
                    {
                        if (value is DateTimeOffset)
                            AddParameter(parameterPairs, name, (DateTimeOffset)value);
                        else if (value is DateTime)
                            AddParameter(parameterPairs, name, (DateTime)value);
                        else if (value is TimeSpan)
                            AddParameter(parameterPairs, name, (TimeSpan)value);
                        else
                            AddParameter(parameterPairs, name, value.ToString());
                    }
                }
                else
                    AddParameter(parameterPairs, name, parameter.Value.ToString());
            }

            var assings = from parameterPair in parameterPairs
                          select $"{parameterPair.name}={parameterPair.value}";

            var queryString = string.Join("&", assings);

            var suffix = formattableString.ToString(new UrlFormatProvider());

            if (queryString.Length > 0)
                suffix += '?' + queryString;

            if (suffix == string.Empty)
                return baseUri;

            return new Uri(baseUriWithSlash, suffix);
        }

        private void AddParameter(ICollection<(string name, string value)> parameters, string name, DateTimeOffset value)
        {
            parameters.Add((name, value.UtcDateTime.ToString("O")));
        }

        private void AddParameter(ICollection<(string name, string value)> parameters, string name, DateTime value)
        {
            parameters.Add((name, value.ToString("s")));
        }

        private void AddParameter(ICollection<(string name, string value)> parameters, string name, TimeSpan value)
        {
            parameters.Add((name, value.ToString("c")));
        }

        private void AddParameter(ICollection<(string name, string value)> parameters, string name, string value)
        {
            parameters.Add((name, value));
        }

        /// <summary>
        /// Формирует URI с параметром-массивом.
        /// </summary>
        /// <param name="formattableString">Строка подключения.</param>
        /// <param name="parameterName">Имя параметра.</param>
        /// <param name="values">Значения.</param>
        /// <returns>URI.</returns>
        protected Uri Uri<T>(FormattableString formattableString, string parameterName, IEnumerable<T> values)
        {
            var queryString = ToQueryString(parameterName, values);
            var suffix = formattableString.ToString(new UrlFormatProvider());

            if (queryString.Length > 0)
                suffix += '?' + queryString;

            if (suffix == string.Empty)
                return baseUri;

            return new Uri(baseUriWithSlash, suffix);
        }

        /// <summary>
        /// Возвращает базовый URI.
        /// </summary>
        /// <returns>URI.</returns>
        protected Uri Uri()
        {
            return baseUri;
        }

        /// <summary>
        /// Конвертирует набор элементов в Query-string, не включая символ <c>'?'</c>.
        /// </summary>
        /// <typeparam name="T">Тип элементов.</typeparam>
        /// <param name="paramName">Название параметра.</param>
        /// <param name="values">Список элементов.</param>
        /// <returns>Query-string, не включая символ <c>'?'</c>.</returns>
        protected static string ToQueryString<T>(string paramName, IEnumerable<T> values)
        {
            if (values == null)
                return null;

            return string.Join("&", values.Select(x => $"{paramName}={x}"));
        }

        /// <summary>
        /// Используется для форматирования адресов URI.
        /// </summary>
        /// <remarks>
        /// <see cref="!:http://www.thomaslevesque.com/2015/02/24/customizing-string-interpolation-in-c-6/">Пользовательские форматы интерполированных строк</see>.
        /// </remarks>
        private class UrlFormatProvider : IFormatProvider
        {
            private static readonly UrlFormatter Formatter = new UrlFormatter();

            public object GetFormat(Type formatType)
            {
                if (formatType == typeof(ICustomFormatter))
                    return Formatter;

                return null;
            }

            class UrlFormatter : ICustomFormatter
            {
                public string Format(string format, object arg, IFormatProvider formatProvider)
                {
                    if (arg == null)
                        return string.Empty;

                    if (format == "raw")
                        return arg.ToString();

                    if (arg is DateTimeOffset && string.IsNullOrEmpty(format))
                        return ((DateTimeOffset)arg).UtcDateTime.ToString("O");

                    if (arg is DateTime && string.IsNullOrEmpty(format))
                        return ((DateTime)arg).ToString("s");

                    if (arg is TimeSpan && string.IsNullOrEmpty(format))
                        return ((TimeSpan)arg).ToString("c");

                    if (arg is IFormattable)
                        return ((IFormattable)arg).ToString(format, formatProvider);

                    return System.Uri.EscapeDataString(arg.ToString());
                }
            }
        }
    }
}
