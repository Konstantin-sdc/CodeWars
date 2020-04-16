namespace CodeWars.Kata.Kyu.L7 {
    internal static class Arge {
        /// <summary>Возвращает количество периодов, за которое начальное количество достигнет целевого</summary>
        /// <param name="p0">Начальное количество</param>
        /// <param name="percent">Периодическое изменение в процентах</param>
        /// <param name="aug">Периодическое абсолютное изменение</param>
        /// <param name="p">Целевое количество</param>
        /// <returns>Количество периодов</returns>
        [KataType(LevelTypes.Kyu, 7)]
        public static int NbYear(int p0, double percent, int aug, int p) {
            var pCount = 0;
            for (var pCur = p0; pCur < p; pCount++) {
                pCur = (int)((pCur * (1 + (0.01 * percent))) + aug);
            }
            return pCount;
        }
    }
}
