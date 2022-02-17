namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using System.Collections.Generic;

    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Представление чтения компании сотрудником поддержки.
    /// </summary>
    public class CompanyView
    {
        /// <summary>
        /// Индивидуальный предприниматель.
        /// </summary>
        public bool IsSoleProprietor { get; set; }
        public String IsSoleProprietorStr { get; set; }

        /// <summary>
        /// Форма организационно-правовой собственности.
        /// </summary>
        public LegalFormView LegalForm { get; set; }

        /// <summary>
        /// Город регистрации.
        /// </summary>
        public CityView RegistrationCity { get; set; }

        /// <summary>
        /// Адрес расположения основного подразделения (юридический).
        /// </summary>
        public string LegalAddress { get; set; }

        /// <summary>
        /// Адрес фактический.
        /// </summary>
        public string ActualAddress { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Телефон для связи.
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Полное наименование.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Краткое наименование.
        /// </summary>
        /// <remarks>Brief name.</remarks>        
        public string Name { get; set; }

        /// <summary>
        /// ИНН (Идентификационный Номер Налогоплательщика).
        /// </summary>
        /// <remarks>
        /// TIN (Tax Identification Number).
        /// </remarks>
        public string Tin { get; set; }

        /// <summary>
        /// КПП (Код причины постановки на учет).
        /// </summary>
        /// <remarks>Аналог термина в английском отстутсвует, использован наиболее часто встречающийся перевод.</remarks>
        public string TaxRegistrationReasonCode { get; set; }

        /// <summary>
        /// ОГРН (Основной Государственный Регистрационный Номер).
        /// </summary>
        /// <remarks>PSRN (Primary State Registration Number).</remarks>
        public string Psrn { get; set; }

        /// <summary>
        /// ОГРН (Основной Государственный Регистрационный Номер).
        /// </summary>
        /// <remarks>PSRNSP (Primary State Registration Number of the Sole Proprietor).</remarks>
        public string Psrnsp { get; set; }

        /// <summary>
        /// Расчетный счет.
        /// </summary>
        public string CheckingAccount { get; set; }

        /// <summary>
        /// Корреспондирующий счёт.
        /// </summary>
        public string CorrespondingAccount { get; set; }

        /// <summary>
        /// БИК (Банковский Идентификационный Код).
        /// </summary>
        /// <remarks>BIC (Bank Identification Code).</remarks>
        public string Bic { get; set; }

        /// <summary>
        /// Наименование банка.
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Должность подписанта.
        /// </summary>
        public string SignatoryPosition { get; set; }

        /// <summary>
        /// Полное имя подписанта.
        /// </summary>
        public string SignatoryFullName { get; set; }

        /// <summary>
        /// Номер паспорта подписанта.
        /// </summary>
        public string SignatoryPassportNumber { get; set; }

        /// <summary>
        /// Наименование документа, предоставляющего право подписи.
        /// </summary>
        public string SignaturePermission { get; set; }

        /// <summary>
        /// Индивидуальный предприниматель.
        /// </summary>
        public bool DraftIsSoleProprietor { get; set; }

        /// <summary>
        /// Форма организационно-правовой собственности.
        /// </summary>
        public LegalFormView DraftLegalForm { get; set; }

        /// <summary>
        /// Город регистрации.
        /// </summary>
        public CityView DraftRegistrationCity { get; set; }

        /// <summary>
        /// Адрес расположения основного подразделения (юридический).
        /// </summary>
        public string DraftLegalAddress { get; set; }

        /// <summary>
        /// Адрес фактический.
        /// </summary>
        public string DraftActualAddress { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        public string DraftPostcode { get; set; }

        /// <summary>
        /// Телефон для связи.
        /// </summary>
        public string DraftContactPhone { get; set; }

        /// <summary>
        /// Полное наименование.
        /// </summary>
        public string DraftFullName { get; set; }

        /// <summary>
        /// Краткое наименование.
        /// </summary>
        /// <remarks>Brief name.</remarks>        
        public string DraftName { get; set; }

        /// <summary>
        /// ИНН (Идентификационный Номер Налогоплательщика).
        /// </summary>
        /// <remarks>
        /// TIN (Tax Identification Number).
        /// </remarks>
        public string DraftTin { get; set; }

        /// <summary>
        /// КПП (Код причины постановки на учет).
        /// </summary>
        /// <remarks>Аналог термина в английском отстутсвует, использован наиболее часто встречающийся перевод.</remarks>
        public string DraftTaxRegistrationReasonCode { get; set; }

        /// <summary>
        /// ОГРН (Основной Государственный Регистрационный Номер).
        /// </summary>
        /// <remarks>PSRN (Primary State Registration Number).</remarks>
        public string DraftPsrn { get; set; }

        /// <summary>
        /// ОГРНИП (Основной Государственный Регистрационный Номер Индивидуального Предпринимателя).
        /// </summary>
        /// <remarks>PSRNSP (Primary State Registration Number of the Sole Proprietor).</remarks>
        public string DraftPsrnsp { get; set; }

        /// <summary>
        /// Расчетный счет.
        /// </summary>
        public string DraftCheckingAccount { get; set; }

        /// <summary>
        /// Корреспондирующий счёт.
        /// </summary>
        public string DraftCorrespondingAccount { get; set; }

        /// <summary>
        /// БИК (Банковский Идентификационный Код).
        /// </summary>
        /// <remarks>BIC (Bank Identification Code).</remarks>
        public string DraftBic { get; set; }

        /// <summary>
        /// Наименование банка.
        /// </summary>
        public string DraftBankName { get; set; }

        /// <summary>
        /// Должность подписанта.
        /// </summary>
        public string DraftSignatoryPosition { get; set; }

        /// <summary>
        /// Полное имя подписанта.
        /// </summary>
        public string DraftSignatoryFullName { get; set; }

        /// <summary>
        /// Номер паспорта подписанта.
        /// </summary>
        public string DraftSignatoryPassportNumber { get; set; }

        /// <summary>
        /// Наименование документа, предоставляющего право подписи.
        /// </summary>
        public string DraftSignaturePermission { get; set; }

        /// <summary>
        /// Согласие на обработку персональных данных.
        /// </summary>
        public bool PersonalDataProcessing { get; set; }

        /// <summary>
        /// Согласие на условия предоставления сервиса.
        /// </summary>
        public bool ServiceTerms { get; set; }

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        /// <remarks>Позднее может быть изменен.</remarks>        
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона для платежей.
        /// </summary>
        public string BillingPhone { get; set; }

        /// <summary>
        /// Статус профиля.
        /// </summary>
        public DirectoryItem ProfileState { get; set; }

        /// <summary>
        /// Причина изменения статуса профиля.
        /// </summary>
        public IReadOnlyCollection<DirectoryItem> ProfileStateReason { get; set; }

        /// <summary>
        /// Поле со строкой, в нее сконвертировно все содержимое из ProfileStateReason, в БЛ этого поля нет
        /// </summary>
        public String ProfileStateReasonStr { get; set; }

        /// <summary>
        /// Баланс и лимит компании, как агрегатора.
        /// </summary>
        public FinanceView AggregatorFinance { get; set; }

        /// <summary>
        /// Баланс и лимит компании, как работодателя.
        /// </summary>
        public FinanceView EmployerFinance { get; set; }
    }
}
