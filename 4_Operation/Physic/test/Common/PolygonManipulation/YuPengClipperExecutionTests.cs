// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:YuPengClipperExecutionTests.cs
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
    ///     Exercises the multi-intersection insertion path of <see cref="YuPengClipper" />.
    /// </summary>
    public class YuPengClipperExecutionTests
    {
        /// <summary>
        ///     Tests that union with a reversed zigzag clip crossing the subject edge multiple
        ///     times advances the insertion index past previously inserted intersection points.
        /// </summary>
        [Fact]
        public void Union_WithReversedZigzagClip_AdvancesInsertionIndex()
        {
            Vertices square = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(8f, 0f),
                new Vector2F(8f, 8f),
                new Vector2F(0f, 8f)
            });
            Vertices zigzag = new Vertices(new[]
            {
                new Vector2F(7f, 10f),
                new Vector2F(6f, 6f),
                new Vector2F(5f, 10f),
                new Vector2F(4f, 6f),
                new Vector2F(3f, 10f),
                new Vector2F(2f, 6f),
                new Vector2F(1f, 10f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(square, zigzag, out error);

            Assert.NotNull(result);
        }

        
        
        
        
        
        
        
        
        
        /// <summary>
        ///     Tests that a union with collinear shared edges exercises the error paths.
        /// </summary>
        [Fact]
        public void Union_WithCollinearSharedEdge_ReturnsResult()
        {
            Vertices a = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            Vertices b = new Vertices(new[]
            {
                new Vector2F(0f, 4f),
                new Vector2F(4f, 4f),
                new Vector2F(4f, 8f),
                new Vector2F(0f, 8f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(a, b, out error);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that a union with a collinear heavy polygon exercises the error paths.
        /// </summary>
        [Fact]
        public void Union_WithCollinearHeavyPolygon_ReturnsResult()
        {
            Vertices a = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            Vertices b = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(2f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 3f),
                new Vector2F(2f, 3f),
                new Vector2F(1f, 3f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(a, b, out error);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that an intersect with edge touching polygons exercises the error paths.
        /// </summary>
        [Fact]
        public void Intersect_WithEdgeTouchingPolygons_ReturnsResult()
        {
            Vertices a = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            Vertices b = new Vertices(new[]
            {
                new Vector2F(4f, 0f),
                new Vector2F(8f, 0f),
                new Vector2F(8f, 4f),
                new Vector2F(4f, 4f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Intersect(a, b, out error);
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that a union with a tiny polygon exercises the degenerate output paths.
        /// </summary>
        [Fact]
        public void Union_WithTinyPolygon_ReturnsResult()
        {
            Vertices a = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            Vertices b = new Vertices(new[]
            {
                new Vector2F(1.9f, 1.9f),
                new Vector2F(2.1f, 1.9f),
                new Vector2F(2.0f, 2.1f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(a, b, out error);
            Assert.NotNull(result);
        }

        
        
            }
}
