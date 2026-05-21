

using Xunit;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     The build test class
    /// </summary>
    public class BuildTest
    {
        /// <summary>
        ///     Tests that build returns expected value
        /// </summary>
        [Fact]
        public void Build_ReturnsExpectedValue()
        {
            TestBuild testBuild = new TestBuild();

            string result = testBuild.Build();

            Assert.Equal("Test", result);
        }

        /// <summary>
        ///     Tests that build does not return null
        /// </summary>
        [Fact]
        public void Build_DoesNotReturnNull()
        {
            TestBuild testBuild = new TestBuild();

            string result = testBuild.Build();

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that build returns correct type
        /// </summary>
        [Fact]
        public void Build_ReturnsCorrectType()
        {
            TestBuild testBuild = new TestBuild();

            string result = testBuild.Build();

            Assert.IsType<string>(result);
        }
    }
}