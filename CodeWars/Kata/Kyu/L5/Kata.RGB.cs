using System;
using System.Text;

namespace CodeWars.Kata.Kyu.L5 {
    public static partial class KataClass {
        /// <summary>Возвращает 16-ричное представление цвета на основе RGB цветов</summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <returns>16-ричное представление</returns>
        public static string RGB(int r, int g, int b) {
            var result = "";
            foreach (var i in new int[3] { r, g, b }) {
                result += Math.Max(0, Math.Min(i, 255)).ToString("X2", CodeWars.KataBase.Invariant);
            }
            return result;
        }
    }
}
