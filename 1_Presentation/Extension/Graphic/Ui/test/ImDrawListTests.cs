// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListTests.cs
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
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Tests for the <see cref="ImDrawList" /> struct.
    /// </summary>
    public class ImDrawListTests
    {
        /// <summary>
        ///     Verifies that default values are zero.
        /// </summary>
        [Fact]
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
        ///     Verifies that ImVector properties round-trip.
        /// </summary>
        [Fact]
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
        [Fact]
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
        ///     Verifies that flags, fringe scale, cmd header and splitter round-trip.
        /// </summary>
        [Fact]
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

        /// <summary>
        ///     Verifies that all writable properties can be written and read back.
        /// </summary>
        [Fact]
        public void AllProperties_WriteAndReadBack()
        {
            ImDrawList drawList = new ImDrawList();
            ImVector cmdBuffer = new ImVector();
            ImVector idxBuffer = new ImVector();
            ImVector vtxBuffer = new ImVector();
            ImVector clipRectStack = new ImVector();
            ImVector textureIdStack = new ImVector();
            ImVector path = new ImVector();
            ImDrawCmdHeader cmdHeader = new ImDrawCmdHeader();
            ImDrawListSplitter splitter = new ImDrawListSplitter();

            drawList.CmdBuffer = cmdBuffer;
            drawList.IdxBuffer = idxBuffer;
            drawList.VtxBuffer = vtxBuffer;
            drawList.Flags = ImDrawListFlags.AntiAliasedLines;
            drawList.VtxCurrentIdx = 100u;
            drawList.Data = new IntPtr(123);
            drawList.OwnerName = new IntPtr(123);
            drawList.VtxWritePtr = new IntPtr(123);
            drawList.IdxWritePtr = new IntPtr(123);
            drawList.ClipRectStack = clipRectStack;
            drawList.TextureIdStack = textureIdStack;
            drawList.Path = path;
            drawList.CmdHeader = cmdHeader;
            drawList.Splitter = splitter;
            drawList.FringeScale = 1.5f;

            Assert.Equal(cmdBuffer, drawList.CmdBuffer);
            Assert.Equal(idxBuffer, drawList.IdxBuffer);
            Assert.Equal(vtxBuffer, drawList.VtxBuffer);
            Assert.Equal(ImDrawListFlags.AntiAliasedLines, drawList.Flags);
            Assert.Equal(100u, drawList.VtxCurrentIdx);
            Assert.Equal(new IntPtr(123), drawList.Data);
            Assert.Equal(new IntPtr(123), drawList.OwnerName);
            Assert.Equal(new IntPtr(123), drawList.VtxWritePtr);
            Assert.Equal(new IntPtr(123), drawList.IdxWritePtr);
            Assert.Equal(clipRectStack, drawList.ClipRectStack);
            Assert.Equal(textureIdStack, drawList.TextureIdStack);
            Assert.Equal(path, drawList.Path);
            Assert.Equal(cmdHeader, drawList.CmdHeader);
            Assert.Equal(splitter, drawList.Splitter);
            Assert.Equal(1.5f, drawList.FringeScale, 5);
        }
    }
}
