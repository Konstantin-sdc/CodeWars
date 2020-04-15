using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars.Kata.Kyu.L5 {

    class SumSquaredDivisors {

        [KataType(LevelTypeEnum.Kyu, 5, "integers-recreation-one")]
        public static string ListSquared(long m, long n) {
            List<long[]> squarList = SquaredList(m, n);
            IEnumerable<string> sl = squarList.Select(s => "[" + string.Join(", ", s) + "]");
            return "[" + string.Join(", ", sl) + "]";
        }

        /// <summary>
        /// Возвращает пары число — сумма квадратов из чисел между введёнными, у которых сумма квадратов делителей сама является квадратом
        /// </summary>
        /// <param name="m">Меньшее число диапазона</param>
        /// <param name="n">Большее число диапазона</param>
        /// <returns></returns>
        private static List<long[]> SquaredList(long m, long n) {
            List<long[]> numbers = new List<long[]>();
            for (long i = m; i <= n; i++) {
                List<long> dividers = GetDividers(i);
                IEnumerable<long> divSquared = dividers.Select(d => d * d);
                long sumSquared = divSquared.Sum();
                bool isSq = IsIntegerSquared(sumSquared);
                if (isSq) {
                    long[] c = { i, sumSquared };
                    numbers.Add(c);
                }
            }
            return numbers;
        }

        /// <summary>Возвращает список всех целочисленных делителей</summary>
        /// <param name="d">Ч</param>
        /// <returns>Список делителей</returns>
        public static List<long> GetDividers(long d) {
            List<long> simple = SimpeDividers(d);
            List<long> dvdrs = SimpeDividers(d);
            for (int i = 2; i < simple.Count(); i++) {
                IEnumerable<long[]> positionCombos = LimitFactorial(simple.Count() - 1, i);
                // Сопоставить цифры в combos с позициями в simple
                foreach (long[] positionCombo in positionCombos) {
                    long[] digitsCombo = new long[positionCombo.Length];
                    for (int k = 0; k < positionCombo.Length; k++) {
                        long position = positionCombo[k];
                        digitsCombo[k] = simple[(int)position];
                    }
                    long composition = GetComposition(digitsCombo);
                    dvdrs.Add(composition);
                }
            }
            dvdrs.Add(1);
            dvdrs.Add(d);
            return dvdrs.Distinct().OrderBy(e => e).ToList();
        }

        /// <summary>Является ли число квадратом целого числа</summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private static bool IsIntegerSquared(long m) {
            if (m < 0) {
                return false;
            }
            long[] mod100 = { 00, 01, 04, 09, 16, 21, 24, 25, 29, 36, 41, 44, 49, 56, 61, 64, 69, 76, 81, 84, 89, 96 };
            if (!mod100.Contains(m % 100)) {
                return false;
            }
            double d = Math.Sqrt(m);
            return d - (long)d == 0;
        }

        /// <summary>Раскладывает целое число на простые делители</summary>
        /// <param name="d">Целое число</param>
        /// <returns>Коллекция простых делителей</returns>
        private static List<long> SimpeDividers(long d) {
            List<long> dvdrs = new List<long>();
            long dvdr = 3, step = 2;
            if (d % 2 == 0) {
                dvdr = 2;
                step = 1;
            }
            for (; dvdr <= d; dvdr += step) {
                if (d % dvdr == 0) {
                    dvdrs.Add(dvdr);
                    dvdrs.AddRange(SimpeDividers(d / dvdr));
                    break;
                }
                if (dvdr > d / 2) {
                    return new List<long>() { d };
                }
            }
            return dvdrs;
        }

        /// <summary>Возвращает сочетание из <paramref name="source"/> по <paramref name="count"/></summary>
        /// <param name="source">Число</param>
        /// <param name="count">Размер комбинации</param>
        /// <param name="start">Начало отчёта</param>
        /// <returns>Список массивов</returns>
        public static IEnumerable<long[]> LimitFactorial(long source, long count, uint start = 0) {
            string message = "{nameof(count)} должно быть > 1, a {nameof(source)} > nameof(count)";
            if (source < count) {
                throw new ArgumentOutOfRangeException(nameof(count), count, message);
            }
            if (count < 1) {
                throw new ArgumentOutOfRangeException(nameof(count), count, message);
            }
            List<long[]> result = new List<long[]>();
            if (count == 1) {
                for (long i = start; i <= source; i++) {
                    result.Add(new long[] { i });
                }
                return result;
            }
            IEnumerable<long[]> prev = LimitFactorial(source, count - 1);
            foreach (long[] comboOld in prev) {
                for (long newItem = comboOld.Last() + 1; newItem <= source; newItem++) {
                    long[] combo = new long[count];
                    Array.Copy(comboOld, combo, comboOld.Length);
                    combo[count - 1] = newItem;
                    result.Add(combo);
                }
            }
            return result;
        }

        public static long GetComposition(IEnumerable<long> seq) {
            long result = seq.ToArray()[0];
            for (long i = 1; i < seq.Count(); i++) {
                result *= seq.ToArray()[i];
            }
            return result;
        }

    }

}
