// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextBufferTests.cs
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
    ///     The im gui text buffer tests class
    /// </summary>
    public class ImGuiTextBufferTests
    {
        /// <summary>
        ///     Tests that default buf should be default im vector
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultBuf_ShouldBeDefaultImVector()
        {
            ImGuiTextBuffer textBuffer = default;
            Assert.Equal(0, textBuffer.Buf.Size);
            Assert.Equal(0, textBuffer.Buf.Capacity);
            Assert.Equal(IntPtr.Zero, textBuffer.Buf.Data);
        }

        /// <summary>
        ///     Tests that buf property should be mutable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BufProperty_ShouldBeMutable()
        {
            ImGuiTextBuffer textBuffer = default;
            IntPtr data = new IntPtr(42);
            ImVector vector = new ImVector(5, 10, data);
            textBuffer.Buf = vector;
            Assert.Equal(5, textBuffer.Buf.Size);
            Assert.Equal(10, textBuffer.Buf.Capacity);
            Assert.Equal(data, textBuffer.Buf.Data);
        }

        /// <summary>
        ///     Tests that setting buf should return same values
        /// </summary>
         [RequireCImguiSystemFact]
        public void SettingBuf_ShouldReturnSameValues()
        {
            ImGuiTextBuffer textBuffer = default;
            textBuffer.Buf = new ImVector(3, 6, IntPtr.Zero);
            Assert.Equal(3, textBuffer.Buf.Size);
            Assert.Equal(6, textBuffer.Buf.Capacity);
            Assert.Equal(IntPtr.Zero, textBuffer.Buf.Data);
        }

        /// <summary>
        ///     Tests that multiple instances should be independent
        /// </summary>
         [RequireCImguiSystemFact]
        public void MultipleInstances_ShouldBeIndependent()
        {
            ImGuiTextBuffer first = default;
            ImGuiTextBuffer second = default;

            first.Buf = new ImVector(1, 2, new IntPtr(10));
            second.Buf = new ImVector(3, 4, new IntPtr(20));

            Assert.Equal(1, first.Buf.Size);
            Assert.Equal(2, first.Buf.Capacity);
            Assert.Equal(new IntPtr(10), first.Buf.Data);

            Assert.Equal(3, second.Buf.Size);
            Assert.Equal(4, second.Buf.Capacity);
            Assert.Equal(new IntPtr(20), second.Buf.Data);
        }
    }
}
