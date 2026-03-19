using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The flipcode decomposer test class
    /// </summary>
    public class FlipcodeDecomposerTest
    {
        /// <summary>
        /// Tests that flipcode decomposer type should be accessible
        /// </summary>
        [Fact]
        public void FlipcodeDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.FlipcodeDecomposer));
        }
    }
}

