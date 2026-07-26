// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawDataTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImDrawDataTests
    {
        [Fact]
        public void Valid_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal((byte)0, data.Valid);
        }

        [Fact]
        public void Valid_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            data.Valid = 1;
            Assert.Equal((byte)1, data.Valid);
        }

        [Fact]
        public void CmdListsCount_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(0, data.CmdListsCount);
        }

        [Fact]
        public void CmdListsCount_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            data.CmdListsCount = 5;
            Assert.Equal(5, data.CmdListsCount);
        }

        [Fact]
        public void TotalIdxCount_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(0, data.TotalIdxCount);
        }

        [Fact]
        public void TotalIdxCount_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            data.TotalIdxCount = 100;
            Assert.Equal(100, data.TotalIdxCount);
        }

        [Fact]
        public void TotalVtxCount_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(0, data.TotalVtxCount);
        }

        [Fact]
        public void TotalVtxCount_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            data.TotalVtxCount = 200;
            Assert.Equal(200, data.TotalVtxCount);
        }

        [Fact]
        public void CmdListsPtr_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(IntPtr.Zero, data.CmdListsPtr);
        }

        [Fact]
        public void CmdListsPtr_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            IntPtr expected = new IntPtr(123);
            data.CmdListsPtr = expected;
            Assert.Equal(expected, data.CmdListsPtr);
        }

        [Fact]
        public void DisplayPos_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(new Vector2F(), data.DisplayPos);
        }

        [Fact]
        public void DisplayPos_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            Vector2F expected = new Vector2F(100f, 200f);
            data.DisplayPos = expected;
            Assert.Equal(expected, data.DisplayPos);
        }

        [Fact]
        public void DisplaySize_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(new Vector2F(), data.DisplaySize);
        }

        [Fact]
        public void DisplaySize_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            Vector2F expected = new Vector2F(1920f, 1080f);
            data.DisplaySize = expected;
            Assert.Equal(expected, data.DisplaySize);
        }

        [Fact]
        public void FramebufferScale_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(new Vector2F(), data.FramebufferScale);
        }

        [Fact]
        public void FramebufferScale_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            Vector2F expected = new Vector2F(1f, 1f);
            data.FramebufferScale = expected;
            Assert.Equal(expected, data.FramebufferScale);
        }

        [Fact]
        public void OwnerViewportPtr_DefaultValue_ReturnsZero()
        {
            ImDrawData data = default;
            Assert.Equal(IntPtr.Zero, data.OwnerViewportPtr);
        }

        [Fact]
        public void OwnerViewportPtr_SetValue_ReturnsSetValue()
        {
            ImDrawData data = default;
            IntPtr expected = new IntPtr(456);
            data.OwnerViewportPtr = expected;
            Assert.Equal(expected, data.OwnerViewportPtr);
        }

        [Fact]
        public void CmdListsRange_CountMatchesCmdListsCount()
        {
            ImDrawData data = default;
            data.CmdListsCount = 3;
            Assert.Equal(3, data.CmdListsRange.Count);
        }

        [Fact]
        public void CmdListsRange_DataMatchesCmdListsPtr()
        {
            ImDrawData data = default;
            IntPtr expected = new IntPtr(789);
            data.CmdListsPtr = expected;
            Assert.Equal(expected, data.CmdListsRange.Data);
        }

        [RequireCImguiSystemFact]
        public void Clear_WhenCalled_DoesNotThrow()
        {
            ImDrawData data = default;
            data.Clear();
        }

        [RequireCImguiSystemFact]
        public void DeIndexAllBuffers_WhenCalled_DoesNotThrow()
        {
            ImDrawData data = default;
            data.DeIndexAllBuffers();
        }

        [RequireCImguiSystemFact]
        public void ScaleClipRects_WhenCalled_DoesNotThrow()
        {
            ImDrawData data = default;
            Vector2F fbScale = new Vector2F(1f, 1f);
            data.ScaleClipRects(fbScale);
        }
    }
}
