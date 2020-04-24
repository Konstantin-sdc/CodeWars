namespace CodeWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static partial class KataBase
    {
        /// <summary>
        /// <para>Умножает число на последовательность,</para>
        /// <para>затем на последовательность результатов.</para>
        /// <para>И так далее, до превышения лимита</para>
        /// </summary>
        /// <param name="a">Число</param>
        /// <param name="sequence">Входящая коллекция</param>
        /// <param name="limit">Лимит</param>
        /// <returns>Коллекция результатов, не превышающих лимит</returns>
        public static IEnumerable<long> Multiplex(long a, IEnumerable<long> sequence, long limit)
        {
            IEnumerable<long> sq = sequence.OrderBy(e => e);
            if (a == 0 || a == 1)
            {
                return sq;
            }
            if (a * sq.ElementAt(0) > limit)
            {
                return sq;
            }
            var mult = new List<long>(sequence.Count());
            for (var i = 0; i < sequence.Count(); i++)
            {
                var b = sq.ElementAt(i);
                var r = a * b;
                if (r > limit)
                {
                    break;
                }
                mult.Add(r);
            }
            return mult.Concat(Multiplex(a, mult, limit));
        }
    }
}

