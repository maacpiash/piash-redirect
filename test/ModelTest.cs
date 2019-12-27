using System;
using Xunit;
using Redirect;

namespace Redirect.Tests
{
    public class ModelTest
    {
        [Fact]
        public void LengthLimitTest()
        {
            const string fullKey = "TooLongToBeAShortcut";
            Shortcut s = new Shortcut { ShortKey = fullKey };
            Assert.StartsWith("TooLon", fullKey);
            Assert.Equal(s.ShortKey.Length, Shortcut.MaxLength);
        }
    }
}
