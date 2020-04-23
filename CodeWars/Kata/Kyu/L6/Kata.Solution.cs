namespace CodeWars.Kata.Kyu.L6
{
    using System.Linq;

    public static partial class KataClass
    {
        /// <summary>Возвращает сумму всех чисел в натуральном ряду, которые делятся на 3 или на 5</summary>
        /// <param name="value">Верхний предел ряда</param>
        /// <returns>Сумма</returns>
        [KataType(LevelTypes.Kyu, 6)]
        public static int Solution(int value)
        {
            try { return Enumerable.Range(0, value).Where(d => d % 3 == 0 || d % 5 == 0).Sum(); }
#pragma warning disable CA1031 // Не перехватывать исключения общих типов
            catch { return int.MaxValue; }
#pragma warning restore CA1031 // Не перехватывать исключения общих типов
        }
    }
}
