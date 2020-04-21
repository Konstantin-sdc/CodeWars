using System.Linq;

using Res = CodeWars.Properties.Resources;

namespace CodeWars.Kata.Kyu.L7
{
    public static partial class KataClass
    {
        /// <summary>Указывает является ли проверяемая строка изограммой</summary>
        /// <param name="s">Проверяемая строка</param>
        /// <returns><see cref="true"/> если является</returns>
        [KataType(LevelTypes.Kyu, 7)]
        public static bool IsIsogram(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new System.ArgumentException(Res.IsNullOrEmpty, nameof(s));
            }

            return s.Length == s.ToLower(KataBase.Invariant).Distinct().Count();
        }
    }
}
