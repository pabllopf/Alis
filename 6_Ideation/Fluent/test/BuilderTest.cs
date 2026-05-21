

using Xunit;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     The builder test class
    /// </summary>
    public class BuilderTest
    {
        /// <summary>
        ///     Tests that builder returns expected value
        /// </summary>
        [Fact]
        public void Builder_ReturnsExpectedValue()
        {
            TestHasBuilder testHasBuilder = new TestHasBuilder();

            string result = testHasBuilder.Builder();

            Assert.Equal("Test", result);
        }

        /// <summary>
        ///     Tests that builder does not return null
        /// </summary>
        [Fact]
        public void Builder_DoesNotReturnNull()
        {
            TestHasBuilder testHasBuilder = new TestHasBuilder();

            string result = testHasBuilder.Builder();

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that builder returns correct type
        /// </summary>
        [Fact]
        public void Builder_ReturnsCorrectType()
        {
            TestHasBuilder testHasBuilder = new TestHasBuilder();

            string result = testHasBuilder.Builder();

            Assert.IsType<string>(result);
        }
    }
}