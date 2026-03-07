using Xunit;

namespace Alis.Core.Test.Boundary
{
    /// <summary>
    /// The boundary tests 19 class
    /// </summary>
    public class BoundaryTests19
    {
        /// <summary>
        /// Tests that validate boundary
        /// </summary>
        /// <param name="value">The value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void ValidateBoundary(int value)
        {
            Assert.True(int.MinValue <= value && value <= int.MaxValue);
        }
    }
}
