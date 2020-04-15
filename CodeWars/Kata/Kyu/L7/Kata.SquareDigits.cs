using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L7 {

    public static partial class Kata {

        /// <summary>Возвращает число, состоящие из квадратов каждой цифры исходного числа</summary>
        /// <param name="n">Исходное число</param>
        /// <returns>Число из квадратов</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static int SquareDigits(int n) {
            IEnumerable<double> digits = n.ToString().Select(s => char.GetNumericValue(s));
            digits = digits.Select(s => s * s);
            return int.Parse(string.Join(null, digits));
        }

    }

}
