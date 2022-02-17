namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Представление контрагента.
    /// </summary>
    public class CounterpartyView 
    {
        /// <summary>
        /// Идентификатор контрагента.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название или имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Форма.
        /// </summary>
        public DirectoryItem Form { get; set; }
    }
}
