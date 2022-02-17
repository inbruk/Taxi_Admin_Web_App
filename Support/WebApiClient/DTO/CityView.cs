namespace Rapport.Support.WebApiClient.DTO
{
    /// <summary>
    /// Представление города.
    /// </summary>
    public class CityView
    {
        /// <summary>
        /// Идентификатор города.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Регион.
        /// </summary>
        public RegionView Region { get; set; }
    }
}
