namespace CodeWars {
    using System.Globalization;
    using System.Linq;

    /// <summary>Класс для тренировок</summary>
    public static partial class KataClass {
        /// <summary>Инвариантная культура.</summary>
        public static readonly CultureInfo Invariant = CultureInfo.InvariantCulture;
        public static int[] MinMax(int[] lst) => new int[] { lst.Min(), lst.Max() };
    }
}
