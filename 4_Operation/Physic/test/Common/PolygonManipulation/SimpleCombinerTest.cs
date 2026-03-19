using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    /// The simple combiner test class
    /// </summary>
    public class SimpleCombinerTest
    {
        /// <summary>
        /// Tests that simple combiner type should be accessible
        /// </summary>
        [Fact]
        public void SimpleCombiner_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.Common.PolygonManipulation.SimpleCombiner));
        }
    }
}

