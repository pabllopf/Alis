

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
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