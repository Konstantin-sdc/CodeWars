namespace CodeWars.Kata.Kyu.L5.Tests
{
    using System.Collections.Generic;

    using Xunit;
    public class Base64UtilsTests
    {
        private readonly IDictionary<string, string> _testFrom64 = new Dictionary<string, string>()
        {
            { "dGhpcyBpcyBhIHN0cmluZyEh", "this is a string!!" },
            { "ZWU=", "ee" },
            { "ZQ==", "e" },
            { "", "" }
        };

        [Fact()]
        public void ToBase64Test()
        {
            var q = Base64Utils.ToBase64("e");
            foreach (var item in _testFrom64)
            {
                var result = Base64Utils.ToBase64(item.Value);
                Assert.Equal(item.Key, result);
            }
        }

        [Fact()]
        public void FromBase64Test()
        {
            foreach (var item in _testFrom64)
            {
                var result = Base64Utils.FromBase64(item.Key);
                Assert.Equal(item.Value, result);
            }
        }
    }
}