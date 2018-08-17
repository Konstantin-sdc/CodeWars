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
        if(a % b > 0) continue;
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

    static Dictionary<string, string> _soundDict = new Dictionary<string, string>() {
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

    static string SoundexSingle(string word) {
      string result = word.ToUpper();
      char fC = result[0];
      foreach(KeyValuePair<string, string> item in _soundDict) {
        result = Regex.Replace(result, item.Key, item.Value);
      }
      result = fC + result.Substring(1);
      return result.Substring(0, 4);
    }

    /// <summary>Кодовая строка</summary>
    static string _codeString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

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

    static List<string> BitGroups(string s, int oldSize, int newSize) {
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
        if(!k.SameResult(kPr)) number = i + 1;
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
    class Kommando {

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
        if(!isGoals) return;
        MatchCount = 1;
        if(GoalsOut > GoalsIn) Wins = 1;
        if(GoalsOut < GoalsIn) Loses = 1;
        if(GoalsOut == GoalsIn) Ties = 1;
      }

      /// <summary>
      /// Если команда не найдена в спискае, — добавляет её в список. 
      /// Если найдена — складывает результаты этой команды.
      /// </summary>
      /// <param name="lst">Список команд</param>
      public void AddToList(List<Kommando> lst) {
        Kommando fc0 = lst.Find(e => e.Name == Name);
        if(fc0 == null) lst.Add(this);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m">Меньшее число диапазона</param>
    /// <param name="n">Большее число диапазона</param>
    /// <returns></returns>
    [KataType(LevelTypeEnum.Kyu, 5, "integers-recreation-one")]
    public static string ListSquared(long n, long m) {
      // Делители для 42 это: 1, 2, 3, 6, 7, 14, 21, 42
      // Делители в квадратах: 1, 4, 9, 36, 49, 196, 441, 1764
      // Сумма этих квадратов = 2500
      // 2500 = 50*50 = 50 в квадрате
      // Даны 2 числа (1 <= m <= n)
      // Найти все числа между ними, у которых сумма квадратов делителей сама является квадратом
      // your code
      return "";
    }

    public static List<long> GetDividers(long dvsn) {
      List<long> dvdrs = SimpeDividers(dvsn).ToList();
      List<long> ads = new List<long>();
      for(int i = 0; i < dvdrs.Count; i++) {
        long r = dvdrs[i];
        for(int k = i + 1; k < dvdrs.Count; k++) {
          r *= dvdrs[k];
          ads.Add(r);
        }
      }
      dvdrs.AddRange(ads);
      dvdrs.Add(1);
      return dvdrs.Distinct().OrderBy(e => e).ToList();
    }

    static IEnumerable<long> SimpeDividers(long dvsn) {
      List<long> dvdrs = new List<long>();
      long dvdr = 3, step = 2;
      if(dvsn % 2 == 0) {
        dvdr = 2;
        step = 1;
      }
      for(; dvdr <= dvsn; dvdr += step) {
        if(dvsn % dvdr == 0) {
          dvdrs.Add(dvdr);
          dvdrs.AddRange(SimpeDividers(dvsn / dvdr));
          break;
        }
        if(dvdr > dvsn / 2) return new List<long>() { dvsn };
      }
      return dvdrs; ;
    }

  }

}

