using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The earclip decomposer test class
    /// </summary>
    public class EarclipDecomposerTest
    {
        /// <summary>
        /// Tests that earclip decomposer type should be accessible
        /// </summary>
        [Fact]
        public void EarclipDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.EarclipDecomposer));
        }
    }
}

