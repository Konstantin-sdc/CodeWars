using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        return "";
      }

    }

  }

}
