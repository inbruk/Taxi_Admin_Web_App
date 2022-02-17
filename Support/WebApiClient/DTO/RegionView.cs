namespace Rapport.Support.WebApiClient.DTO
{
    /// <summary>
    /// Представление региона.
    /// </summary>
    public class RegionView
    {
        /// <summary>
        /// Идентификатор региона.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название региона.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Полное название.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public CountryView Country { get; set; }
    }
}
