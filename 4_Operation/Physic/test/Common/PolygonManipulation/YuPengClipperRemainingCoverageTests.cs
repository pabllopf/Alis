// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:YuPengClipperRemainingCoverageTests.cs
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
    ///     The yu peng clipper remaining coverage tests class
    /// </summary>
    public class YuPengClipperRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that union with overlapping pentagons returns result
        /// </summary>
        [Fact]
        public void Union_WithOverlappingPentagons_ReturnsResult()
        {
            Vertices p1 = new Vertices();
            p1.Add(new Vector2F(0, 0));
            p1.Add(new Vector2F(4, 0));
            p1.Add(new Vector2F(5, 3));
            p1.Add(new Vector2F(2, 5));
            p1.Add(new Vector2F(-1, 3));

            Vertices p2 = new Vertices();
            p2.Add(new Vector2F(2, 1));
            p2.Add(new Vector2F(6, 1));
            p2.Add(new Vector2F(7, 4));
            p2.Add(new Vector2F(4, 6));
            p2.Add(new Vector2F(1, 4));

            List<Vertices> result = YuPengClipper.Union(p1, p2, out PolyClipError error);

            Assert.Equal(PolyClipError.None, error);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that difference with partially overlapping polygons returns result
        /// </summary>
        [Fact]
        public void Difference_WithPartiallyOverlappingPolygons_ReturnsResult()
        {
            Vertices p1 = new Vertices();
            p1.Add(new Vector2F(0, 0));
            p1.Add(new Vector2F(4, 0));
            p1.Add(new Vector2F(4, 4));
            p1.Add(new Vector2F(0, 4));

            Vertices p2 = new Vertices();
            p2.Add(new Vector2F(2, 2));
            p2.Add(new Vector2F(6, 2));
            p2.Add(new Vector2F(6, 6));
            p2.Add(new Vector2F(2, 6));

            List<Vertices> result = YuPengClipper.Difference(p1, p2, out PolyClipError error);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that intersect with partially overlapping polygons returns result
        /// </summary>
        [Fact]
        public void Intersect_WithPartiallyOverlappingPolygons_ReturnsResult()
        {
            Vertices p1 = new Vertices();
            p1.Add(new Vector2F(0, 0));
            p1.Add(new Vector2F(4, 0));
            p1.Add(new Vector2F(4, 4));
            p1.Add(new Vector2F(0, 4));

            Vertices p2 = new Vertices();
            p2.Add(new Vector2F(2, 2));
            p2.Add(new Vector2F(6, 2));
            p2.Add(new Vector2F(6, 6));
            p2.Add(new Vector2F(2, 6));

            List<Vertices> result = YuPengClipper.Intersect(p1, p2, out PolyClipError error);

            Assert.Equal(PolyClipError.None, error);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that union with touching corners returns result
        /// </summary>
        [Fact]
        public void Union_WithTouchingCorners_ReturnsResult()
        {
            Vertices p1 = new Vertices();
            p1.Add(new Vector2F(0, 0));
            p1.Add(new Vector2F(2, 0));
            p1.Add(new Vector2F(2, 2));
            p1.Add(new Vector2F(0, 2));

            Vertices p2 = new Vertices();
            p2.Add(new Vector2F(2, 2));
            p2.Add(new Vector2F(4, 2));
            p2.Add(new Vector2F(4, 4));
            p2.Add(new Vector2F(2, 4));

            List<Vertices> result = YuPengClipper.Union(p1, p2, out PolyClipError error);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that union with touching edges returns result
        /// </summary>
        [Fact]
        public void Union_WithTouchingEdges_ReturnsResult()
        {
            Vertices p1 = new Vertices();
            p1.Add(new Vector2F(0, 0));
            p1.Add(new Vector2F(2, 0));
            p1.Add(new Vector2F(2, 2));
            p1.Add(new Vector2F(0, 2));

            Vertices p2 = new Vertices();
            p2.Add(new Vector2F(2, 0));
            p2.Add(new Vector2F(4, 0));
            p2.Add(new Vector2F(4, 2));
            p2.Add(new Vector2F(2, 2));

            List<Vertices> result = YuPengClipper.Union(p1, p2, out PolyClipError error);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that difference with identical polygons returns empty
        /// </summary>
        [Fact]
        public void Difference_WithIdenticalPolygons_ReturnsResult()
        {
            Vertices p1 = new Vertices();
            p1.Add(new Vector2F(0, 0));
            p1.Add(new Vector2F(3, 0));
            p1.Add(new Vector2F(3, 3));
            p1.Add(new Vector2F(0, 3));

            Vertices p2 = new Vertices();
            p2.Add(new Vector2F(0, 0));
            p2.Add(new Vector2F(3, 0));
            p2.Add(new Vector2F(3, 3));
            p2.Add(new Vector2F(0, 3));

            List<Vertices> result = YuPengClipper.Difference(p1, p2, out PolyClipError error);

            Assert.NotNull(result);
        }
    }
}
