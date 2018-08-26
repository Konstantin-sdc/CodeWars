using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;


namespace CodeWars {

  public static partial class Kata {

    /// <summary>Возвращает два числа из натурального ряда, произведение которых равно сумме всех чисел этого ряда, исключая эти два числа</summary>
    /// <param name="n">Верхний предел ряда. Всегда > 0</param>
    /// <returns>Массив чисел</returns>
    [KataType(LevelTypeEnum.Kyu, 5)]
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
        if(a % b > 0) {
          continue;
        }

        result.Add(new long[2] { i, a / b });
      }
      return result;
    }

    /// <summary>Возвращает сумму периметров квадратов в ряду Фибоначи</summary>
    /// <param name="n"></param>
    /// <returns></returns>
    [KataType(LevelTypeEnum.Kyu, 5)]
    public static BigInteger Perimeter(BigInteger n) {
      BigInteger first = 0, second = 1, fibSum = first + second;
      for(int i = 2; i < n; i++) {
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
    [KataType(LevelTypeEnum.Kyu, 5)]
    public static bool IsMerge(string s, string part1, string part2) {
      return MayExtract(s, part1, part2);
      //NOTE Символы в составляющих строках могут повторятся, совпадать с исмволами другой строки, быть разного регистра.
    }

    private static bool MayExtract(string s, params string[] parts) {
      string ordS = string.Join("", s.OrderBy(k => k));
      string p = string.Join("", parts);
      string ordP = string.Join("", p.OrderBy(k => k));
      if(!ordS.Equals(ordP)) {
        return false;
      }

      foreach(string part in parts) {
        int start = 0;
        foreach(char item in part) {
          start = s.IndexOf(item, start);
          if(start == -1) {
            return false;
          }
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
    [KataType(LevelTypeEnum.Kyu, 5)]
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

    private static Dictionary<string, string> _soundDict = new Dictionary<string, string>() {
      { "(?!^)[HW]", "" },
      { "[BFPV]", "1" },
      { "[CGJKQSXZ]", "2" },
      { "[DT]", "3" },
      { "[L]", "4" },
      { "[MN]", "5" },
      { "[R]", "6" },
      { @"(\d+)\1", "$1"},
      { @"(?!^)[AEIOUY]", "" },
      { @"$", "000" }
    };

    /// <summary>Преобразует слова английского языка по алгоритму SOUNDEX</summary>
    /// <param name="names">Строка из слов, разделённых пробелом</param>
    /// <returns>SOUNDEX-коды группы слов</returns>
    [KataType(LevelTypeEnum.Kyu, 5)]
    public static string Soundex(string names) {
      string[] result = names.Split(' ');
      for(int i = 0; i < result.Length; i++) {
        result[i] = SoundexSingle(result[i]);
      }
      return string.Join(" ", result);
    }

    private static string SoundexSingle(string word) {
      string result = word.ToUpper();
      char fC = result[0];
      foreach(KeyValuePair<string, string> item in _soundDict) {
        result = Regex.Replace(result, item.Key, item.Value);
      }
      result = fC + result.Substring(1);
      return result.Substring(0, 4);
    }

    /// <summary>Кодовая строка</summary>
    private static string _codeString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

    /// <summary>
    /// Возвращает результат base64 кодирования исходной строки <paramref name="s"/> с использованием UTF-8
    /// </summary>
    /// <param name="s">Исходная строка</param>
    /// <returns>Результат</returns>
    [KataType(LevelTypeEnum.Kyu, 5)]
    public static string ToBase64(string s) {
      // Преобразовать строку в массив байтов
      // Преобразовать массив байт в массив бит
      // Сгруппировать биты в группы по 6
      List<string> bitGroups = BitGroups(s, 8, 6);
      // Каждую группу бит перевести в число десятичного формата
      // Заменить такое число на знак, расположенный по тому-же интексу в кодовой строке
      // Добавить недостающие знаки "=" в конец строки
      IEnumerable<int> indexes = bitGroups.Select(b => Convert.ToInt32(b, 2));
      IEnumerable<char> chars = indexes.Select(b => _codeString[b]);
      int rmdr = string.Join("", bitGroups).Length % 3;
      int adsCount = (rmdr == 0) ? 0 : (3 - rmdr);
      return string.Join("", chars) + new string('=', adsCount);
    }

    /// <summary>
    /// Возвращает результат base64 декодирования исходной последовательности <paramref name="s"/> с использованием UTF-8
    /// </summary>
    /// <param name="s">Исходная последовательность</param>
    /// <returns>Результат</returns>
    [KataType(LevelTypeEnum.Kyu, 5)]
    public static string FromBase64(string s) {
      // Убрать знаки "=" из строки и прочие, кого нет в кодовой строке
      s = string.Join("", s.Where(c => _codeString.Contains(c)));
      // Заменить знаки на их индексы в кодовой строке
      // Каждый индекс заменить на группу бит (м.б. с дополнением до 6)
      // Перегруппировать биты по 8
      List<string> bitGroups = BitGroups(s, 6, 8);
      // Перевести биты в символы
      byte[] bytes = bitGroups.Select(b => Convert.ToByte(b, 2)).ToArray();
      return Encoding.UTF8.GetString(bytes);
    }

    private static List<string> BitGroups(string s, int oldSize, int newSize) {
      IEnumerable<int> indexes = s.Select(c => _codeString.IndexOf(c));
      IEnumerable<string> bitList = indexes.Select(c => Convert.ToString(c, 2).PadLeft(oldSize, '0'));
      string bitString = string.Join("", bitList);
      List<string> bitGroups = new List<string>();
      for(int i = 0; i < bitString.Length; i += newSize) {
        string subS = bitString.Substring(i);
        int limit = newSize - 1;
        string bitG = string.Join("", subS.Where((c, index) => index <= limit));
        bitGroups.Add(bitG);
      }
      return bitGroups;
    }

    [KataType(LevelTypeEnum.Kyu, 5, "57c178e16662d0d932000120")]
    public static string BundesLigaTable(string[] results) {
      List<Kommando> kList = new List<Kommando>();
      foreach(string item in results) {
        string score = item.Split(new char[] { ' ' }).First();
        string[] goals = score.Split(':');
        string[] kommands = item.Remove(0, score.Length + 1)
          .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
        Kommando k0 = new Kommando(kommands[0], goals[0], goals[1]);
        Kommando k1 = new Kommando(kommands[1], goals[1], goals[0]);
        k0.AddToList(kList);
        k1.AddToList(kList);
      }
      kList = kList
        .OrderByDescending(k => k.Points)
        .ThenByDescending(k => k.GoalsOut - k.GoalsIn)
        .ThenByDescending(k => k.GoalsOut)
        .ThenBy(k => k.Name.ToLower())
        .ToList();
      List<string> komResults = new List<string>();
      for(int i = 0, number = 1; i < kList.Count; i++) {
        Kommando k = kList[i];
        Kommando kPr = (i - 1 >= 0) ? kList[i - 1] : k;
        if(!k.SameResult(kPr)) {
          number = i + 1;
        }

        string komStr = string.Join("  ",
          number.ToString().PadLeft(2) + ".",
          k.Name.PadRight(30) + k.MatchCount.ToString(),
          k.Wins.ToString(),
          k.Ties.ToString(),
          k.Loses.ToString(),
          k.GoalsOut.ToString() + ":" + k.GoalsIn.ToString(),
          k.Points
          );
        komResults.Add(komStr);
      }
      return string.Join("\n", komResults).Replace(".  ", ". ");
    }

    /// <summary>Команда</summary>
    private class Kommando {

      /// <summary>Название команды</summary>
      public string Name;
      /// <summary>Матчей сыграно</summary>
      public int MatchCount;
      /// <summary>Голов забито</summary>
      public int GoalsOut;
      /// <summary>Голов получено</summary>
      public int GoalsIn;
      /// <summary>Матчей выиграно</summary>
      public int Wins;
      /// <summary>Матчей вничью</summary>
      public int Ties;
      /// <summary>Матчей проиграно</summary>
      public int Loses;
      /// <summary>Очков заработано</summary>
      public int Points => Wins * 3 + Ties;

      /// <summary>Возвращает новыйэкземпляр класса <see cref="Kommando"/></summary>
      /// <param name="comName">Название команды</param>
      /// <param name="gOut">Голов забито</param>
      /// <param name="gIn">Голов получено</param>
      public Kommando(string comName, string gOut, string gIn) {
        Name = comName;
        bool isGoals =
          int.TryParse(gOut, out GoalsOut) &&
          int.TryParse(gIn, out GoalsIn);
        if(!isGoals) {
          return;
        }

        MatchCount = 1;
        if(GoalsOut > GoalsIn) {
          Wins = 1;
        }

        if(GoalsOut < GoalsIn) {
          Loses = 1;
        }

        if(GoalsOut == GoalsIn) {
          Ties = 1;
        }
      }

      /// <summary>
      /// Если команда не найдена в спискае, — добавляет её в список. 
      /// Если найдена — складывает результаты этой команды.
      /// </summary>
      /// <param name="lst">Список команд</param>
      public void AddToList(List<Kommando> lst) {
        Kommando fc0 = lst.Find(e => e.Name == Name);
        if(fc0 == null) {
          lst.Add(this);
        }
        else {
          fc0.GoalsIn += GoalsIn;
          fc0.GoalsOut += GoalsOut;
          fc0.Loses += Loses;
          fc0.MatchCount += MatchCount;
          fc0.Ties += Ties;
          fc0.Wins += Wins;
        }
      }

      /// <summary>Возвращает результат проверки совпадения зачёта с другой командой</summary>
      /// <param name="k">Проверяемая команда</param>
      /// <returns>true, если резульаты совпадают</returns>
      public bool SameResult(Kommando k) {
        return (
          Points == k.Points &&
          GoalsOut - GoalsIn == k.GoalsOut - k.GoalsIn &&
          GoalsOut == k.GoalsOut
          );
      }
    }

    [KataType(LevelTypeEnum.Kyu, 5, "integers-recreation-one")]
    public static string ListSquared(long m, long n) {
      List<long[]> squarList = SquaredList(m, n);
      IEnumerable<string> sl = squarList.Select(s => "[" + string.Join(", ", s) + "]");
      return "[" + string.Join(", ", sl) + "]";
    }

    /// <summary>
    /// Возвращает пары число — сумма квадратов из чисел между введёнными, у которых сумма квадратов делителей сама является квадратом
    /// </summary>
    /// <param name="m">Меньшее число диапазона</param>
    /// <param name="n">Большее число диапазона</param>
    /// <returns></returns>
    private static List<long[]> SquaredList(long m, long n) {
      List<long[]> numbers = new List<long[]>();
      for(long i = m; i <= n; i++) {
        List<long> dividers = GetDividers(i);
        IEnumerable<long> divSquared = dividers.Select(d => d * d);
        long sumSquared = divSquared.Sum();
        bool isSq = IsIntegerSquared(sumSquared);
        if(isSq) {
          long[] c = { i, sumSquared };
          numbers.Add(c);
        }
      }
      return numbers;
    }

    /// <summary>Возвращает список всех целочисленных делителей</summary>
    /// <param name="d">Ч</param>
    /// <returns>Список делителей</returns>
    public static List<long> GetDividers(long d) {
      List<long> simple = SimpeDividers(d);
      List<long> dvdrs = SimpeDividers(d);
      for(int i = 2; i < simple.Count(); i++) {
        IEnumerable<long[]> positionCombos = LimitFactorial(simple.Count() - 1, i);
        // Сопоставить цифры в combos с позициями в simple
        foreach(long[] positionCombo in positionCombos) {
          long[] digitsCombo = new long[positionCombo.Length];
          for(int k = 0; k < positionCombo.Length; k++) {
            long position = positionCombo[k];
            digitsCombo[k] = simple[(int)position];
          }
          long composition = GetComposition(digitsCombo);
          dvdrs.Add(composition);
        }
      }
      dvdrs.Add(1);
      dvdrs.Add(d);
      return dvdrs.Distinct().OrderBy(e => e).ToList();
    }

    public static long GetComposition(IEnumerable<long> seq) {
      long result = seq.ToArray()[0];
      for(long i = 1; i < seq.Count(); i++) {
        result *= seq.ToArray()[i];
      }
      return result;
    }

    /// <summary>
    /// <para>Умножает число на последовательность,</para>
    /// <para>затем на последовательность результатов.</para>
    /// <para>И так далее, до превышения лимита</para>
    /// </summary>
    /// <param name="a">Число</param>
    /// <param name="sequence">Входящая коллекция</param>
    /// <param name="limit">Лимит</param>
    /// <returns>Коллекция результатов, не превышающих лимит</returns>
    public static IEnumerable<long> Multiplex(long a, IEnumerable<long> sequence, long limit) {
      IEnumerable<long> sq = sequence.OrderBy(e => e);
      if(a == 0 || a == 1) {
        return sq;
      }
      if(a * sq.ElementAt(0) > limit) {
        return sq;
      }
      List<long> mult = new List<long>(sequence.Count());
      for(int i = 0; i < sequence.Count(); i++) {
        long b = sq.ElementAt(i);
        long r = a * b;
        if(r > limit) {
          break;
        }
        mult.Add(r);
      }
      return mult.Concat(Multiplex(a, mult, limit));
    }

    /// <summary>Возвращает сочетание из <paramref name="source"/> по <paramref name="count"/></summary>
    /// <param name="source">Число</param>
    /// <param name="count">Размер комбинации</param>
    /// <param name="start">Начало отчёта</param>
    /// <returns>Список массивов</returns>
    public static IEnumerable<long[]> LimitFactorial(long source, long count, uint start = 0) {
      string message = "{nameof(count)} должно быть > 1, a {nameof(source)} > nameof(count)";
      if(source < count) {
        throw new ArgumentOutOfRangeException(nameof(count), count, message);
      }
      if(count < 1) {
        throw new ArgumentOutOfRangeException(nameof(count), count, message);
      }
      List<long[]> result = new List<long[]>();
      if(count == 1) {
        for(long i = start; i <= source; i++) {
          result.Add(new long[] { i });
        }
        return result;
      }
      IEnumerable<long[]> prev = LimitFactorial(source, count - 1);
      foreach(long[] comboOld in prev) {
        for(long newItem = comboOld.Last() + 1; newItem <= source; newItem++) {
          long[] combo = new long[count];
          Array.Copy(comboOld, combo, comboOld.Length);
          combo[count - 1] = newItem;
          result.Add(combo);
        }
      }
      return result;
    }

    /// <summary>Раскладывает целое число на простые делители</summary>
    /// <param name="d">Целое число</param>
    /// <returns>Коллекция простых делителей</returns>
    private static List<long> SimpeDividers(long d) {
      List<long> dvdrs = new List<long>();
      long dvdr = 3, step = 2;
      if(d % 2 == 0) {
        dvdr = 2;
        step = 1;
      }
      for(; dvdr <= d; dvdr += step) {
        if(d % dvdr == 0) {
          dvdrs.Add(dvdr);
          dvdrs.AddRange(SimpeDividers(d / dvdr));
          break;
        }
        if(dvdr > d / 2) {
          return new List<long>() { d };
        }
      }
      return dvdrs;
    }

    /// <summary>Является ли число квадратом целого числа</summary>
    /// <param name="m"></param>
    /// <returns></returns>
    private static bool IsIntegerSquared(long m) {
      if(m < 0) {
        return false;
      }
      long[] mod100 = { 00, 01, 04, 09, 16, 21, 24, 25, 29, 36, 41, 44, 49, 56, 61, 64, 69, 76, 81, 84, 89, 96 };
      if(!mod100.Contains(m % 100)) {
        return false;
      }
      double d = Math.Sqrt(m);
      return d - (long)d == 0;
    }

    /// <summary>
    /// <para>Принимает целое число.</para>
    /// <para>К каждой группе его цифр припиывает число количества этих цифр.</para>
    /// <para>Уменьшает группы до одной цифры.</para>
    /// <para>Возвращает полученную комбинацию в виде целого числа.</para>
    /// </summary>
    /// <param name="number">Исходное число</param>
    /// <returns>Комбинация</returns>
    [KataType(LevelTypeEnum.Kyu, 5, "conways-look-and-say-generalized")]
    public static ulong LookSay(ulong number) {
      string s = number.ToString();
      List<List<char>> gs = GroupSeparate(s);
      IEnumerable<string> result = gs.Select(e => e.Count + e.First().ToString());
      return Convert.ToUInt64(string.Join("", result));
    }

    private static List<List<T>> GroupSeparate<T>(IEnumerable<T> seq) {
      List<List<T>> result = new List<List<T>>();
      if(seq.First() == null) {
        return result;
      }
      LinkedList<T> lkLs = new LinkedList<T>(seq);
      for(LinkedListNode<T> i = lkLs.First; i != null; i = i.Next) {
        if(i.Previous == null || !i.Value.Equals(i.Previous.Value)) {
          result.Add(new List<T>());
        }
        result.Last().Add(i.Value);
      }
      return result;
    }

  }

}

