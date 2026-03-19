using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The bayazit decomposer test class
    /// </summary>
    public class BayazitDecomposerTest
    {
        /// <summary>
        /// Tests that bayazit decomposer type should be accessible
        /// </summary>
        [Fact]
        public void BayazitDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.BayazitDecomposer));
        }
    }
}

