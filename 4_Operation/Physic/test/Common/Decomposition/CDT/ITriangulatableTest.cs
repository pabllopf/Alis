// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ITriangulatableTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT
{
    /// <summary>
    ///     The i triangulatable test class
    /// </summary>
    public class ITriangulatableTest
    {
        /// <summary>
        ///     The test triangulatable class
        /// </summary>
        /// <seealso cref="ITriangulatable" />
        private class TestTriangulatable : ITriangulatable
        {
            /// <summary>
            ///     The points
            /// </summary>
            private readonly List<TriangulationPoint> points = new List<TriangulationPoint>();

            /// <summary>
            ///     The triangles
            /// </summary>
            private readonly List<DelaunayTriangle> triangles = new List<DelaunayTriangle>();

            /// <summary>
            ///     Gets the value of the get points
            /// </summary>
            public IList<TriangulationPoint> GetPoints => points;

            /// <summary>
            ///     Gets the value of the get triangles
            /// </summary>
            public IList<DelaunayTriangle> GetTriangles => triangles;

            /// <summary>
            ///     Gets the value of the triangulation mode
            /// </summary>
            public TriangulationMode TriangulationMode => TriangulationMode.Polygon;

            /// <summary>
            ///     Prepares the triangulation using the specified tcx
            /// </summary>
            /// <param name="tcx">The tcx</param>
            public void PrepareTriangulation(TriangulationContext tcx) { }

            /// <summary>
            ///     Adds the triangle using the specified t
            /// </summary>
            /// <param name="t">The t</param>
            public void AddTriangle(DelaunayTriangle t)
            {
                triangles.Add(t);
            }

            /// <summary>
            ///     Adds the triangles using the specified list
            /// </summary>
            /// <param name="list">The list</param>
            public void AddTriangles(IEnumerable<DelaunayTriangle> list)
            {
                triangles.AddRange(list);
            }

            /// <summary>
            ///     Clears the triangles
            /// </summary>
            public void ClearTriangles()
            {
                triangles.Clear();
            }
        }

        /// <summary>
        ///     Tests that i triangulatable should be interface
        /// </summary>
        [Fact]
        public void ITriangulatable_ShouldBeInterface()
        {
            var type = typeof(ITriangulatable);
            
            Assert.True(type.IsInterface);
        }

        /// <summary>
        ///     Tests that test triangulatable should implement interface
        /// </summary>
        [Fact]
        public void TestTriangulatable_ShouldImplementInterface()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            
            Assert.IsAssignableFrom<ITriangulatable>(triangulatable);
        }

        /// <summary>
        ///     Tests that get points should return collection
        /// </summary>
        [Fact]
        public void GetPoints_ShouldReturnCollection()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            
            IList<TriangulationPoint> points = triangulatable.GetPoints;
            
            Assert.NotNull(points);
        }

        /// <summary>
        ///     Tests that get triangles should return collection
        /// </summary>
        [Fact]
        public void GetTriangles_ShouldReturnCollection()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            
            IList<DelaunayTriangle> triangles = triangulatable.GetTriangles;
            
            Assert.NotNull(triangles);
        }

        /// <summary>
        ///     Tests that add triangle should add to collection
        /// </summary>
        [Fact]
        public void AddTriangle_ShouldAddToCollection()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            
            triangulatable.AddTriangle(triangle);
            
            Assert.Single(triangulatable.GetTriangles);
        }

        /// <summary>
        ///     Tests that add triangles should add multiple triangles
        /// </summary>
        [Fact]
        public void AddTriangles_ShouldAddMultipleTriangles()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            List<DelaunayTriangle> triangles = new List<DelaunayTriangle>
            {
                new DelaunayTriangle(new TriangulationPoint(0, 0), new TriangulationPoint(1, 0), new TriangulationPoint(0, 1)),
                new DelaunayTriangle(new TriangulationPoint(1, 0), new TriangulationPoint(1, 1), new TriangulationPoint(0, 1))
            };
            
            triangulatable.AddTriangles(triangles);
            
            Assert.Equal(2, triangulatable.GetTriangles.Count);
        }

        /// <summary>
        ///     Tests that clear triangles should empty collection
        /// </summary>
        [Fact]
        public void ClearTriangles_ShouldEmptyCollection()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangulatable.AddTriangle(triangle);
            
            triangulatable.ClearTriangles();
            
            Assert.Empty(triangulatable.GetTriangles);
        }

        /// <summary>
        ///     Tests that triangulation mode should be accessible
        /// </summary>
        [Fact]
        public void TriangulationMode_ShouldBeAccessible()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            
            TriangulationMode mode = triangulatable.TriangulationMode;
            
            Assert.Equal(TriangulationMode.Polygon, mode);
        }

        /// <summary>
        ///     Tests that prepare triangulation should be callable
        /// </summary>
        [Fact]
        public void PrepareTriangulation_ShouldBeCallable()
        {
            TestTriangulatable triangulatable = new TestTriangulatable();
            TriangulationContext context = null;
            
            triangulatable.PrepareTriangulation(context);
            
            Assert.NotNull(triangulatable);
        }
    }
}

