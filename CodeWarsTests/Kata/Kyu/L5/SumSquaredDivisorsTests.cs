using System.Collections.Generic;
using TestedClass = CodeWars.Kata.Kyu.L5.SumSquaredDivisors.SumSquaredDivisorsCaller;
using Xunit;
using System.Runtime.InteropServices;

namespace CodeWars.Kata.Kyu.L5.SumSquaredDivisorsTests {
    public class SumSquaredDivisorsTests {
        private readonly IDictionary<long[], string> _testValues;
        private readonly TestedClass _testedObject; 

        public SumSquaredDivisorsTests() {
            _testValues = new Dictionary<long[], string>() {
                {new long[2]{1,250}, "[[1, 1], [42, 2500], [246, 84100]]" },
                {new long[2]{42,250}, "[[42, 2500], [246, 84100]]" },
                {new long[2]{250,500}, "[[287, 84100]]" },
            };
            _testedObject = new TestedClass();
        }

        [Fact()]
        public void ListSquaredTest() {
            string a, b, c;
            var message = $@"
Input {a}. 
Expected == {b}. 
Actual == {b}
";
            foreach (var item in _testValues) {
                string result = _testedObject.ListSquared(item.Key[0], item.Key[1]);
                Assert.True(result == item.Value, message);
            }
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