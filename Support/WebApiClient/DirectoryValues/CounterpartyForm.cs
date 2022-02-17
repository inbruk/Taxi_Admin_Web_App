namespace Rapport.Support.WebApiClient.DirectoryValues
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Перечисляет формы контрагентов.
    /// </summary>
    public enum CounterpartyForm
    {
        /// <summary>
        /// Ни одна из форм.
        /// </summary>
        [Display(Name = nameof(None))]
        None = 0x0000,

        /// <summary>
        /// Компания-агрегатор.
        /// </summary>
        [Display(Name = nameof(Aggregator))]
        Aggregator = 0x0001,

        /// <summary>
        /// Компания-работодатель.
        /// </summary>
        [Display(Name = nameof(Employer))]
        Employer = 0x0002,

        /// <summary>
        /// Персона-водитель.
        /// </summary>
        [Display(Name = nameof(Driver))]
        Driver = 0x0100,
    }
}
