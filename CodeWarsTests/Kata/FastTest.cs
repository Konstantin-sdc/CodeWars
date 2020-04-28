namespace CodeWarsTests.Kata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using CodeWars.Kata.Kyu.L5;
    public class FastTest
    {
        [Fact()]
        public void RemainderTest()
        {
            int result = 2 % 5; // 2
            Assert.True(false, "RESULT = " + result.ToString());
        }

        [Fact()]
        public void EmptyCountTest()
        {
            int[] array = new int[0];
            Assert.True(false, "RESULT = " + array[0]);
        }

        [Fact()]
        public void GroupingTest()
        {
            var q = new List<string>()
            {
                "w","e","r", "t","y","u", "i","o","p"
            };
            var groupSize = 4;
            var groups = q.GroupBy(e => q.IndexOf(e) / groupSize);
            var result = groups.ToList();
        }

        [Fact()]
        public void ConvertTest()
        {
            // 0001 01 F если Man
            var actual = "B";
            var expected = "E";
            var actualPos = Base64Utils.CodeString.IndexOf(actual);
            var expectPos = Base64Utils.CodeString.IndexOf(expected);
            var bitsActual = Convert.ToString(actualPos, 2);
            var bitsExpect = Convert.ToString(expectPos, 2);

            byte q = 77;
            int qq = 77;
            var w = Convert.ToString(q, 2);
            var ww = Convert.ToString(qq, 2);
        }

    }
}