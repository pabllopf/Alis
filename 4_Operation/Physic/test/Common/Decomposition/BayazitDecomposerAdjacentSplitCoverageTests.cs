using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    public class BayazitDecomposerAdjacentSplitCoverageTests
    {
        private static void Run(params Vector2F[] pts)
        {
            Vertices v = new Vertices(pts);
            Assert.True(v.Count >= 3);
            var parts = BayazitDecomposer.ConvexPartition(v);
            Assert.NotEmpty(parts);
        }

        [Fact]
        public void Triangulate_ReflexNotchPolygons_AdjacentSplit()
        {
            Run(new Vector2F(0, 0), new Vector2F(4, 0), new Vector2F(4, 1), new Vector2F(2, 3), new Vector2F(0, 4), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 2), new Vector2F(3, 1), new Vector2F(1, 2), new Vector2F(1, 0));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 3), new Vector2F(4, 1), new Vector2F(2, 3), new Vector2F(0, 3));
            Run(new Vector2F(0, 0), new Vector2F(4, 0), new Vector2F(4, 2), new Vector2F(3, 4), new Vector2F(1, 4), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 1), new Vector2F(4, 2), new Vector2F(3, 1), new Vector2F(2, 2), new Vector2F(1, 1), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 1), new Vector2F(4, 2), new Vector2F(2, 1), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(3, 0), new Vector2F(3, 1), new Vector2F(2, 0.5f), new Vector2F(1, 1), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(4, 0), new Vector2F(4, 0.5f), new Vector2F(2, 1.5f), new Vector2F(0, 0.5f));
            Run(new Vector2F(0, 0), new Vector2F(8, 0), new Vector2F(8, 2), new Vector2F(6, 4), new Vector2F(4, 2), new Vector2F(2, 4), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 3), new Vector2F(3, 2), new Vector2F(2, 3), new Vector2F(0, 3));
            Run(new Vector2F(0, 0), new Vector2F(7, 0), new Vector2F(7, 1), new Vector2F(5, 1), new Vector2F(5, 2), new Vector2F(3, 2), new Vector2F(3, 1), new Vector2F(1, 1), new Vector2F(1, 0));
            Run(new Vector2F(0, 0), new Vector2F(4, 0), new Vector2F(4, 4), new Vector2F(3, 1), new Vector2F(1, 3), new Vector2F(0, 4));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 2), new Vector2F(5, 0.5f), new Vector2F(4, 2), new Vector2F(2, 1), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(3, 0), new Vector2F(3, 3), new Vector2F(2, 1), new Vector2F(1, 2), new Vector2F(0, 3));
            Run(new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 1), new Vector2F(4, 0.5f), new Vector2F(3, 1), new Vector2F(2, 0.5f), new Vector2F(1, 1), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(4, 0), new Vector2F(4, 2), new Vector2F(3, 1.2f), new Vector2F(2, 2), new Vector2F(1, 1.2f), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 3), new Vector2F(5, 2), new Vector2F(4, 3), new Vector2F(3, 1), new Vector2F(2, 3), new Vector2F(1, 2), new Vector2F(0, 3));
            Run(new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 2), new Vector2F(4, 1.5f), new Vector2F(3, 2), new Vector2F(2, 1.5f), new Vector2F(1, 2), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(4, 0), new Vector2F(4, 1), new Vector2F(3, 0.8f), new Vector2F(2, 1), new Vector2F(1, 0.8f), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(7, 0), new Vector2F(7, 2), new Vector2F(5, 1.5f), new Vector2F(4, 2), new Vector2F(3, 1), new Vector2F(2, 2), new Vector2F(1, 1.5f), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 4), new Vector2F(4, 3), new Vector2F(3, 4), new Vector2F(2, 2), new Vector2F(0, 4));
            Run(new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 3), new Vector2F(4, 2), new Vector2F(3, 3), new Vector2F(2, 1), new Vector2F(1, 3), new Vector2F(0, 3));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 1), new Vector2F(4, 1), new Vector2F(3, 2), new Vector2F(2, 1), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(8, 0), new Vector2F(8, 1), new Vector2F(6, 1), new Vector2F(5, 2), new Vector2F(4, 1), new Vector2F(3, 2), new Vector2F(2, 1), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(7, 0), new Vector2F(7, 2), new Vector2F(5, 1), new Vector2F(4, 2), new Vector2F(3, 1), new Vector2F(2, 2), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 1), new Vector2F(3, 0.5f), new Vector2F(2, 1), new Vector2F(1, 0.5f), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 2), new Vector2F(5, 1), new Vector2F(4, 2), new Vector2F(2, 1), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(9, 0), new Vector2F(9, 2), new Vector2F(7, 1), new Vector2F(6, 2), new Vector2F(5, 1), new Vector2F(4, 2), new Vector2F(3, 1), new Vector2F(2, 2), new Vector2F(0, 2));
            Run(new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 1), new Vector2F(8, 3), new Vector2F(7, 1), new Vector2F(6, 4), new Vector2F(5, 2), new Vector2F(4, 4), new Vector2F(3, 1), new Vector2F(2, 3), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(8, 0), new Vector2F(8, 1), new Vector2F(6, 2), new Vector2F(5, 1), new Vector2F(4, 3), new Vector2F(3, 1), new Vector2F(2, 2), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(6, 0), new Vector2F(6, 1), new Vector2F(4, 1.5f), new Vector2F(3, 0.5f), new Vector2F(2, 1.5f), new Vector2F(0, 1));
            Run(new Vector2F(0, 0), new Vector2F(7, 0), new Vector2F(7, 1), new Vector2F(5, 2), new Vector2F(4, 1), new Vector2F(3, 3), new Vector2F(2, 1), new Vector2F(0, 1));
        }
    }
}