// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawVertRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw vert remaining coverage tests class
    /// </summary>
    public class ImDrawVertRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
        {
            ImDrawVert vert = default;
            Assert.Equal(0f, vert.Pos.X, 5);
            Assert.Equal(0f, vert.Pos.Y, 5);
            Assert.Equal(0f, vert.Uv.X, 5);
            Assert.Equal(0f, vert.Uv.Y, 5);
            Assert.Equal(0u, vert.Col);
        }

        /// <summary>
        ///     Tests that vector properties round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void VectorProperties_RoundTrip()
        {
            ImDrawVert vert = default;
            vert.Pos = new Vector2F(1f, 2f);
            vert.Uv = new Vector2F(3f, 4f);
            Assert.Equal(1f, vert.Pos.X, 5);
            Assert.Equal(2f, vert.Pos.Y, 5);
            Assert.Equal(3f, vert.Uv.X, 5);
            Assert.Equal(4f, vert.Uv.Y, 5);
        }

        /// <summary>
        ///     Tests that col round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Col_RoundTrip()
        {
            ImDrawVert vert = default;
            vert.Col = 0xFFFFFFFFu;
            Assert.Equal(0xFFFFFFFFu, vert.Col);
        }
    }
}
