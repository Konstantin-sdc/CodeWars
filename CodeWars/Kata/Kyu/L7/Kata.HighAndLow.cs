using System.Collections.Generic;
using System.Linq;

using Res = CodeWars.Properties.Resources;

namespace CodeWars.Kata.Kyu.L7
{
    public static partial class KataClass
    {
        /// <summary>7 Возвращает самое большое и самое малое числа из строки чисел</summary>
        /// <param name="numbers">Строка чисел, разделённых пробелами</param>
        /// <returns>Строка из наибольшего и наименьшего чисел</returns>
        [KataType(LevelTypes.Kyu, 7)]
        public static string HighAndLow(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                throw new System.ArgumentException(Res.IsNullOrEmpty, nameof(numbers));
            }

            IEnumerable<int> intArr = numbers.Split(' ').Select(int.Parse);
            return intArr.Max() + " " + intArr.Min();
        }
    }
}
