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
    /// <summary>
    /// The simplex test class
    /// </summary>
    public class SimplexTest
    {
        /// <summary>
        /// Tests that get search direction with single vertex should negate vertex
        /// </summary>
        [Fact]
        public void GetSearchDirection_WithSingleVertex_ShouldNegateVertex()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(2.0f, -3.0f) }
                    }
            };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-2.0f, 3.0f), direction);
        }

        /// <summary>
        /// Tests that get search direction with two vertices when sgn positive should return perpendicular clockwise
        /// </summary>
        [Fact]
        public void GetSearchDirection_WithTwoVertices_WhenSgnPositive_ShouldReturnPerpendicularClockwise()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) }
                    }
            };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-1.0f, -1.0f), direction);
        }

        /// <summary>
        /// Tests that get search direction with two vertices when sgn negative should return perpendicular counter clockwise
        /// </summary>
        [Fact]
        public void GetSearchDirection_WithTwoVertices_WhenSgnNegative_ShouldReturnPerpendicularCounterClockwise()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(0.0f, -1.0f) }
                    }
            };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-1.0f, 1.0f), direction);
        }

        /// <summary>
        /// Tests that get search direction with three vertices should return zero
        /// </summary>
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

        /// <summary>
        /// Tests that get closest point with count zero should return zero
        /// </summary>
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

        /// <summary>
        /// Tests that get closest point with count one should return vertex w
        /// </summary>
        [Fact]
        public void GetClosestPoint_WithCountOne_ShouldReturnVertexW()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) }
                    }
            };

            Vector2F point = simplex.GetClosestPoint();

            Assert.Equal(new Vector2F(3.0f, 4.0f), point);
        }

        /// <summary>
        /// Tests that get closest point with count two should blend vertices
        /// </summary>
        [Fact]
        public void GetClosestPoint_WithCountTwo_ShouldBlendVertices()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f), A = 0.3f },
                        [1] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f), A = 0.7f }
                    }
            };

            Vector2F point = simplex.GetClosestPoint();

            Assert.Equal(new Vector2F(0.3f, 0.7f), point);
        }

        /// <summary>
        /// Tests that get closest point with count three should return zero
        /// </summary>
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

        /// <summary>
        /// Tests that get witness points with count zero should return zero
        /// </summary>
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

        /// <summary>
        /// Tests that get witness points with single point should return stored points
        /// </summary>
        [Fact]
        public void GetWitnessPoints_WithSinglePoint_ShouldReturnStoredPoints()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex
                        {
                            Wa = new Vector2F(1.0f, 2.0f),
                            Wb = new Vector2F(3.0f, 4.0f)
                        }
                    }
            };

            simplex.GetWitnessPoints(out Vector2F pointA, out Vector2F pointB);

            Assert.Equal(new Vector2F(1.0f, 2.0f), pointA);
            Assert.Equal(new Vector2F(3.0f, 4.0f), pointB);
        }

        /// <summary>
        /// Tests that get witness points with two vertices should blend
        /// </summary>
        [Fact]
        public void GetWitnessPoints_WithTwoVertices_ShouldBlend()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { Wa = new Vector2F(1.0f, 0.0f), Wb = new Vector2F(2.0f, 0.0f), A = 0.4f },
                        [1] = new SimplexVertex { Wa = new Vector2F(0.0f, 1.0f), Wb = new Vector2F(0.0f, 2.0f), A = 0.6f }
                    }
            };

            simplex.GetWitnessPoints(out Vector2F pA, out Vector2F pB);

            Assert.Equal(new Vector2F(0.4f, 0.6f), pA);
            Assert.Equal(new Vector2F(0.8f, 1.2f), pB);
        }

        /// <summary>
        /// Tests that get witness points with three vertices should blend
        /// </summary>
        [Fact]
        public void GetWitnessPoints_WithThreeVertices_ShouldBlend()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { Wa = new Vector2F(1.0f, 0.0f), Wb = new Vector2F(2.0f, 0.0f), A = 0.2f },
                        [1] = new SimplexVertex { Wa = new Vector2F(0.0f, 1.0f), Wb = new Vector2F(0.0f, 2.0f), A = 0.3f },
                        [2] = new SimplexVertex { Wa = new Vector2F(0.0f, 0.0f), Wb = new Vector2F(0.0f, 0.0f), A = 0.5f }
                    }
            };

            simplex.GetWitnessPoints(out Vector2F pA, out Vector2F pB);

            Assert.Equal(new Vector2F(0.2f, 0.3f), pA);
            Assert.Equal(pA, pB);
        }

        /// <summary>
        /// Tests that get witness points with invalid count should throw
        /// </summary>
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

        /// <summary>
        /// Tests that get metric with count zero should return zero
        /// </summary>
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

        /// <summary>
        /// Tests that get metric with count one should return zero
        /// </summary>
        [Fact]
        public void GetMetric_WithCountOne_ShouldReturnZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(5.0f, 0.0f) }
                    }
            };

            Assert.Equal(0.0f, simplex.GetMetric());
        }

        /// <summary>
        /// Tests that get metric with two points should return segment length
        /// </summary>
        [Fact]
        public void GetMetric_WithTwoPoints_ShouldReturnSegmentLength()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) }
                    }
            };

            float metric = simplex.GetMetric();

            Assert.Equal(5.0f, metric, 5);
        }

        /// <summary>
        /// Tests that get metric with three points should return cross product
        /// </summary>
        [Fact]
        public void GetMetric_WithThreePoints_ShouldReturnCrossProduct()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) }
                    }
            };

            float metric = simplex.GetMetric();

            Assert.Equal(4.0f, metric, 5);
        }

        /// <summary>
        /// Tests that solve 2 should keep two vertices when origin on segment
        /// </summary>
        [Fact]
        public void Solve2_ShouldKeepTwoVertices_WhenOriginOnSegment()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) }
                    }
            };

            simplex.Solve2();

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 2 should reduce to closest vertex when origin outside segment
        /// </summary>
        [Fact]
        public void Solve2_ShouldReduceToClosestVertex_WhenOriginOutsideSegment()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(5.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(7.0f, 0.0f) }
                    }
            };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 2 should reduce to v 0 whend 122 non positive
        /// </summary>
        [Fact]
        public void Solve2_ShouldReduceToV0_Whend122NonPositive()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) }
                    }
            };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 should reduce to vertex 0 when closest
        /// </summary>
        [Fact]
        public void Solve3_ShouldReduceToVertex0_WhenClosest()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(5.0f, 1.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) }
                    }
            };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 should reduce to edge 01 when origin projects on edge 01
        /// </summary>
        [Fact]
        public void Solve3_ShouldReduceToEdge01_WhenOriginProjectsOnEdge01()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) }
                    }
            };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 should reduce to edge 02 when origin projects on edge 02
        /// </summary>
        [Fact]
        public void Solve3_ShouldReduceToEdge02_WhenOriginProjectsOnEdge02()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(0.0f, -1.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(0.0f, 1.0f) }
                    }
            };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 should reduce to vertex 1 when closest
        /// </summary>
        [Fact]
        public void Solve3_ShouldReduceToVertex1_WhenClosest()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(-2.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(-0.5f, 0.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(-2.0f, 3.0f) }
                    }
            };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 should reduce to vertex 2 when closest
        /// </summary>
        [Fact]
        public void Solve3_ShouldReduceToVertex2_WhenClosest()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(-2.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(-2.0f, 3.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(-0.5f, 0.0f) }
                    }
            };

            simplex.Solve3();

            Assert.Equal(1, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 should reduce to edge 12 when origin projects on edge 12
        /// </summary>
        [Fact]
        public void Solve3_ShouldReduceToEdge12_WhenOriginProjectsOnEdge12()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(-1.0f, 0.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(1.0f, 0.0f) }
                    }
            };

            simplex.Solve3();

            Assert.Equal(2, simplex.Count);
        }

        /// <summary>
        /// Tests that solve 3 should keep three when origin inside triangle
        /// </summary>
        [Fact]
        public void Solve3_ShouldKeepThree_WhenOriginInsideTriangle()
        {
            Simplex simplex = new Simplex
            {
                Count = 3,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { W = new Vector2F(2.0f, 0.0f) },
                        [1] = new SimplexVertex { W = new Vector2F(0.0f, 2.0f) },
                        [2] = new SimplexVertex { W = new Vector2F(-2.0f, -1.0f) }
                    }
            };

            simplex.Solve3();

            Assert.Equal(3, simplex.Count);
        }

        /// <summary>
        /// Tests that write cache should store state
        /// </summary>
        [Fact]
        public void WriteCache_ShouldStoreState()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>
                    {
                        [0] = new SimplexVertex { IndexA = 0, IndexB = 2, W = new Vector2F(1.0f, 0.0f) },
                        [1] = new SimplexVertex { IndexA = 1, IndexB = 3, W = new Vector2F(0.0f, 1.0f) }
                    }
            };

            SimplexCache cache = new SimplexCache();
            simplex.WriteCache(ref cache);

            Assert.Equal(2, cache.Count);
            Assert.Equal(0, cache.IndexA[0]);
            Assert.Equal(2, cache.IndexB[0]);
            Assert.Equal(1, cache.IndexA[1]);
            Assert.Equal(3, cache.IndexB[1]);
            Assert.True(cache.Metric > 0.0f);
        }

        /// <summary>
        /// Tests that read cache should restore state from valid cache
        /// </summary>
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

        /// <summary>
        /// Tests that read cache should reset when metric degraded
        /// </summary>
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

        /// <summary>
        /// Tests that get closest point with invalid count returns zero
        /// </summary>
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

        /// <summary>
        /// Tests that get metric with invalid count returns zero
        /// </summary>
        [Fact]
        public void GetMetric_WithInvalidCount_ReturnsZero()
        {
            Simplex simplex = new Simplex
            {
                Count = 4,
                V = new FixedArray3<SimplexVertex>()
            };

            float metric = simplex.GetMetric();

            Assert.Equal(0.0f, metric, 5);
        }

        /// <summary>
        /// Tests that get search direction with invalid count returns zero
        /// </summary>
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
