namespace Rapport.Support.WebApiClient.DTO
{
    using System;

    /// <summary>
    /// Комментарий к заказу.
    /// </summary>
    public class OrderCommentView
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата и время создания.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Текст комментария.
        /// </summary>
        public string Content { get; set; }
    }
}
