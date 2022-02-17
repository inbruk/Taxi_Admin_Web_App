namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Представление записи в реестре счета контрагента.
    /// </summary>
    public class RecordView
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Платежная система.
        /// </summary>
        /// <remarks>Если операция внутренняя, то поле отсутствует.</remarks>
        public DirectoryItem PaymentSystem { get; set; }
        
        /// <summary>
        /// Тип записи.
        /// </summary>
        /// <remarks>Например "Поступление" или "Комиссия системы".</remarks>
        public DirectoryItem RecordType { get; set; }

        /// <summary>
        /// Контрагент отправитель.
        /// </summary>
        public CounterpartyView Source { get; set; }

        /// <summary>
        /// Контрагент получатель.
        /// </summary>
        public CounterpartyView Destination { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Сумма.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Комиссия (сбор) платежной системы.
        /// </summary>
        /// <remarks>Если операция внутренняя, то поле отсутствует.</remarks>
        public decimal? Commission { get; set; }

        /// <summary>
        /// Сальдо.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Дата и время обработки операции.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
    }
}
