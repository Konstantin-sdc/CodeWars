namespace CodeWars.Kata.Kyu.L4.Tests
{
    using System.Collections.Generic;
    using Xunit;
    using CodeWars.Kata.Kyu.L4;
    using System;

    public class KataTests
    {
        [Fact()]
        public void ExpandDependenciesTest_Examples()
        {
            var startValues = new Dictionary<string, string[]>()
            {
                ["A"] = new string[] { "B", "D" },
                ["B"] = new string[] { "C" },
                ["C"] = new string[] { "D" },
                ["D"] = new string[] { }
            };
            var correctResults = new Dictionary<string, string[]>()
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
            var startValues = new Dictionary<string, string[]>();
            var correctResults = new Dictionary<string, string[]>();
            Assert.Equal(correctResults, Kata.ExpandDependencies(startValues));
        }

        [Fact()]
        public void ExpandDependenciesTest_Circular()
        {
            var startFiles = new Dictionary<string, string[]>();
            startFiles["A"] = new string[] { "B" };
            startFiles["B"] = new string[] { "C" };
            startFiles["C"] = new string[] { "D" };
            startFiles["D"] = new string[] { "A" };
            Assert.Throws<InvalidOperationException>(delegate { Kata.ExpandDependencies(startFiles); });
        }
    }
}