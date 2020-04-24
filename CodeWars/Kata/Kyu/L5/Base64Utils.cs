namespace CodeWars.Kata.Kyu.L5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Base64Utils
    {
        /// <summary>Кодовая строка.</summary>
        private const string _codeString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        /// <summary>
        /// Возвращает результат base64 кодирования исходной строки <paramref name="s"/> с использованием UTF-8
        /// </summary>
        /// <param name="s">Исходная строка</param>
        /// <returns>Результат</returns>
        [KataType(LevelTypes.Kyu, 5)]
        public static string ToBase64(string s)
        {
            // Преобразовать строку в массив байтов
            // Преобразовать массив байт в массив бит
            // Сгруппировать биты в группы по 6
            var bitGroups = BitGroups(s, 8, 6);
            // Каждую группу бит перевести в число десятичного формата
            // Заменить такое число на знак, расположенный по тому-же интексу в кодовой строке
            // Добавить недостающие знаки "=" в конец строки
            var indexes = bitGroups.Select(b => Convert.ToInt32(b, 2));
            var chars = indexes.Select(b => _codeString[b]);
            var rmdr = string.Concat(bitGroups).Length % 3;
            var adsCount = (rmdr == 0) ? 0 : (3 - rmdr);
            return string.Join("", chars) + new string('=', adsCount);
        }

        /// <summary>
        /// Возвращает результат base64 декодирования исходной последовательности <paramref name="s"/> с использованием UTF-8
        /// </summary>
        /// <param name="s">Исходная последовательность</param>
        /// <returns>Результат</returns>
        [KataType(LevelTypes.Kyu, 5)]
        public static string FromBase64(string s)
        {
            // Убрать знаки "=" из строки и прочие, кого нет в кодовой строке
            s = string.Join("", s.Where(c => _codeString.Contains(c)));
            // Заменить знаки на их индексы в кодовой строке
            // Каждый индекс заменить на группу бит (м.б. с дополнением до 6)
            // Перегруппировать биты по 8
            var bitGroups = BitGroups(s, 6, 8);
            // Перевести биты в символы
            var bytes = bitGroups.Select(b => Convert.ToByte(b, 2)).ToArray();
            return Encoding.UTF8.GetString(bytes);
        }

        private static List<string> BitGroups(string s, int oldSize, int newSize)
        {
            var indexes = s.Select(c => _codeString.IndexOf(c));
            var bitList = indexes.Select(c => Convert.ToString(c, 2).PadLeft(oldSize, '0'));
            var bitString = string.Concat(bitList);
            var bitGroups = new List<string>();
            for (var i = 0; i < bitString.Length; i += newSize)
            {
                var subS = bitString.Substring(i);
                var limit = newSize - 1;
                var bitG = string.Join("", subS.Where(index => index <= limit));
                bitGroups.Add(bitG);
            }
            return bitGroups;
        }
    }
}
