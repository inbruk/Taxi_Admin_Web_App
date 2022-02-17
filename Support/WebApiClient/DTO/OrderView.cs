namespace Rapport.Support.WebApiClient.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Rapport.BusinessTools.DirectoryEngine;

    /// <summary>
    /// Представляет заказ с точки зрения техподдержки
    /// </summary>
    public class OrderView
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор тарифного плана.
        /// </summary>
        public long? TariffPlanId { get; set; }

        /// <summary>
        /// Адрес места отправления.
        /// </summary>
        public Place Start { get; set; }

        /// <summary>
        /// Адрес места назначения.
        /// </summary>
        public Place End { get; set; }

        /// <summary>
        /// Расчетная стоимость поездки.
        /// </summary>
        public decimal? EstimatedPrice { get; set; }

        /// <summary>
        /// Время бесплатного ожидания.
        /// </summary>
        public TimeSpan? FreeWaitingTime { get; set; }

        /// <summary>
        /// Стоимость ожидания.
        /// </summary>
        public decimal? WaitingPrice { get; set; }

        /// <summary>
        /// Стоимость пожеланий.
        /// </summary>
        /// <remarks>
        /// Если пассажир забыл указать перевозку животного, стоимость поездки окажется выше расчетной.
        /// Дополнительная стоимость определяется в момент посадки в машину.
        /// </remarks>
        public decimal? ExtraPrice { get; set; }

        /// <summary>
        /// Окончательная стоимость поездки.
        /// </summary>
        /// <remarks>
        /// Если во время поездки пассажир просил заехать на адрес, где-то остановиться и подождать,
        /// окончательная стоимость окажется выше расчетной. Окончательная стоимость определяется в момент
        /// прибытия к месту назначение.
        /// </remarks>
        public decimal? ActualPrice { get; set; }

        /// <summary>
        /// Дата и время создания.
        /// </summary>
        /// <remarks><c>null</c>, если статус не был установлен.</remarks>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Контрольное время заказа (время, на которое пассажир заказывает такси).
        /// </summary>
        /// <remarks>
        /// <c>null</c> означает ближайшее время.
        /// <c>null</c>, если статус не был установлен.
        /// </remarks>
        public DateTimeOffset? DepartedAt { get; set; }

        /// <summary>
        /// Время принятия заказа водителем.
        /// </summary>
        /// <remarks><c>null</c>, если статус не был установлен.</remarks>
        public DateTimeOffset? ArrivalAt { get; set; }

        /// <summary>
        /// Расчетная длительность доезда машины до пассажира.
        /// </summary>
        public TimeSpan? ArrivalTime { get; set; }

        /// <summary>
        /// Время доезда водителя к месту отправления.
        /// </summary>
        /// <remarks><c>null</c>, если статус не был установлен.</remarks>
        public DateTimeOffset? WaitingAt { get; set; }

        /// <summary>
        /// Время ожидания пассажира.
        /// </summary>
        /// <remarks><c>null</c>, если ожидание не началось.</remarks>
        public TimeSpan? WaitingTime { get; set; }

        /// <summary>
        /// Время начала поездки с пассажиром.
        /// </summary>
        /// <remarks><c>null</c>, если статус не был установлен.</remarks>
        public DateTimeOffset? ExecutingAt { get; set; }

        /// <summary>
        /// Время прибытия к месту назначения.
        /// </summary>
        public DateTimeOffset? FinishedAt { get; set; }

        /// <summary>
        /// Время окончательного закрытия заказа.
        /// </summary>
        /// <remarks>
        /// То есть когда водителем получены деньги от пассажира.
        /// <c>null</c>, если статус не был установлен.
        /// </remarks>
        public DateTimeOffset? ClosedAt { get; set; }

        /// <summary>
        /// Причина завершения заказа.
        /// </summary>
        public DirectoryItem CompletionReason { get; set; }

        /// <summary>
        /// Состояние заказа.
        /// </summary>
        public DirectoryItem State { get; set; }

        /// <summary>
        /// Комментарии пассажира к заказу.
        /// </summary>
        public IEnumerable<OrderCommentView> Comments { get; set; }

        public String LastPassengersComment
        {
            get
            {
                if( Comments == null ) return null;
                List<OrderCommentView> list = Comments.ToList();
                int lastPos = list.Count - 1;
                if (lastPos <= 0) return null;
                String result = list[lastPos].Content;

                return result;
            }
        }
    }
}
