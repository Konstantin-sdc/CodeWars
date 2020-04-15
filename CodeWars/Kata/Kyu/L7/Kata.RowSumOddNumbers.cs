namespace CodeWars.Kata.Kyu.L7 {

    public static partial class Kata {

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
