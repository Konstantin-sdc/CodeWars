namespace CodeWarsTests
{
    using CodeWars;
    using System.Collections.Generic;
    using System.Linq;

    using Xunit;

    public class KataBaseTests
    {
        private IDictionary<int[], int> _MaxComDividers = new Dictionary<int[], int>()
        {
            { new int[2]{ 1, 2 }, 1 },
            { new int[2]{ 1, 3 }, 1 },
            { new int[2]{ 1, 4 }, 1 },
            { new int[2]{ 1, 4 }, 1 },
            { new int[2]{ 5, 3 }, 1 },
            { new int[2]{ 3, 18 }, 3 },
            { new int[2]{ 4, 24 }, 4 },
            { new int[2]{ 6, 48 }, 6 },
        };

        /// <summary>Test for <see cref="KataBase.SimpeDividers(long)"/></summary>
        [Fact()]
        public void SimpeDividersTest()
        {
            var result = KataBase.SimpeDividers(24);
            Assert.True(false, "RESULT = " + result);
        }

        /// <summary>Test method for <see cref="KataBase.GetMaxCommonDivider(long, long)"/></summary>
        [Fact()]
        public void GetMaxCommonDividerTest()
        {
            var message = "INPUT = {0} RESULT = {1}";
            foreach (var item in _MaxComDividers)
            {
                var input = string.Join(", ", item.Key);
                var result = KataBase.GetMaxCommonDivider(item.Key[0], item.Key[1]);
                Assert.True(result == item.Value, string.Format(message, input, result));
            }
        }
    }
}