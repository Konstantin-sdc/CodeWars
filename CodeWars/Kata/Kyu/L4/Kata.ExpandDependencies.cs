namespace CodeWars.Kata.Kyu.L4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Res = Properties.Resources;

    public static partial class Kata
    {
        #region Rules
        // Если ключ не имеет зависимостей, к нему прилагается значение с пустым массивом
        #endregion
        /// <summary>Возвращает полные цепи зависимостей для каждого ключа.</summary>
        /// <param name="source">
        /// <para>Словарь прямых зависимостей.</para>
        /// <para>Ключи — имена файлов.</para>
        /// <para>Значения — массивы строк, каждая из которых является прямой зависимостю для соответствующего ключа.</para>
        /// </param>
        /// <returns>
        /// <para>Dictionari of fulldependencies.</para>
        /// <para>Empty dictonary if source dictonary is empty.</para>
        /// </returns>
        [KataType(LevelTypes.Kyu, 4, "56293ae77e20756fc500002e")]
        public static Dictionary<string, string[]> ExpandDependencies(IDictionary<string, string[]> source)
        {
            #region Exceptions
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            // Если обнаружена кольцевая зависимость — вернуть InvalidOperationException
            #endregion
            // Если исходник пуст — вернуть пустой словарь
            if (source.Count == 0)
                return new Dictionary<string, string[]>();
            var result = new Dictionary<string, string[]>();
            foreach (var srcItem in source)
            {
                var depList = GetDep(source, srcItem.Key, srcItem.Key);
                if (depList.Contains(srcItem.Key)) 
                    throw new InvalidOperationException();
                var depA = depList.Distinct().ToArray();
                Array.Sort(depA);
                result.Add(srcItem.Key, depA);
            }
            return result;
        }

        /// <summary>Глубокие связи ключа</summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="dic">Словарь</param>
        /// <param name="key">Ключ</param>
        /// <returns>Коллекция связей</returns>
        public static IEnumerable<string> GetDep(IDictionary<string, string[]> dic, string key, string firstKey)
        {
            #region Exceptions
            if (dic is null)
                throw new ArgumentNullException(nameof(dic));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException(Res.IsNull, nameof(key));
            #endregion
            if (!dic.ContainsKey(key) || dic[key].Length == 0)
                return new List<string>();
            IEnumerable<string> result = dic[key];
            foreach (var item in dic[key])
            {
                if (item == firstKey)
                    throw new InvalidOperationException();
                var sr = GetDep(dic, item, firstKey);
                result = result.Concat(sr);
            }
            return result;
        }
    }
}
