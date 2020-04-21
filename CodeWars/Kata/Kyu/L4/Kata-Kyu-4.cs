using System.Collections.Generic;
using System.Linq;

using Res = CodeWars.Properties.Resources;

namespace CodeWars
{
    public static partial class KataBase
    {
        /// <summary>Возвращает полные цепи зависимостей для каждого ключа</summary>
        /// <param name="source">Словарь прямых зависимостей</param>
        /// <returns>Словарь полных зависимостей</returns>
        [KataType(LevelTypes.Kyu, 4, "56293ae77e20756fc500002e")]
        public static Dictionary<string, string[]> ExpandDependencies(Dictionary<string, string[]> source)
        {
            if (source is null)
            {
                throw new System.ArgumentNullException(nameof(source));
            }
            // Если обнаружена кольцевая зависимость — вернуть InvalidOperationException
            // Если ключ не имеет зависимостей, к нему прилагается значение с пустым массивом
            // Если исходник пуст — вернуть пустой словарь
            if (source.Count == 0)
            {
                return new Dictionary<string, string[]>();
            }

            var result = new Dictionary<string, string[]>();
            foreach (KeyValuePair<string, string[]> srcItem in source)
            {
                IEnumerable<string> depList = GetDep(source, srcItem.Key);
                if (depList.Contains(srcItem.Key)) throw new System.InvalidOperationException();
                var depA = depList.Distinct().ToArray();
                result.Add(srcItem.Key, depA);
            }
            return result;
        }

        /// <summary>Глубокие связи ключа</summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="dic">Словарь</param>
        /// <param name="key">Ключ</param>
        /// <returns>Коллекция связей</returns>
        public static IEnumerable<string> GetDep(Dictionary<string, string[]> dic, string key)
        {
            if (dic is null)
            {
                throw new System.ArgumentNullException(nameof(dic));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new System.ArgumentException(Res.IsNull, nameof(key));
            }

            if (!dic.ContainsKey(key) || dic[key].Length == 0)
            {
                return new List<string>();
            }

            IEnumerable<string> result = dic[key];
            foreach (var item in dic[key])
            {
                IEnumerable<string> sr = GetDep(dic, item);
                result = result.Concat(sr);
            }
            return result;
        }
    }
}
