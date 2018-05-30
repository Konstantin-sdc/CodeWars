using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars {
  class Program {
    static void Main() {
      //Kata.SquareDigits(1234);
      //Kata.Maskify("Qwertyuiopasdf");
      //bool res = Kata.IsIsogram("QwEr");
      //int qqq = Kata.Persistence(103);
      string[] arr = { "qq", "dddd", "hhhh", "yy", "aaaaa", "s" };
      string[] arr2 = new string[0];
      //Kata.LongestConsec(arr2, 12);
      //Kata.NbYear(10, 2, 5, 20);
      string[] names = { "Ryan", "Kieran", "Jason", "Yous" };
      //Kata.FriendOrFoe(names);
      //Kata.RowSumOddNumbers(-42);
      //Kata.SumDigPow(0, 10000000);
      //Kata.Order("qw2fd kh3ikh hgh5ug yfu1hf");
      //Kata.Solution(int.MaxValue);
      //Kata.FindNb(91716553919377);
      //Kata.ListSquared(2, 250);
      //Xbonacci xbonacci = new Xbonacci();
      // 1,1,1,3,5,9,17,31,57,105
      //double[] d0 = xbonacci.Tribonacci(new double[] { 1, 1, 1 }, 10);
      // 
      string rgbHex00 = Kata.Rgb(-300, 128, 300);
    }
  }

  public static class Kata {

    public static string ListSquared(long m, long n) {
      // 42 делится на 1, 2, 3, 6, 7, 14, 21, 42
      // Квадраты этих делителей — из 1, 4, 9, 36, 49, 196, 441, 1764
      // Сумма квадратов делителей — 2500 = 50^2
      // От m до n включительно найти все целые числа, сумма квадратов делителей которых также является квадратом
      // list_squared(1, 250) --> [[1, 1], [42, 2500], [246, 84100]]

      // Сумма квадратов должна заканчиваться на 0, 1, 4, 5, 9 чтобы самой быть квадратом
      // Для чётных чисел проверятьтолько чётные делители, для нечётных — нечётные
      // Частное автоматом записывать в делитель
      // Прекратить проверять делители, если очередной будет > половины делимого

      for(long i = m; i <= n; i++) {
        // Выбор стартового делителя
        long divisor = (i % 2 == 0) ? 2 : 3;
        IEnumerable<long> divisorList = new List<long>() { 1, m };
        for(; divisor <= i / 2; divisor += 2) {
          if(i % divisor == 0) {
            divisorList.ToList().Add(divisor);
            divisorList.ToList().Add(i / divisor);
          }
        }
        divisorList = divisorList.Distinct().OrderBy(d => d);
        var QuadSum = divisorList.Select(d => Math.Pow(d, 2)).Sum();
        var sqrt = Math.Sqrt(QuadSum);
        //if(sqrt % 1 == 0) ;
      }

      for(long i = m; i <= i; i++) {
        break;
      }
      return "";
    }

    public static long FindNb(long m) {
      double volume = 0;
      long result = 0;
      for(int i = 1; volume < m; i++, result++) {
        volume += Math.Pow(i, 3);
      }
      return (volume == m) ? result : -1;
    }

    public static int Solution(int value) {
      try { return Enumerable.Range(0, value).Where(d => (d % 3 == 0 || d % 5 == 0)).Sum(); }
      catch { return int.MaxValue; }
    }

    public static string Order(string words) {
      string[] wordArray = words.Split(' ');
      var digits = words.Where(c => Char.IsDigit(c)).Select(c => Char.GetNumericValue(c));
      Array.Sort(digits.ToArray(), wordArray);
      return String.Join(" ", wordArray);
      throw new NotImplementedException();
    }

    public static long[] SumDigPow(long a, long b) {
      // Из диапазона от a до b включительно, вернуть такие числа, которые получаются сложением их цифр, 
      // в степенях, равных местам цифр в числе типа 135 = 1^1 + 3^2 + 5^3
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

    /// <summary>YYY</summary>
    /// <param name="n">Номер блока, считая от 1</param>
    /// <returns></returns>
    public static long RowSumOddNumbers(long n) {
      long firstBlockCount = 1;
      long firstVaue = 1;
      long countStep = 1;
      long valueStep = 2;

      // Count elements in block n
      long nBlockCount = firstBlockCount + countStep * (n - 1);
      // Count elements in all blocks, include n
      long allCount = (firstBlockCount + nBlockCount) * n / 2;
      // Last element value in block n
      long lastValue = firstVaue + valueStep * (allCount - 1);
      return lastValue + (lastValue + n / 2 * -valueStep) * (n - 1);
    }

    public static IEnumerable<string> FriendOrFoe(string[] n) => n.Where(s => s.Length == 4);

    /// <summary>Возвращает количество периодов, за которое начальное количество достигнет целевого</summary>
    /// <param name="p0">Начальное количество</param>
    /// <param name="percent">Периодическое изменение в процентах</param>
    /// <param name="aug">Периодическое абсолютное изменение</param>
    /// <param name="p">Целевое количество</param>
    /// <returns></returns>
    public static int NbYear(int p0, double percent, int aug, int p) {
      int pCount = 0;
      for(int pCur = p0; pCur < p; pCount++) {
        pCur = (int)(pCur * (1 + 0.01 * percent) + aug);
      }
      return pCount;
    }

    /// <summary>Вернуть первую наидлиннейшую строку, состоящую из k элементов массива</summary>
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

    public static string HighAndLow(string numbers) {
      var intArr = numbers.Split(' ').Select(int.Parse);
      return intArr.Max() + " " + intArr.Min();
    }

    public static int SquareDigits(int n) {
      var digits = n.ToString().Select(s => Char.GetNumericValue(s));
      digits = digits.Select(s => s * s);
      return int.Parse(String.Join(null, digits));
    }

    private static List<int> _digits(int n) {
      #region Withh recursion
      if(n < 10) return new List<int> { n };
      List<int> result = _digits(n / 10);
      result.Add(n % 10);
      #endregion
      return result;
    }

    public static string Maskify(string cc) {
      //return (cc.Length > 4) ? new string('#', cc.Length - 4) + cc.Substring(cc.Length - 4) : cc;
      int startIndex = (cc.Length > 4) ? cc.Length - 4 : 0;
      return new string('#', startIndex) + cc.Substring(startIndex);
    }

    public static bool IsIsogram(string str) {
      return str.Length == str.ToLower().Distinct().Count();
    }

    public static int Persistence(long n) {
      if(n < 10) return 0;
      var digits = n.ToString().Select(e => Char.GetNumericValue(e));
      long baseNumber = 1;
      //var bn = n.ToString().Aggregate();
      foreach(long digit in digits) {
        baseNumber *= digit;
        if(digit == 0) break;
      }
      int multCount = Persistence(baseNumber);
      multCount++;
      return multCount;
    }

    public static int[] MinMax(int[] lst) => new int[] { lst.Min(), lst.Max() };

    public static string Rgb(int r, int g, int b) {
      string result = "";
      foreach(int i in new int[3] { r, g, b }) {
        result += Math.Max(0, Math.Min(i, 255)).ToString("X2");
      }
      return result;
      //return HexColor(r, g, b);
    }
    private static string HexColor(params int[] p) {
      string[] arr = new string[3];
      for(int i = 0; i < p.Length; i++) {
        if(p[i] < 0) p[i] = 0;
        if(p[i] > 255) p[i] = 255;
        arr[i] = p[i].ToString("X2");
      }
      return String.Join("", arr);
    }
    private static string HexColor02(params int[] p) {
      string result = "";
      for(int i = 0; i < p.Length; i++) {
        result += Math.Max(0, Math.Min(p[i], 255)).ToString("X2");
      }
      return result;
    }
  }

  public class Xbonacci {
    // signature всегда должна содержать 3 числа
    public double[] Tribonacci(double[] signature, int n) {
      // hackonacci me
      // if n==0, then return an array of length 1, containing only a 0
      if(n < 1 || signature.Length != 3) return new double[] { 0 };
      double[] result = new double[n];
      int sc = (n <= signature.Length) ? n : signature.Length;
      // Запись сигнатуры
      for(int i = 0; i < sc; i++) {
        result[i] = signature[i];
      }
      if(n <= signature.Length) return result;
      for(int i = sc; i < n; i++) {
        result[i] = result[i - 1] + result[i - 2] + result[i - 3];
      }
      return result;
    }
  }
}
