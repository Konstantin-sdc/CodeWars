using System;
namespace CodeWars.Kata.Kyu.L6 {

    class SumFractions {

        [KataType(LevelTypeEnum.Kyu, 6, "5517fcb0236c8826940003c9")]
        public static string SumFracts(int[,] args) {
            int zeroLength = args.GetLength(0);
            int[,] tArray = new int[zeroLength, 2];
            for (int i = 0; i < zeroLength; i++) {
                int[] reduced = GetReducedFraction(args[i, 0], args[i, 1]);
                tArray[i, 0] = reduced[0];
                tArray[i, 1] = reduced[1];
            }
            int numerator = 0;
            int denumerator = 1;
            for (int i = 0; i < zeroLength; i++) {
                denumerator *= tArray[i, 1];
            }
            for (int i = 0; i < zeroLength; i++) {
                numerator += tArray[i, 0] * denumerator / tArray[i, 1];
            }
            var result = GetReducedFraction(numerator, denumerator);
            if (result[1] == 1) return result[0].ToString();
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

            var divider = small;
            var remainder = big % divider;
            while (remainder != 0) {
                if (Math.Abs(remainder) == 1) {
                    return defResult;
                }
                divider = remainder;
                remainder = big % divider;
            }

            remainder = small % divider;
            while (remainder != 0) {
                if (Math.Abs(remainder) == 1) {
                    return defResult;
                }
                divider = remainder;
                remainder = small % remainder;
            }

            return defResult;
        }

        private int GetMaxDivider(int number, int divider) {
            var remainder = number % divider;
            while (remainder != 0) {
                if (Math.Abs(remainder) == 1) {
                    return number;
                }
                divider = remainder;
                remainder = number % divider;
            }
            return number;
        }

    }

}
