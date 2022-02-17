namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using System.Collections.Generic;

    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Представление ТС (транспортного средства).
    /// </summary>
    public class VehicleView
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Регистрационный номер ТС.
        /// </summary>        
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Город регистрации.
        /// </summary>
        public CityView RegistrationCity { get; set; }

        /// <summary>
        /// Дата регистрации.
        /// </summary>
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// Цвет ТС.
        /// </summary>
        public DirectoryItem Color { get; set; }

        /// <summary>
        /// Тип кузова ТС.
        /// </summary>
        public DirectoryItem Body { get; set; }

        /// <summary>
        /// Модель ТС.
        /// </summary>
        public ModelView Model { get; set; }

        /// <summary>
        /// Год выпуска ТС.
        /// </summary>
        public int? ManufactureYear { get; set; }

        /// <summary>
        /// Номер лицензии такси.
        /// </summary>
        public string LicenseNumber { get; set; }

        /// <summary>
        /// Наименование владельца лицензии такси.
        /// </summary>
        public string LicenseOwnerName { get; set; }

        /// <summary>
        /// Дата выдачи лицензии такси.
        /// </summary>
        public DateTime? LicenseStartDate { get; set; }

        /// <summary>
        /// Срок действия лицензии такси.
        /// </summary>
        public DateTime? LicenseEndDate { get; set; }

        /// <summary>
        /// Наименование органа, выдавшего лицензию такси.
        /// </summary>
        public string LicenseAuthorityIssued { get; set; }

        /// <summary>
        /// Номер страхового полиса ТС.
        /// </summary>
        public string InsuranceNumber { get; set; }

        /// <summary>
        /// Наименование организации выдавшей страховой полис.
        /// </summary>
        public string InsuranceAuthorityIssued { get; set; }

        /// <summary>
        /// Дата окончания действия страхового полиса.
        /// </summary>
        public DateTime? InsuranceEndDate { get; set; }

        /// <summary>
        /// Дата прохождения тех. осмотра ТС.
        /// </summary>
        public DateTime? InspectionDate { get; set; }

        /// <summary>
        /// Наименование собственника.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Основание владения.
        /// </summary>
        public DirectoryItem Possession { get; set; }

        /// <summary>
        /// Статус профиля.
        /// </summary>
        public DirectoryItem ProfileState { get; set; }
        /// <summary>
        /// Черновой цвет ТС.
        /// </summary>
        public DirectoryItem DraftColor { get; set; }

        /// <summary>
        /// Черновой тип кузова ТС.
        /// </summary>
        public DirectoryItem DraftBody { get; set; }

        /// <summary>
        /// Черновая модель ТС.
        /// </summary>
        public ModelView DraftModel { get; set; }

        /// <summary>
        /// Черновой год выпуска ТС.
        /// </summary>
        public int? DraftManufactureYear { get; set; }

        /// <summary>
        /// Черновое наименования собственника.
        /// </summary>
        public string DraftOwner { get; set; }

        /// <summary>
        /// Чернововая дата регистрации.
        /// </summary>
        public DateTime? DraftRegistrationDate { get; set; }

        /// <summary>
        /// Черновой город регистрации.
        /// </summary>
        public CityView DraftRegistrationCity { get; set; }

        /// <summary>
        /// Черновой номер лицензии такси.
        /// </summary>
        public string DraftLicenseNumber { get; set; }

        /// <summary>
        /// Черновое наименование владельца лицензии такси.
        /// </summary>
        public string DraftLicenseOwnerName { get; set; }

        /// <summary>
        /// Черновая дата начала действия (выдачи) лицензии такси.
        /// </summary>
        public DateTime? DraftLicenseStartDate { get; set; }

        /// <summary>
        /// Черновая дата окончания действия лицензии такси.
        /// </summary>
        public DateTime? DraftLicenseEndDate { get; set; }

        /// <summary>
        /// Черновое наименование органа, выдавшего лицензию такси.
        /// </summary>
        public string DraftLicenseAuthorityIssued { get; set; }

        /// <summary>
        /// Черновой номер страхового полиса ТС.
        /// </summary>
        public string DraftInsuranceNumber { get; set; }

        /// <summary>
        /// Черновое наименование организации выдавшей страховой полис.
        /// </summary>
        public string DraftInsuranceAuthorityIssued { get; set; }

        /// <summary>
        /// Черновая дата окончания действия страхового полиса.
        /// </summary>
        public DateTime? DraftInsuranceEndDate { get; set; }

        /// <summary>
        /// Черновая дата прохождения тех. осмотра ТС.
        /// </summary>
        public DateTime? DraftInspectionDate { get; set; }

        /// <summary>
        /// Черновое основание владения.
        /// </summary>
        public DirectoryItem DraftPossession { get; set; }

        /// <summary>
        /// Идентификаторы прикрепленных водителей.
        /// </summary>
        public ICollection<long> AttachedDriverIds { get; set; }
    }
}
