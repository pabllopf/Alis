// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulatorTest.cs
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
using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The triangulator test class
    /// </summary>
    public class TriangulatorTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with polyline
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithPolyline()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            Assert.NotNull(triangulator);
            Assert.NotNull(triangulator.Triangles);
            Assert.NotNull(triangulator.Trapezoids);
        }

        /// <summary>
        ///     Tests that triangulator should generate triangles for square
        /// </summary>
        [Fact]
        public void Triangulator_ShouldGenerateTriangles_ForSquare()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            Assert.NotEmpty(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangulator should generate trapezoids
        /// </summary>
        [Fact]
        public void Triangulator_ShouldGenerateTrapezoids()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            Assert.NotNull(triangulator.Trapezoids);
        }

        /// <summary>
        ///     Tests that triangulator should handle triangle polygon
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandleTrianglePolygon()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(5, 10)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            Assert.NotNull(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangulator should handle pentagon
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandlePentagon()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(12, 5),
                new Point(5, 12),
                new Point(-2, 5)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            Assert.NotEmpty(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangulator should accept custom sheer value
        /// </summary>
        [Fact]
        public void Triangulator_ShouldAcceptCustomSheerValue()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.01f);
            
            Assert.NotNull(triangulator);
        }

        /// <summary>
        ///     Tests that triangulator should handle zero sheer value
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandleZeroSheerValue()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(10, 0),
                new Point(10, 10),
                new Point(0, 10)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.0f);
            
            Assert.NotNull(triangulator);
        }

        /// <summary>
        ///     Tests that triangulator should handle negative coordinates
        /// </summary>
        [Fact]
        public void Triangulator_ShouldHandleNegativeCoordinates()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(-10, -10),
                new Point(10, -10),
                new Point(10, 10),
                new Point(-10, 10)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            Assert.NotEmpty(triangulator.Triangles);
        }

        /// <summary>
        ///     Tests that triangles property should be accessible
        /// </summary>
        [Fact]
        public void TrianglesProperty_ShouldBeAccessible()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(5, 0),
                new Point(5, 5)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            var triangles = triangulator.Triangles;
            
            Assert.NotNull(triangles);
        }

        /// <summary>
        ///     Tests that trapezoids property should be accessible
        /// </summary>
        [Fact]
        public void TrapezoidsProperty_ShouldBeAccessible()
        {
            List<Point> polyLine = new List<Point>
            {
                new Point(0, 0),
                new Point(5, 0),
                new Point(5, 5)
            };
            
            Triangulator triangulator = new Triangulator(polyLine, 0.001f);
            
            var trapezoids = triangulator.Trapezoids;
            
            Assert.NotNull(trapezoids);
        }
    }
}

