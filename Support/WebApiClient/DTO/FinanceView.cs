namespace Rapport.Support.WebApiClient.DTO
{
    /// <summary>
    /// Финансовая информация.
    /// </summary>
    public class FinanceView
    {
        /// <summary>
        /// Баланс.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Лимит.
        /// </summary>
        public decimal Limit { get; set; }
    }
}
