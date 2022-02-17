namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using System.Collections.Generic;

    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Представление модели автомобиля.
    /// </summary>
    public class ModelView
    {
        /// <summary>
        /// Идентификатор модели.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название модели.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Полное название модели, включая марку, например Ford Mondeo.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Бренд (марка), к которому относится данная модель.
        /// </summary>
        public DirectoryItem Brand { get; set; }

        /// <summary>
        /// Класс ТС.
        /// </summary>
        public DirectoryItem Class { get; set; }
    }
}
