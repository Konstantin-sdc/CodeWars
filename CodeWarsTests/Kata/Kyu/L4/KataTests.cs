namespace CodeWars.Kata.Kyu.L4.Tests
{
    using CodeWars.Kata.Kyu.L4;

    using System;
    using System.Collections.Generic;

    using Xunit;

    using TestDict = System.Collections.Generic.Dictionary<string, string[]>;

    public class KataTests
    {
        [Fact()]
        public void ExpandDependenciesTest_Examples()
        {
            var startValues = new TestDict()
            {
                ["A"] = new string[] { "B", "D" },
                ["B"] = new string[] { "C" },
                ["C"] = new string[] { "D" },
                ["D"] = new string[] { }
            };
            var correctResults = new TestDict()
            {
                ["A"] = new string[] { "B", "C", "D" },
                ["B"] = new string[] { "C", "D" },
                ["C"] = new string[] { "D" },
                ["D"] = new string[] { }
            };
            Assert.Equal(correctResults, Kata.ExpandDependencies(startValues));
        }

        [Fact()]
        public void ExpandDependenciesTest_Empties()
        {
            var startValues = new TestDict();
            var correctResults = new TestDict();
            Assert.Equal(correctResults, Kata.ExpandDependencies(startValues));
        }

        [Fact()]
        public void ExpandDependenciesTest_Circular()
        {
            var startItems0 = new TestDict
            {
                ["A"] = new string[] { "B" },
                ["B"] = new string[] { "C" },
                ["C"] = new string[] { "D" },
                ["D"] = new string[] { "A" }
            };
            var startItems1 = new TestDict
            {
                ["a"] = new string[] { "b" },
                ["b"] = new string[] { "c" },
                ["c"] = new string[] { "d" },
                ["d"] = new string[] { "b" },
            };
            var startItems = new List<TestDict>()
            {
                //startItems0,
                startItems1
            };
            foreach (var item in startItems)
                Assert.Throws<InvalidOperationException>(delegate { Kata.ExpandDependencies(item); });
        }

        [Fact()]
        public void GetCircularTest()
        {
            var startItems0 = new TestDict
            {
                ["A"] = new string[] { "B" },
                ["B"] = new string[] { "C" },
                ["C"] = new string[] { "D" },
                ["D"] = new string[] { "A" }
            };
            var result = Kata.GetCircular(startItems0);
        }
    }
}