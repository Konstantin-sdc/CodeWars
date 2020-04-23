namespace CodeWars.Kata.Kyu.L5.SumSquaredDivisorsTests
{
    using System.Collections.Generic;

    using Xunit;

    using TestedClass = CodeWars.Kata.Kyu.L5.SumSquaredDivisors.SumSquaredDivisorsCaller;

    public class SumSquaredDivisorsTests
    {
        private readonly IDictionary<long[], string> _testValues;

        public SumSquaredDivisorsTests()
        {
            _testValues = new Dictionary<long[], string>() {
                {new long[2]{1,250}, "[[1, 1], [42, 2500], [246, 84100]]" },
                {new long[2]{42,250}, "[[42, 2500], [246, 84100]]" },
                {new long[2]{250,500}, "[[287, 84100]]" },
            };
        }

        [Fact()]
        public void ListSquaredTest()
        {
            foreach (var item in _testValues)
            {
                var result = TestedClass.ListSquared(item.Key[0], item.Key[1]);
                var message = $@"
Input {item.Key}. 
Expected == {item.Value}. 
Actual == {result}
";
                Assert.True(result == item.Value, message);
            }
        }

        [Fact()]
        public void SquaredListTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void IsIntegerSquaredTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void SimpeDividersTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void LimitFactorialTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetCompositionTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}