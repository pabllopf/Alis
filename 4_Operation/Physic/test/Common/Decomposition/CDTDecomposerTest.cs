using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The cdt decomposer test class
    /// </summary>
    public class CDTDecomposerTest
    {
        /// <summary>
        /// Tests that cdt decomposer type should be accessible
        /// </summary>
        [Fact]
        public void CDTDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CdtDecomposer));
        }
    }
}

