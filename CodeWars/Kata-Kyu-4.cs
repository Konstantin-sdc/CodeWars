using System.Collections.Generic;
using System.Linq;

namespace CodeWars {

  public static partial class Kata {

    /// <summary>Принимает массив целых чисел. Возвращает строку с диапазонами.</summary>
    /// <returns>Строка</returns>
    [KataType(LevelTypeEnum.Kyu, 4, "range-extraction")]
    public static string Extract(int[] args) {
      List<List<int>> gList = new List<List<int>>();
      for(int i = 0; i < args.Length; i++) {
        if(i==0||args[i]-args[i-1]!=1) {
          gList.Add(new List<int>());
        }
        gList.Last().Add(args[i]);
      }
      List<string> result = new List<string>();
      foreach(var item in gList) {
        if(item.Count < 3) {
          result.Add(string.Join(",", item));
        }
        else {
          int f = item.First();
          int l = item.Last();
          result.Add(string.Join("-", f, l));
        }
      }
      return string.Join(",", result);
    }

  }

}
