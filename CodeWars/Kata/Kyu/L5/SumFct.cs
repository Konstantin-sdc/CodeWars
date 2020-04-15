﻿using System.Numerics;

namespace CodeWars.Kata.Kyu.L5 {

    class SumFct {

        /// <summary>Возвращает сумму периметров квадратов в ряду Фибоначи</summary>
        /// <param name="n"></param>
        /// <returns></returns>
        [KataType(LevelTypeEnum.Kyu, 5)]
        public static BigInteger Perimeter(BigInteger n) {
            BigInteger first = 0, second = 1, fibSum = first + second;
            for (int i = 2; i < n; i++) {
                BigInteger current = first + second;
                fibSum += current;
                first = second;
                second = current;
            }
            return fibSum * 4;
        }

    }

}