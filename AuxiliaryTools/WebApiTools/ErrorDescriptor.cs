namespace Rapport.AuxiliaryTools.WabApiTools
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Описывает <see cref="!:http://jsonapi.org/format/#error-objects">ошибку из JSON API</see>.
    /// </summary>
    [DataContract(Name = "error")]
    public class ErrorDescriptor
    {
        /// <summary>
        /// Возвращает или задает уникальный идентификатор ошибочной ситуации.
        /// </summary>
        [DataMember(Name = "id", IsRequired = false)]
        public string Id { get; set; }

        /// <summary>
        /// Возвращает или задает HTTP-статус, представленный как строковое значение.
        /// </summary>
        [DataMember(Name = "status", IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// Возвращает или задает код ошибки, специфичный для приложения.
        /// </summary>
        [DataMember(Name = "code", IsRequired = false)]
        public string Code { get; set; }

        /// <summary>
        /// Возвращает или задает краткое описание ошибки.
        /// </summary>
        [DataMember(Name = "title", IsRequired = true)]
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает детальное описание ошибки.
        /// </summary>
        [DataMember(Name = "detail", IsRequired = false)]
        public string Detail { get; set; }
    }
}
