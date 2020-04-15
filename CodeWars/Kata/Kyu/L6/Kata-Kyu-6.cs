﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars {

    public static partial class KataClass {

        /// <summary>Возвращает массив чисел из входящего диапазона с такими свойствами, что эти числа равны сумме составляющих их цифр, 
        /// в степенях, равных местам цифр в числе. (например: 135 = 1^1 + 3^2 + 5^3)
        /// </summary>
        /// <param name="a">Начало входящего диапазона</param>
        /// <param name="b">Конец входящего диапазона</param>
        /// <returns>Массив чисел, удовлетворяющих условию</returns>
        [KataType(LevelTypeEnum.Kyu, 6)]
        public static long[] SumDigPow(long a, long b) {
            // Места считаются от 1
            // Если (цифра числа в степени позиция цифры) >= числа, то пропустить проверку этого числа.
            // var qqq = Math.Pow(9_223372_036854_775807, (double)1/20);
            List<long> result = new List<long>();
            for(long number = a; number <= b; number++) {
                // Коллекция цифр в числе
                IEnumerable<long> digitsCollection = number.ToString().Select(s => (long)Char.GetNumericValue(s));
                // Пройтись по цифрам числа, возвести в степень и сложить
                long testNumber = 0;
                for(int position = 0; position < digitsCollection.Count(); position++) {
                    if(testNumber >= number) break;
                    long digitInPow = (long)Math.Pow(digitsCollection.ElementAt(position), position + 1);
                    // Если цифра в степени уже > number, прекратить проверку number
                    if(digitInPow > number) break;
                    testNumber += digitInPow;
                }
                if(testNumber == number) result.Add(testNumber);
            }
            return result.ToArray();
        }

        /// <summary>Возвращает строку из слов исходной строки, отсортированных согласно числам в этих словах</summary>
        /// <param name="words">Исходная строка</param>
        /// <returns>Итоговая строка</returns>
        [KataType(LevelTypeEnum.Kyu, 6)]
        public static string Order(string words) {
            string[] wordArray = words.Split(' ');
            IEnumerable<double> digits = words.Where(c => Char.IsDigit(c)).Select(c => Char.GetNumericValue(c));
            Array.Sort(digits.ToArray(), wordArray);
            return String.Join(" ", wordArray);
            throw new NotImplementedException();
        }

        /// <summary>Возвращает сумму всех чисел в натуральном ряду, которые делятся на 3 или на 5</summary>
        /// <param name="value">Верхний предел ряда</param>
        /// <returns>Сумма</returns>
        [KataType(LevelTypeEnum.Kyu, 6)]
        public static int Solution(int value) {
            try { return Enumerable.Range(0, value).Where(d => (d % 3 == 0 || d % 5 == 0)).Sum(); }
            catch { return int.MaxValue; }
        }

    }

}
