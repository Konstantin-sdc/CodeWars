﻿namespace CodeWars.Kata.Kyu.Esolangs
{
    using CodeWars;
    using CodeWars.Kata.Kyu.L5;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Res = Properties.Resources;

    public static class SmallFuck
    {
        /// <summary>Интерпретатор для smallfuck</summary>
        /// <param name="code">Входящий код. Правила обработки данных. Все непредусмотренные символы игнорируются.</param>
        /// <param name="source">Начальное состояние хранилища данных. битовая строка из 0 и 1. Иные символы игнорируются.</param>
        /// <returns>Строка</returns>
        [KataType(LevelTypes.Kyu, 5, "esolang-interpreters-number-2-custom-smallfuck-interpreter")]
        public static string Interpreter(string code, string source)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException(Res.IsNullOrEmpty, nameof(code));
            if (string.IsNullOrEmpty(source))
                throw new ArgumentException(Res.IsNullOrEmpty, nameof(source));
            #region Rules
            // > - Move pointer to the right (by 1 cell)
            // < -Move pointer to the left(by 1 cell)
            // * - Flip the bit at the current cell
            // [ - Jump past matching ] if value at current cell is 0
            // ] - Jump back to matching [ if value at current cell is nonzero
            #endregion
            var paireds = GetPairedPositions(code, '[', ']');
            var data = source.Where(e => e == '0' || e == '1').ToList();
            var dataPoint = 0;
            for (var i = 0; i < code.Length; i++)
            {
                if (dataPoint < 0 || dataPoint >= data.Count)
                    break;
                var command = code[i];
                switch (command)
                {
                    case '>':
                        ++dataPoint;
                        continue;
                    case '<':
                        --dataPoint;
                        continue;
                    case '*':                        
                        data[dataPoint] = data[dataPoint] == '0' ? '1' : '0';
                        continue;
                    case '[':
                        CodeForward(ref i, data[dataPoint], paireds);
                        continue;
                    case ']':
                        CodeBack(ref i, data[dataPoint], paireds);
                        continue;
                    default:
                        continue;
                }
            }
            return string.Concat(data);
        }

        /// <summary>Смещает указатель кода вперёд на парную позицию.</summary>
        /// <param name="codePount">Текущий указатель кода.</param>
        /// <param name="currentData">Текущее значение данных под указателем.</param>
        /// <param name="paireds">Словарь расположения пар.</param>
        private static void CodeForward(ref int codePount, char currentData, Dictionary<int, int> paireds)
        {
            if (currentData == '0') codePount = paireds[codePount];
        }

        /// <summary>Смещает указатель кода назад на парную позицию.</summary>
        /// <param name="codePount">Текущий указатель кода.</param>
        /// <param name="currentData">Текущее значение данных под указателем.</param>
        /// <param name="paireds">Словарь расположения пар.</param>
        private static void CodeBack(ref int codePount, char currentData, Dictionary<int, int> paireds)
        {
            if (currentData == '1')
            {
                var point = codePount;
                codePount = paireds.First(e => e.Value == point).Key;
            }
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

        /// <summary>Интерпретатор для Paintfuck</summary>
        /// <param name="code">Управляющий код. Неуправляющие символы игнорируются.</param>
        /// <param name="iterations">Неотрицательное целое число итераций, нужных для возврата конечного состояния таблицы данных.</param>
        /// <param name="width">Количество столбцов в таблице данных</param>
        /// <param name="height">Количество строк в таблице данных</param>
        /// <returns>Преобразованная таблица</returns>
        [KataType(LevelTypes.Kyu, 4, "esolang-interpreters-number-3-custom-paintf-star-star-k-interpreter")]
        public static string PaintFuckInterpreter(string code, int iterations, int width, int height)
        {
#pragma warning restore IDE0060, CA1801 // Удалите неиспользуемый параметр
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException(Res.IsNullOrEmpty, nameof(code));
            #region Rules
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
            #endregion
            return "";
        }
    }
}
