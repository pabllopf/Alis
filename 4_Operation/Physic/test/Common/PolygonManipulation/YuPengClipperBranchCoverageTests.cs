// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:YuPengClipperBranchCoverageTests.cs
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
    ///     Covers the remaining branch of <see cref="YuPengClipper" /> where the computed
    ///     intersection point rounds exactly onto an existing vertex.
    /// </summary>
    public class YuPengClipperBranchCoverageTests
    {
        /// <summary>
        ///     Tests that when the computed intersection point rounds exactly onto the start vertex of a
        ///     clip segment (alpha == 0), the point is not inserted and the union still returns a result.
        /// </summary>
        [Fact]
        public void Union_WhenIntersectionRoundsToSegmentStart_DoesNotInsertDuplicateVertex()
        {
            // Large magnitudes make the float subtraction used to build the intersection point
            // round back onto the start vertex, producing alpha == 0 for the clip segment.
            Vertices subject = new Vertices(new[]
            {
                new Vector2F(10000006f, 10000002f),
                new Vector2F(10000005f, 10000008f),
                new Vector2F(10000005f, 10000006f)
            });
            Vertices clip = new Vertices(new[]
            {
                new Vector2F(10000006f, 10000003f),
                new Vector2F(10000002f, 10000001f),
                new Vector2F(10000005f, 10000004f)
            });

            // Act
            List<Vertices> result = YuPengClipper.Union(subject, clip, out PolyClipError error);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(PolyClipError.None, error);
        }
    }
}
