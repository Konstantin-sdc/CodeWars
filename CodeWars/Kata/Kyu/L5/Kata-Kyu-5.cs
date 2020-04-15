using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;


namespace CodeWars {

    public static partial class KataClass {

        /// <summary>Возвращает два числа из натурального ряда, произведение которых равно сумме всех чисел этого ряда, исключая эти два числа</summary>
        /// <param name="n">Верхний предел ряда. Всегда > 0</param>
        /// <returns>Массив чисел</returns>
        [KataType(LevelTypeEnum.Kyu, 5)]
        public static List<long[]> RemovNb(long n) {
            List<long[]> result = new List<long[]>();
            // Вычислить сумму натурального ряда от 1 до n
            long sum;
            checked {
                sum = (n + 1) * n / 2;
            }
            // Минимальный первый элемент
            long firstMin = (sum - 2 * n + 1) / n;
            // Максимальный первый элемент
            long firstMax = (sum - 2 * firstMin - 1) / firstMin;
            // Второй элемент
            long searchRange = firstMax - firstMin;
            for(long i = firstMin; i <= firstMax; i++) {
                long a = sum - i;
                long b = i + 1;
                if(a % b > 0) {
                    continue;
                }

                result.Add(new long[2] { i, a / b });
            }
            return result;
        }

        /// <summary>Возвращает сумму периметров квадратов в ряду Фибоначи</summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [KataType(LevelTypeEnum.Kyu, 5)]
        public static BigInteger Perimeter(BigInteger n) {
            BigInteger first = 0, second = 1, fibSum = first + second;
            for(int i = 2; i < n; i++) {
                BigInteger current = first + second;
                fibSum += current;
                first = second;
                second = current;
            }
            return fibSum * 4;
        }

        /// <summary>Интерпретатор</summary>
        /// <param name="code">Код Paintfuck, который должен быть выполнен, передается как строка. </param>
        /// <param name="iterations"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        [KataType(LevelTypeEnum.Kyu, 5)]
        public static string Interpret(string code, int iterations, int width, int height) {
            // Правила
            // n - Переместить указатель данных на север(вверх)
            // e - Переместить указатель данных на восток(справа)
            // s - Переместить указатель данных на юг(вниз)
            // w - Переместить указатель данных на запад(слева)
            // * - Переверните бит в текущей ячейке(то же, что и в Smallfuck)
            // [- Переход мимо соответствия,] если бит под текущим указателем 0(тот же, что и в Smallfuck)
            // ]- Вернитесь к совпадению[(если бит под текущим указателем отличен от нуля) (то же, что и в Smallfuck)

            // Любой символ, не из вышеперечисленных должен игнорироваться

            return "";
        }

        /// <summary>Кодовая строка</summary>
        private static string _codeString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        /// <summary>
        /// Возвращает результат base64 кодирования исходной строки <paramref name="s"/> с использованием UTF-8
        /// </summary>
        /// <param name="s">Исходная строка</param>
        /// <returns>Результат</returns>
        [KataType(LevelTypeEnum.Kyu, 5)]
        public static string ToBase64(string s) {
            // Преобразовать строку в массив байтов
            // Преобразовать массив байт в массив бит
            // Сгруппировать биты в группы по 6
            List<string> bitGroups = BitGroups(s, 8, 6);
            // Каждую группу бит перевести в число десятичного формата
            // Заменить такое число на знак, расположенный по тому-же интексу в кодовой строке
            // Добавить недостающие знаки "=" в конец строки
            IEnumerable<int> indexes = bitGroups.Select(b => Convert.ToInt32(b, 2));
            IEnumerable<char> chars = indexes.Select(b => _codeString[b]);
            int rmdr = string.Join("", bitGroups).Length % 3;
            int adsCount = (rmdr == 0) ? 0 : (3 - rmdr);
            return string.Join("", chars) + new string('=', adsCount);
        }

        /// <summary>
        /// Возвращает результат base64 декодирования исходной последовательности <paramref name="s"/> с использованием UTF-8
        /// </summary>
        /// <param name="s">Исходная последовательность</param>
        /// <returns>Результат</returns>
        [KataType(LevelTypeEnum.Kyu, 5)]
        public static string FromBase64(string s) {
            // Убрать знаки "=" из строки и прочие, кого нет в кодовой строке
            s = string.Join("", s.Where(c => _codeString.Contains(c)));
            // Заменить знаки на их индексы в кодовой строке
            // Каждый индекс заменить на группу бит (м.б. с дополнением до 6)
            // Перегруппировать биты по 8
            List<string> bitGroups = BitGroups(s, 6, 8);
            // Перевести биты в символы
            byte[] bytes = bitGroups.Select(b => Convert.ToByte(b, 2)).ToArray();
            return Encoding.UTF8.GetString(bytes);
        }

        private static List<string> BitGroups(string s, int oldSize, int newSize) {
            IEnumerable<int> indexes = s.Select(c => _codeString.IndexOf(c));
            IEnumerable<string> bitList = indexes.Select(c => Convert.ToString(c, 2).PadLeft(oldSize, '0'));
            string bitString = string.Join("", bitList);
            List<string> bitGroups = new List<string>();
            for(int i = 0; i < bitString.Length; i += newSize) {
                string subS = bitString.Substring(i);
                int limit = newSize - 1;
                string bitG = string.Join("", subS.Where((c, index) => index <= limit));
                bitGroups.Add(bitG);
            }
            return bitGroups;
        }

        /// <summary>
        /// <para>Умножает число на последовательность,</para>
        /// <para>затем на последовательность результатов.</para>
        /// <para>И так далее, до превышения лимита</para>
        /// </summary>
        /// <param name="a">Число</param>
        /// <param name="sequence">Входящая коллекция</param>
        /// <param name="limit">Лимит</param>
        /// <returns>Коллекция результатов, не превышающих лимит</returns>
        public static IEnumerable<long> Multiplex(long a, IEnumerable<long> sequence, long limit) {
            IEnumerable<long> sq = sequence.OrderBy(e => e);
            if(a == 0 || a == 1) {
                return sq;
            }
            if(a * sq.ElementAt(0) > limit) {
                return sq;
            }
            List<long> mult = new List<long>(sequence.Count());
            for(int i = 0; i < sequence.Count(); i++) {
                long b = sq.ElementAt(i);
                long r = a * b;
                if(r > limit) {
                    break;
                }
                mult.Add(r);
            }
            return mult.Concat(Multiplex(a, mult, limit));
        }

    }

}

