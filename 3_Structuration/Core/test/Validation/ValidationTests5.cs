using System.Collections.Generic;
using Xunit;

namespace Alis.Core.Test.Validation
{
    /// <summary>
    /// The validation tests class
    /// </summary>
    public class ValidationTests5
    {
        /// <summary>
        /// Tests that validate value
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(1000)]
        public void ValidateValue(int value)
        {
            Assert.True(value >= 0);
        }

        /// <summary>
        /// Tests that validate string
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData("")]
        [InlineData("test")]
        [InlineData("verification")]
        [InlineData("xunit")]
        public void ValidateString(string value)
        {
            Assert.NotNull(value);
        }

        /// <summary>
        /// Tests that validate collection
        /// </summary>
        [Fact]
        public void ValidateCollection()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(5, list.Count);
        }

        /// <summary>
        /// Tests that validate equality
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        public void ValidateEquality(int a, int b)
        {
            Assert.Equal(a, b);
        }
    }
}
