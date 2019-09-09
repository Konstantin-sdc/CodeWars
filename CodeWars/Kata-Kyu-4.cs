using System.Collections.Generic;
using System.Linq;

namespace CodeWars {

    public static partial class Kata {

        /// <summary>Принимает массив целых чисел. Возвращает строку с диапазонами.</summary>
        /// <returns>Строка</returns>
        [KataType(LevelTypeEnum.Kyu, 4, "range-extraction")]
        public static string Extract(int[] args) {
            var gList = new List<List<int>>();
            for(int i = 0; i < args.Length; i++) {
                if(i == 0 || args[i] - args[i - 1] != 1) {
                    gList.Add(new List<int>());
                }
                gList.Last().Add(args[i]);
            }
            var result = new List<string>();
            foreach(List<int> item in gList) {
                if(item.Count < 3) {
                    result.Add(string.Join(",", item));
                }
                else {
                    int f = item.First();
                    int l = item.Last();
                    result.Add(string.Join("-", f, l));
                }
            }
            return string.Join(",", result);
        }

        /// <summary>Возвращает полные цепи зависимостей для каждого ключа</summary>
        /// <param name="source">Словарь прямых зависимостей</param>
        /// <returns>Словарь полных зависимостей</returns>
        [KataType(LevelTypeEnum.Kyu, 4, "56293ae77e20756fc500002e")]
        public static Dictionary<string, string[]> ExpandDependencies(Dictionary<string, string[]> source) {
            // Если обнаружена кольцевая зависимость — вернуть InvalidOperationException
            // Если ключ не имеет зависимостей, к нему прилагается значение с пустым массивом
            // Если исходник пуст — вернуть пустой словарь
            if(source.Count == 0) return new Dictionary<string, string[]>();
            var result = new Dictionary<string, string[]>();
            foreach(KeyValuePair<string, string[]> srcItem in source) {
                IEnumerable<string> depList = GetDep(source, srcItem.Key);
                if(depList.Contains(srcItem.Key)) throw new System.InvalidOperationException();
                string[] depA = depList.Distinct().ToArray();
                result.Add(srcItem.Key, depA);
            }
            return result;
        }

        /// <summary>Глубокие связи ключа</summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="dic">Словарь</param>
        /// <param name="key">Ключ</param>
        /// <returns>Коллекция связей</returns>
        public static IEnumerable<string> GetDep(Dictionary<string, string[]> dic, string key) {
            if(!dic.ContainsKey(key) || dic[key].Length == 0) return new List<string>();
            IEnumerable<string> result = dic[key];
            foreach(string item in dic[key]) {
                IEnumerable<string> sr = GetDep(dic, item);
                result = result.Concat(sr);
            }
            return result;
        }
    }

}
