using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L5 {

    /// <summary>
    /// Все целые числа между заданными, у которых сумма квадратов делителей сама является квадратом.
    /// </summary>
    public static class SumSquaredDivisors {
#if DEBUG
        /// <summary>Тестовый вызывальщик.</summary>
        public class SumSquaredDivisorsCaller {
            public string ListSquared(long m, long n) {
                return SumSquaredDivisors.ListSquared(m, n);
            }
            public List<long[]> SquaredList(long m, long n) {
                return SumSquaredDivisors.SquaredList(m, n);
            }
            public bool IsIntegerSquared(long m) {
                return SumSquaredDivisors.IsIntegerSquared(m);
            }
            public List<long> SimpeDividers(long d) {
                return SumSquaredDivisors.SimpeDividers(d);
            }
            public IEnumerable<long[]> LimitFactorial(long source, long count, uint start = 0) {
                return SumSquaredDivisors.LimitFactorial(source, count, start);
            }
            public long GetComposition(IEnumerable<long> seq) {
                return SumSquaredDivisors.GetComposition(seq);
            }
        }
#endif
        #region ClassMembers

        /// <summary>Возвращает список квадратов делителей в форме строки.</summary>
        /// <param name="m">Первое число.</param>
        /// <param name="n">Второе число.</param>
        /// <returns>Строка списка квадратов.</returns>
        [KataType(LevelTypes.Kyu, 5, "integers-recreation-one")]
        public static string ListSquared(long m, long n) {
            List<long[]> squarList = SquaredList(m, n);
            IEnumerable<string> sl = squarList.Select(s => "[" + string.Join(", ", s) + "]");
            return "[" + string.Join(", ", sl) + "]";
        }

        /// <summary>Возвращает список всех целочисленных делителей</summary>
        /// <param name="d">Число.</param>
        /// <returns>Список делителей</returns>
        public static List<long> GetDividers(long d) {
            List<long> simple = SimpeDividers(d);
            List<long> dvdrs = SimpeDividers(d);
            for (var i = 2; i < simple.Count; i++) {
                IEnumerable<long[]> positionCombos = LimitFactorial(simple.Count - 1, i);

                // Сопоставить цифры в combos с позициями в simple
                foreach (long[] positionCombo in positionCombos) {
                    var digitsCombo = new long[positionCombo.Length];
                    for (var k = 0; k < positionCombo.Length; k++) {
                        var position = positionCombo[k];
                        digitsCombo[k] = simple[(int)position];
                    }

                    var composition = GetComposition(digitsCombo);
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
        public static bool IsIntegerSquared(long m) {
            if (m < 0) {
                return false;
            }

            long[] mod100 = { 00, 01, 04, 09, 16, 21, 24, 25, 29, 36, 41, 44, 49, 56, 61, 64, 69, 76, 81, 84, 89, 96 };
            if (!mod100.Contains(m % 100)) {
                return false;
            }

            var d = Math.Sqrt(m);
            return d - (long)d == 0;
        }

        /// <summary>
        ///     Возвращает пары число — сумма квадратов из чисел между введёнными, у которых сумма квадратов делителей сама
        ///     является квадратом.
        /// </summary>
        /// <param name="m">Меньшее число диапазона.</param>
        /// <param name="n">Большее число диапазона.</param>
        /// <returns>Пары число — сумма квадратов.</returns>
        private static List<long[]> SquaredList(long m, long n) {
            var numbers = new List<long[]>();
            for (var i = m; i <= n; i++) {
                List<long> dividers = GetDividers(i);
                IEnumerable<long> divSquared = dividers.Select(d => d * d);
                var sumSquared = divSquared.Sum();
                var isSq = IsIntegerSquared(sumSquared);
                if (isSq) {
                    long[] c = { i, sumSquared };
                    numbers.Add(c);
                }
            }

            return numbers;
        }

        /// <summary>Раскладывает целое число на простые делители</summary>
        /// <param name="d">Целое число</param>
        /// <returns>Коллекция простых делителей</returns>
        private static List<long> SimpeDividers(long d) {
            var dvdrs = new List<long>();
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
                    return new List<long> { d };
                }
            }

            return dvdrs;
        }

        /// <summary>Возвращает сочетание из <paramref name="source" /> по <paramref name="count" /></summary>
        /// <param name="source">Число</param>
        /// <param name="count">Размер комбинации</param>
        /// <param name="start">Начало отчёта</param>
        /// <returns>Список массивов</returns>
        private static IEnumerable<long[]> LimitFactorial(long source, long count, uint start = 0) {
            var message = $"{nameof(count)} должно быть > 1, a {nameof(source)} > {nameof(count)}";
            if (source < count) {
                throw new ArgumentOutOfRangeException(nameof(count), count, message);
            }

            if (count < 1) {
                throw new ArgumentOutOfRangeException(nameof(count), count, message);
            }

            var result = new List<long[]>();
            if (count == 1) {
                for (long i = start; i <= source; i++) {
                    result.Add(new[] { i });
                }

                return result;
            }

            IEnumerable<long[]> prev = LimitFactorial(source, count - 1);
            foreach (long[] comboOld in prev) {
                for (var newItem = comboOld.Last() + 1; newItem <= source; newItem++) {
                    var combo = new long[count];
                    Array.Copy(comboOld, combo, comboOld.Length);
                    combo[count - 1] = newItem;
                    result.Add(combo);
                }
            }

            return result;
        }

        private static long GetComposition(IEnumerable<long> seq) {
            var result = seq.ToArray()[0];
            for (long i = 1; i < seq.Count(); i++) {
                result *= seq.ToArray()[i];
            }

            return result;
        }

        #endregion

    }
}