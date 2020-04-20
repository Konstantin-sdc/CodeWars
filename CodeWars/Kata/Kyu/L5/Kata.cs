using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CodeWars.Kata.Kyu.L5 {
    public static partial class KataClass {
        static CultureInfo _cultureInfo = CultureInfo.InvariantCulture;
        /// <summary>
        /// <para>Принимает целое число.</para>
        /// <para>К каждой группе его цифр припиывает число количества этих цифр.</para>
        /// <para>Уменьшает группы до одной цифры.</para>
        /// <para>Возвращает полученную комбинацию в виде целого числа.</para>
        /// </summary>
        /// <param name="number">Исходное число</param>
        /// <returns>Комбинация</returns>
        [KataType(LevelTypes.Kyu, 5, "conways-look-and-say-generalized")]
        public static ulong LookSay(ulong number) {
            var s = number.ToString(CodeWars.KataBase.Invariant);
            List<List<char>> gs = GroupSeparate(s);
            IEnumerable<string> result = gs.Select(e => e.Count + e[0].ToString(_cultureInfo));
            return Convert.ToUInt64(string.Concat(result), _cultureInfo);
        }

        /// <summary>Проводит раздельную группировку элементов в коллоекции</summary>
        /// <typeparam name="T">ип элементов в коллекции</typeparam>
        /// <param name="seq">Коллекция</param>
        /// <returns>Коллекция групп</returns>
        private static List<List<T>> GroupSeparate<T>(IEnumerable<T> seq) {
            var result = new List<List<T>>();
            if (seq.First() == null) {
                return result;
            }
            for (var i = 0; i < seq.Count(); i++) {
                T item = seq.ElementAt(i);
                if (i == 0 || !seq.ElementAt(i - 1).Equals(item)) {
                    result.Add(new List<T>());
                }
                result.Last().Add(item);
            }
            return result;
        }
    }
}
