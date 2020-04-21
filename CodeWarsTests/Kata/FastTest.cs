using Xunit;
namespace CodeWarsTests.Kata {
    public class FastTest {
        [Fact()]
        public void RemainderTest() {
            int result = 2 % 5; // 2
            Assert.True(false, "RESULT = " + result.ToString());
        }

        [Fact()]
        public void EmptyCountTest() {
            int[] array = new int[0];
            Assert.True(false, "RESULT = " + array[0]);
        }
    }
}