// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmdHeaderCoverageTests.cs
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
    ///     The im draw cmd header coverage tests class
    /// </summary>
    public class ImDrawCmdHeaderCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImDrawCmdHeader_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImDrawCmdHeader header = default(ImDrawCmdHeader);

            Assert.Equal(0f, header.ClipRect.X, 5);
            Assert.Equal(0f, header.ClipRect.Y, 5);
            Assert.Equal(0f, header.ClipRect.Z, 5);
            Assert.Equal(0f, header.ClipRect.W, 5);
            Assert.Equal(IntPtr.Zero, header.TextureId);
            Assert.Equal(0u, header.VtxOffset);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImDrawCmdHeader_SetProperties_StoresValuesCorrectly()
        {
            ImDrawCmdHeader header = new ImDrawCmdHeader
            {
                ClipRect = new Vector4F(1f, 2f, 3f, 4f),
                TextureId = new IntPtr(5),
                VtxOffset = 6u
            };

            Assert.Equal(1f, header.ClipRect.X, 5);
            Assert.Equal(2f, header.ClipRect.Y, 5);
            Assert.Equal(3f, header.ClipRect.Z, 5);
            Assert.Equal(4f, header.ClipRect.W, 5);
            Assert.Equal(new IntPtr(5), header.TextureId);
            Assert.Equal(6u, header.VtxOffset);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImDrawCmdHeader_IsValueType_CopyIsIndependent()
        {
            ImDrawCmdHeader original = new ImDrawCmdHeader { VtxOffset = 10u };
            ImDrawCmdHeader copy = original;

            copy.VtxOffset = 20u;

            Assert.Equal(10u, original.VtxOffset);
            Assert.Equal(20u, copy.VtxOffset);
        }
    }
}