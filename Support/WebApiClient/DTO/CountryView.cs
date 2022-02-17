namespace Rapport.Support.WebApiClient.DTO
{
    /// <summary>
    /// Представление страны.
    /// </summary>
    public class CountryView
    {
        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название страны.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Полное название.
        /// </summary>
        public string FullName { get; set; }
    }
}
