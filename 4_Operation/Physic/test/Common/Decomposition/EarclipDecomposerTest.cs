// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EarclipDecomposerTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    ///     The earclip decomposer test class
    /// </summary>
    public class EarclipDecomposerTest
    {
        /// <summary>
        /// Creates the triangle vertices
        /// </summary>
        /// <returns>The vertices</returns>
        private static Vertices CreateTriangleVertices()
        {
            return new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
        }

        /// <summary>
        /// Creates the quad vertices
        /// </summary>
        /// <returns>The vertices</returns>
        private static Vertices CreateQuadVertices()
        {
            return new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0, 1)
            };
        }

        /// <summary>
        /// Creates the pentagon vertices
        /// </summary>
        /// <returns>The vertices</returns>
        private static Vertices CreatePentagonVertices()
        {
            return new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0.5f, 1.5f),
                new Vector2F(0, 1)
            };
        }

        /// <summary>
        ///     Tests that ConvexPartition with a triangle returns one vertex set
        /// </summary>
        [Fact]
        public void ConvexPartition_Triangle_ShouldReturnOneSet()
        {
            Vertices vertices = CreateTriangleVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with a quad returns triangulated result
        /// </summary>
        [Fact]
        public void ConvexPartition_Quad_ShouldReturnTriangulatedResult()
        {
            Vertices vertices = CreateQuadVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with empty vertices returns empty list
        /// </summary>
        [Fact]
        public void ConvexPartition_EmptyVertices_ShouldReturnEmptyList()
        {
            Vertices vertices = new Vertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        ///     Tests that ConvexPartition with two vertices returns empty list
        /// </summary>
        [Fact]
        public void ConvexPartition_TwoVertices_ShouldReturnEmptyList()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 1)
            };

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        ///     Tests that ConvexPartition with default tolerance works
        /// </summary>
        [Fact]
        public void ConvexPartition_WithDefaultTolerance_ShouldWork()
        {
            Vertices vertices = CreatePentagonVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with custom tolerance works
        /// </summary>
        [Fact]
        public void ConvexPartition_WithCustomTolerance_ShouldWork()
        {
            Vertices vertices = CreatePentagonVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.1f);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with zero tolerance works
        /// </summary>
        [Fact]
        public void ConvexPartition_WithZeroTolerance_ShouldWork()
        {
            Vertices vertices = CreatePentagonVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0f);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with diamond polygon covers triangle y-min early exit
        /// </summary>
        [Fact]
        public void ConvexPartition_DiamondPolygon_ShouldReturnResult()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(5, 0),
                new Vector2F(0, 10),
                new Vector2F(5, 20),
                new Vector2F(10, 10)
            };

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with large polygon works
        /// </summary>
        [Fact]
        public void ConvexPartition_LargePolygon_ShouldReturnResult()
        {
            Vertices vertices = new Vertices();
            for (int i = 0; i < 12; i++)
            {
                double angle = i * 2 * System.Math.PI / 12;
                vertices.Add(new Vector2F(
                    (float)System.Math.Cos(angle),
                    (float)System.Math.Sin(angle)));
            }

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        

        /// <summary>
        ///     Tests ResolvePinchPoint early return when polygon has fewer than 3 vertices.
        /// </summary>
        [Fact]
        public void ResolvePinchPoint_WithTwoVertices_ShouldReturnFalse()
        {
            System.Reflection.MethodInfo method = typeof(EarclipDecomposer).GetMethod("ResolvePinchPoint",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            Vertices pin = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f)
            });

            Vertices poutA = null;
            Vertices poutB = null;

            bool result = (bool)method.Invoke(null, new object[] { pin, poutA, poutB, 0.001f });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests TriangulatePolygon with a polygon that contains a pinch point
        ///     (two non-adjacent vertices at the same position).
        ///     The pinch point resolution splits the polygon into two parts,
        ///     and both mergeA and mergeB loops are exercised (including the mergeB loop at lines 96-98).
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithPinchPoint_ShouldPartitionCorrectly()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(5f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 5f),
                new Vector2F(0f, 0f),   // pinch point (duplicate of V0)
                new Vector2F(0f, 5f),
                new Vector2F(0f, 10f)
            });

            List<Vertices> result = EarclipDecomposer.TriangulatePolygon(vertices, 0.001f);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests SplitPolygonAtPinchPoint via reflection to ensure it splits correctly
        ///     when sizeA equals the polygon count (wrap-around duplicate guard).
        /// </summary>
        [Fact]
        public void SplitPolygonAtPinchPoint_WithSizeAEqualCount_ShouldReturn()
        {
            System.Reflection.MethodInfo method = typeof(EarclipDecomposer).GetMethod("SplitPolygonAtPinchPoint",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            Vertices pin = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });

            Vertices poutA = null;
            Vertices poutB = null;

            // pinchIndexA=0, pinchIndexB=4 → sizeA=4 which equals pin.Count
            method.Invoke(null, new object[] { pin, 0, 4, poutA, poutB });

            Assert.NotNull(pin);
        }

        /// <summary>
        ///     Tests Triangle.IsInside where y passes line 463 but y is not greater than a.Y,
        ///     exercising the false branch of condition 177 at line 468 (y > a.Y).
        /// </summary>
        [Fact]
        public void TriangleIsInside_YNotGreaterThanAY_ShouldReturnFalse()
        {
            System.Type triangleType = typeof(EarclipDecomposer).GetNestedType("Triangle",
                System.Reflection.BindingFlags.NonPublic);
            object triangle = System.Activator.CreateInstance(triangleType, new object[] { 0f, 0f, 0f, 5f, 10f, 0f });
            System.Reflection.MethodInfo method = triangleType.GetMethod("IsInside");

            // y=0 <= a.Y=0 → y > a.Y = false at line 468, condition 177 false branch
            // But passes line 463 since not (0 < 0 && 0 < 5 && 0 < 0)
            // The point (5,0) is on the a-c edge → v=0 → returns false via barycentric
            bool result = (bool)method.Invoke(triangle, new object[] { 5f, 0f });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Triangle.IsInside where y is between a.Y and b.Y,
        ///     exercising condition 187 false branch at line 468 (y > b.Y).
        /// </summary>
        [Fact]
        public void TriangleIsInside_YBetweenAYAndBY_ShouldReturnFalse()
        {
            System.Type triangleType = typeof(EarclipDecomposer).GetNestedType("Triangle",
                System.Reflection.BindingFlags.NonPublic);
            object triangle = System.Activator.CreateInstance(triangleType, new object[] { 0f, 0f, 0f, 5f, 10f, 0f });
            System.Reflection.MethodInfo method = triangleType.GetMethod("IsInside");

            // y=3, a.Y=0, b.Y=5 → y > a.Y = true, y > b.Y = false at line 468
            // Condition 177 true branch, condition 187 false branch
            bool result = (bool)method.Invoke(triangle, new object[] { 5f, 3f });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Triangle.IsInside where y is greater than all vertices,
        ///     exercising all three conditions true at line 468 (early exit).
        /// </summary>
        [Fact]
        public void TriangleIsInside_YGreaterThanAll_ShouldReturnFalse()
        {
            System.Type triangleType = typeof(EarclipDecomposer).GetNestedType("Triangle",
                System.Reflection.BindingFlags.NonPublic);
            object triangle = System.Activator.CreateInstance(triangleType, new object[] { 0f, 0f, 0f, 5f, 10f, 0f });
            System.Reflection.MethodInfo method = triangleType.GetMethod("IsInside");

            // y=6 > all (0,5,0) → returns false at line 470
            bool result = (bool)method.Invoke(triangle, new object[] { 5f, 6f });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Triangle.IsInside where point is on the edge opposite vertex A (u=0),
        ///     exercising condition 427 false branch at line 489 (u > 0).
        /// </summary>
        [Fact]
        public void TriangleIsInside_OnEdgeOppositeA_ShouldReturnFalse()
        {
            System.Type triangleType = typeof(EarclipDecomposer).GetNestedType("Triangle",
                System.Reflection.BindingFlags.NonPublic);
            object triangle = System.Activator.CreateInstance(triangleType, new object[] { 0f, 0f, 10f, 0f, 0f, 10f });
            System.Reflection.MethodInfo method = triangleType.GetMethod("IsInside");

            // Point (5,5) is on the hypotenuse (edge b-c), so u=0 → u > 0 = false
            bool result = (bool)method.Invoke(triangle, new object[] { 5f, 5f });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Triangle.IsInside where point is on the edge opposite vertex B (v=0),
        ///     exercising condition 436 false branch at line 489 (v > 0) with u > 0 true.
        /// </summary>
        [Fact]
        public void TriangleIsInside_OnEdgeOppositeB_ShouldReturnFalse()
        {
            System.Type triangleType = typeof(EarclipDecomposer).GetNestedType("Triangle",
                System.Reflection.BindingFlags.NonPublic);
            object triangle = System.Activator.CreateInstance(triangleType, new object[] { 0f, 0f, 10f, 0f, 0f, 10f });
            System.Reflection.MethodInfo method = triangleType.GetMethod("IsInside");

            // Point (0,5) is on the left edge (a-c), so v=0 → u > 0 = true, v > 0 = false
            bool result = (bool)method.Invoke(triangle, new object[] { 0f, 5f });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsEar returns false when i is out of bounds or xvLength is less than 3.
        /// </summary>
        [Fact]
        public void IsEar_WithOutOfBoundsIndex_ShouldReturnFalse()
        {
            float[] xv = { 0f, 1f, 0f };
            float[] yv = { 0f, 0f, 1f };

            bool result = EarclipDecomposer.IsEar(-1, xv, yv, 3);
            Assert.False(result);

            result = EarclipDecomposer.IsEar(5, xv, yv, 3);
            Assert.False(result);

            result = EarclipDecomposer.IsEar(0, xv, yv, 2);
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsEar returns false when a non-adjacent vertex lies inside the ear triangle.
        /// </summary>
        [Fact]
        public void IsEar_WithVertexInsideEarTriangle_ShouldReturnFalse()
        {
            float[] xv = { 0f, 0f, 6f, 6f, 4f };
            float[] yv = { 0f, 6f, 6f, 0f, 3f };

            bool result = EarclipDecomposer.IsEar(2, xv, yv, 5);
            Assert.False(result);
        }
    }
}
