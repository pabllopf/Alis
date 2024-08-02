// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmdTest.cs
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

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im draw cmd test class
    /// </summary>
    public class ImDrawCmdTest
    {
        /// <summary>
        /// Tests that clip rect should be initialized correctly
        /// </summary>
        [Fact]
        public void ClipRect_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {ClipRect = new Vector4(1.0f, 2.0f, 3.0f, 4.0f)};
            
            // Act
            Vector4 clipRect = drawCmd.ClipRect;
            
            // Assert
            Assert.Equal(new Vector4(1.0f, 2.0f, 3.0f, 4.0f), clipRect);
        }
        
        /// <summary>
        /// Tests that texture id should be initialized correctly
        /// </summary>
        [Fact]
        public void TextureId_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {TextureId = new IntPtr(123)};
            
            // Act
            IntPtr textureId = drawCmd.TextureId;
            
            // Assert
            Assert.Equal(new IntPtr(123), textureId);
        }
        
        /// <summary>
        /// Tests that vtx offset should be initialized correctly
        /// </summary>
        [Fact]
        public void VtxOffset_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {VtxOffset = 10};
            
            // Act
            uint vtxOffset = drawCmd.VtxOffset;
            
            // Assert
            Assert.Equal(10u, vtxOffset);
        }
        
        /// <summary>
        /// Tests that idx offset should be initialized correctly
        /// </summary>
        [Fact]
        public void IdxOffset_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {IdxOffset = 20};
            
            // Act
            uint idxOffset = drawCmd.IdxOffset;
            
            // Assert
            Assert.Equal(20u, idxOffset);
        }
        
        /// <summary>
        /// Tests that elem count should be initialized correctly
        /// </summary>
        [Fact]
        public void ElemCount_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {ElemCount = 30};
            
            // Act
            uint elemCount = drawCmd.ElemCount;
            
            // Assert
            Assert.Equal(30u, elemCount);
        }
        
        /// <summary>
        /// Tests that user callback should be initialized correctly
        /// </summary>
        [Fact]
        public void UserCallback_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallback = new IntPtr(456)};
            
            // Act
            IntPtr userCallback = drawCmd.UserCallback;
            
            // Assert
            Assert.Equal(new IntPtr(456), userCallback);
        }
        
        /// <summary>
        /// Tests that user callback data should be initialized correctly
        /// </summary>
        [Fact]
        public void UserCallbackData_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallbackData = new IntPtr(789)};
            
            // Act
            IntPtr userCallbackData = drawCmd.UserCallbackData;
            
            // Assert
            Assert.Equal(new IntPtr(789), userCallbackData);
        }
        
        /// <summary>
        /// Tests that get clip rect should return correct value
        /// </summary>
        [Fact]
        public void GetClipRect_ShouldReturnCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {ClipRect = new Vector4(1.0f, 2.0f, 3.0f, 4.0f)};
            
            // Act
            Vector4 clipRect = drawCmd.GetClipRect();
            
            // Assert
            Assert.Equal(new Vector4(1.0f, 2.0f, 3.0f, 4.0f), clipRect);
        }
        
        /// <summary>
        /// Tests that get texture id should return correct value
        /// </summary>
        [Fact]
        public void GetTextureId_ShouldReturnCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {TextureId = new IntPtr(123)};
            
            // Act
            IntPtr textureId = drawCmd.GetTextureId();
            
            // Assert
            Assert.Equal(new IntPtr(123), textureId);
        }
        
        /// <summary>
        /// Tests that get vtx offset should return correct value
        /// </summary>
        [Fact]
        public void GetVtxOffset_ShouldReturnCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {VtxOffset = 10};
            
            // Act
            uint vtxOffset = drawCmd.GetVtxOffset();
            
            // Assert
            Assert.Equal(10u, vtxOffset);
        }
        
        /// <summary>
        /// Tests that get idx offset should return correct value
        /// </summary>
        [Fact]
        public void GetIdxOffset_ShouldReturnCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {IdxOffset = 20};
            
            // Act
            uint idxOffset = drawCmd.GetIdxOffset();
            
            // Assert
            Assert.Equal(20u, idxOffset);
        }
        
        /// <summary>
        /// Tests that get elem count should return correct value
        /// </summary>
        [Fact]
        public void GetElemCount_ShouldReturnCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {ElemCount = 30};
            
            // Act
            uint elemCount = drawCmd.GetElemCount();
            
            // Assert
            Assert.Equal(30u, elemCount);
        }
        
        /// <summary>
        /// Tests that get user callback should return correct value
        /// </summary>
        [Fact]
        public void GetUserCallback_ShouldReturnCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallback = new IntPtr(456)};
            
            // Act
            IntPtr userCallback = drawCmd.GetUserCallback();
            
            // Assert
            Assert.Equal(new IntPtr(456), userCallback);
        }
        
        /// <summary>
        /// Tests that get user callback data should return correct value
        /// </summary>
        [Fact]
        public void GetUserCallbackData_ShouldReturnCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallbackData = new IntPtr(789)};
            
            // Act
            IntPtr userCallbackData = drawCmd.GetUserCallbackData();
            
            // Assert
            Assert.Equal(new IntPtr(789), userCallbackData);
        }
        
        /// <summary>
        /// Tests that set user callback data should set correct value
        /// </summary>
        [Fact]
        public void SetUserCallbackData_ShouldSetCorrectValue()
        {
            // Arrange
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr value = new IntPtr(789);
            
            // Act
            drawCmd.SetUserCallbackData(value);
            
            // Assert
            Assert.Equal(value, drawCmd.UserCallbackData);
        }
    }
}