using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L5 {

    public class Kata {

        /// <summary>
        /// <para>Принимает целое число.</para>
        /// <para>К каждой группе его цифр припиывает число количества этих цифр.</para>
        /// <para>Уменьшает группы до одной цифры.</para>
        /// <para>Возвращает полученную комбинацию в виде целого числа.</para>
        /// </summary>
        /// <param name="number">Исходное число</param>
        /// <returns>Комбинация</returns>
        [KataType(LevelTypeEnum.Kyu, 5, "conways-look-and-say-generalized")]
        public static ulong LookSay(ulong number) {
            string s = number.ToString();
            List<List<char>> gs = GroupSeparate(s);
            IEnumerable<string> result = gs.Select(e => e.Count + e.First().ToString());
            return Convert.ToUInt64(string.Join("", result));
        }

        /// <summary>Проводит раздельную группировку элементов в коллоекции</summary>
        /// <typeparam name="T">ип элементов в коллекции</typeparam>
        /// <param name="seq">Коллекция</param>
        /// <returns>Коллекция групп</returns>
        private static List<List<T>> GroupSeparate<T>(IEnumerable<T> seq) {
            List<List<T>> result = new List<List<T>>();
            if (seq.First() == null) {
                return result;
            }
            for (int i = 0; i < seq.Count(); i++) {
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
