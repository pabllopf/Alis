// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListTest.cs
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
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im draw list test class
    /// </summary>
    	  
	 public class ImDrawListTest 
    {
        /// <summary>
        ///     Tests that cmd buffer should set and get correctly
        /// </summary>
        [Fact]
        public void CmdBuffer_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImVector cmdBuffer = new ImVector();
            drawList.CmdBuffer = cmdBuffer;
            Assert.Equal(cmdBuffer, drawList.CmdBuffer);
        }

        /// <summary>
        ///     Tests that idx buffer should set and get correctly
        /// </summary>
        [Fact]
        public void IdxBuffer_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImVector idxBuffer = new ImVector();
            drawList.IdxBuffer = idxBuffer;
            Assert.Equal(idxBuffer, drawList.IdxBuffer);
        }

        /// <summary>
        ///     Tests that vtx buffer should set and get correctly
        /// </summary>
        [Fact]
        public void VtxBuffer_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImVector vtxBuffer = new ImVector();
            drawList.VtxBuffer = vtxBuffer;
            Assert.Equal(vtxBuffer, drawList.VtxBuffer);
        }

        /// <summary>
        ///     Tests that flags should set and get correctly
        /// </summary>
        [Fact]
        public void Flags_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            drawList.Flags = ImDrawListFlags.AntiAliasedLines;
            Assert.Equal(ImDrawListFlags.AntiAliasedLines, drawList.Flags);
        }

        /// <summary>
        ///     Tests that vtx current idx should set and get correctly
        /// </summary>
        [Fact]
        public void VtxCurrentIdx_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            drawList.VtxCurrentIdx = 100;
            Assert.Equal(100u, drawList.VtxCurrentIdx);
        }

        /// <summary>
        ///     Tests that data should set and get correctly
        /// </summary>
        [Fact]
        public void Data_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            IntPtr data = new IntPtr(123);
            drawList.Data = data;
            Assert.Equal(data, drawList.Data);
        }

        /// <summary>
        ///     Tests that owner name should set and get correctly
        /// </summary>
        [Fact]
        public void OwnerName_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            IntPtr ownerName = new IntPtr(123);
            drawList.OwnerName = ownerName;
            Assert.Equal(ownerName, drawList.OwnerName);
        }

        /// <summary>
        ///     Tests that vtx write ptr should set and get correctly
        /// </summary>
        [Fact]
        public void VtxWritePtr_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            IntPtr vtxWritePtr = new IntPtr(123);
            drawList.VtxWritePtr = vtxWritePtr;
            Assert.Equal(vtxWritePtr, drawList.VtxWritePtr);
        }

        /// <summary>
        ///     Tests that idx write ptr should set and get correctly
        /// </summary>
        [Fact]
        public void IdxWritePtr_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            IntPtr idxWritePtr = new IntPtr(123);
            drawList.IdxWritePtr = idxWritePtr;
            Assert.Equal(idxWritePtr, drawList.IdxWritePtr);
        }

        /// <summary>
        ///     Tests that clip rect stack should set and get correctly
        /// </summary>
        [Fact]
        public void ClipRectStack_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImVector clipRectStack = new ImVector();
            drawList.ClipRectStack = clipRectStack;
            Assert.Equal(clipRectStack, drawList.ClipRectStack);
        }

        /// <summary>
        ///     Tests that texture id stack should set and get correctly
        /// </summary>
        [Fact]
        public void TextureIdStack_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImVector textureIdStack = new ImVector();
            drawList.TextureIdStack = textureIdStack;
            Assert.Equal(textureIdStack, drawList.TextureIdStack);
        }

        /// <summary>
        ///     Tests that path should set and get correctly
        /// </summary>
        [Fact]
        public void Path_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImVector path = new ImVector();
            drawList.Path = path;
            Assert.Equal(path, drawList.Path);
        }

        /// <summary>
        ///     Tests that cmd header should set and get correctly
        /// </summary>
        [Fact]
        public void CmdHeader_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImDrawCmdHeader cmdHeader = new ImDrawCmdHeader();
            drawList.CmdHeader = cmdHeader;
            Assert.Equal(cmdHeader, drawList.CmdHeader);
        }

        /// <summary>
        ///     Tests that splitter should set and get correctly
        /// </summary>
        [Fact]
        public void Splitter_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            ImDrawListSplitter splitter = new ImDrawListSplitter();
            drawList.Splitter = splitter;
            Assert.Equal(splitter, drawList.Splitter);
        }

        /// <summary>
        ///     Tests that fringe scale should set and get correctly
        /// </summary>
        [Fact]
        public void FringeScale_Should_SetAndGetCorrectly()
        {
            ImDrawList drawList = new ImDrawList();
            drawList.FringeScale = 1.5f;
            Assert.Equal(1.5f, drawList.FringeScale);
        }
    }
}