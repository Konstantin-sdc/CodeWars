using System;
using System.Collections.Generic;

namespace CodeWars {
  public partial class Kata {

    /// <summary>Интерактивное создание класса</summary>
    /// <param name="className">Имя класса</param>
    /// <param name="properties">Свойства класса (имя, тип)</param>
    /// <param name="actualType"></param>
    /// <returns>false, если класс уже существует в этой сборке</returns>
    [KataType(LevelTypeEnum.Kyu, 3, "589394ae1a880832e2000092")]
    public static bool DefineClass(string className, Dictionary<string, Type> properties, ref Type actualType) {
      return true;
    }

  }

}

