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
    /// <summary>
    /// The im draw cmd tests class
    /// </summary>
    public class ImDrawCmdTests
    {
        /// <summary>
        /// Tests that clip rect get set works correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void ClipRect_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            Vector4F expected = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            drawCmd.ClipRect = expected;
            Assert.Equal(expected, drawCmd.ClipRect);
        }

        /// <summary>
        /// Tests that texture id get set works correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TextureId_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr expected = new IntPtr(123);
            drawCmd.TextureId = expected;
            Assert.Equal(expected, drawCmd.TextureId);
        }

        /// <summary>
        /// Tests that vtx offset get set works correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void VtxOffset_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            const uint expected = 10;
            drawCmd.VtxOffset = expected;
            Assert.Equal(expected, drawCmd.VtxOffset);
        }

        /// <summary>
        /// Tests that idx offset get set works correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void IdxOffset_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            const uint expected = 20;
            drawCmd.IdxOffset = expected;
            Assert.Equal(expected, drawCmd.IdxOffset);
        }

        /// <summary>
        /// Tests that elem count get set works correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void ElemCount_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            const uint expected = 30;
            drawCmd.ElemCount = expected;
            Assert.Equal(expected, drawCmd.ElemCount);
        }

        /// <summary>
        /// Tests that user callback get set works correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void UserCallback_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr expected = new IntPtr(456);
            drawCmd.UserCallback = expected;
            Assert.Equal(expected, drawCmd.UserCallback);
        }

        /// <summary>
        /// Tests that user callback data get set works correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void UserCallbackData_GetSet_WorksCorrectly()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr expected = new IntPtr(789);
            drawCmd.UserCallbackData = expected;
            Assert.Equal(expected, drawCmd.UserCallbackData);
        }

        /// <summary>
        /// Tests that get clip rect returns clip rect
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetClipRect_ReturnsClipRect()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ClipRect = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f)};
            Assert.Equal(new Vector4F(1.0f, 2.0f, 3.0f, 4.0f), drawCmd.GetClipRect());
        }

        /// <summary>
        /// Tests that get texture id returns texture id
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetTextureId_ReturnsTextureId()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {TextureId = new IntPtr(123)};
            Assert.Equal(new IntPtr(123), drawCmd.GetTextureId());
        }

        /// <summary>
        /// Tests that get vtx offset returns vtx offset
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetVtxOffset_ReturnsVtxOffset()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {VtxOffset = 10};
            Assert.Equal(10u, drawCmd.GetVtxOffset());
        }

        /// <summary>
        /// Tests that get idx offset returns idx offset
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetIdxOffset_ReturnsIdxOffset()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {IdxOffset = 20};
            Assert.Equal(20u, drawCmd.GetIdxOffset());
        }

        /// <summary>
        /// Tests that get elem count returns elem count
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetElemCount_ReturnsElemCount()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {ElemCount = 30};
            Assert.Equal(30u, drawCmd.GetElemCount());
        }

        /// <summary>
        /// Tests that get user callback returns user callback
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetUserCallback_ReturnsUserCallback()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallback = new IntPtr(456)};
            Assert.Equal(new IntPtr(456), drawCmd.GetUserCallback());
        }

        /// <summary>
        /// Tests that get user callback data returns user callback data
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetUserCallbackData_ReturnsUserCallbackData()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {UserCallbackData = new IntPtr(789)};
            Assert.Equal(new IntPtr(789), drawCmd.GetUserCallbackData());
        }

        /// <summary>
        /// Tests that set user callback data sets correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetUserCallbackData_SetsCorrectValue()
        {
            ImDrawCmd drawCmd = new ImDrawCmd();
            IntPtr value = new IntPtr(789);
            drawCmd.SetUserCallbackData(value);
            Assert.Equal(value, drawCmd.UserCallbackData);
        }

        /// <summary>
        /// Tests that default clip rect returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ClipRect_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(default, drawCmd.ClipRect);
        }

        /// <summary>
        /// Tests that default texture id returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_TextureId_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.TextureId);
        }

        /// <summary>
        /// Tests that default vtx offset returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_VtxOffset_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.VtxOffset);
        }

        /// <summary>
        /// Tests that default idx offset returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_IdxOffset_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.IdxOffset);
        }

        /// <summary>
        /// Tests that default elem count returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_ElemCount_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.ElemCount);
        }

        /// <summary>
        /// Tests that default user callback returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_UserCallback_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.UserCallback);
        }

        /// <summary>
        /// Tests that default user callback data returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Default_UserCallbackData_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.UserCallbackData);
        }

        /// <summary>
        /// Tests that get clip rect default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetClipRect_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(default, drawCmd.GetClipRect());
        }

        /// <summary>
        /// Tests that get texture id default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetTextureId_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.GetTextureId());
        }

        /// <summary>
        /// Tests that get vtx offset default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetVtxOffset_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.GetVtxOffset());
        }

        /// <summary>
        /// Tests that get idx offset default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetIdxOffset_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.GetIdxOffset());
        }

        /// <summary>
        /// Tests that get elem count default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetElemCount_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(0u, drawCmd.GetElemCount());
        }

        /// <summary>
        /// Tests that get user callback default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetUserCallback_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.GetUserCallback());
        }

        /// <summary>
        /// Tests that get user callback data default returns zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetUserCallbackData_Default_ReturnsZero()
        {
            ImDrawCmd drawCmd = default;
            Assert.Equal(IntPtr.Zero, drawCmd.GetUserCallbackData());
        }
    }
}
