// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmdTests.cs
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
    public class ImDrawCmdTests
    {
        [Fact]
        public void ClipRect_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            Vector4F expected = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            drawCmd.ClipRect = expected;
            Assert.Equal(expected, drawCmd.ClipRect);
        }

        [Fact]
        public void TextureId_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr expected = new IntPtr(123);
            drawCmd.TextureId = expected;
            Assert.Equal(expected, drawCmd.TextureId);
        }

        [Fact]
        public void VtxOffset_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            const uint expected = 10;
            drawCmd.VtxOffset = expected;
            Assert.Equal(expected, drawCmd.VtxOffset);
        }

        [Fact]
        public void IdxOffset_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            const uint expected = 20;
            drawCmd.IdxOffset = expected;
            Assert.Equal(expected, drawCmd.IdxOffset);
        }

        [Fact]
        public void ElemCount_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            const uint expected = 30;
            drawCmd.ElemCount = expected;
            Assert.Equal(expected, drawCmd.ElemCount);
        }

        [Fact]
        public void UserCallback_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr expected = new IntPtr(456);
            drawCmd.UserCallback = expected;
            Assert.Equal(expected, drawCmd.UserCallback);
        }

        [Fact]
        public void UserCallbackData_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr expected = new IntPtr(789);
            drawCmd.UserCallbackData = expected;
            Assert.Equal(expected, drawCmd.UserCallbackData);
        }

        [Fact]
        public void GetClipRect_ReturnsClipRect()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ClipRect = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f)};
            Assert.Equal(new Vector4F(1.0f, 2.0f, 3.0f, 4.0f), drawCmd.GetClipRect());
        }

        [Fact]
        public void GetTextureId_ReturnsTextureId()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {TextureId = new IntPtr(123)};
            Assert.Equal(new IntPtr(123), drawCmd.GetTextureId());
        }

        [Fact]
        public void GetVtxOffset_ReturnsVtxOffset()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {VtxOffset = 10};
            Assert.Equal(10u, drawCmd.GetVtxOffset());
        }

        [Fact]
        public void GetIdxOffset_ReturnsIdxOffset()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {IdxOffset = 20};
            Assert.Equal(20u, drawCmd.GetIdxOffset());
        }

        [Fact]
        public void GetElemCount_ReturnsElemCount()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ElemCount = 30};
            Assert.Equal(30u, drawCmd.GetElemCount());
        }

        [Fact]
        public void GetUserCallback_ReturnsUserCallback()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallback = new IntPtr(456)};
            Assert.Equal(new IntPtr(456), drawCmd.GetUserCallback());
        }

        [Fact]
        public void GetUserCallbackData_ReturnsUserCallbackData()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallbackData = new IntPtr(789)};
            Assert.Equal(new IntPtr(789), drawCmd.GetUserCallbackData());
        }

        [Fact]
        public void SetUserCallbackData_SetsCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr value = new IntPtr(789);
            drawCmd.SetUserCallbackData(value);
            Assert.Equal(value, drawCmd.UserCallbackData);
        }

        [Fact]
        public void Default_ClipRect_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(default, drawCmd.ClipRect);
        }

        [Fact]
        public void Default_TextureId_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.TextureId);
        }

        [Fact]
        public void Default_VtxOffset_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.VtxOffset);
        }

        [Fact]
        public void Default_IdxOffset_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.IdxOffset);
        }

        [Fact]
        public void Default_ElemCount_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.ElemCount);
        }

        [Fact]
        public void Default_UserCallback_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.UserCallback);
        }

        [Fact]
        public void Default_UserCallbackData_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.UserCallbackData);
        }

        [Fact]
        public void GetClipRect_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(default, drawCmd.GetClipRect());
        }

        [Fact]
        public void GetTextureId_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.GetTextureId());
        }

        [Fact]
        public void GetVtxOffset_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.GetVtxOffset());
        }

        [Fact]
        public void GetIdxOffset_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.GetIdxOffset());
        }

        [Fact]
        public void GetElemCount_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.GetElemCount());
        }

        [Fact]
        public void GetUserCallback_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.GetUserCallback());
        }

        [Fact]
        public void GetUserCallbackData_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.GetUserCallbackData());
        }
    }
}
