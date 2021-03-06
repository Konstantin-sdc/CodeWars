﻿namespace CodeWars.Kata.Kyu.L6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Res = Properties.Resources;

    public static partial class KataClass
    {
        /// <summary>Возвращает строку из слов исходной строки, отсортированных согласно числам в этих словах</summary>
        /// <param name="words">Исходная строка</param>
        /// <returns>Итоговая строка</returns>
        [KataType(LevelTypes.Kyu, 6)]
        public static string Order(string words)
        {
            if (string.IsNullOrEmpty(words))
            {
                throw new ArgumentException(Res.IsNullOrEmpty, nameof(words));
            }

            var wordArray = words.Split(' ');
            IEnumerable<double> digits = words.Where(c => Char.IsDigit(c)).Select(c => Char.GetNumericValue(c));
            Array.Sort(digits.ToArray(), wordArray);
            return String.Join(" ", wordArray);
            throw new NotImplementedException();
        }
    }
}
