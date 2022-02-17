namespace Rapport.BusinessTools.TokenEngine
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Представление набора данных, описывающих токен аутентификации.
    /// </summary>
    /// <remarks>Подробности d <see cref="!:https://tools.ietf.org/html/rfc6749#section-5.1">RFC 6749</see>.</remarks>
    internal class AccessTokenResponse
    {
        /// <summary>
        /// Токен доступа.
        /// </summary>
        [Required]
        public string access_token { get; set; }

        /// <summary>
        /// Тип токена.
        /// Поле содержит <see cref="!:https://tools.ietf.org/html/rfc6749#section-7.1">строку "bearer"</see>.
        /// </summary>
        [Required]
        public string token_type { get; set; }

        /// <summary>
        /// Время жизни токена в секундах.
        /// </summary>
        [Required]
        public int expires_in { get; set; }

        /// <summary>
        /// Токен обновления.
        /// </summary>
        [Required]
        public string refresh_token { get; set; }
    }
}
