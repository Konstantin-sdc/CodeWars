using System;

namespace CodeWars {
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    internal sealed class KataTypeAttribute : Attribute {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        // This is a positional argument
        public KataTypeAttribute(LevelTypes levelType, int levelValue, string kataId = "") {
            LevelType = levelType;
            LevelValue = levelValue;
            var link = "https://www.codewars.com/kata/" + kataId + "/train/csharp";
            KataLink = new Uri(link);
        }
        /// <summary>Значение уровня ката</summary>
        public int LevelValue { get; }
        /// <summary>Тип уровня ката</summary>
        public LevelTypes LevelType { get; }
        public Uri KataLink;
    }
    /// <summary>Типы уровней ката</summary>
    internal enum LevelTypes {
        /// <summary>Кю</summary>
        Kyu,
        /// <summary>Дан</summary>
        Dan
    };
}
