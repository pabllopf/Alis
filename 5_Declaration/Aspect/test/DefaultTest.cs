using Xunit;

namespace Alis.Core.Aspect.Test
{
    /// <summary>
    /// The default test class
    /// </summary>
    public class DefaultTest
    {
        /// <summary>
        /// Tests that always returns true
        /// </summary>
        [Fact]
        public void AlwaysReturnsTrue()
        {
            Assert.True(true);
        }
    }
}