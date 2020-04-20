namespace CodeWars.Kata.Kyu.L7 {
    public static partial class KataClass {
        /// <summary>Маскирует символом # все символы входящей строки, кроме последних четырёх</summary>
        /// <param name="cc">Строка,которую следует замаскировать</param>
        /// <returns>Замаскированная строка</returns>
        [KataType(LevelTypes.Kyu, 7)]
        public static string Maskify(string cc) {
            if (cc is null) {
                throw new System.ArgumentNullException(nameof(cc));
            }

            var startIndex = cc.Length > 4 ? cc.Length - 4 : 0;
            return new string('#', startIndex) + cc.Substring(startIndex);
        }
    }
}
