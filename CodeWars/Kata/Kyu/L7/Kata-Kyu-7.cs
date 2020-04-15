using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars {

    public static partial class Kata {

        /// <summary>7 Возвращает самое большое и самое малое числа из строки чисел</summary>
        /// <param name="numbers">Строка чисел, разделённых пробелами</param>
        /// <returns>Строка из наибольшего и наименьшего чисел</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static string HighAndLow(string numbers) {
            IEnumerable<int> intArr = numbers.Split(' ').Select(int.Parse);
            return intArr.Max() + " " + intArr.Min();
        }

        /// <summary>Маскирует символом # все символы входящей строки, кроме последних четырёх</summary>
        /// <param name="cc">Строка,которую следует замаскировать</param>
        /// <returns>Замаскированная строка</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static string Maskify(string cc) {
            int startIndex = (cc.Length > 4) ? cc.Length - 4 : 0;
            return new string('#', startIndex) + cc.Substring(startIndex);
        }

        /// <summary>Указывает является ли проверяемая строка изограммой</summary>
        /// <param name="s">Проверяемая строка</param>
        /// <returns><see cref="true"/> если является</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static bool IsIsogram(string s) {
            return s.Length == s.ToLower().Distinct().Count();
        }

        /// <summary>Возвращает число, состоящие из квадратов каждой цифры исходного числа</summary>
        /// <param name="n">Исходное число</param>
        /// <returns>Число из квадратов</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static int SquareDigits(int n) {
            IEnumerable<double> digits = n.ToString().Select(s => Char.GetNumericValue(s));
            digits = digits.Select(s => s * s);
            return int.Parse(String.Join(null, digits));
        }

        /// <summary>Возвращает количество периодов, за которое начальное количество достигнет целевого</summary>
        /// <param name="p0">Начальное количество</param>
        /// <param name="percent">Периодическое изменение в процентах</param>
        /// <param name="aug">Периодическое абсолютное изменение</param>
        /// <param name="p">Целевое количество</param>
        /// <returns>Количество периодов</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static int NbYear(int p0, double percent, int aug, int p) {
            int pCount = 0;
            for(int pCur = p0; pCur < p; pCount++) {
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
            long nBlockCount = firstBlockCount + countStep * (n - 1);
            // Count elements in all blocks, include n
            long allCount = (firstBlockCount + nBlockCount) * n / 2;
            // Last element value in block n
            long lastValue = firstVaue + valueStep * (allCount - 1);
            return lastValue + (lastValue + n / 2 * -valueStep) * (n - 1);
        }

    }

}
