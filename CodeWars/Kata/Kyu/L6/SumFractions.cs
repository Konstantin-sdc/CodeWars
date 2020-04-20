using System;
namespace CodeWars.Kata.Kyu.L6 {
    public static class SumFractions {
        [KataType(LevelTypes.Kyu, 6, "5517fcb0236c8826940003c9")]
#pragma warning disable CA1814 // Используйте массивы массивов вместо многомерных массивов
        public static string SumFracts(int[,] args) {
            if (args is null) {
                throw new ArgumentNullException(nameof(args));
            }
            var zeroLength = args.GetLength(0);
            var tArray = new int[zeroLength, 2];
#pragma warning restore CA1814 // Используйте массивы массивов вместо многомерных массивов
            for (var i = 0; i < zeroLength; i++) {
                var reduced = GetReducedFraction(args[i, 0], args[i, 1]);
                tArray[i, 0] = reduced[0];
                tArray[i, 1] = reduced[1];
            }
            var numerator = 0;
            var denumerator = 1;
            for (var i = 0; i < zeroLength; i++) {
                denumerator *= tArray[i, 1];
            }
            for (var i = 0; i < zeroLength; i++) {
                numerator += tArray[i, 0] * denumerator / tArray[i, 1];
            }
            var result = GetReducedFraction(numerator, denumerator);
            if (result[1] == 1) return result[0].ToString(KataBase.Invariant);
            return $"[{result[0]}, {result[1]}]";
        }

        private static int[] GetReducedFraction(int nmr, int dnmr) {
            var defResult = new int[2] { nmr, dnmr };
            if (nmr == 0 || dnmr == 0) {
                return defResult;
            }
            var bigNmr = nmr >= dnmr;
            var big = bigNmr ? nmr : dnmr;
            var small = bigNmr ? dnmr : nmr;

            var maxBigDivider = GetMaxDivider(big, small);
            if (small%maxBigDivider==0) {
                return new int[2] { big / maxBigDivider, small / maxBigDivider };
            }
            var maxSmallDivider = GetMaxDivider(small, maxBigDivider);
            if (true) {

            }
            return defResult;
        }

        private static int GetMaxDivider(int number, int divider) {
            var remainder = number % divider;
            while (remainder != 0) {
                if (Math.Abs(remainder) == 1) {
                    return number;
                }
                divider = remainder;
                remainder = number % divider;
            }
            return divider;
        }
#if DEBUG
#pragma warning disable CA1034 // Вложенные типы не должны быть видимыми
        public static class SumFractionsCall {
#pragma warning restore CA1034 // Вложенные типы не должны быть видимыми
            /// <summary>Тестовый вызыватель <see cref="GetReducedFraction(int, int)"/></summary>
            public static int[] GetReducedFractionCaller(int nmr, int dnmr) {
                return GetReducedFraction(nmr, dnmr);
            }
            /// <summary>Тестовый вызыватель <see cref="GetMaxDivider(int, int)"/></summary>
            public static int GetMaxDividerCaller(int number, int divider) {
                return GetMaxDivider(number, divider);
            }
        }
#endif
    }
}
