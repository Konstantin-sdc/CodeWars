namespace CodeWars.Kata.Kyu.L4
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using CortBlock = System.ValueTuple<System.ValueTuple<int, int>, System.ValueTuple<int, int>, int>;

    public static partial class Kata
    {
        /// <summary>Возвращает многомерный массив из идентификаторов массива <paramref name="pieces"/>.</summary>
        /// <param name="pieces">Массив кортежей.</param>
        /// <param name="width">Ширина (количество столбцов) результата.</param>
        /// <param name="height">Высота (количество строк) результата.</param>
        /// <returns>Двумерный массив.</returns>
        [KataType(LevelTypes.Kyu, 4, "5ef2bc554a7606002a366006")]
        [SuppressMessage("Performance", "CA1814:Используйте массивы массивов вместо многомерных массивов", Justification = "<Ожидание>")]
        public static int[,] PuzzleSolver(((int l, int r) top, (int l, int r) btn, int Id)[] pieces, int width, int height)
        {
            #region Rules
            // Цель - решить головоломку типа «кусочки бумаги». 
            // Входные данные - различные части этой головоломки, 
            // нужно найти, в каком порядке их переставить, чтобы «картина» головоломки была полной. 
            // Порядок частей — слева направо, сверху вниз.

            // Головоломки могуд быть большого размера.
            // Ширина и высота от 2 до 100(включительно).
            // Пазл может быть прямоугольным

            // Все части пазла будут представлены следующим образом: 
            // 4 числа, сгруппированных в 2 кортежа, которые представляют собой «картинку» на изделии. 
            // Каждая деталь имеет размер 2х2. 1 идентификационный номер. 
            // Все идентификационные номера в головоломке уникальны, но их значение может быть случайным. 
            // Две части соседние, если они имеют одинаковый рисунок на границе, где они соприкасаютсяв графическом представлении.
            // Все числа будут неотрицательными целыми числами(за исключением чисел «картинки» внешней границы в C#)

            // Например, ((1, 2), (3, 4), 1) где последня единица это id
            // эквивалентен квадратному кусочку головоломки с идентификационным номером 1: 
            // +-----+
            // | 1 2 |            
            // | 3 4 |
            // +-----+ 

            // Если кусок находится на границе или в углу, некоторые числа будут заменены на None (-1 в C#):
            // ((-1, -1), (1, 2), 10) --> upper border
            // ((9, -1), (-1, -1), 11) --> bottom right corner

            // Решение головоломки
            // Двумерный массив Id частей согласно их порядку, а также размер пазла(ширину и высоту).
            #endregion

            // your code here
            #region Exceptions
            if (pieces is null)
                throw new ArgumentNullException(nameof(pieces));
            // Если ширина и высота указаны, значит pieces count может не соответствовать их произведению.
            if (width * height > pieces.Length)
            {
                var msg = $"{nameof(pieces).Length} < {nameof(width)} * {nameof(height)}";
                throw new ArgumentOutOfRangeException(nameof(pieces), msg);
            }
            #endregion

            //
            // var firstColumn = new List<CortBlock>(height) { pieces.First(p => p.top.l == -1 && p.btn.l == -1) };
            var firstColumn = pieces.Where(p => p.top.l == -1 && p.btn.l == -1);

            // sort firsColumn

            var lines = firstColumn.Count();
            var columns = pieces.Length / lines;
            var result = new int[lines, columns];

            for (var i = 0; i < lines; i++)
            {
                result[i, 0] = firstColumn.ElementAt(i).Id;
            }
            for (var i = 0; i < firstColumn.Count(); i++)
            {
                var current = firstColumn.ElementAt(i);
                var line = new List<int> { current.Id };
                foreach (var item in line)
                {
                    var last = pieces.First(p => p.top.l == current.top.r && p.btn.l == current.btn.r);
                    line.Add(last.Id);
                    // add line to result
                    if (last.top.l == -1) break;
                }
            }
            return result;
        }
    }
}
