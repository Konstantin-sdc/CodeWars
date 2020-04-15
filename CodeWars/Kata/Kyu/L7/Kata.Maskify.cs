namespace CodeWars.Kata.Kyu.L7 {

    public partial class Kata {

        /// <summary>Маскирует символом # все символы входящей строки, кроме последних четырёх</summary>
        /// <param name="cc">Строка,которую следует замаскировать</param>
        /// <returns>Замаскированная строка</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static string Maskify(string cc) {
            var startIndex = cc.Length > 4 ? cc.Length - 4 : 0;
            return new string('#', startIndex) + cc.Substring(startIndex);
        }

    }

}
