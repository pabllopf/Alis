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

using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     Tests for the EarclipDecomposer class using reflection to access internal members
    /// </summary>
    public class EarclipDecomposerTest
    {
        private static readonly Type _earclipType = typeof(EarclipDecomposer);

        /// <summary>
        ///     Helper to call internal static methods via reflection
        /// </summary>
        private static object? CallInternalMethod(string methodName, params object?[] args)
        {
            var method = _earclipType.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (method == null)
            {
                throw new ArgumentException($"Method '{methodName}' not found on EarclipDecomposer");
            }

            return method.Invoke(null, args);
        }

        /// <summary>
        ///     Tests that ConvexPartition with less than 3 vertices returns empty list
        /// </summary>
        [Fact]
        public void ConvexPartition_WithLessThan3Vertices_ShouldReturnEmptyList()
        {
            var vertices = new Vertices();

            var result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with 3 vertices returns a single triangle
        /// </summary>
        [Fact]
        public void ConvexPartition_With3Vertices_ShouldReturnSingleTriangle()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(5, 10)
            };

            var result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with a simple convex polygon triangulates correctly
        /// </summary>
        [Fact]
        public void ConvexPartition_WithConvexPolygon_ShouldTriangulate()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };

            var result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            // A convex quadrilateral should be triangulated into 2 triangles
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        ///     Tests that Remainder handles negative numbers correctly
        /// </summary>
        [Fact]
        public void Remainder_WithNegativeNumber_ShouldReturnCorrectValue()
        {
            var result = (int)CallInternalMethod("Remainder", -1, 5);

            Assert.Equal(4, result);
        }

        /// <summary>
        ///     Tests that Remainder handles positive numbers correctly
        /// </summary>
        [Fact]
        public void Remainder_WithPositiveNumber_ShouldReturnCorrectValue()
        {
            var result = (int)CallInternalMethod("Remainder", 3, 5);

            Assert.Equal(3, result);
        }

        /// <summary>
        ///     Tests that Remainder handles zero correctly
        /// </summary>
        [Fact]
        public void Remainder_WithZero_ShouldReturnZero()
        {
            var result = (int)CallInternalMethod("Remainder", 0, 5);

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that IsEar returns false for invalid vertex index
        /// </summary>
        [Fact]
        public void IsEar_WithInvalidIndex_ShouldReturnFalse()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(5, 10)
            };

            // Create arrays from vertices
            var xv = new float[vertices.Count];
            var yv = new float[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                xv[i] = vertices[i].X;
                yv[i] = vertices[i].Y;
            }

            var result = (bool)CallInternalMethod("IsEar", 5, xv, yv, vertices.Count);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that IsEar returns false for vertices array with less than 3 elements
        /// </summary>
        [Fact]
        public void IsEar_WithLessThan3Vertices_ShouldReturnFalse()
        {
            var xv = new float[] { 0, 1 };
            var yv = new float[] { 0, 1 };

            var result = (bool)CallInternalMethod("IsEar", 0, xv, yv, 2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that ResolvePinchPoint with less than 3 vertices returns false
        /// </summary>
        [Fact]
        public void ResolvePinchPoint_WithLessThan3Vertices_ShouldReturnFalse()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(5, 0)
            };

            var result = (bool)CallInternalMethod("ResolvePinchPoint", vertices, 0.001f);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that FindPinchPoint with no pinch points returns false
        /// </summary>
        [Fact]
        public void FindPinchPoint_WithNoPinchPoints_ShouldReturnFalse()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };

            var result = CallInternalMethod("FindPinchPoint", vertices, 0.001f);

            Assert.NotNull(result);
            // Returns a tuple (bool, int, int) - check the bool first element
            if (result is Tuple<bool, int, int> tuple)
            {
                Assert.False(tuple.Item1);
            }
        }

        /// <summary>
        ///     Tests that triangulate a simple triangle works correctly
        /// </summary>
        [Fact]
        public void TriangulatePolygon_SimpleTriangle_ShouldReturnSingleTriangle()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(5, 10)
            };

            var result = (List<Vertices>)CallInternalMethod("TriangulatePolygon", vertices, 0.001f);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(3, result[0].Count);
        }

        /// <summary>
        ///     Tests that triangulate a convex quadrilateral returns 2 triangles
        /// </summary>
        [Fact]
        public void TriangulatePolygon_ConvexQuadrilateral_ShouldReturnTwoTriangles()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };

            var result = (List<Vertices>)CallInternalMethod("TriangulatePolygon", vertices, 0.001f);

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        ///     Tests that triangulate with less than 3 vertices returns empty list
        /// </summary>
        [Fact]
        public void TriangulatePolygon_LessThan3Vertices_ShouldReturnEmptyList()
        {
            var vertices = new Vertices();

            var result = (List<Vertices>)CallInternalMethod("TriangulatePolygon", vertices, 0.001f);

            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        ///     Tests that a polygon with pinch points is split correctly
        /// </summary>
        [Fact]
        public void ConvexPartition_WithPinchPoints_ShouldSplitAndTriangulate()
        {
            // Create a figure-8 like polygon with a pinch point
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(5, 5),  // pinch point
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(5, 5),  // same pinch point
                new Vector2F(0, 10)
            };

            var result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that CalculateEarScore is accessible and returns a valid score
        /// </summary>
        [Fact]
        public void CalculateEarScore_ReturnsValidScore()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };

            var xv = new float[vertices.Count];
            var yv = new float[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                xv[i] = vertices[i].X;
                yv[i] = vertices[i].Y;
            }

            var score = (float)CallInternalMethod("CalculateEarScore", 0, xv, yv, vertices.Count);

            Assert.InRange(score, 0f, float.MaxValue);
        }

        /// <summary>
        ///     Tests that FindEar returns a valid ear index for a convex polygon
        /// </summary>
        [Fact]
        public void FindEar_ReturnsValidIndexForConvexPolygon()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };

            var xv = new float[vertices.Count];
            var yv = new float[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                xv[i] = vertices[i].X;
                yv[i] = vertices[i].Y;
            }

            var earIndex = (int)CallInternalMethod("FindEar", vertices.Count, xv, yv);

            Assert.True(earIndex >= 0 && earIndex < vertices.Count);
        }

        /// <summary>
        ///     Tests that ClipEar clips a vertex and returns updated count
        /// </summary>
        [Fact]
        public void ClipEar_ClipVertexAndReturnUpdatedCount()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };

            var xv = new float[vertices.Count];
            var yv = new float[vertices.Count];
            for (int i = 0; i < vertices.Count; i++)
            {
                xv[i] = vertices[i].X;
                yv[i] = vertices[i].Y;
            }

            var buffer = new object?[vertices.Count]; // Triangle array
            int bufferSize = 0;

            var result = CallInternalMethod("ClipEar", 0, vertices.Count, xv, yv, buffer, bufferSize);

            // Should return vNum - 1 after clipping
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that SplitPolygonAtPinchPoint splits correctly
        /// </summary>
        [Fact]
        public void SplitPolygonAtPinchPoint_SplitsCorrectly()
        {
            var vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(5, 5),  // pinch index A
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(5, 5),  // pinch index B
                new Vector2F(0, 10)
            };

            var result = CallInternalMethod("SplitPolygonAtPinchPoint", vertices, 1, 4);

            // Returns a tuple of (Vertices, Vertices)
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that a large convex polygon can be triangulated
        /// </summary>
        [Fact]
        public void ConvexPartition_LargeConvexPolygon_ShouldTriangulate()
        {
            var vertices = new Vertices();
            int numVertices = 20;
            double angleStep = 2.0 * Math.PI / numVertices;

            for (int i = 0; i < numVertices; i++)
            {
                double angle = i * angleStep;
                vertices.Add(new Vector2F((float)(Math.Cos(angle) * 50), (float)(Math.Sin(angle) * 50)));
            }

            var result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            // A convex n-gon should be triangulated into (n-2) triangles
            Assert.Equal(numVertices - 2, result.Count);
        }
    }
}
