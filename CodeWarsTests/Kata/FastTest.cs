namespace CodeWarsTests.Kata
{
    using CodeWars.Kata.Kyu.L5;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    public class FastTest
    {
        [Fact()]
        public void RemainderTest()
        {
            int a = 0 % 5;
            int b = -1 % 5;
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

        [Fact()]
        public void BitArrayTest()
        {
            var testBitArray = new BitArray[3];
            for (int i = 0; i < testBitArray.Length; i++)
                testBitArray[i] = new BitArray(2, false);
            testBitArray[1][1] = true;
        }

        [Fact()]
        public void BoolArrayTest()
        {
            var testBoolArray = new bool[3, 4];
            testBoolArray[1, 1] = true;
            testBoolArray[1, 3] = true;
            var height = testBoolArray.GetLength(0);
            var width = testBoolArray.GetLength(1);
            var stringArray = new string[height];
            for (var i = 0; i < stringArray.Length; i++)
            {
                for (var k = 0; k < width; k++)
                    stringArray[i] += Convert.ToInt32(testBoolArray[i, k]);
            }
        }

        [Fact()]
        public void CharBoolTest()
        {
            var b = true;
            var i = Convert.ToInt32(b);
            var c = Convert.ToChar(i);
            var c2 = (char)i;
            var c3 = i.ToString();            
        }
    }
}