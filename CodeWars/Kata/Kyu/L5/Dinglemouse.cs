using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeWars.Kata.Kyu.L5 {
    public static class Dinglemouse {
        private static readonly Dictionary<string, string> _soundDict = new Dictionary<string, string>() {
            { "(?!^)[HW]", "" },
            { "[BFPV]", "1" },
            { "[CGJKQSXZ]", "2" },
            { "[DT]", "3" },
            { "[L]", "4" },
            { "[MN]", "5" },
            { "[R]", "6" },
            { @"(\d+)\1", "$1"},
            { @"(?!^)[AEIOUY]", "" },
            { @"$", "000" }
        };

        /// <summary>Преобразует слова английского языка по алгоритму SOUNDEX</summary>
        /// <param name="names">Строка из слов, разделённых пробелом</param>
        /// <returns>SOUNDEX-коды группы слов</returns>
        [KataType(LevelTypes.Kyu, 5)]
        public static string Soundex(string names) {
            var result = names.Split(' ');
            for (var i = 0; i < result.Length; i++) {
                result[i] = SoundexSingle(result[i]);
            }
            return string.Join(" ", result);
        }

        private static string SoundexSingle(string word) {
            var result = word.ToUpper();
            var fC = result[0];
            foreach (KeyValuePair<string, string> item in _soundDict) {
                result = Regex.Replace(result, item.Key, item.Value);
            }
            result = fC + result.Substring(1);
            return result.Substring(0, 4);
        }
    }
}
