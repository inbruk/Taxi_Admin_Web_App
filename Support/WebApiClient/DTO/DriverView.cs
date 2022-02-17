namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Модель водителя с точки зрения службы поддержки.
    /// </summary>
    public class DriverView
    {
        /// <summary>
        /// Идентификатор водителя
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Имя, отчество.
        /// </summary>
        public string GivenNames { get; set; }
        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Идентификатор компании-работодателя, если самозанятый водитель.
        /// </summary>
        public long? OwnEmployerId { get; set; }
        /// <summary>
        /// Номер телефона, на который зарегистрирован водитель.
        /// </summary>
        public string RegistrationPhone { get; set; }
        /// <summary>
        /// Состояние профиля водителя.
        /// </summary>
        public DirectoryItem ProfileState { get; set; }
        /// <summary>
        /// Дата и время последнего медицинского освидетельствования.
        /// </summary>
        public DateTime? MedicalExaminationDate { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public DirectoryItem Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Гражданство.
        /// </summary>
        public CountryView CitizenshipCountry { get; set; }
        /// <summary>
        /// Гражданство (для редактирования).
        /// </summary>
        public CountryView DraftCitizenshipCountry { get; set; }
        /// <summary>
        /// Город фактического адреса.
        /// </summary>
        public CityView HomeCity { get; set; }
        /// <summary>
        /// Город фактического адреса (для редактирования).
        /// </summary>
        public CityView DraftHomeCity { get; set; }
        /// <summary>
        /// Улица фактического адреса.
        /// </summary>
        public string HomeThoroughfare { get; set; }
        /// <summary>
        /// Улица фактического адреса (для редактирования).
        /// </summary>
        public string DraftHomeThoroughfare { get; set; }
        /// <summary>
        /// Дом фактического адреса.
        /// </summary>
        public string HomePremise { get; set; }
        /// <summary>
        /// Дом фактического адреса (для редактирования).
        /// </summary>
        public string DraftHomePremise { get; set; }
        /// <summary>
        /// Квартира фактического адреса.
        /// </summary>
        public string HomeSubpremise { get; set; }
        /// <summary>
        /// Квартира фактического адреса (для редактирования).
        /// </summary>
        public string DraftHomeSubpremise { get; set; }
        /// <summary>
        /// Почтовый индекс фактического адреса.
        /// </summary>
        public string HomePostalCode { get; set; }
        /// <summary>
        /// Почтовый индекс фактического адреса (для редактирования).
        /// </summary>
        public string DraftHomePostalCode { get; set; }
        /// <summary>
        /// Город адреса регистрации.
        /// </summary>
        public CityView ResidenceCity { get; set; }
        /// <summary>
        /// Город адреса регистрации (для редактирования).
        /// </summary>
        public CityView DraftResidenceCity { get; set; }
        /// <summary>
        /// Улица адреса регистрации.
        /// </summary>
        public string ResidenceThoroughfare { get; set; }
        /// <summary>
        /// Улица адреса регистрации (для редактирования).
        /// </summary>
        public string DraftResidenceThoroughfare { get; set; }
        /// <summary>
        /// Дом адреса регистрации.
        /// </summary>
        public string ResidencePremise { get; set; }
        /// <summary>
        /// Дом адреса регистрации (для редактирования).
        /// </summary>
        public string DraftResidencePremise { get; set; }
        /// <summary>
        /// Квартира адреса регистрации.
        /// </summary>
        public string ResidenceSubpremise { get; set; }
        /// <summary>
        /// Квартира адреса регистрации (для редактирования).
        /// </summary>
        public string DraftResidenceSubpremise { get; set; }

        /// <summary>
        /// полный адрес для карточки водителя
        /// </summary>
        public String FullResidenceAddress
        {
            get
            {
                String result = "";

                if ( ResidenceCity != null )         result = result + ResidenceCity.Name + ", ";
                if ( ResidenceThoroughfare != null ) result = result + ResidenceThoroughfare + " ";
                if ( ResidencePremise != null )      result = result + ResidencePremise + ", ";
                if ( ResidenceSubpremise != null)    result = result + ResidenceSubpremise;

                return result;
            }
        }

        /// <summary>
        /// черновой полный адрес для карточки водителя
        /// </summary>
        public String DraftFullResidenceAddress
        {
            get
            {
                String result = "";

                if ( DraftResidenceCity != null )         result = result + DraftResidenceCity.Name + ", ";
                if ( DraftResidenceThoroughfare != null ) result = result + DraftResidenceThoroughfare + " ";
                if ( DraftResidencePremise != null )      result = result + DraftResidencePremise + ", ";
                if ( DraftResidenceSubpremise != null )   result = result + DraftResidenceSubpremise;

                return result;
            }
        }
        /// <summary>
        /// Почтовый индекс адреса регистрации.
        /// </summary>
        public string ResidencePostalCode { get; set; }
        /// <summary>
        /// Почтовый индекс адреса регистрации (для редактирования).
        /// </summary>
        public string DraftResidencePostalCode { get; set; }
        /// <summary>
        /// Страна выдачи водительских прав.
        /// </summary>
        public CountryView LicenseCountry { get; set; }
        /// <summary>
        /// Страна выдачи водительских прав (для редактирования).
        /// </summary>
        public CountryView DraftLicenseCountry { get; set; }
        /// <summary>
        /// Номер водительских прав.
        /// </summary>
        public string LicenseNumber { get; set; }
        /// <summary>
        /// Номер водительских прав (для редактирования).
        /// </summary>
        public string DraftLicenseNumber { get; set; }
        /// <summary>
        /// Категории водительских прав.
        /// </summary>
        public DirectoryItem[] LicenseClasses { get; set; }

        /// <summary>
        /// Все категории транспорта в одной строке
        /// </summary>
        public String FullLicenseClasses
        {
            get
            {
                StringBuilder sb = new StringBuilder(500);
                foreach(var currItem in LicenseClasses)
                {
                    sb.Append(currItem.Name);
                    sb.Append(" ");
                }
                String result = sb.ToString();
                return result;
            }
        }

        /// <summary>
        /// Категории водительских прав (для редактирования).
        /// </summary>
        public DirectoryItem[] DraftLicenseClasses { get; set; }

        /// <summary>
        /// Все категории транспорта в одной строке (черновик)
        /// </summary>
        public String DraftFullLicenseClasses
        {
            get
            {
                StringBuilder sb = new StringBuilder(500);
                foreach (var currItem in LicenseClasses)
                {
                    sb.Append(currItem.Name);
                    sb.Append(" ");
                }
                String result = sb.ToString();
                return result;
            }
        }

        /// <summary>
        /// Дата выдачи водительских прав.
        /// </summary>
        public DateTime? LicenseStartDate { get; set; }
        /// <summary>
        /// Дата выдачи водительских прав (для редактирования).
        /// </summary>
        public DateTime? DraftLicenseStartDate { get; set; }
        /// <summary>
        /// Срок действия водительских прав.
        /// </summary>
        public DateTime? LicenseEndDate { get; set; }
        /// <summary>
        /// Срок действия водительских прав (для редактирования).
        /// </summary>
        public DateTime? DraftLicenseEndDate { get; set; }
        /// <summary>
        /// Год начала стажа.
        /// </summary>
        public int? ExperienceFrom { get; set; }
        /// <summary>
        /// Год начала стажа (для редактирования).
        /// </summary>
        public int? DraftExperienceFrom { get; set; }
        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public string PassportNumber { get; set; }
        /// <summary>
        /// Номер паспорта (для редактирования).
        /// </summary>
        public string DraftPassportNumber { get; set; }
        /// <summary>
        /// Кем выдан паспорт.
        /// </summary>
        public string PassportIssuedBy { get; set; }
        /// <summary>
        /// Кем выдан паспорт (для редактирования).
        /// </summary>
        public string DraftPassportIssuedBy { get; set; }
        /// <summary>
        /// Когда выдан паспорт.
        /// </summary>
        public DateTime? PassportStartDate { get; set; }
        /// <summary>
        /// Когда выдан паспорт (для редактирования).
        /// </summary>
        public DateTime? DraftPassportStartDate { get; set; }
        /// <summary>
        /// ИНН.
        /// </summary>
        public string Tin { get; set; }
        /// <summary>
        /// ИНН (для редактирования).
        /// </summary>
        public string DraftTin { get; set; }
        /// <summary>
        /// Согласен на обработку персональных данных.
        /// </summary>
        public bool IsAgreedPersonalDataProcessing { get; set; }
        /// <summary>
        /// Согласен с условиями использования сервиса.
        /// </summary>
        public bool IsAgreedServiceTerms { get; set; }
        /// <summary>
        /// Смена
        /// </summary>
        public ShiftView Shift { get; set; }
        /// <summary>
        /// Финансы
        /// </summary>
        public FinanceView Finance { get; set; }
    }
}
