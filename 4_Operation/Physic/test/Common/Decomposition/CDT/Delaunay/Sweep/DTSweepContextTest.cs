using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    /// The dt sweep context test class
    /// </summary>
    public class DTSweepContextTest
    {
        /// <summary>
        /// Tests that dt sweep context type should be accessible
        /// </summary>
        [Fact]
        public void DTSweepContext_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep.DtSweepContext));
        }
    }
}

