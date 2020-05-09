namespace CodeWars.Kata.Kyu.Esolangs.Tests
{
    using CodeWars.Kata.Kyu.L4;

    using System.Collections.Generic;

    using Xunit;

    public class PaintFuckTests
    {
        private IDictionary<(string code, int iterations, int width, int height), string> _testValues = new Dictionary<(string, int, int, int), string>()
        {
            {
                ("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 0, 6, 9),
                "000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000"
            },
            {
                ("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 7, 6, 9),
                "111100\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000\r\n000000"
            },
            {
                ("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 19, 6, 9),
                "111100\r\n000010\r\n000001\r\n000010\r\n000100\r\n000000\r\n000000\r\n000000\r\n000000"
            },
            {
                ("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 42, 6, 9),
                "111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000"
            },
            {
                ("*e*e*e*es*es*ws*ws*w*w*w*n*n*n*ssss*s*s*s*", 100, 6, 9),
                "111100\r\n100010\r\n100001\r\n100010\r\n111100\r\n100000\r\n100000\r\n100000\r\n100000"
            },
        };

        [Fact()]
        public void InterpretTest()
        {
            foreach (var item in _testValues)
            {
                var k = item.Key;
                var result = PaintFuck.Interpret(k.code, k.iterations, k.width, k.height);
                Assert.True(result == item.Value, "This test needs an implementation");
            }
        }
    }
}