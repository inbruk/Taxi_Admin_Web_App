namespace Rapport.Support.WebApiClient.DTO
{
    /// <summary>
    /// Смена и заказ.
    /// </summary>
    public class ShiftOrderView
    {
        /// <summary>
        /// Смена.
        /// </summary>
        public ShiftView Shift { get; set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        public OrderView Order { get; set; }
    }
}
