using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
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

        /// <summary>
        /// Verifies that a simple rectangle triangulates into two non-degenerate triangles.
        /// </summary>
        [Fact]
        public void DTSweep_TriangulatesRectangleIntoTwoTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(2.0f, 0.0f),
                new Vector2F(2.0f, 1.0f),
                new Vector2F(0.0f, 1.0f)
            };

            var triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.Equal(vertices.Count - 2, triangles.Count);
            foreach (Vertices triangle in triangles)
            {
                Assert.Equal(3, triangle.Count);
                Assert.True(triangle.GetArea() > 0.0f);
            }
        }
    }
}
