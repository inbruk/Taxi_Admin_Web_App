namespace Rapport.Support.WebApiClient.DTO
{
    /// <summary>
    /// Представление организационно-правовой формы.
    /// </summary>
    public class LegalFormView
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        public long CountryId { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
