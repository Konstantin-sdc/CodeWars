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

        [Fact()]
        public void PuzzleSolverTest()
        {
            var puzzle = new ((int, int), (int, int), int)[]
            {
                ((-1,5),(-1,-1),3),
                ((17,-1),(-1,-1),9),
                ((-1,4),(-1,5),8),
                ((4,11),(5,17),5),
                ((11,-1),(17,-1),2),
                ((-1,-1),(-1,4),7),
                ((5,17),(-1,-1),1),
                ((-1,-1),(11,-1),4),
                ((-1,-1),(4,11),6),
            };
            int[,] sol = new int[3, 3]
            {
                {7,6,4},
                {8,5,2},
                {3,1,9},
            };
            Assert.Equal(sol, Kata.PuzzleSolver(puzzle, 3, 3));
        }
    }
}