// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmdHeaderRemainingCoverageTests.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw cmd header remaining coverage tests class
    /// </summary>
    public class ImDrawCmdHeaderRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default values are zero
        /// </summary>
        [Fact]
        public void Default_ValuesAreZero()
        {
            ImDrawCmdHeader header = default;
            Assert.Equal(0f, header.ClipRect.X, 5);
            Assert.Equal(0f, header.ClipRect.Y, 5);
            Assert.Equal(0f, header.ClipRect.Z, 5);
            Assert.Equal(0f, header.ClipRect.W, 5);
            Assert.Equal(IntPtr.Zero, header.TextureId);
            Assert.Equal(0u, header.VtxOffset);
        }

        /// <summary>
        ///     Tests that clip rect round trip
        /// </summary>
        [Fact]
        public void ClipRect_RoundTrip()
        {
            ImDrawCmdHeader header = default;
            Vector4F expected = new Vector4F(1f, 2f, 3f, 4f);
            header.ClipRect = expected;
            Assert.Equal(1f, header.ClipRect.X, 5);
            Assert.Equal(2f, header.ClipRect.Y, 5);
            Assert.Equal(3f, header.ClipRect.Z, 5);
            Assert.Equal(4f, header.ClipRect.W, 5);
        }

        /// <summary>
        ///     Tests that texture id and vtx offset round trip
        /// </summary>
        [Fact]
        public void TextureIdAndVtxOffset_RoundTrip()
        {
            ImDrawCmdHeader header = default;
            header.TextureId = new IntPtr(42);
            header.VtxOffset = 123u;
            Assert.Equal(new IntPtr(42), header.TextureId);
            Assert.Equal(123u, header.VtxOffset);
        }
    }
}
