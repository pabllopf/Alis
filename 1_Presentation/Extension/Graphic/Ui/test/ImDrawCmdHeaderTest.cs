// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmdHeaderTest.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw cmd header test class
    /// </summary>
    public class ImDrawCmdHeaderTest
    {
        /// <summary>
        ///     Tests that clip rect should be initialized correctly
        /// </summary>
        [Fact]
        public void ClipRect_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmdHeader drawCmdHeader = new ImDrawCmdHeader {ClipRect = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f)};

            // Act
            Vector4F clipRect = drawCmdHeader.ClipRect;

            // Assert
            Assert.Equal(new Vector4F(1.0f, 2.0f, 3.0f, 4.0f), clipRect);
        }

        /// <summary>
        ///     Tests that texture id should be initialized correctly
        /// </summary>
        [Fact]
        public void TextureId_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmdHeader drawCmdHeader = new ImDrawCmdHeader {TextureId = new IntPtr(123)};

            // Act
            IntPtr textureId = drawCmdHeader.TextureId;

            // Assert
            Assert.Equal(new IntPtr(123), textureId);
        }

        /// <summary>
        ///     Tests that vtx offset should be initialized correctly
        /// </summary>
        [Fact]
        public void VtxOffset_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmdHeader drawCmdHeader = new ImDrawCmdHeader {VtxOffset = 10};

            // Act
            uint vtxOffset = drawCmdHeader.VtxOffset;

            // Assert
            Assert.Equal(10u, vtxOffset);
        }
    }
}