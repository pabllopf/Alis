// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawVertCoverageTests.cs
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
    ///     The im draw vert coverage tests class
    /// </summary>
    public class ImDrawVertCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImDrawVert_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImDrawVert vert = default(ImDrawVert);

            Assert.Equal(0f, vert.Pos.X, 5);
            Assert.Equal(0f, vert.Pos.Y, 5);
            Assert.Equal(0f, vert.Uv.X, 5);
            Assert.Equal(0f, vert.Uv.Y, 5);
            Assert.Equal(0u, vert.Col);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImDrawVert_SetProperties_StoresValuesCorrectly()
        {
            ImDrawVert vert = new ImDrawVert
            {
                Pos = new Vector2F(1f, 2f),
                Uv = new Vector2F(3f, 4f),
                Col = 5u
            };

            Assert.Equal(1f, vert.Pos.X, 5);
            Assert.Equal(2f, vert.Pos.Y, 5);
            Assert.Equal(3f, vert.Uv.X, 5);
            Assert.Equal(4f, vert.Uv.Y, 5);
            Assert.Equal(5u, vert.Col);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImDrawVert_IsValueType_CopyIsIndependent()
        {
            ImDrawVert original = new ImDrawVert { Col = 10u };
            ImDrawVert copy = original;

            copy.Col = 20u;

            Assert.Equal(10u, original.Col);
            Assert.Equal(20u, copy.Col);
        }
    }
}