namespace CodeWars.Kata.Kyu.L6
{
    public static class ASum
    {
        /// <summary>
        /// <para>Возвращает количество кубов, нужное для достижения объёма = m.</para>
        /// <para>Кубы начинаются с размеров 1х1х1.</para>
        /// <para>Сторона каждого последующего куба больше стороны предыдущего на 1.</para>
        /// </summary>
        /// <param name="m">Нужный объём</param>
        /// <returns>Количество кубов или -1, если объём не может уместить количество.</returns>
        [KataType(LevelTypes.Kyu, 6)]
        public static long FindNb(params long[] m)
        {
            long s = 1, v = 0, count = 0;
            for (; v < m[0]; s++, count++)
            {
                v += s * s * s;
            }
            return (m[0] == v) ? count : -1;
        }
    }
}
