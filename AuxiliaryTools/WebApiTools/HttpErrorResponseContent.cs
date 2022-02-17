namespace Rapport.AuxiliaryTools.WabApiTools
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Описывает объект, который возвращается в теле (content) ответа HTTP при возникновении ошибок.
    /// </summary>
    /// <remarks>Подробности в <see cref="!:http://jsonapi.org/format/#document-top-level">JSON API</see>.</remarks>
    [DataContract]
    public class HttpErrorResponseContent
    {
        /// <summary>
        /// Возвращает список ошибок.
        /// </summary>
        [DataMember(Name = "errors", IsRequired = true)]
        public ICollection<ErrorDescriptor> Errors { get; } = new List<ErrorDescriptor>();
    }
}
