using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars {
  public static partial class Kata {

    /// <summary>Возвращает 16-ричное представление цвета на основе RGB цветов</summary>
    /// <param name="r">Red</param>
    /// <param name="g">Green</param>
    /// <param name="b">Blue</param>
    /// <returns>16-ричное представление</returns>
    public static string HEXfromRGB(int r, int g, int b) {
      string result = "";
      foreach(int i in new int[3] { r, g, b }) {
        result += Math.Max(0, Math.Min(i, 255)).ToString("X2");
      }
      return result;
    }
  }
}
