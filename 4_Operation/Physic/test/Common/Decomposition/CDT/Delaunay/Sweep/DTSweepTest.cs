using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    /// The dt sweep test class
    /// </summary>
    public class DTSweepTest
    {
        /// <summary>
        /// Tests that dt sweep type should be accessible
        /// </summary>
        [Fact]
        public void DTSweep_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep.DtSweep));
        }
    }
}

