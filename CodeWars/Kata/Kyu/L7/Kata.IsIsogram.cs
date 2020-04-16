using System.Linq;

namespace CodeWars.Kata.Kyu.L7 {

    public static partial class Kata {

        /// <summary>Указывает является ли проверяемая строка изограммой</summary>
        /// <param name="s">Проверяемая строка</param>
        /// <returns><see cref="true"/> если является</returns>
        [KataType(LevelTypes.Kyu, 7)]
        public static bool IsIsogram(string s) {
            return s.Length == s.ToLower().Distinct().Count();
        }

    }

}
