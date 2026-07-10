using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class SimplexRemainingCoverageTests
    {
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
            Assert.Equal(0.0f, cache.Metric);
        }

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
            Assert.Equal(0.0f, cache.Metric);
        }

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
            Assert.Equal(1.0f, simplex.V[0].A);
        }

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
            Assert.Equal(1.0f, simplex.V[0].A);
        }

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
            Assert.Equal(0.5f, simplex.V[0].A);
            Assert.Equal(0.5f, simplex.V[1].A);
        }

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
            Assert.Equal(1.0f, simplex.V[0].A);
        }

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
            Assert.Equal(1.0f, simplex.V[0].A);
        }

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
            Assert.Equal(1.0f, simplex.V[0].A);
        }

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

            Assert.Equal(0.0f, metric);
        }
    }
}
