namespace CodeWars.Kata.Kyu.Esolangs.Tests
{
    using System.Collections.Generic;

    using Xunit;

    public class SmallFuckTests
    {
        private static readonly Dictionary<(string code, string source), string> _testValues = new Dictionary<(string, string), string>()
        {
            {("*", "00101100"), "10101100" },
            {(">*>*", "00101100"), "01001100" },
            {("*>*>*>*>*>*>*>*", "00101100"), "11010011" },
            {("*>*>>*>>>*>*", "00101100"), "11111111" },
            {(">>>>>*<*<<*", "00101100"), "00000000" },
        };


        [Fact()]
        public void InterpreterTest()
        {
            foreach (var item in _testValues)
            {
                var cd = item.Key.code;
                var src = item.Key.source;
                Assert.True(SmallFuck.Interpreter(cd, src) == item.Value);
            }
        }
    }
}