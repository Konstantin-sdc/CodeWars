using System;
using System.Reflection;

namespace CodeWars {

  [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
  internal sealed class KataLevelAttribute : Attribute {
    // See the attribute guidelines at 
    //  http://go.microsoft.com/fwlink/?LinkId=85236

    // This is a positional argument
    public KataLevelAttribute(LevelTypeEnum levelType, int levelValue) {
      LevelType = levelType;
      LevelValue = levelValue;
    }
    /// <summary>Значение уровня ката</summary>
    public int LevelValue { get; private set; }
    /// <summary>Тип уровня ката</summary>
    public LevelTypeEnum LevelType { get; private set; }

  }
  /// <summary>Типы уровней ката</summary>
  internal enum LevelTypeEnum {
    /// <summary>Кю</summary>
    Kyu,
    /// <summary>Дан</summary>
    Dan
  };


}
