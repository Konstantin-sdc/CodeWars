namespace CodeWars.Kata.Kyu.L5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Base64Utils
    {
        /// <summary>Кодовая строка.</summary>
        public const string CodeString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        /// <summary>
        /// Возвращает результат base64 кодирования исходной строки <paramref name="s"/> с использованием UTF-8
        /// </summary>
        /// <param name="s">Исходная строка</param>
        /// <returns>Результат</returns>
        [KataType(LevelTypes.Kyu, 5, "5270f22f862516c686000161")]
        public static string ToBase64(string s)
        {
            var byteArray = Encoding.UTF8.GetBytes(s);
            var bytes = ByteGroups(byteArray.ToList(), 8, 6);
            var chars = bytes.Select(e => CodeString[e]).ToList();
            var toFour = (chars.Count % 4 == 0) ? 0 : 4 - (chars.Count % 4);
            var result = string.Concat(chars);
            return (toFour == 0) ? result : result + new string('=', toFour);
        }

        /// <summary>
        /// Возвращает результат base64 декодирования исходной последовательности <paramref name="s"/> с использованием UTF-8
        /// </summary>
        /// <param name="s">Исходная последовательность</param>
        /// <returns>Результат</returns>
        [KataType(LevelTypes.Kyu, 5, "5270f22f862516c686000161")]
        public static string FromBase64(string s)
        {
            s = string.Concat(s.Where(c => CodeString.Contains(c)));
            var bytes = s.Select(c => (byte)CodeString.IndexOf(c));
            bytes = ByteGroups(bytes, 6, 8);
            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        /// <summary>Конверсия байтов через перегруппировку битов.</summary>
        /// <param name="bytes">Входящая коллекция байтов.</param>
        /// <param name="oldSize">Начальный размер групп.</param>
        /// <param name="newSize">Конечный размер групп.</param>
        /// <returns>Преобразованная коллекция байтов.</returns>
        private static IEnumerable<byte> ByteGroups(IEnumerable<byte> bytes, int oldSize, int newSize)
        {
            var bitItems = bytes.Select(e => Convert.ToString(e, 2));
            bitItems = bitItems.Select(e => e.PadLeft(oldSize, '0'));
            var oneString = string.Concat(bitItems);
            var l = oneString.Length;
            var rmd = l % newSize;
            if (oldSize > newSize)
            {
                var toAdd = (rmd == 0) ? 0 : newSize - rmd;
                oneString += new string('0', toAdd);
            }
            if (oldSize < newSize)
                oneString = oneString.Substring(0, l - rmd);
            var sIndex = 0;
            var bitGroups = oneString.GroupBy(e => oneString.IndexOf(e, sIndex++) / newSize);
            var newBitStrings = bitGroups.Select(e => string.Concat(e));
            var result = newBitStrings.Select(e => Convert.ToByte(e, 2));
            return result;
        }

    }
}
