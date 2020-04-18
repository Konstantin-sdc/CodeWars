using Xunit;
using Moq;
namespace CodeWars.Kata.Kyu.L5.Tests {
    public class SumSquaredDivisorsTests {
        [Fact()]
        public void ListSquaredTest() {
            Mock<SumSquaredDivisors> mock = new Mock<SumSquaredDivisors>();
            mock.Setup(s => s.ListSquared_Call(1, 2)).Returns("");
        }

        [Fact()]
        public void GetDividersTest() {

        }

        [Fact()]
        public void ListSquaredCallerTest() {

        }

        [Fact()]
        public void SquaredListCallerTest() {

        }

        [Fact()]
        public void IsIntegerSquaredCallerTest() {

        }

        [Fact()]
        public void SimpeDividersCallerTest() {

        }

        [Fact()]
        public void LimitFactorialCallerTest() {

        }

        [Fact()]
        public void GetCompositionCallerTest() {

        }
    }
}