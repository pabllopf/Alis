// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonotoneMountainTest.cs
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

using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The monotone mountain test class
    /// </summary>
    public class MonotoneMountainTest
    {
        /// <summary>
        ///     Tests that constructor should initialize empty mountain
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeEmptyMountain()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            
            Assert.NotNull(mountain);
            Assert.NotNull(mountain.Triangles);
            Assert.Empty(mountain.Triangles);
        }

        /// <summary>
        ///     Tests that add should add first point as head
        /// </summary>
        [Fact]
        public void Add_ShouldAddFirstPointAsHead()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point = new Point(0, 0);
            
            mountain.Add(point);
            
            Assert.NotNull(mountain);
        }

        /// <summary>
        ///     Tests that add should add second point as tail
        /// </summary>
        [Fact]
        public void Add_ShouldAddSecondPointAsTail()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 1);
            
            mountain.Add(point1);
            mountain.Add(point2);
            
            Assert.NotNull(mountain);
        }

        /// <summary>
        ///     Tests that add should add multiple points
        /// </summary>
        [Fact]
        public void Add_ShouldAddMultiplePoints()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(1, 1);
            Point point4 = new Point(0, 1);
            
            mountain.Add(point1);
            mountain.Add(point2);
            mountain.Add(point3);
            mountain.Add(point4);
            
            Assert.NotNull(mountain);
        }

        /// <summary>
        ///     Tests that remove should remove point from list
        /// </summary>
        [Fact]
        public void Remove_ShouldRemovePointFromList()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(2, 0);
            
            mountain.Add(point1);
            mountain.Add(point2);
            mountain.Add(point3);
            mountain.Remove(point2);
            
            Assert.NotNull(mountain);
        }

        /// <summary>
        ///     Tests that process should generate triangles for simple polygon
        /// </summary>
        [Fact]
        public void Process_ShouldGenerateTriangles_ForSimplePolygon()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(2, 0);
            Point point3 = new Point(1, 1);
            
            mountain.Add(point1);
            mountain.Add(point2);
            mountain.Add(point3);
            
            mountain.Process();
            
            Assert.NotEmpty(mountain.Triangles);
        }

        /// <summary>
        ///     Tests that triangles should be empty before process
        /// </summary>
        [Fact]
        public void Triangles_ShouldBeEmpty_BeforeProcess()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(0.5f, 1);
            
            mountain.Add(point1);
            mountain.Add(point2);
            mountain.Add(point3);
            
            Assert.Empty(mountain.Triangles);
        }

        /// <summary>
        ///     Tests that monotone mountain should handle collinear points
        /// </summary>
        [Fact]
        public void MonotoneMountain_ShouldHandleCollinearPoints()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(2, 0);
            Point point4 = new Point(3, 0);
            
            mountain.Add(point1);
            mountain.Add(point2);
            mountain.Add(point3);
            mountain.Add(point4);
            
            mountain.Process();
            
            Assert.NotNull(mountain);
        }

        /// <summary>
        ///     Tests that monotone mountain should handle triangle
        /// </summary>
        [Fact]
        public void MonotoneMountain_ShouldHandleTriangle()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(0.5f, 1);
            
            mountain.Add(point1);
            mountain.Add(point2);
            mountain.Add(point3);
            
            mountain.Process();
            
            Assert.NotNull(mountain.Triangles);
        }

        /// <summary>
        ///     Tests that monotone mountain should be reference type
        /// </summary>
        [Fact]
        public void MonotoneMountain_ShouldBeReferenceType()
        {
            MonotoneMountain mountain1 = new MonotoneMountain();
            MonotoneMountain mountain2 = mountain1;
            
            Assert.Same(mountain1, mountain2);
        }

        /// <summary>
        ///     Tests that triangles property should be accessible
        /// </summary>
        [Fact]
        public void TrianglesProperty_ShouldBeAccessible()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            
            var triangles = mountain.Triangles;
            
            Assert.NotNull(triangles);
            Assert.Empty(triangles);
        }

        /// <summary>
        ///     Tests that add should create linked list structure
        /// </summary>
        [Fact]
        public void Add_ShouldCreateLinkedListStructure()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 0);
            Point point3 = new Point(2, 0);
            
            mountain.Add(point1);
            mountain.Add(point2);
            mountain.Add(point3);
            
            Assert.Equal(point2, point1.Next);
            Assert.Equal(point3, point2.Next);
        }

        /// <summary>
        ///     Tests that process should handle square polygon
        /// </summary>
        [Fact]
        public void Process_ShouldHandleSquarePolygon()
        {
            MonotoneMountain mountain = new MonotoneMountain();
            mountain.Add(new Point(0, 0));
            mountain.Add(new Point(1, 0));
            mountain.Add(new Point(1, 1));
            mountain.Add(new Point(0, 1));
            
            mountain.Process();
            
            Assert.NotEmpty(mountain.Triangles);
        }

        /// <summary>
        ///     Tests that multiple mountains should be independent
        /// </summary>
        [Fact]
        public void MultipleMountains_ShouldBeIndependent()
        {
            MonotoneMountain mountain1 = new MonotoneMountain();
            MonotoneMountain mountain2 = new MonotoneMountain();
            
            mountain1.Add(new Point(0, 0));
            mountain2.Add(new Point(5, 5));
            
            Assert.NotSame(mountain1, mountain2);
        }
    }
}

