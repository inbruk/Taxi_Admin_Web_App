namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using System.Collections.Generic;
    
    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Представление смены.
    /// </summary>
    public class ShiftView
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Регистрационный номер автомобиля.
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Цвет автомобиля.
        /// </summary>
        public DirectoryItem VehicleColor { get; set; }

        /// <summary>
        /// Тип кузова автомобиля.
        /// </summary>
        public DirectoryItem VehicleBody { get; set; }

        /// <summary>
        /// Модель автомобиля.
        /// </summary>
        public ModelView VehicleModel { get; set; }

        /// <summary>
        ///  Классы ТС, для которых смена может принимать заказы.
        /// </summary>
        public IReadOnlyCollection<DirectoryItem> VehicleClasses { get; set; }

        /// <summary>
        /// Состояние смены.
        /// </summary>
        public DirectoryItem State { get; set; }

        /// <summary>
        /// Название компании-работодателя.
        /// </summary>
        public string EmployerCompanyName { get; set; }

        /// <summary>
        /// Время, до которого смена не может принимать заказы.
        /// </summary>
        public DateTimeOffset? BannedUntil { get; set; }

        /// <summary>
        /// Последнее известное/текущее местоположение
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Последний известный адрес местоположения
        /// </summary>
        public String LastKnownAddress { get; set; }
    }
}
