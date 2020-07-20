namespace CodeWars.Kata.Kyu.L4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StripCommentsSolution
    {
        /// <summary>Возвращает строку, в которой удалены комментарии и все символы после них.</summary>
        /// <param name="text">Входящая строка с комментариями.</param>
        /// <param name="cs">Массив обозначений комментариев.</param>
        /// <returns>Очищеная строка.</returns>
        [KataType(LevelTypes.Kyu, 4, "51c8e37cee245da6b40000bd")]
        public static string StripComments(string text, string[] cs)
        {
            var sep = "\n";
            var so = StringSplitOptions.None;
            var inpArr = text.Split(new string[] { sep }, so);
            var result = inpArr.Select(e => e.Split(cs, so)[0].TrimEnd());
            return string.Join(sep, result);
        }
    }
}
