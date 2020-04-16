using System.Linq;

namespace CodeWars.Kata.Kyu.L5 {

    static class StringMerger {

        /// <summary>
        /// Возвращает возможность объединения и перемешиваения двух строку в третию, 
        /// без изменения порядка символов в исходных строках.
        /// </summary>
        /// <param name="s">Итоговая строка</param>
        /// <param name="part1">Первая строка</param>
        /// <param name="part2">Вторая строка</param>
        /// <returns>true, если объединение возможно</returns>
        [KataType(LevelTypes.Kyu, 5)]
        public static bool IsMerge(string s, string part1, string part2) {
            return MayExtract(s, part1, part2);
            //NOTE Символы в составляющих строках могут повторятся, совпадать с исмволами другой строки, быть разного регистра.
        }

        private static bool MayExtract(string s, params string[] parts) {
            string ordS = string.Join("", s.OrderBy(k => k));
            string p = string.Join("", parts);
            string ordP = string.Join("", p.OrderBy(k => k));
            if (!ordS.Equals(ordP)) {
                return false;
            }

            foreach (string part in parts) {
                int start = 0;
                foreach (char item in part) {
                    start = s.IndexOf(item, start);
                    if (start == -1) {
                        return false;
                    }
                }
            }
            return true;
        }

    }

}
