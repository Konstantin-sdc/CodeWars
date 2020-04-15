using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L7 {

    public static partial class Kata {

        /// <summary>Возвращает количество периодов, за которое начальное количество достигнет целевого</summary>
        /// <param name="p0">Начальное количество</param>
        /// <param name="percent">Периодическое изменение в процентах</param>
        /// <param name="aug">Периодическое абсолютное изменение</param>
        /// <param name="p">Целевое количество</param>
        /// <returns>Количество периодов</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static int NbYear(int p0, double percent, int aug, int p) {
            var pCount = 0;
            for (var pCur = p0; pCur < p; pCount++) {
                pCur = (int)(pCur * (1 + 0.01 * percent) + aug);
            }
            return pCount;
        }

        /// <summary>Возвращает строки, длина которых = 4</summary>
        /// <param name="n">Массив строк для проверки</param>
        /// <returns>Коллекция строк</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static IEnumerable<string> FriendOrFoe(string[] n) => n.Where(s => s.Length == 4);

        /// <summary>Возвращает сумму нечётных чисел числового треугольника</summary>
        /// <param name="n">Номер блока, считая от 1</param>
        /// <returns>Сумма нечётных чисел</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static long RowSumOddNumbers(long n) {
            long firstBlockCount = 1;
            long firstVaue = 1;
            long countStep = 1;
            long valueStep = 2;
            // Count elements in block n
            var nBlockCount = firstBlockCount + countStep * (n - 1);
            // Count elements in all blocks, include n
            var allCount = (firstBlockCount + nBlockCount) * n / 2;
            // Last element value in block n
            var lastValue = firstVaue + valueStep * (allCount - 1);
            return lastValue + (lastValue + n / 2 * -valueStep) * (n - 1);
        }

    }

}
