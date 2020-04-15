using System.Collections.Generic;
using System.Linq;

namespace CodeWars {

    public static partial class KataClass {

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
            foreach (char item in source) {
                if (item == '0' || item == '1') {
                    data.Add(item);
                }
            }
            int dataPoint = 0;
            for (int i = 0; i < code.Length; i++) {
                if (dataPoint < 0 || dataPoint >= data.Count) {
                    break;
                }
                char command = code[i];
                if (command == '>') ++dataPoint;
                if (command == '<') --dataPoint;
                if (command == '*') data[dataPoint] = (data[dataPoint] == '0') ? '1' : '0';
                if (command == '[') {
                    CodeForward(ref i, data[dataPoint], paireds);
                    continue;
                }
                if (command == '[') {
                    CodeBack(ref i, data[dataPoint], paireds);
                    continue;
                }
            }
            return string.Join("", data);
        }

        private static void CodeForward(ref int codePount, char currentData, Dictionary<int, int> paireds) {
            //if(currentData == '1') ++codePount;
            if (currentData == '0') codePount = paireds[codePount];
            return;
        }

        private static void CodeBack(ref int codePount, char currentData, Dictionary<int, int> paireds) {
            //if(currentData == '0') ++codePount;
            if (currentData == '1') {
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
            if (code.Count() < 2 || !code.Contains(open)) return null;
            Dictionary<int, int> result = new Dictionary<int, int>();
            List<int> oPositions = new List<int>();
            int opCount = 0;
            int closCount = 0;
            for (int i = 0; i < code.Count(); i++) {
                if (code.ElementAt(i).Equals(open)) {
                    oPositions.Add(i);
                }
            }
            foreach (int position in oPositions) {
                for (int i = position; i < code.Count(); i++) {
                    if (code.ElementAt(i).Equals(open)) {
                        opCount++;
                        continue;
                    }
                    if (code.ElementAt(i).Equals(close)) {
                        closCount++;
                    }
                    else continue;
                    if (opCount != 0 && opCount == closCount) {
                        result.Add(position, i);
                        opCount = 0;
                        closCount = 0;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>Интерпретатор для Paintfuck</summary>
        /// <param name="code">Управляющий код. Неуправляющие символы игнорируются.</param>
        /// <param name="iterations">Неотрицательное целое число итераций, нужных для возврата конечного состояния таблицы данных.</param>
        /// <param name="width">Количество столбцов в таблице данных</param>
        /// <param name="height">Количество строк в таблице данных</param>
        /// <returns>Преобразованная таблица</returns>
        [KataType(LevelTypeEnum.Kyu, 4, "esolang-interpreters-number-3-custom-paintf-star-star-k-interpreter")]
        public static string PaintFuckInterpreter(string code, int iterations, int width, int height) {
            //n - Move data pointer north(up)
            //e - Move data pointer east(right)
            //s - Move data pointer south(down)
            //w - Move data pointer west(left)
            //* -Flip the bit at the current cell(same as in Smallfuck)
            //[ - Jump past matching ] if bit under current pointer is 0 (same as in Smallfuck)
            //] - Jump back to the matching [ (if bit under current pointer is nonzero) (same as in Smallfuck)

            // Команды чувствительны к регистру
            // UNDONE ЧТО ЗА НЕЯСНАЯ ХРЕНЬ?! Интерпретатор должен инициализировать все ячейки таблицы со значением 0, независимот размера таблицы.
            // В начале указатель данных всегда в левом верхнем углу таблицы
            // Количество итераций это количество обработанных символов таблицы?
            // Переход между [] или обратно — одна итерация, независимо от числа команд между ними. Другой переход — другая итерация.
            // Интерпретатор возвращает конечное состояние таблицы при любом из указанныхусловий: 
            // 1. Все команды прочинаны слева направо.
            // 2. Интерпретатор выполнил нужное количество итераций.
            // Интерпретатор возвращает конечное состояние таблицы данных вида 0101\r\n0101\r\n0101.

            // Если управляющих символов нет — вернуть исходное состояние таблицы данных
            // Если iterations == 0 — вернуть исходное состояние таблицы данных

            // Implement your interpreter here
            return "";
        }

    }

}
