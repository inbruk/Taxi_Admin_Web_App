namespace Rapport.AuxiliaryTools.WabApiTools
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// Реализует исключение, возникающее в случае ошибок при вызове других микросервисов.
    /// </summary>
    [Serializable]
    public class HttpResponseMessageException : Exception
    {
        /// <summary>
        /// Возвращает код статуса, полученный при вызове метода микросервиса.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Возвращает объект, полученный при вызове метода микросервиса.
        /// </summary>
        public HttpErrorResponseContent Content { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="HttpResponseMessageException"/>.
        /// </summary>
        public HttpResponseMessageException(HttpStatusCode statusCode, HttpErrorResponseContent content)
            : base("Invalid HTTP status.")
        {
            StatusCode = statusCode;
            Content = content;
        }

        /// <summary>
        /// Десериализует экземпляр типа <see cref="HttpResponseMessageException"/> из потока сериализации.
        /// </summary>
        /// <param name="info">Поток сериализации.</param>
        /// <param name="context">Контекст сериализации.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected HttpResponseMessageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            StatusCode = (HttpStatusCode)info.GetValue(nameof(StatusCode), typeof(HttpStatusCode));
            Content = (HttpErrorResponseContent)info.GetValue(nameof(Content), typeof(HttpErrorResponseContent));
        }

        /// <summary>
        /// Сериализует экземпляр <see cref="HttpResponseMessageException"/>.
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(StatusCode), StatusCode, typeof(HttpStatusCode));
            info.AddValue(nameof(Content), Content, typeof(HttpErrorResponseContent));
        }
    }

}