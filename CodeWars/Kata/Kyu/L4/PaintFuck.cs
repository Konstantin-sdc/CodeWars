namespace CodeWars.Kata.Kyu.L4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Res = Properties.Resources;

    public static class PaintFuck
    {
        #region Rules
        // Не командные символы игнорируются
        //
        // Символы команд регистрозависимы.
        // Интерпретатор должен инициализировать все ячейки в сетке данных значением 0 независимо от ширины и высоты сетки. 
        // указатель всегда должен начинаться в верхнем левом углу сетки данных (т. Е. Первая строка, первый столбец).
        // 
        // Одна итерация определяется как один шаг в программе, то есть количество оцениваемых символов команды. 
        // Например, учитывая программу nessewnnnewwwsswse и количество итераций 5, 
        // ваш интерпретатор должен оценить, nesse прежде чем возвращать конечное состояние таблицы данных. 
        //
        // Некомандные символы не должны учитываться при подсчете количества итераций.
        // переход к совпадению ] при [ обнаружении (или наоборот) считается одной итерацией, 
        // независимо от количества символов команды между ними. 
        // Следующая итерация начинается с команды сразу после сопоставления ] или [.
        //
        // Интерпретатор должен нормально завершать работу и возвращать конечное состояние сетки данных 2D всякий раз, 
        // когда любое из упомянутых условий становится истинным: 
        // (1) все команды были рассмотрены слева направо, или 
        // (2) ваш интерпретатор уже выполнил указанное число итераций во втором аргументе.
        // Возвращаемое значение вашего интерпретатора должно быть представлением конечного состояния сетки данных 2D, 
        // где каждая строка отделена от следующей с помощью CRLF ( \r\n). 
        // Например, если конечное состояние вашей таблицы данных ==
        // [
        //   [1, 0, 0],
        //   [0, 1, 0],
        //   [0, 0, 1]
        // ]
        // ... тогда ваша возвращаемая строка должна быть "100\r\n010\r\n001".
        //
        // Пример:
        // TestCaseData("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 0, 6, 9, "000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000")
        // .Returns("000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000")
        #endregion
        private static readonly char[] _commandSymbols = new char[] { 'n', 'e', 's', 'w', '*', '[', ']' };

        /// <summary>Интерпретатор для PaintFuck.</summary>
        /// <param name="code">
        /// <para>Код Paintfuck, который нужно выполнить.</para>
        /// <para>Комментарии (не командные символы), игнорируются.</para>
        /// </param>
        /// <param name="iterations">
        /// Неотрицательное целое число, = количество итераций перед возвращением конечного состояния сетки данных.
        /// </param>
        /// <param name="width">Положительное целое число = количество столбцов в сетке данных.</param>
        /// <param name="height">Положительное целое число = количество строк в сетке данных.</param>
        /// <returns>
        /// <para>Начальное состояние сетки данных, если <paramref name="code"/> пуст.</para>
        /// <para>Начальное состояние сетки данных, если <paramref name="iterations"/> == 0.</para>
        /// </returns>
        public static string Interpret(string code, int iterations, int width, int height)
        {
            #region Exceptions
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException(Res.VarOutOutOfRange, nameof(code));
            if (iterations < 0)
                throw new ArgumentOutOfRangeException(nameof(iterations), Res.VarOutOutOfRange + " < 0");
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), Res.VarOutOutOfRange + " <= 0");
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), Res.VarOutOutOfRange + " <= 0");
            #endregion
            #region DataGrid initialise
            var data = new bool[height, width];
            if (iterations == 0)
                return GetResultGrid(data);
            #endregion
            #region Data Pointer Moving
            #region Rules
            // n - Переместить указатель данных на север(вверх)
            // e - Переместить указатель данных на восток(вправо)
            // s - Переместить указатель данных на юг(вниз)
            // w - Переместить указатель данных на запад(влево)
            // * - Отразить бит в текущей ячейке(так же, как в Smallfuck)
            // [ - Пропускать совпадение, ] если бит под текущим указателем равен 0 (так же, как в Smallfuck)
            // ] - Перейти к соответствию [ (если бит под текущим указателем ненулевой) (так же, как в Smallfuck)            
            #endregion
            var paireds = GetPairedPositions(code, '[', ']');
            var strPos = 0;
            var colPos = 0;
            for (int i = 0, j = 0; i < code.Length || j <= iterations; i++, j++)
            {
                var command = code[i];
                switch (command)
                {
                    case 'n':
                        ++strPos;
                        continue;
                    case 'e':
                        ++colPos;
                        continue;
                    case 's':
                        --strPos;
                        continue;
                    case 'w':
                        --colPos;
                        continue;
                    case '*':
                        data[strPos, colPos] = !data[strPos, colPos];
                        continue;
                    case '[':
                        CodeForward(ref i, data[strPos, colPos], paireds);
                        continue;
                    case ']':
                        CodeBack(ref i, data[strPos, colPos], paireds);
                        continue;
                    default:
                        continue;
                }
            }
            #endregion
            return GetResultGrid(data);
        }

        /// <summary>Возвращает позиции парных элементов коллекции</summary>
        /// <typeparam name="T">Тип элемента в коллекции</typeparam>
        /// <param name="code">Коллекция</param>
        /// <param name="open">Элемент первый в паре</param>
        /// <param name="close">Элемент второй в паре</param>
        /// <returns>Словарь</returns>
        private static Dictionary<int, int> GetPairedPositions<T>(IEnumerable<T> code, T open, T close)
        {
            if (code.Count() < 2 || !code.Contains(open)) return null;
            var result = new Dictionary<int, int>();
            var opPositions = new List<int>();
            var opCount = 0;
            var closCount = 0;
            for (var i = 0; i < code.Count(); i++)
            {
                if (code.ElementAt(i).Equals(open))
                    opPositions.Add(i);
            }
            foreach (var position in opPositions)
            {
                for (var i = position; i < code.Count(); i++)
                {
                    if (code.ElementAt(i).Equals(open))
                    {
                        opCount++;
                        continue;
                    }
                    if (code.ElementAt(i).Equals(close))
                        closCount++;
                    else
                        continue;
                    if (opCount != 0 && opCount == closCount)
                    {
                        result.Add(position, i);
                        opCount = 0;
                        closCount = 0;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>Смещает указатель кода вперёд на парную позицию.</summary>
        /// <param name="codePount">Текущий указатель кода.</param>
        /// <param name="currentData">Текущее значение данных под указателем.</param>
        /// <param name="paireds">Словарь расположения пар.</param>
        private static void CodeForward(ref int codePount, bool currentData, Dictionary<int, int> paireds)
        {
            if (currentData == false) codePount = paireds[codePount];
        }

        /// <summary>Смещает указатель кода назад на парную позицию.</summary>
        /// <param name="codePount">Текущий указатель кода.</param>
        /// <param name="currentData">Текущее значение данных под указателем.</param>
        /// <param name="paireds">Словарь расположения пар.</param>
        private static void CodeBack(ref int codePount, bool currentData, Dictionary<int, int> paireds)
        {
            if (currentData == true)
            {
                var point = codePount;
                codePount = paireds.First(e => e.Value == point).Key;
            }
        }

        /// <summary>Возвращает форматированную сетку данных из строк.</summary>
        /// <param name="boolArray">Двумерный массив</param>
        /// <returns>Блок строк из 1 и 0 одинаковой длины.</returns>
        private static string GetResultGrid(bool[,] boolArray)
        {
            if (boolArray is null)
                throw new ArgumentNullException(nameof(boolArray));
            var height = boolArray.GetLength(0);
            var width = boolArray.GetLength(1);
            var stringArray = new string[height];
            for (var i = 0; i < stringArray.Length; i++)
            {
                for (var k = 0; k < width; k++)
                    stringArray[i] += Convert.ToInt32(boolArray[i, k]);
            }
            return string.Join("\r\n", stringArray);
        }
    }
}
