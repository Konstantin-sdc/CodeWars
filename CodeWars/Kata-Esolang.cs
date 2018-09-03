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

      /// <summary>
      /// 
      /// </summary>
      /// <param name="code">Входящий код. 8-битная строка из 0 и 1. Иные символы игнорируются</param>
      /// <param name="tape">Начальное состояние хранилища данных. Правила обработки данных. Все непредусмотренные символы игнорируются.</param>
      /// <returns>Строка</returns>
      [KataType(LevelTypeEnum.Kyu, 5, "esolang-interpreters-number-2-custom-smallfuck-interpreter")]
      public static string Interpreter(string code, string tape) {
        // Rules
        // > - Move pointer to the right (by 1 cell)
        // < -Move pointer to the left(by 1 cell)
        // *-Flip the bit at the current cell
        // [-Jump past matching] if value at current cell is 0
        // ] -Jump back to matching[(if value at current cell is nonzero)
        return "";
      }

    }

  }

}
