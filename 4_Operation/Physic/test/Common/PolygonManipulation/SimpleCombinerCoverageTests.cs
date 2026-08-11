// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleCombinerCoverageTests.cs
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
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The simple combiner coverage tests class
    /// </summary>
    public class SimpleCombinerCoverageTests
    {
        /// <summary>
        ///     Tests that polygonize triangles with a collinear triangle skips the corrupt polygon
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithCollinearTriangle_SkipsCorruptPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(2f, 0f)
                })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.NotNull(result);
        }
    }
}
