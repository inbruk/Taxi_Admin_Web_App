namespace Rapport.AuxiliaryTools.WabApiTools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// Массивы данных для представления в JSON.
    /// </summary>    
    public class JsonArray<T>
    {
        /// <summary>
        /// Представляет последовательность элементов.
        /// </summary>
        public IReadOnlyList<T> Items { get; }

        /// <summary>
        /// Инициализирует новый экземпляр типа <see cref="JsonArray{T}"/>
        /// </summary>
        /// <param name="items"></param>
        [JsonConstructor]
        public JsonArray(IEnumerable<T> items)
        {
            if (items == null)
                Items = new T[0];
            else if (items is IReadOnlyList<T>)
                Items = items as IReadOnlyList<T>;
            else
                Items = items.ToArray();
        }

        /// <summary>
        /// Отображает массив JSON в элементы другого типа.
        /// </summary>
        /// <typeparam name="TResult">Тип элементов целевого массива.</typeparam>
        /// <param name="selector">Функция-преобразователь элементов.</param>
        /// <returns>Массив JSON с преобразованными элементами.</returns>
        public JsonArray<TResult> Map<TResult>(Func<T, TResult> selector)
        {
            return new JsonArray<TResult>(Items.Select(selector));
        }
    }
}
