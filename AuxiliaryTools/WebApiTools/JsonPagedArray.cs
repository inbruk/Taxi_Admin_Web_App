namespace Rapport.AuxiliaryTools.WabApiTools
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Представляет одну страницу последовательности элементов.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonPagedArray<T> : JsonArray<T>
    {
        /// <summary>
        /// Пустая страница.
        /// </summary>
        public static readonly JsonPagedArray<T> Empty = new JsonPagedArray<T>(new T[0], 0, 0);

        /// <summary>
        /// Номер страницы с результатами.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Общее количество страниц.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр типа <see cref="JsonPagedArray{T}"/>
        /// </summary>
        [JsonConstructor]
        public JsonPagedArray( IEnumerable<T> items, int page, int pageCount )
            : base(items)
        {
            Page = page;
            PageCount = pageCount;
        }
    }
}
