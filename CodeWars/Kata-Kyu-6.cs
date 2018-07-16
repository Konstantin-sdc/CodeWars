using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars {

  public static partial class Kata {

    /// <summary>Возвращает количество операций умножения, которые нужно провести над цифрами данного числа до тех пор, 
    /// пока они не станут одной цифрой.</summary>
    /// <param name="n">Проверяемое число</param>
    /// <returns>Необходимое число умножений</returns>
    [KataLevel(LevelTypeEnum.Kyu, 6)]
    public static int Persistence(long n) {
      if(n < 10) return 0;
      var digits = n.ToString().Select(e => Char.GetNumericValue(e));
      long baseNumber = 1;
      foreach(long digit in digits) {
        baseNumber *= digit;
        if(digit == 0) break;
      }
      int multCount = Persistence(baseNumber);
      multCount++;
      return multCount;
    }

    /// <summary>Вернуть первую наидлиннейшую строку, состоящую из k элементов массива</summary>
    /// <param name="strarr">Входящий массив</param>
    /// <param name="k">Нужное число элементов</param>
    /// <returns>Строка</returns>
    [KataLevel(LevelTypeEnum.Kyu, 6)]
    public static String LongestConsec(string[] strarr, int k) {
      if(k > strarr.Length) return String.Empty;
      // Скользящая группировка
      string result = String.Empty;
      for(int i = 0; i < strarr.Length; i++) {
        IEnumerable<string> subGroup = strarr.Skip(i).Take(k);
        string subString = String.Join(String.Empty, subGroup);
        if(subString.Length > result.Length) result = subString;
      }
      return result;
    }

    /// <summary>Возвращает массив чисел из входящего диапазона с такими свойствами, что эти числа равны сумме составляющих их цифр, 
    /// в степенях, равных местам цифр в числе. (например: 135 = 1^1 + 3^2 + 5^3)
    /// </summary>
    /// <param name="a">Начало входящего диапазона</param>
    /// <param name="b">Конец входящего диапазона</param>
    /// <returns>Массив чисел, удовлетворяющих условию</returns>
    [KataLevel(LevelTypeEnum.Kyu, 6)]
    public static long[] SumDigPow(long a, long b) {
      // Места считаются от 1
      // Если (цифра числа в степени позиция цифры) >= числа, то пропустить проверку этого числа.
      // var qqq = Math.Pow(9_223372_036854_775807, (double)1/20);
      List<long> result = new List<long>();
      for(long number = a; number <= b; number++) {
        // Коллекция цифр в числе
        var digitsCollection = number.ToString().Select(s => (long)Char.GetNumericValue(s));
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
    [KataLevel(LevelTypeEnum.Kyu, 6)]
    public static string Order(string words) {
      string[] wordArray = words.Split(' ');
      var digits = words.Where(c => Char.IsDigit(c)).Select(c => Char.GetNumericValue(c));
      Array.Sort(digits.ToArray(), wordArray);
      return String.Join(" ", wordArray);
      throw new NotImplementedException();
    }

    /// <summary>Возвращает сумму всех чисел в натуральном ряду, которые делятся на 3 или на 5</summary>
    /// <param name="value">Верхний предел ряда</param>
    /// <returns>Сумма</returns>
    [KataLevel(LevelTypeEnum.Kyu, 6)]
    public static int Solution(int value) {
      try { return Enumerable.Range(0, value).Where(d => (d % 3 == 0 || d % 5 == 0)).Sum(); }
      catch { return int.MaxValue; }
    }

    /// <summary>
    /// <para>Возвращает количество кубов, нужное для достижения объёма = m.</para>
    /// <para>Кубы начинаются с размеров 1х1х1.</para>
    /// <para>Сторона каждого последующего куба больше стороны предыдущего на 1.</para>
    /// </summary>
    /// <param name="m">Нужный объём</param>
    /// <returns>Количество кубов или -1, если объём не может уместить количество.</returns>
    [KataLevel(LevelTypeEnum.Kyu, 6)]
    public static long FindNb(long m) {
      long s = 1, v = 0, count = 0;
      for(; v < m; s++, count++) {
        v += s * s * s;
      }
      return (m == v) ? count : -1;
    }

  }

}
