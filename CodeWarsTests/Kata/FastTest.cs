using Xunit;
namespace CodeWarsTests.Kata {
    public class FastTest {
        [Fact()]
        public void RemainderTest() {
            int result = 2 % 5;
            Assert.True(true, result.ToString());
        }
    }
}
