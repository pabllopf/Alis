// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    /// The dt sweep test class
    /// </summary>
    public class DTSweepTest
    {
        /// <summary>
        /// Tests that dt sweep type should be accessible
        /// </summary>
        [Fact]
        public void DTSweep_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(DtSweep));
        }

        /// <summary>
        /// Verifies that a simple rectangle triangulates into two non-degenerate triangles.
        /// </summary>
        [Fact]
        public void DTSweep_TriangulatesRectangleIntoTwoTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(2.0f, 0.0f),
                new Vector2F(2.0f, 1.0f),
                new Vector2F(0.0f, 1.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.Equal(vertices.Count - 2, triangles.Count);
            foreach (Vertices triangle in triangles)
            {
                Assert.Equal(3, triangle.Count);
                Assert.True(triangle.GetArea() > 0.0f);
            }
        }
    }
}
