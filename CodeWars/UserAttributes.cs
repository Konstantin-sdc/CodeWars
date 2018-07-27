using System;
using System.Reflection;

namespace CodeWars {

  [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
  internal sealed class KataTypeAttribute : Attribute {
    // See the attribute guidelines at 
    //  http://go.microsoft.com/fwlink/?LinkId=85236

    // This is a positional argument
    public KataTypeAttribute(LevelTypeEnum levelType, int levelValue, string kataId) {
      LevelType = levelType;
      LevelValue = levelValue;
      string link = @"https://www.codewars.com/kata/"+ kataId + @"/train/csharp";
      KataLink = new Uri(link);
    }
    /// <summary>Значение уровня ката</summary>
    public int LevelValue { get; private set; }
    /// <summary>Тип уровня ката</summary>
    public LevelTypeEnum LevelType { get; private set; }
    public Uri KataLink;

  }
  /// <summary>Типы уровней ката</summary>
  internal enum LevelTypeEnum {
    /// <summary>Кю</summary>
    Kyu,
    /// <summary>Дан</summary>
    Dan
  };


}
