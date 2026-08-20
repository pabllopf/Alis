// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="ImDrawList" /> struct.
    /// </summary>
    public class ImDrawListRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ValuesAreZero()
        {
            ImDrawList drawList = default;
            Assert.Equal(0u, drawList.VtxCurrentIdx);
            Assert.Equal(IntPtr.Zero, drawList.Data);
            Assert.Equal(IntPtr.Zero, drawList.OwnerName);
            Assert.Equal(IntPtr.Zero, drawList.VtxWritePtr);
            Assert.Equal(IntPtr.Zero, drawList.IdxWritePtr);
            Assert.Equal(0f, drawList.FringeScale, 5);
            Assert.Equal(ImDrawListFlags.None, drawList.Flags);
        }

        /// <summary>
        ///     Verifies that ImVector properties round-trip via default.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImVectorProperties_RoundTrip()
        {
            ImDrawList drawList = default;
            ImVector v = default;
            drawList.CmdBuffer = v;
            drawList.IdxBuffer = v;
            drawList.VtxBuffer = v;
            drawList.ClipRectStack = v;
            drawList.TextureIdStack = v;
            drawList.Path = v;
            Assert.Equal(v, drawList.CmdBuffer);
            Assert.Equal(v, drawList.IdxBuffer);
            Assert.Equal(v, drawList.VtxBuffer);
            Assert.Equal(v, drawList.ClipRectStack);
            Assert.Equal(v, drawList.TextureIdStack);
            Assert.Equal(v, drawList.Path);
        }

        /// <summary>
        ///     Verifies that integer and pointer properties round-trip.
        /// </summary>
         [RequireCImguiSystemFact]
        public void IntPtrAndUint_RoundTrip()
        {
            ImDrawList drawList = default;
            drawList.VtxCurrentIdx = 42u;
            drawList.Data = new IntPtr(100);
            drawList.OwnerName = new IntPtr(200);
            drawList.VtxWritePtr = new IntPtr(300);
            drawList.IdxWritePtr = new IntPtr(400);
            Assert.Equal(42u, drawList.VtxCurrentIdx);
            Assert.Equal(new IntPtr(100), drawList.Data);
            Assert.Equal(new IntPtr(200), drawList.OwnerName);
            Assert.Equal(new IntPtr(300), drawList.VtxWritePtr);
            Assert.Equal(new IntPtr(400), drawList.IdxWritePtr);
        }

        /// <summary>
        ///     Verifies that Flags, FringeScale, CmdHeader, and Splitter round-trip.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Flags_FringeScale_CmdHeader_Splitter_RoundTrip()
        {
            ImDrawList drawList = default;
            drawList.Flags = ImDrawListFlags.AntiAliasedLines | ImDrawListFlags.AllowVtxOffset;
            drawList.FringeScale = 1.5f;
            ImDrawCmdHeader header = default;
            ImDrawListSplitter splitter = default;
            drawList.CmdHeader = header;
            drawList.Splitter = splitter;
            Assert.Equal(ImDrawListFlags.AntiAliasedLines | ImDrawListFlags.AllowVtxOffset, drawList.Flags);
            Assert.Equal(1.5f, drawList.FringeScale, 5);
            Assert.Equal(header, drawList.CmdHeader);
            Assert.Equal(splitter, drawList.Splitter);
        }
    }
}
