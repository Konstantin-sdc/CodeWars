using System;
using System.Collections.Generic;
using System.Linq;

using Res = CodeWars.Properties.Resources;

namespace CodeWars.Kata.Kyu.L5
{

    /// <summary>
    /// Все целые числа между заданными, у которых сумма квадратов делителей сама является квадратом.
    /// </summary>
    public static class SumSquaredDivisors
    {
        #region ClassMembers
        /// <summary>Возвращает список квадратов делителей в форме строки.</summary>
        /// <param name="m">Первое число.</param>
        /// <param name="n">Второе число.</param>
        /// <returns>Строка списка квадратов.</returns>
        [KataType(LevelTypes.Kyu, 5, "integers-recreation-one")]
        public static string ListSquared(long m, long n)
        {
            List<long[]> squarList = SquaredList(m, n);
            IEnumerable<string> sl = squarList.Select(s => "[" + string.Join(", ", s) + "]");
            return "[" + string.Join(", ", sl) + "]";
        }

        /// <summary>
        /// Возвращает пары число — сумма квадратов из чисел между введёнными, 
        /// у которых сумма квадратов делителей сама является квадратом.
        /// </summary>
        /// <param name="m">Первое число диапазона.</param>
        /// <param name="n">Второе число диапазона.</param>
        /// <returns>Пары число — сумма квадратов. Сортировка по возрастанию.</returns>
        private static List<long[]> SquaredList(long m, long n)
        {
            var bigFirst = (m > n) ? true : false;
            var big = bigFirst ? m : n;
            var small = bigFirst ? n : m;
            var numbers = new List<long[]>();
            for (var i = small; i <= big; i++)
            {
                List<long> dividers = KataBase.GetDividers(i);
                IEnumerable<long> divSquared = dividers.Select(d => d * d);
                var sumSquared = divSquared.Sum();
                var isSq = KataBase.IsIntegerSquared(sumSquared);
                if (isSq)
                {
                    long[] c = { i, sumSquared };
                    numbers.Add(c);
                }
            }

            return numbers;
        }
        #endregion

#if DEBUG
        /// <summary>Тестовый вызывальщик.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Вложенные типы не должны быть видимыми", Justification = "<Ожидание>")]
        public static class SumSquaredDivisorsCaller
        {
            public static string ListSquared(long m, long n)
            {
                return SumSquaredDivisors.ListSquared(m, n);
            }
            public static List<long[]> SquaredList(long m, long n)
            {
                return SumSquaredDivisors.SquaredList(m, n);
            }
        }
#endif

    }
}