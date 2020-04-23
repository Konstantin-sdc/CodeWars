namespace CodeWars.Kata.Kyu.L6.Tests
{
    using System;
    using Xunit;

    public class SumFractionsTests
    {
        private readonly int[,] _a = new int[,] { { 1, 2 }, { 2, 9 }, { 3, 18 }, { 4, 24 }, { 6, 48 } };
        private readonly string _expected = "[85, 72]";

        [Fact()]
        public void SumFractsTest()
        {
            var result = SumFractions.SumFracts(_a);
            Assert.True(result == _expected, "This test needs an implementation");
        }
    }
}