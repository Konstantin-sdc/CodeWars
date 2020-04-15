﻿using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata.Kyu.L7 {

    public static partial class Kata {

        /// <summary>Возвращает строки, длина которых = 4</summary>
        /// <param name="n">Массив строк для проверки</param>
        /// <returns>Коллекция строк</returns>
        [KataType(LevelTypeEnum.Kyu, 7)]
        public static IEnumerable<string> FriendOrFoe(string[] n) => n.Where(s => s.Length == 4);

    }

}