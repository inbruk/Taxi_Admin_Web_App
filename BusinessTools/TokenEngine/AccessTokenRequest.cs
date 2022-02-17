namespace Rapport.BusinessTools.TokenEngine
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Набор данных, необходимых для аутентификации в соответствии со стандартом
    /// <see cref="!:https://tools.ietf.org/html/rfc6749#section-4.3.2">RFC 6749</see>.
    /// </summary>
    internal class AccessTokenRequest
    {
        /// <summary>
        /// Тип авторизации в соответствии со стандартом
        /// <see cref="!:https://tools.ietf.org/html/rfc6749">OAuth 2.0</see>. Поддерживаются
        /// значения <c>password</c> (https://tools.ietf.org/html/rfc6749#section-4.3),
        /// <c>refresh_token</c> (https://tools.ietf.org/html/rfc6749#section-6) и
        /// <c>http://taxys.ru/schema/grants/passwordless</c> (https://tools.ietf.org/html/rfc6749#section-4.5).
        /// </summary>
        [Required]
        public string grant_type { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// Адрес электронной почты или номер телефона. Номер телефона должен содержать только цифры
        /// и включать код страны, например, "79875554433". Поле используется при аутентификации
        /// <c>password</c> или <c>http://taxys.ru/schema/grants/passwordless</c>.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Пароль пользователя. Поле используется при аутентификации <c>password</c>.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Одноразовый код. Поле используется при аутентификации <c>http://taxys.ru/schema/grants/passwordless</c>.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Токен обновления. Поле используется при аутентификации <c>refresh_token</c>.
        /// </summary>
        public string refresh_token { get; set; }
    }
}
