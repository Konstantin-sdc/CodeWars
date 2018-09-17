using System.Collections.Generic;
using System.Linq;

namespace CodeWars {

  public static partial class Kata {

    public static class Esolang {

      /// <summary>Принимаетс троку кода эзотерического языка и возвращает результат интерпретации</summary>
      /// <param name="code">Эзотерическая строка</param>
      /// <returns>Результат</returns>
      [KataType(LevelTypeEnum.Kyu, 6, "esolang-interpreters-number-1-introduction-to-esolangs-and-my-first-interpreter-ministringfuck")]
      public static string MyFirstInterpreter(string code) {
        // Язык MiniStringFuck https://esolangs.org/wiki/MiniStringFuck
        // Инструкции "+" и ".". Остальные сиволы интерпретатор игнорирует.
        // Данные хранятся в одной ячейке памяти.
        // Ячейка имеет 256 элементов, от 0 до 255
        // Если количество элеметов > 256 то оно = 0
        // + символ — увеличить ячейку на 1
        // . символ — вывести ASCII значение ячейки
        // Например +++.++.++++. — Значение 3 - вывести, значение 5 - вывести, значение 9 — вывести.
        byte cell = 0;
        string result = "";
        foreach(char item in code) {
          if(item == '+') {
            try {
              ++cell;
            }
            catch(System.OverflowException) {
              cell = 0;
            }
          }
          if(item == '.') {
            result += (char)cell;
          }
        }
        return result;
      }

      /// <summary>Интерпретатор для smallfuck</summary>
      /// <param name="code">Входящий код. Правила обработки данных. Все непредусмотренные символы игнорируются.</param>
      /// <param name="source">Начальное состояние хранилища данных. битовая строка из 0 и 1. Иные символы игнорируются.</param>
      /// <returns>Строка</returns>
      [KataType(LevelTypeEnum.Kyu, 5, "esolang-interpreters-number-2-custom-smallfuck-interpreter")]
      public static string Interpreter(string code, string source) {
        // Rules
        // > - Move pointer to the right (by 1 cell)
        // < -Move pointer to the left(by 1 cell)
        // *-Flip the bit at the current cell
        // [-Jump past matching ] if value at current cell is 0
        // ] -Jump back to matching [(if value at current cell is nonzero)
        Dictionary<int, int> paireds = GetPairedPosition(code, '[', ']');
        List<char> data = new List<char>();
        foreach(char item in source) {
          if(item == '0' || item == '1') {
            data.Add(item);
          }
        }
        int dataPoint = 0;
        for(int i = 0; i < code.Length; i++) {
          if(dataPoint < 0 || dataPoint >= data.Count) {
            break;
          }
          char command = code[i];
          if(command == '>') ++dataPoint;
          if(command == '<') --dataPoint;
          if(command == '*') data[dataPoint] = (data[dataPoint] == '0') ? '1' : '0';
          if(command == '[') {
            CodeForward(ref i, data[dataPoint], paireds);
            continue;
          }
          if(command == '[') {
            CodeBack(ref i, data[dataPoint], paireds);
            continue;
          }
        }
        return string.Join("", data);
      }

      private static void CodeForward(ref int codePount, char currentData, Dictionary<int, int> paireds) {
        //if(currentData == '1') ++codePount;
        if(currentData == '0') codePount = paireds[codePount];
        return;
      }

      private static void CodeBack(ref int codePount, char currentData, Dictionary<int, int> paireds) {
        //if(currentData == '0') ++codePount;
        if(currentData == '1') {
          int point = codePount;
          codePount = paireds.Where(e => e.Value == point).First().Key;
        }
        return;
      }

      /// <summary>Возвращает позиции парных элементов коллекции</summary>
      /// <typeparam name="T">Тип элемента в коллекции</typeparam>
      /// <param name="code">Коллекция</param>
      /// <param name="open">Элемент первый в паре</param>
      /// <param name="close">Элемент второй в паре</param>
      /// <returns>Словарь</returns>
      private static Dictionary<int, int> GetPairedPosition<T>(IEnumerable<T> code, T open, T close) {
        if(code.Count() < 2 || !code.Contains(open)) return null;
        Dictionary<int, int> result = new Dictionary<int, int>();
        List<int> oPositions = new List<int>();
        int opCount = 0;
        int closCount = 0;
        for(int i = 0; i < code.Count(); i++) {
          if(code.ElementAt(i).Equals(open)) {
            oPositions.Add(i);
          }
        }
        foreach(int position in oPositions) {
          for(int i = position; i < code.Count(); i++) {
            if(code.ElementAt(i).Equals(open)) {
              opCount++;
              continue;
            }
            if(code.ElementAt(i).Equals(close)) {
              closCount++;
            }
            else continue;
            if(opCount != 0 && opCount == closCount) {
              result.Add(position, i);
              opCount = 0;
              closCount = 0;
              break;
            }
          }
        }
        return result;
      }

    }

  }

}
