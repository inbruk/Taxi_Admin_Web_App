namespace Rapport.Support.WebApiClient.DirectoryValues
{
    /// <summary>
    /// Описывает статусы профилей.
    /// </summary>
    public enum ProfileState
    {
        /// <summary>
        /// Профиль недозаполнен.
        /// </summary>
        /// <remarks>
        /// Состояние устанавливается при создании компании, водителя или автомобиля.
        /// </remarks>
        Incompleted = 10,

        /// <summary>
        /// Профиль заполнен, но не проверен.
        /// </summary>
        Updated = 20,

        /// <summary>
        /// Профиль на проверке.
        /// </summary>
        Verificating = 30,

        /// <summary>
        /// Профиль подтверждён.
        /// </summary>
        Approved = 40,

        /// <summary>
        /// Профиль утверждён.
        /// </summary>
        Confirmed = 50,

        /// <summary>
        /// Профиль отклонён.
        /// </summary>
        Rejected = 60,
    }
}
