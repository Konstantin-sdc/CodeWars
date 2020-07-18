namespace CodeWars.Kata.Kyu.L4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Res = Properties.Resources;

    public static partial class Kata
    {
        /// <summary>Возвращает полные цепи зависимостей для каждого ключа.</summary>
        /// <param name="source">Словарь прямых зависимостей.</param>
        /// <returns>
        /// <para>Dictionary of fulldependencies.</para>
        /// <para>Empty dictionary if source dictonary is empty.</para>
        /// </returns>
        /// <exception cref="InvalidOperationException">Параметр <paramref name="source"/> is <see langword="null"/>.</exception>
        [KataType(LevelTypes.Kyu, 4, "56293ae77e20756fc500002e")]
        public static Dictionary<string, string[]> ExpandDependencies(IDictionary<string, string[]> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (source.Count == 0)
                return new Dictionary<string, string[]>();
            var result = new Dictionary<string, string[]>();
            foreach (var item in source.Keys)
            {
                var depChain = GetDepChains(source, item).ToList();
                depChain.RemoveAt(0);
                result.Add(item, depChain.ToArray());
            }
            return result;
        }

        /// <summary>Возвращает глубокие связи ключа, вкючая сам ключ.</summary>
        /// <typeparam name="T">Тип данных.</typeparam>
        /// <param name="dict">Словарь.</param>
        /// <param name="key">Ключ.</param>
        /// <param name="circ">Служебный параметр.</param>
        /// <returns><see cref="IEnumerable{T}"/> Коллекция связей.</returns>
        /// <exception cref="InvalidOperationException">Зависимости ключа являются циклическими.</exception>
        private static IEnumerable<T> GetDepChains<T>(IDictionary<T, T[]> dict, T key, IEnumerable<T> circ = null)
        {
            circ = circ ?? GetCircular(dict);
            if (circ.Contains(key))
                throw new InvalidOperationException();
            var dependensies = new List<T> { key };
            if (!dict.ContainsKey(key))
                return dependensies;
            var values = dict[key];
            if (values is null || values.Length == 0)
                return dependensies;
            foreach (var item in values)
            {
                var deps = GetDepChains(dict, item, circ);
                dependensies.AddRange(deps);
            }
            return dependensies.Distinct();
        }

        /// <summary>
        /// Возврщает коллекцию ключей из исходного словаря,
        /// которые имеют циклические ссылки.
        /// </summary>
        /// <typeparam name="T">Тип данных словаря.</typeparam>
        /// <param name="dict">Словарь для проверки.</param>
        /// <returns><see cref="IEnumerable{T}"/> Коллекция с результатами.</returns>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="dict"/> имеет значение <see langword="null"/>.</exception>
        public static IEnumerable<T> GetCircular<T>(IDictionary<T, T[]> dict)
        {
            if (dict is null)
                throw new ArgumentNullException(nameof(dict));
            var result = new Dictionary<T, T[]>(dict);
            for (var i = 0; i < result.Keys.Count; i++)
            {
                var testKey = result.Keys.ElementAt(i);
                var testValue = result[testKey];
                var newValue = testValue.Where(e => result.ContainsKey(e)).ToArray();
                result[testKey] = newValue;
                if (newValue == null || !newValue.Any())
                {
                    result.Remove(testKey);
                    i = -1;
                }
            }
            return result.Keys;
        }

    }
}
