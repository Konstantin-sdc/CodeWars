using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CodeWars {

  /// <summary>Класс для тренировок</summary>
  public static partial class Kata {

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

    /// <summary>Задания на 7 кю</summary>
    public static class Kyu7 {

      /// <summary>7 Возвращает самое большое и самое малое числа изстроки чисел</summary>
      /// <param name="numbers">Строка чисел, разделённых пробелами</param>
      /// <returns>Строка из наибольшего и наименьшего чисел</returns>
      public static string HighAndLow(string numbers) {
        var intArr = numbers.Split(' ').Select(int.Parse);
        return intArr.Max() + " " + intArr.Min();
      }

      /// <summary>Маскирует символом # все символы входящей строки, кроме последних четырёх</summary>
      /// <param name="cc">Строка,которую следует замаскировать</param>
      /// <returns>Замаскированная строка</returns>
      public static string Maskify(string cc) {
        int startIndex = (cc.Length > 4) ? cc.Length - 4 : 0;
        return new string('#', startIndex) + cc.Substring(startIndex);
      }

      /// <summary>Указывает является ли проверяемая строка изограммой</summary>
      /// <param name="s">Проверяемая строка</param>
      /// <returns><see cref="true"/> если является</returns>
      public static bool IsIsogram(string s) {
        return s.Length == s.ToLower().Distinct().Count();
      }

      /// <summary>Возвращает число, состоящие из квадратов каждой цифры исходного числа</summary>
      /// <param name="n">Исходное число</param>
      /// <returns>Число из квадратов</returns>
      public static int SquareDigits(int n) {
        var digits = n.ToString().Select(s => Char.GetNumericValue(s));
        digits = digits.Select(s => s * s);
        return int.Parse(String.Join(null, digits));
      }

      /// <summary>Возвращает количество периодов, за которое начальное количество достигнет целевого</summary>
      /// <param name="p0">Начальное количество</param>
      /// <param name="percent">Периодическое изменение в процентах</param>
      /// <param name="aug">Периодическое абсолютное изменение</param>
      /// <param name="p">Целевое количество</param>
      /// <returns>Количество периодов</returns>
      public static int NbYear(int p0, double percent, int aug, int p) {
        int pCount = 0;
        for(int pCur = p0; pCur < p; pCount++) {
          pCur = (int)(pCur * (1 + 0.01 * percent) + aug);
        }
        return pCount;
      }

      /// <summary>Возвращает строки, длина которых = 4</summary>
      /// <param name="n">Массив строк для проверки</param>
      /// <returns>Коллекция строк</returns>
      public static IEnumerable<string> FriendOrFoe(string[] n) => n.Where(s => s.Length == 4);

      // hack: Есть более красивые варианты решения
      /// <summary>Возвращает сумму нечётных чисел числового треугольника</summary>
      /// <param name="n">Номер блока, считая от 1</param>
      /// <returns>Сумма нечётных чисел</returns>
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

    }

    private static List<int> _digits(int n) {
      #region Withh recursion
      if(n < 10) return new List<int> { n };
      List<int> result = _digits(n / 10);
      result.Add(n % 10);
      #endregion
      return result;
    }

    /// <summary>Задания на 6 кю</summary>
    public static class Kyu6 {

      /// <summary>Возвращает количество операций умножения, которые нужно провести над цифрами данного числа до тех пор, 
      /// пока они не станут одной цифрой.</summary>
      /// <param name="n">Проверяемое число</param>
      /// <returns>Необходимое число умножений</returns>
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
      public static int Solution(int value) {
        try { return Enumerable.Range(0, value).Where(d => (d % 3 == 0 || d % 5 == 0)).Sum(); }
        catch { return int.MaxValue; }
      }

    }

    public static int[] MinMax(int[] lst) => new int[] { lst.Min(), lst.Max() };

    /// <summary>Возвращает два числа из натурального ряда, произведение которых равно сумме всех чисел этого ряда, исключая эти два числа</summary>
    /// <param name="n">Верхний предел ряда. Всегда > 0</param>
    /// <returns>Массив чисел</returns>
    [KataLevel(LevelTypeEnum.Kyu, 5)]
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
      long searchRange = firstMax - firstMin;
      for(long i = firstMin; i <= firstMax; i++) {
        long a = sum - i;
        long b = i + 1;
        if(a % b > 0) continue;
        result.Add(new long[2] { i, a / b });
      }
      return result;
    }

    /// <summary>Возвращает сумму периметров квадратов в ряду Фибоначи</summary>
    /// <param name="n"></param>
    /// <returns></returns>
    [KataLevel(LevelTypeEnum.Kyu, 5)]
    public static BigInteger Perimeter(BigInteger n) {
      BigInteger first = 0, second = 1, fibSum = first + second;
      for(var i = 2; i < n; i++) {
        BigInteger current = first + second;
        fibSum += current;
        first = second;
        second = current;
      }
      return fibSum * 4;
    }

    /// <summary>
    /// Возвращает возможность объединения и перемешиваения двух строку в третию, 
    /// без изменения порядка символов в исходных строках.
    /// </summary>
    /// <param name="s">Итоговая строка</param>
    /// <param name="part1">Первая строка</param>
    /// <param name="part2">Вторая строка</param>
    /// <returns>true, если объединение возможно</returns>
    [KataLevel(LevelTypeEnum.Kyu, 5)]
    public static bool IsMerge(string s, string part1, string part2) {
      return MayExtract(s, part1, part2);
      //NOTE Символы в составляющих строках могут повторятся, совпадать с исмволами другой строки, быть разного регистра.
    }

    private static bool MayExtract(string s, params string[] parts) {
      string ordS = string.Join("", s.OrderBy(k => k));
      string p = string.Join("", parts);
      string ordP = string.Join("", p.OrderBy(k => k));
      if(!ordS.Equals(ordP)) return false;
      foreach(string part in parts) {
        int start = 0;
        foreach(char item in part) {
          start = s.IndexOf(item, start);
          if(start == -1) return false;
        }
      }
      return true;
    }

    /// <summary>Интерпретатор</summary>
    /// <param name="code">Код Paintfuck, который должен быть выполнен, передается как строка. </param>
    /// <param name="iterations"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    [KataLevel(LevelTypeEnum.Kyu, 5)]
    public static string Interpret(string code, int iterations, int width, int height) {
      // Правила
      // n - Переместить указатель данных на север(вверх)
      // e - Переместить указатель данных на восток(справа)
      // s - Переместить указатель данных на юг(вниз)
      // w - Переместить указатель данных на запад(слева)
      // * - Переверните бит в текущей ячейке(то же, что и в Smallfuck)
      // [- Переход мимо соответствия,] если бит под текущим указателем 0(тот же, что и в Smallfuck)
      // ]- Вернитесь к совпадению[(если бит под текущим указателем отличен от нуля) (то же, что и в Smallfuck)

      // Любой символ, не из вышеперечисленных должен игнорироваться

      return "";
    }

    [KataLevel(LevelTypeEnum.Kyu, 5)]
    public static string Soundex(string names) {
      string[] namesArr = names.Split(' ');
      string[] outArr = new string[namesArr.Length];
      Dictionary<string, char> worDig = new Dictionary<string, char>() {
        { "r", '6' },
        { "bfpv", '1' },
        { "cgjkqsxz", '2' },
        { "dt", '3' },
        { "l", '4' },
        { "mn", '5' }
      };
      string rmvChrs0 = "hw";
      string rmvChrs1 = "aeiouhw";
      for(int i = 0; i < namesArr.Length; i++) {
        var word = namesArr[i].ToLower().ToList();
        // Сохранить первую букву.
        char firstChar = namesArr[i][0];
        var noFirst = word.Skip(1);
        // Удалить все h и w, кроме первой буквы слова
        noFirst = noFirst.Where(c => !rmvChrs0.Contains(c));
        // Заменить согласные буквы, включая первую, на цифры
        foreach(var item in worDig) {          
          for(int k = 0; k < word.Count; k++) {
            if(item.Key.Contains(word[k])) word[k] = item.Value;
          }
        }
        // Сократить любую последовательность одинаковых цифр до одной
        List<int> rmvDs = new List<int>();
        for(int k = 0; k + 1 < word.Count; k++) {
          if(word[k] == word[k + 1] && char.IsDigit(word[k])) rmvDs.Add(k + 1);
        }
        rmvDs.ForEach(c => { word[c] = 'a'; });
        // Удалить все a, e, i, o, u, y, кроме первой буквы слова
        noFirst = noFirst.Where(c => !rmvChrs1.Contains(c));
        // Заменить первый символ буквой, запомненной на шаге 1        
        // Добавить нули, если нужно
        // Обрезать до первых четырёх букв
        outArr[i] = (firstChar + string.Join("", noFirst) + "000").Substring(0, 4);
      }
      // Вернуть в верхнем регистре
      return string.Join(" ", outArr).ToUpper();
    }

  }
}
