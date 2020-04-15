using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L7 {

    public partial class Kata {

        /// <summary>7 Возвращает самое большое и самое малое числа из строки чисел</summary>
        /// <param name="numbers">Строка чисел, разделённых пробелами</param>
        /// <returns>Строка из наибольшего и наименьшего чисел</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static string HighAndLow(string numbers) {
            IEnumerable<int> intArr = numbers.Split(' ').Select(int.Parse);
            return intArr.Max() + " " + intArr.Min();
        }

    }

}
