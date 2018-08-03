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
      foreach(var item in _soundDict) {
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
      var indexes = bitGroups.Select(b => Convert.ToInt32(b, 2));
      var chars = indexes.Select(b => _codeString[b]);
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
      var bytes = bitGroups.Select(b => Convert.ToByte(b, 2)).ToArray();
      return Encoding.UTF8.GetString(bytes);
    }

    static List<string> BitGroups(string s, int oldSize, int newSize) {
      var indexes = s.Select(c => _codeString.IndexOf(c));
      var bitList = indexes.Select(c => Convert.ToString(c, 2).PadLeft(oldSize, '0'));
      string bitString = string.Join("", bitList);
      var bitGroups = new List<string>();
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
      // Дан массив строк
      // Каждый элемент: x:y [Команда 1] - [Команда 2]
      // Например: {6:0 Бавария Мюнхен - Вердер Бремен, -:- Айнтрахт Франкфурт - Шальке 04}
      // Команда, забившая больше голов — выигрывает
      // Вернуть строку, состоящую из данных массива.
      // Строка должна быть отформатирована в виде таблицы
      // Каждая строка таблицы: 
      // Номер строки таблицы, без ведущих нулей. Два места.
      // Точка.
      // Пробел
      // Название команды. 30 мест. С ведомыми пробелами до 30 мест.
      // Количество сыгранных матчей. Одно место.
      // Два пробела.
      // Количество выигранных матчей. 1 место.
      // Два пробела
      // Количество ничьих. 1 место
      // Два пробела
      // Количество проигрышей. 1 место.
      // Два пробела
      // Отношение забитых и полученных мячей, формат — 6:3
      // Два пробела 
      // Количество очков. 3 за выигрыш. 1 за ничью. 
      // Сортировка таблицы
      // Очки по убыванию
      // Большая разность в голах
      // Большее число забитых голов
      // Имя команды без учёта регистра

      List<Kommando> kList = new List<Kommando>();
      foreach(var item in results) {
        string score = item.Split(new char[] { ' ' }).First();
        int[] goals = score.Split(':').Select(s => int.Parse(s)).ToArray();
        string[] kommands = item.Remove(0, score.Length + 1)
          .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
        Kommando k0 = new Kommando(kommands[0], goals[0], goals[1]);
        Kommando k1 = new Kommando(kommands[1], goals[1], goals[0]);
        k0.AddToList(kList);
        k1.AddToList(kList);
      }
      // Сортировка по достижениям
      kList = kList
        .OrderByDescending(k => k.PointsCount)
        .ThenByDescending(k => k.GoalsOut - k.GoalsIn)
        .ThenByDescending(k => k.GoalsOut)
        .ThenByDescending(k => k.Name.ToLower())
        .ToList();
      // Добавление строк в лист результатов
      List<string> komResults = new List<string>();
      foreach(var k in kList) {
        string komStr = string.Join("  ",
          k.Name.PadRight(30) + k.MatchCount.ToString(),
          k.WinCount.ToString(),
          k.TieCount.ToString(),
          k.LosCount.ToString(),
          k.GoalsOut.ToString() + ":" + k.GoalsIn.ToString(),
          k.PointsCount
          );
        komResults.Add(komStr);
      }
      for(int i = 0; i < komResults.Count; i++) {
        string number = (i + 1).ToString().PadLeft(1);
        komResults[i] = string.Join(". ", number, komResults[i]);
      }
      return string.Join(Environment.NewLine, komResults).Replace(".  ", ". ");
    }

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
      public int WinCount;
      /// <summary>Матчей вничью</summary>
      public int TieCount;
      /// <summary>Матчей проиграно</summary>
      public int LosCount;
      /// <summary>Очков заработано</summary>
      public int PointsCount => WinCount * 3 + TieCount;

      /// <summary>Возвращает новыйэкземпляр класса <see cref="Kommando"/></summary>
      /// <param name="comName">Название команды</param>
      /// <param name="gOut">Голов забито</param>
      /// <param name="gIn">Голов получено</param>
      public Kommando(string comName, int gOut, int gIn) {
        Name = comName;
        MatchCount = 1;
        GoalsOut = gOut;
        GoalsIn = gIn;
        if(gOut > gIn) WinCount = 1;
        if(gOut < gIn) LosCount = 1;
        if(gOut == gIn) TieCount = 1;
      }

      /// <summary>
      /// Если команда не найдена в спискае, — добавляет её в список. 
      /// Если найдена — складывает результаты этой команды.
      /// </summary>
      /// <param name="lst">Список команд</param>
      public void AddToList(List<Kommando> lst) {
        var fc0 = lst.Find(e => e.Name == Name);
        if(fc0 == null) lst.Add(this);
        else {
          fc0.GoalsIn += GoalsIn;
          fc0.GoalsOut += GoalsOut;
          fc0.LosCount += LosCount;
          fc0.MatchCount += MatchCount;
          fc0.TieCount += TieCount;
          fc0.WinCount += WinCount;
        }
      }

    }

  }

}

