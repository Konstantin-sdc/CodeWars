using System.Linq;

namespace CodeWars.Kata.Kyu.L7 {
    public static partial class Kata {
        /// <summary>Указывает является ли проверяемая строка изограммой</summary>
        /// <param name="s">Проверяемая строка</param>
        /// <returns><see cref="true"/> если является</returns>
        [KataType(LevelTypes.Kyu, 7)]
        public static bool IsIsogram(string s) {
            if (string.IsNullOrEmpty(s)) {
                throw new System.ArgumentException("message", nameof(s));
            }

            return s.Length == s.ToLower(KataClass.Invariant).Distinct().Count();
        }
    }
}
