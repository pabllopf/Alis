using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The simplex remaining coverage tests class
    /// </summary>
    public class SimplexRemainingCoverageTests
    {
        /// <summary>
        /// Tests that read cache with count 2 and valid metric should keep count 2
        /// </summary>
        [Fact]
        public void ReadCache_WithCount2_AndValidMetric_ShouldKeepCount2()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(edge, 0);
            DistanceProxy proxyB = new DistanceProxy(circle, 0);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            SimplexCache cache = new SimplexCache
            {
                Count = 2,
                Metric = 2.0f
            };
            cache.IndexA[0] = 0;
            cache.IndexA[1] = 1;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 0;

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref proxyA, ref xfA, ref proxyB, ref xfB);

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that read cache with count 2 and metric too large should reset
        /// </summary>
        [Fact]
        public void ReadCache_WithCount2_AndMetricTooLarge_ShouldReset()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(edge, 0);
            DistanceProxy proxyB = new DistanceProxy(circle, 0);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            SimplexCache cache = new SimplexCache
            {
                Count = 2,
                Metric = 0.5f
            };
            cache.IndexA[0] = 0;
            cache.IndexA[1] = 1;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 0;

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref proxyA, ref xfA, ref proxyB, ref xfB);

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that read cache with count 2 and metric degenerate should reset
        /// </summary>
        [Fact]
        public void ReadCache_WithCount2_AndMetricDegenerate_ShouldReset()
        {
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            CircleShape circle2 = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(circle, 0);
            DistanceProxy proxyB = new DistanceProxy(circle2, 0);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);

            SimplexCache cache = new SimplexCache
            {
                Count = 2,
                Metric = 1000.0f
            };
            cache.IndexA[0] = 0;
            cache.IndexA[1] = 0;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 0;

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref proxyA, ref xfA, ref proxyB, ref xfB);

            Assert.True(simplex.Count == 1);
        }

        /// <summary>
        /// Tests that read cache with count 3 should restore three vertices
        /// </summary>
        [Fact]
        public void ReadCache_WithCount3_ShouldRestoreThreeVertices()
        {
            Vertices triVerts = new Vertices
            {
                new Vector2F(-2.0f, -2.0f),
                new Vector2F(2.0f, -2.0f),
                new Vector2F(0.0f, 2.0f)
            };
            PolygonShape poly = new PolygonShape(triVerts, 1.0f);
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(poly, 0);
            DistanceProxy proxyB = new DistanceProxy(circle, 0);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f);

            SimplexCache cache = new SimplexCache
            {
                Count = 3,
                Metric = 16.0f
            };
            cache.IndexA[0] = 0;
            cache.IndexA[1] = 1;
            cache.IndexA[2] = 2;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 0;
            cache.IndexB[2] = 0;

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref proxyA, ref xfA, ref proxyB, ref xfB);

            Assert.Equal(3, simplex.Count);
        }

        /// <summary>
        /// Tests that read cache with count 0 should initialize with one vertex
        /// </summary>
        [Fact]
        public void ReadCache_WithCount0_ShouldInitializeWithOneVertex()
        {
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(circle, 0);
            DistanceProxy proxyB = new DistanceProxy(circle, 0);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;

            SimplexCache cache = new SimplexCache
            {
                Count = 0,
                Metric = 0.0f
            };

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref proxyA, ref xfA, ref proxyB, ref xfB);

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that write cache with count 0 should store zero metric
        /// </summary>
        [Fact]
        public void WriteCache_WithCount0_ShouldStoreZeroMetric()
        {
            Simplex simplex = new Simplex
            {
                Count = 0,
                V = new FixedArray3<SimplexVertex>()
            };

            SimplexCache cache = new SimplexCache();
            simplex.WriteCache(ref cache);

            Assert.Equal(0u, cache.Count);
            Assert.Equal(0.0f, cache.Metric, 5);
        }

        /// <summary>
        /// Tests that write cache with count 1 should store single vertex
        /// </summary>
        [Fact]
        public void WriteCache_WithCount1_ShouldStoreSingleVertex()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { IndexA = 5, IndexB = 10 };

            SimplexCache cache = new SimplexCache();
            simplex.WriteCache(ref cache);

            Assert.Equal(1, (int)cache.Count);
            Assert.Equal(5, (int)cache.IndexA[0]);
            Assert.Equal(10, (int)cache.IndexB[0]);
            Assert.Equal(0.0f, cache.Metric, 5);
        }

        /// <summary>
        /// Tests that write cache with count 3 should store all vertices
        /// </summary>
        [Fact]
        public void WriteCache_WithCount3_ShouldStoreAllVertices()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { IndexA = 0, IndexB = 0 };
            simplex.V[1] = new SimplexVertex { IndexA = 1, IndexB = 1 };
            simplex.V[2] = new SimplexVertex { IndexA = 2, IndexB = 2 };

            SimplexCache cache = new SimplexCache();
            simplex.WriteCache(ref cache);

            Assert.Equal(3, (int)cache.Count);
            Assert.Equal(0, (int)cache.IndexA[0]);
            Assert.Equal(0, (int)cache.IndexB[0]);
            Assert.Equal(1, (int)cache.IndexA[1]);
            Assert.Equal(1, (int)cache.IndexB[1]);
            Assert.Equal(2, (int)cache.IndexA[2]);
            Assert.Equal(2, (int)cache.IndexB[2]);
        }

        /// <summary>
        /// Tests that get search direction with two vertices when sgn is zero should return counter clockwise
        /// </summary>
        [Fact]
        public void GetSearchDirection_WithTwoVertices_WhenSgnIsZero_ShouldReturnCounterClockwise()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(0.0f, -1.0f), direction);
        }

        /// <summary>
        /// Tests that solve 2 when d 122 is exactly zero should reduce to v 0
        /// </summary>
        [Fact]
        public void Solve2_WhenD122IsExactlyZero_ShouldReduceToV0()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
            Assert.Equal(1.0f, simplex.V[0].A, 5);
        }

        /// <summary>
        /// Tests that solve 2 when d 121 is exactly zero should reduce to v 1 and swap
        /// </summary>
        [Fact]
        public void Solve2_WhenD121IsExactlyZero_ShouldReduceToV1AndSwap()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
            Assert.Equal(1.0f, simplex.V[0].A, 5);
        }

        /// <summary>
        /// Tests that solve 2 when origin on segment should compute barycentric coords
        /// </summary>
        [Fact]
        public void Solve2_WhenOriginOnSegment_ShouldComputeBarycentricCoords()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-2.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) };

            simplex.Solve2();

            Assert.Equal(2, simplex.Count);
            Assert.Equal(0.5f, simplex.V[0].A, 5);
            Assert.Equal(0.5f, simplex.V[1].A, 5);
        }

        /// <summary>
        /// Tests that solve 3 when d 122 and d 132 are zero should reduce to vertex 0
        /// </summary>
        [Fact]
        public void Solve3_WhenD122AndD132AreZero_ShouldReduceToVertex0()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
            Assert.Equal(1.0f, simplex.V[0].A, 5);
        }

        /// <summary>
        /// Tests that solve 3 when d 121 and d 232 are zero should reduce to vertex 1 and swap
        /// </summary>
        [Fact]
        public void Solve3_WhenD121AndD232AreZero_ShouldReduceToVertex1AndSwap()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
            Assert.Equal(1.0f, simplex.V[0].A, 5);
        }

        /// <summary>
        /// Tests that solve 3 when d 131 and d 231 are zero should reduce to vertex 2 and swap
        /// </summary>
        [Fact]
        public void Solve3_WhenD131AndD231AreZero_ShouldReduceToVertex2AndSwap()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
            Assert.Equal(1.0f, simplex.V[0].A, 5);
        }

        /// <summary>
        /// Tests that solve 3 when origin inside triangle should keep three and compute barycentric
        /// </summary>
        [Fact]
        public void Solve3_WhenOriginInsideTriangle_ShouldKeepThreeAndComputeBarycentric()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(3.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 3.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(-2.0f, -2.0f) };

            simplex.Solve3();

            Assert.Equal(3, simplex.Count);
            Assert.True(simplex.V[0].A > 0.0f);
            Assert.True(simplex.V[1].A > 0.0f);
            Assert.True(simplex.V[2].A > 0.0f);
        }

        /// <summary>
        /// Tests that solve 3 edge 01 path should reduce to edge 01
        /// </summary>
        [Fact]
        public void Solve3_Edge01Path_ShouldReduceToEdge01()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 3.0f) };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 edge 02 path should reduce to edge 02
        /// </summary>
        [Fact]
        public void Solve3_Edge02Path_ShouldReduceToEdge02()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, -1.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(3.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 edge 12 path should reduce to edge 12
        /// </summary>
        [Fact]
        public void Solve3_Edge12Path_ShouldReduceToEdge12()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 3.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that get witness points default case should throw
        /// </summary>
        [Fact]
        public void GetWitnessPoints_DefaultCase_ShouldThrow()
        {
            Simplex simplex = new Simplex
            {
                Count = 4,
                V = new FixedArray3<SimplexVertex>()
            };

            Assert.Throws<InvalidOperationException>(() => simplex.GetWitnessPoints(out _, out _));
        }

        /// <summary>
        /// Tests that get metric with two points zero length should return zero
        /// </summary>
        [Fact]
        public void GetMetric_WithTwoPoints_ZeroLength_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 1.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(1.0f, 1.0f) };

            float metric = simplex.GetMetric();

            Assert.Equal(0.0f, metric, 5);
        }

        /// <summary>
        /// Tests that solve 3 when d 231 is non positive should not trigger edge 12
        /// </summary>
        [Fact]
        public void Solve3_WhenD231NonPositive_ShouldNotTriggerEdge12()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-5.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(10.0f, -3.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(5.0f, 1.0f) };

            simplex.Solve3();

            Assert.Equal(3, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 when d 232 is non positive should not trigger edge 12
        /// </summary>
        [Fact]
        public void Solve3_WhenD232NonPositive_ShouldNotTriggerEdge12()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-5.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(2.0f, -1.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(5.0f, 1.0f) };

            simplex.Solve3();

            Assert.Equal(3, simplex.Count);
        }
    }
}
