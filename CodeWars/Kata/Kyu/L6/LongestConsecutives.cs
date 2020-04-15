using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L6 {

    class LongestConsecutives {

        /// <summary>Вернуть первую наидлиннейшую строку, состоящую из k элементов массива</summary>
        /// <param name="strarr">Входящий массив</param>
        /// <param name="k">Нужное число элементов</param>
        /// <returns>Строка</returns>
        [KataType(LevelTypeEnum.Kyu, 6)]
        public static String LongestConsec(string[] strarr, int k) {
            if (k > strarr.Length) return String.Empty;
            // Скользящая группировка
            string result = String.Empty;
            for (int i = 0; i < strarr.Length; i++) {
                IEnumerable<string> subGroup = strarr.Skip(i).Take(k);
                string subString = String.Join(String.Empty, subGroup);
                if (subString.Length > result.Length) result = subString;
            }
            return result;
        }

    }

}
