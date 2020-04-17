
namespace CodeWars.Kata.Kyu.L6 {
    public static partial class Kata {
        /// <summary>Принимаетс строку кода эзотерического языка и возвращает результат интерпретации.</summary>
        /// <param name="code">Эзотерическая строка.</param>
        /// <returns>Результат.</returns>
        [KataType(LevelTypes.Kyu, 6, "esolang-interpreters-number-1-introduction-to-esolangs-and-my-first-interpreter-ministringfuck")]
        public static string MyFirstInterpreter(string code) {
            #region Instructions
            // Язык MiniStringFuck https://esolangs.org/wiki/MiniStringFuck
            // Инструкции "+" и ".". Остальные сиволы интерпретатор игнорирует.
            // Данные хранятся в одной ячейке памяти.
            // Ячейка имеет 256 элементов, от 0 до 255
            // Если количество элеметов > 256 то оно = 0
            // + символ — увеличить ячейку на 1
            // . символ — вывести ASCII значение ячейки
            // Например +++.++.++++. — Значение 3 - вывести, значение 5 - вывести, значение 9 — вывести.
            #endregion
            byte cell = 0;
            var result = "";
            foreach (var item in code) {
                if (item == '+') {
                    try {
                        ++cell;
                    }
                    catch (System.OverflowException) {
                        cell = 0;
                    }
                }
                if (item == '.') {
                    result += (char)cell;
                }
            }
            return result;
        }
    }
}
