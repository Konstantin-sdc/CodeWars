namespace CodeWars
{
    using CodeWars;

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using Res = Properties.Resources;

    /// <summary>Класс для тренировок</summary>
    public static partial class KataBase
    {
        /// <summary>Инвариантная культура.</summary>
        public static readonly CultureInfo Invariant = CultureInfo.InvariantCulture;

        /// <summary>Возвращает список всех целочисленных делителей</summary>
        /// <param name="d">Число.</param>
        /// <returns>Список делителей</returns>
        public static List<long> GetDividers(long d)
        {
            var simple = SimpeDividers(d).ToList();
            var dvdrs = SimpeDividers(d).ToList();
            for (var i = 2; i < simple.Count; i++)
            {
                var positionCombos = LimitFactorial(simple.Count - 1, i);

                // Сопоставить цифры в combos с позициями в simple
                foreach (var positionCombo in positionCombos)
                {
                    var digitsCombo = new long[positionCombo.Length];
                    for (var k = 0; k < positionCombo.Length; k++)
                    {
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
        /// <param name="m">Число.</param>
        /// <returns>true, если да.</returns>
        public static bool IsIntegerSquared(long m)
        {
            if (m < 0)
            {
                return false;
            }

            long[] mod100 = { 00, 01, 04, 09, 16, 21, 24, 25, 29, 36, 41, 44, 49, 56, 61, 64, 69, 76, 81, 84, 89, 96 };
            if (!mod100.Contains(m % 100))
            {
                return false;
            }

            var d = Math.Sqrt(m);
            return d - (long)d == 0;
        }

        /// <summary>Перемножает элементы коллекции.</summary>
        /// <param name="seq">Коллекция.</param>
        /// <returns>Произведение элементов.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="seq"/> is null.</exception>
        public static long GetComposition(IEnumerable<long> seq)
        {
            if (seq is null)
                throw new ArgumentNullException(nameof(seq), Res.IsNull);
            if (!seq.Any())
                return 1;
            var result = seq.ToArray()[0];
            for (long i = 1; i < seq.Count(); i++)
            {
                try
                {
                    result *= seq.ToArray()[i];
                }
                catch (Exception)
                {
                    throw new Exception("ZDESYA!");
                }
            }
            return result;
        }

        /// <summary>Раскладывает целое число на простые делители</summary>
        /// <param name="d">Целое число.</param>
        /// <returns>Коллекция простых делителей</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="d"/> == 0.</exception>
        public static IEnumerable<long> SimpeDividers(long d)
        {
            var dvdrs = new List<long>();
            long dvdr = 3, step = 2;
            if (d % 2 == 0)
            {
                dvdr = 2;
                step = 1;
            }

            for (; dvdr <= d; dvdr += step)
            {
                if (d % dvdr == 0)
                {
                    dvdrs.Add(dvdr);
                    dvdrs.AddRange(SimpeDividers(d / dvdr));
                    break;
                }

                if (dvdr > d / 2)
                {
                    return new List<long> { d };
                }
            }

            return dvdrs;
        }

        /// <summary>Возвращает сочетание из <paramref name="source" /> по <paramref name="count" />.</summary>
        /// <param name="source">Число.</param>
        /// <param name="count">Размер комбинации.</param>
        /// <param name="start">Начало отчёта.</param>
        /// <returns>Список массивов.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Не передавать литералы в качестве локализованных параметров", Justification = "<Ожидание>")]
        private static IEnumerable<long[]> LimitFactorial(long source, long count, uint start = 0)
        {
            var message = $"{nameof(count)} <= 1, или {nameof(source)} < {nameof(count)}";
            if (source < count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, message);
            }

            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count, message);
            }

            var result = new List<long[]>();
            if (count == 1)
            {
                for (long i = start; i <= source; i++)
                {
                    result.Add(new[] { i });
                }

                return result;
            }

            var prev = LimitFactorial(source, count - 1);
            foreach (var comboOld in prev)
            {
                for (var newItem = comboOld.Last() + 1; newItem <= source; newItem++)
                {
                    var combo = new long[count];
                    Array.Copy(comboOld, combo, comboOld.Length);
                    combo[count - 1] = newItem;
                    result.Add(combo);
                }
            }

            return result;
        }

        /// <summary>Возвращает наибольший обшмй делитель двух чисел.</summary>
        /// <param name="first">Первое число.</param>
        /// <param name="second">Второе число.</param>
        /// <returns>Делитель.</returns>
        public static long GetMaxCommonDivider(long first, long second)
        {
            var big = (first >= second) ? first : second;
            var small = (first >= second) ? second : first;
            var remainder = big % small;
            return remainder == 0 ?
                small : GetMaxCommonDivider(small, remainder);
        }
    }
}