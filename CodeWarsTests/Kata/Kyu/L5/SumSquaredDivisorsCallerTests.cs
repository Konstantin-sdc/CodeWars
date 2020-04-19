using System.Collections.Generic;
using TestedClass = CodeWars.Kata.Kyu.L5.SumSquaredDivisors.SumSquaredDivisorsCaller;
using Xunit;

namespace CodeWars.Kata.Kyu.L5.SumSquaredDivisorsTests {
    public class SumSquaredDivisorsCallerTests {
        private readonly IDictionary<long[], string> _testValues;
        private TestedClass _testedObject; 

        public SumSquaredDivisorsCallerTests() {
            _testValues = new Dictionary<long[], string>() {
                {new long[2]{1,250}, "[[1, 1], [42, 2500], [246, 84100]]" },
                {new long[2]{42,250}, "[[42, 2500], [246, 84100]]" },
                {new long[2]{250,500}, "[[287, 84100]]" },
            };
            _testedObject = new TestedClass();
        }

        [Fact()]
        public void ListSquaredTest() {
            foreach (var item in _testValues) {
                _testedObject.ListSquared(item.Key[0], item.Key[1]);
            }
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void SquaredListTest() {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void IsIntegerSquaredTest() {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void SimpeDividersTest() {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void LimitFactorialTest() {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetCompositionTest() {
            Assert.True(false, "This test needs an implementation");
        }
    }
}