using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L4 {
    public static class RangeExtraction {
        /// <summary>Принимает массив целых чисел. Возвращает строку с диапазонами.</summary>
        /// <returns>Строка</returns>
        [KataType(LevelTypes.Kyu, 4, "range-extraction")]
        public static string Extract(int[] args) {
            var gList = new List<List<int>>();
            for (var i = 0; i < args.Length; i++) {
                if (i == 0 || args[i] - args[i - 1] != 1) {
                    gList.Add(new List<int>());
                }
                gList.Last().Add(args[i]);
            }
            var result = new List<string>();
            foreach (List<int> item in gList) {
                if (item.Count < 3) {
                    result.Add(string.Join(",", item));
                }
                else {
                    var f = item[0];
                    var l = item.Last();
                    result.Add(string.Join("-", f, l));
                }
            }
            return string.Join(",", result);
        }
    }
}
