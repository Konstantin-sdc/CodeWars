using System.Collections.Generic;

namespace CodeWars.Kata.Kyu.L5 {

    static class RemovedNumbers {

        /// <summary>
        /// Возвращает два числа из натурального ряда, произведение которых равно сумме всех чисел этого ряда, исключая эти два числа.
        /// </summary>
        /// <param name="n">Верхний предел ряда. Всегда > 0.</param>
        /// <returns>Массив чисел.</returns>
        [KataType(LevelTypes.Kyu, 5)]
        public static List<long[]> RemovNb(long n) {
            List<long[]> result = new List<long[]>();
            // Вычислить сумму натурального ряда от 1 до n
            long sum;
            checked {
                sum = (n + 1) * n / 2;
            }
            // Минимальный первый элемент
            long firstMin = (sum - 2 * n + 1) / n;
            // Максимальный первый элемент
            long firstMax = (sum - 2 * firstMin - 1) / firstMin;
            // Второй элемент
            for (long i = firstMin; i <= firstMax; i++) {
                long a = sum - i;
                long b = i + 1;
                if (a % b > 0) {
                    continue;
                }

                result.Add(new long[2] { i, a / b });
            }
            return result;
        }

    }

}
