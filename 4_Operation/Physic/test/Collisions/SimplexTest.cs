// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class SimplexTest
    {
        [Fact]
        public void GetSearchDirection_WithSingleVertex_ShouldNegateVertex()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(2.0f, -3.0f) };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-2.0f, 3.0f), direction);
        }

        [Fact]
        public void GetSearchDirection_WithTwoVertices_WhenSgnPositive_ShouldReturnPerpendicularClockwise()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-1.0f, -1.0f), direction);
        }

        [Fact]
        public void GetSearchDirection_WithTwoVertices_WhenSgnNegative_ShouldReturnPerpendicularCounterClockwise()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, -1.0f) };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-1.0f, 1.0f), direction);
        }

        [Fact]
        public void GetSearchDirection_WithThreeVertices_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(Vector2F.Zero, direction);
        }

        [Fact]
        public void GetClosestPoint_WithCountZero_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 0,
                V = new FixedArray3<SimplexVertex>()
            };

            Vector2F point = simplex.GetClosestPoint();

            Assert.Equal(Vector2F.Zero, point);
        }

        [Fact]
        public void GetClosestPoint_WithCountOne_ShouldReturnVertexW()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) };

            Vector2F point = simplex.GetClosestPoint();

            Assert.Equal(new Vector2F(3.0f, 4.0f), point);
        }

        [Fact]
        public void GetClosestPoint_WithCountTwo_ShouldBlendVertices()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f), A = 0.3f };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f), A = 0.7f };

            Vector2F point = simplex.GetClosestPoint();

            Assert.Equal(new Vector2F(0.3f, 0.7f), point);
        }

        [Fact]
        public void GetClosestPoint_WithCountThree_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };

            Vector2F point = simplex.GetClosestPoint();

            Assert.Equal(Vector2F.Zero, point);
        }

        [Fact]
        public void GetWitnessPoints_WithCountZero_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 0,
                V = new FixedArray3<SimplexVertex>()
            };

            simplex.GetWitnessPoints(out Vector2F pA, out Vector2F pB);

            Assert.Equal(Vector2F.Zero, pA);
            Assert.Equal(Vector2F.Zero, pB);
        }

        [Fact]
        public void GetWitnessPoints_WithSinglePoint_ShouldReturnStoredPoints()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex
            {
                Wa = new Vector2F(1.0f, 2.0f),
                Wb = new Vector2F(3.0f, 4.0f)
            };

            simplex.GetWitnessPoints(out Vector2F pointA, out Vector2F pointB);

            Assert.Equal(new Vector2F(1.0f, 2.0f), pointA);
            Assert.Equal(new Vector2F(3.0f, 4.0f), pointB);
        }

        [Fact]
        public void GetWitnessPoints_WithTwoVertices_ShouldBlend()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { Wa = new Vector2F(1.0f, 0.0f), Wb = new Vector2F(2.0f, 0.0f), A = 0.4f };
            simplex.V[1] = new SimplexVertex { Wa = new Vector2F(0.0f, 1.0f), Wb = new Vector2F(0.0f, 2.0f), A = 0.6f };

            simplex.GetWitnessPoints(out Vector2F pA, out Vector2F pB);

            Assert.Equal(new Vector2F(0.4f, 0.6f), pA);
            Assert.Equal(new Vector2F(0.8f, 1.2f), pB);
        }

        [Fact]
        public void GetWitnessPoints_WithThreeVertices_ShouldBlend()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { Wa = new Vector2F(1.0f, 0.0f), Wb = new Vector2F(2.0f, 0.0f), A = 0.2f };
            simplex.V[1] = new SimplexVertex { Wa = new Vector2F(0.0f, 1.0f), Wb = new Vector2F(0.0f, 2.0f), A = 0.3f };
            simplex.V[2] = new SimplexVertex { Wa = new Vector2F(0.0f, 0.0f), Wb = new Vector2F(0.0f, 0.0f), A = 0.5f };

            simplex.GetWitnessPoints(out Vector2F pA, out Vector2F pB);

            Assert.Equal(new Vector2F(0.2f, 0.3f), pA);
            Assert.Equal(pA, pB);
        }

        [Fact]
        public void GetWitnessPoints_WithInvalidCount_ShouldThrow()
        {
            Simplex simplex = new Simplex
            {
                Count = 4,
                V = new FixedArray3<SimplexVertex>()
            };

            Assert.Throws<InvalidOperationException>(() => simplex.GetWitnessPoints(out _, out _));
        }

        [Fact]
        public void GetMetric_WithCountZero_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 0,
                V = new FixedArray3<SimplexVertex>()
            };

            Assert.Equal(0.0f, simplex.GetMetric());
        }

        [Fact]
        public void GetMetric_WithCountOne_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(5.0f, 0.0f) };

            Assert.Equal(0.0f, simplex.GetMetric());
        }

        [Fact]
        public void GetMetric_WithTwoPoints_ShouldReturnSegmentLength()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) };

            float metric = simplex.GetMetric();

            Assert.Equal(5.0f, metric);
        }

        [Fact]
        public void GetMetric_WithThreePoints_ShouldReturnCrossProduct()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) };

            float metric = simplex.GetMetric();

            Assert.Equal(4.0f, metric);
        }

        [Fact]
        public void Solve2_ShouldKeepTwoVertices_WhenOriginOnSegment()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };

            simplex.Solve2();

            Assert.Equal(2, simplex.Count);
        }

        [Fact]
        public void Solve2_ShouldReduceToClosestVertex_WhenOriginOutsideSegment()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(5.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(7.0f, 0.0f) };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void Solve2_ShouldReduceToV0_Whend122NonPositive()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void Solve3_ShouldReduceToVertex0_WhenClosest()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(5.0f, 1.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void Solve3_ShouldReduceToEdge01_WhenOriginProjectsOnEdge01()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        [Fact]
        public void Solve3_ShouldReduceToEdge02_WhenOriginProjectsOnEdge02()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, -1.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        [Fact]
        public void Solve3_ShouldReduceToVertex1_WhenClosest()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-2.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(-0.5f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(-2.0f, 3.0f) };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void Solve3_ShouldReduceToVertex2_WhenClosest()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(-2.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(-2.0f, 3.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(-0.5f, 0.0f) };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void Solve3_ShouldReduceToEdge12_WhenOriginProjectsOnEdge12()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        [Fact]
        public void Solve3_ShouldKeepThree_WhenOriginInsideTriangle()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) };
            simplex.V[2] = new SimplexVertex { W = new Vector2F(-2.0f, -1.0f) };

            simplex.Solve3();

            Assert.Equal(3, simplex.Count);
        }

        [Fact]
        public void WriteCache_ShouldStoreState()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { IndexA = 0, IndexB = 2, W = new Vector2F(1.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { IndexA = 1, IndexB = 3, W = new Vector2F(0.0f, 1.0f) };

            SimplexCache cache = new SimplexCache();
            simplex.WriteCache(ref cache);

            Assert.Equal(2, cache.Count);
            Assert.Equal(0, cache.IndexA[0]);
            Assert.Equal(2, cache.IndexB[0]);
            Assert.Equal(1, cache.IndexA[1]);
            Assert.Equal(3, cache.IndexB[1]);
            Assert.True(cache.Metric > 0.0f);
        }

        [Fact]
        public void ReadCache_ShouldRestoreState_FromValidCache()
        {
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(shapeA, 0);
            DistanceProxy proxyB = new DistanceProxy(shapeB, 0);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(2.0f, 0.0f), 0.0f);

            SimplexCache cache = new SimplexCache
            {
                Count = 1,
                Metric = 1.0f
            };
            cache.IndexA[0] = 0;
            cache.IndexB[0] = 0;

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref proxyA, ref xfA, ref proxyB, ref xfB);

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void ReadCache_ShouldReset_WhenMetricDegraded()
        {
            PolygonShape shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            DistanceProxy proxyA = new DistanceProxy(shapeA, 0);
            DistanceProxy proxyB = new DistanceProxy(shapeB, 0);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(3.0f, 0.0f), 0.0f);

            SimplexCache cache = new SimplexCache
            {
                Count = 2,
                Metric = 1000.0f
            };
            cache.IndexA[0] = 0;
            cache.IndexA[1] = 1;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 1;

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref proxyA, ref xfA, ref proxyB, ref xfB);

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void GetClosestPoint_WithInvalidCount_ReturnsZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 4,
                V = new FixedArray3<SimplexVertex>()
            };

            Vector2F point = simplex.GetClosestPoint();

            Assert.Equal(Vector2F.Zero, point);
        }

        [Fact]
        public void GetMetric_WithInvalidCount_ReturnsZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 4,
                V = new FixedArray3<SimplexVertex>()
            };

            float metric = simplex.GetMetric();

            Assert.Equal(0.0f, metric);
        }

        [Fact]
        public void GetSearchDirection_WithInvalidCount_ReturnsZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 4,
                V = new FixedArray3<SimplexVertex>()
            };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(Vector2F.Zero, direction);
        }
    }
}
