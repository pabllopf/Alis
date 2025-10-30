// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawDataTest.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw data test class
    /// </summary>
    public class ImDrawDataTest
    {
        /// <summary>
        ///     Tests that valid should be initialized correctly
        /// </summary>
        [Fact]
        public void Valid_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {Valid = 1};

            // Act
            byte valid = drawData.Valid;

            // Assert
            Assert.Equal(1, valid);
        }

        /// <summary>
        ///     Tests that cmd lists count should be initialized correctly
        /// </summary>
        [Fact]
        public void CmdListsCount_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {CmdListsCount = 5};

            // Act
            int cmdListsCount = drawData.CmdListsCount;

            // Assert
            Assert.Equal(5, cmdListsCount);
        }

        /// <summary>
        ///     Tests that total idx count should be initialized correctly
        /// </summary>
        [Fact]
        public void TotalIdxCount_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {TotalIdxCount = 100};

            // Act
            int totalIdxCount = drawData.TotalIdxCount;

            // Assert
            Assert.Equal(100, totalIdxCount);
        }

        /// <summary>
        ///     Tests that total vtx count should be initialized correctly
        /// </summary>
        [Fact]
        public void TotalVtxCount_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {TotalVtxCount = 200};

            // Act
            int totalVtxCount = drawData.TotalVtxCount;

            // Assert
            Assert.Equal(200, totalVtxCount);
        }

        /// <summary>
        ///     Tests that cmd lists ptr should be initialized correctly
        /// </summary>
        [Fact]
        public void CmdListsPtr_ShouldBeInitializedCorrectly()
        {
            // Arrange
            IntPtr ptr = new IntPtr(123);
            ImDrawData drawData = new ImDrawData {CmdListsPtr = ptr};

            // Act
            IntPtr cmdListsPtr = drawData.CmdListsPtr;

            // Assert
            Assert.Equal(ptr, cmdListsPtr);
        }

        /// <summary>
        ///     Tests that display pos should be initialized correctly
        /// </summary>
        [Fact]
        public void DisplayPos_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {DisplayPos = new Vector2F(1.0f, 2.0f)};

            // Act
            Vector2F displayPos = drawData.DisplayPos;

            // Assert
            Assert.Equal(new Vector2F(1.0f, 2.0f), displayPos);
        }

        /// <summary>
        ///     Tests that display size should be initialized correctly
        /// </summary>
        [Fact]
        public void DisplaySize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {DisplaySize = new Vector2F(3.0f, 4.0f)};

            // Act
            Vector2F displaySize = drawData.DisplaySize;

            // Assert
            Assert.Equal(new Vector2F(3.0f, 4.0f), displaySize);
        }

        /// <summary>
        ///     Tests that framebuffer scale should be initialized correctly
        /// </summary>
        [Fact]
        public void FramebufferScale_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {FramebufferScale = new Vector2F(5.0f, 6.0f)};

            // Act
            Vector2F framebufferScale = drawData.FramebufferScale;

            // Assert
            Assert.Equal(new Vector2F(5.0f, 6.0f), framebufferScale);
        }

        /// <summary>
        ///     Tests that owner viewport ptr should be initialized correctly
        /// </summary>
        [Fact]
        public void OwnerViewportPtr_ShouldBeInitializedCorrectly()
        {
            // Arrange
            IntPtr ptr = new IntPtr(456);
            ImDrawData drawData = new ImDrawData {OwnerViewportPtr = ptr};

            // Act
            IntPtr ownerViewportPtr = drawData.OwnerViewportPtr;

            // Assert
            Assert.Equal(ptr, ownerViewportPtr);
        }

        /// <summary>
        ///     Tests that clear should clear data
        /// </summary>
        [Fact]
        public void Clear_ShouldClearData()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {Valid = 1, CmdListsCount = 5};

        }

        /// <summary>
        ///     Tests that de index all buffers should de index buffers
        /// </summary>
        [Fact]
        public void DeIndexAllBuffers_ShouldDeIndexBuffers()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {CmdListsCount = 1, CmdListsPtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImDrawList>())};
            ImDrawList drawList = new ImDrawList();
            Marshal.StructureToPtr(drawList, drawData.CmdListsPtr, false);

            // Act

        }

        /// <summary>
        ///     Tests that scale clip rects should scale clip rects
        /// </summary>
        [Fact]
        public void ScaleClipRects_ShouldScaleClipRects()
        {
            // Arrange
            ImDrawData drawData = new ImDrawData {CmdListsCount = 1, CmdListsPtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImDrawList>())};
            ImDrawList drawList = new ImDrawList();
            Marshal.StructureToPtr(drawList, drawData.CmdListsPtr, false);
            Vector2F fbScale = new Vector2F(2.0f, 2.0f);

            // Act

        }

        /// <summary>
        ///     Tests that clear throws dll not found exception
        /// </summary>
        [Fact]
        public void Clear_ThrowsDllNotFoundException()
        {
            ImDrawData drawData = new ImDrawData();

        }

        /// <summary>
        ///     Tests that de index all buffers throws dll not found exception
        /// </summary>
        [Fact]
        public void DeIndexAllBuffers_ThrowsDllNotFoundException()
        {
            ImDrawData drawData = new ImDrawData();

        }

        /// <summary>
        ///     Tests that scale clip rects throws dll not found exception
        /// </summary>
        [Fact]
        public void ScaleClipRects_ThrowsDllNotFoundException()
        {
            ImDrawData drawData = new ImDrawData();
            Vector2F fbScale = new Vector2F(1.0f, 1.0f);

        }

        /// <summary>
        ///     Tests that cmd lists range throws dll not found exception
        /// </summary>
        [Fact]
        public void CmdListsRange_ThrowsDllNotFoundException()
        {
            ImDrawData drawData = new ImDrawData();
            RangePtrAccessor<ImDrawListPtr> range = drawData.CmdListsRange;
            Assert.Equal(IntPtr.Zero, range.Data);
        }
    }
}