using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars {
  public static partial class Kata {

    /// <summary>Принимает массив целых чисел. Возвращает строку с диапазонами.</summary>
    /// <param name="args">Массив</param>
    /// <returns>Строка</returns>
    [KataType(LevelTypeEnum.Kyu, 4, "range-extraction")]
    public static string Extract(int[] args) {
      // input {-6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20};
      // returns "-6,-3-1,3-5,7-11,14,15,17-20"
      // В диапазон объединять минимум 3 числа
      List<List<int>> gList = new List<List<int>>();
      for(int i = 0; i < args.Length; i++) {
        if(i==0||args[i]-args[i-1]!=1) {
          gList.Add(new List<int>());
        }
        gList.Last().Add(args[i]);
      }
      string result = "";
      foreach(var item in gList) {
        if(item.Count < 3) {
          result += string.Join(",", item);
        }
        else {
          result += item.First() + "-" + item.Last();
        }
      }
      return result;  //TODO
    }

  }
}
