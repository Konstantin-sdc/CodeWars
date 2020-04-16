using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L6 {

    static class Persist {

        /// <summary>Возвращает количество операций умножения, которые нужно провести над цифрами данного числа до тех пор, 
        /// пока они не станут одной цифрой.</summary>
        /// <param name="n">Проверяемое число</param>
        /// <returns>Необходимое число умножений</returns>
        [KataType(LevelTypes.Kyu, 6)]
        public static int Persistence(long n) {
            if (n < 10) return 0;
            IEnumerable<double> digits = n.ToString().Select(e => Char.GetNumericValue(e));
            long baseNumber = 1;
            foreach (var digit in digits.OfType<long>()) {
                baseNumber *= digit;
                if (digit == 0) break;
            }
            var multCount = Persistence(baseNumber);
            multCount++;
            return multCount;
        }

    }

}
