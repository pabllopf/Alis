using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The seidel decomposer test class
    /// </summary>
    public class SeidelDecomposerTest
    {
        /// <summary>
        /// Tests that seidel decomposer type should be accessible
        /// </summary>
        [Fact]
        public void SeidelDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.SeidelDecomposer));
        }
    }
}

