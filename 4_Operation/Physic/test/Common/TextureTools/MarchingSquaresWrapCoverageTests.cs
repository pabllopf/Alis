// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquaresWrapCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    ///     The marching squares wrap coverage tests class
    /// </summary>
    public class MarchingSquaresWrapCoverageTests
    {
        /// <summary>
        ///     Tests that comb left wraps the insertion iterator when the match is at the last polygon vertex.
        /// </summary>
        [Fact]
        public void CombLeft_WithMatchAtLastVertex_WrapsIterator()
        {
            MarchingSquares.GeomPoly polya = new MarchingSquares.GeomPoly();
            MarchingSquares.GeomPoly polyb = new MarchingSquares.GeomPoly();
            polya.Points.Add(new Vector2F(5, 5));
            polya.Points.Add(new Vector2F(2, 2));
            polya.Points.Add(new Vector2F(1, 1));
            polya.Length = 3;
            polyb.Points.Add(new Vector2F(9, 9));
            polyb.Points.Add(new Vector2F(10, 10));
            polyb.Points.Add(new Vector2F(5, 5));
            polyb.Length = 3;

            MarchingSquares.CombLeft(ref polya, ref polyb);

            Assert.Equal(4, polya.Length);
            Assert.True(polyb.Points.Empty());
        }
    }
}