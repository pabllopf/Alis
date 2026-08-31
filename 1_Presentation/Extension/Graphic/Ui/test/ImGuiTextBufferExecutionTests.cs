// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextBufferExecutionTests.cs
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
    ///     The im gui text buffer execution tests class
    /// </summary>
    public class ImGuiTextBufferExecutionTests
    {
        /// <summary>
        ///     Tests that the buf property round-trips an ImVector value
        /// </summary>
        [Fact]
        public void ImGuiTextBuffer_Buf_RoundTripsImVector()
        {
            ImGuiTextBuffer textBuffer = default;
            ImVector expected = new ImVector(5, 10, new IntPtr(12345));

            textBuffer.Buf = expected;

            Assert.Equal(5, textBuffer.Buf.Size);
            Assert.Equal(10, textBuffer.Buf.Capacity);
            Assert.Equal(new IntPtr(12345), textBuffer.Buf.Data);
        }

        /// <summary>
        ///     Tests that the buf property can be overwritten
        /// </summary>
        [Fact]
        public void ImGuiTextBuffer_Buf_OverwritesPreviousValue()
        {
            ImGuiTextBuffer textBuffer = new ImGuiTextBuffer { Buf = new ImVector(1, 2, IntPtr.Zero) };

            textBuffer.Buf = new ImVector(3, 4, new IntPtr(9));

            Assert.Equal(3, textBuffer.Buf.Size);
            Assert.Equal(4, textBuffer.Buf.Capacity);
            Assert.Equal(new IntPtr(9), textBuffer.Buf.Data);
        }

        /// <summary>
        ///     Tests that the buf property defaults to an empty ImVector
        /// </summary>
        [Fact]
        public void ImGuiTextBuffer_Default_BufIsZeroedImVector()
        {
            ImGuiTextBuffer textBuffer = default;

            Assert.Equal(0, textBuffer.Buf.Size);
            Assert.Equal(0, textBuffer.Buf.Capacity);
            Assert.Equal(IntPtr.Zero, textBuffer.Buf.Data);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiTextBuffer_IsValueType_CopiesAreIndependent()
        {
            ImGuiTextBuffer original = new ImGuiTextBuffer { Buf = new ImVector(1, 2, IntPtr.Zero) };
            ImGuiTextBuffer copy = original;

            copy.Buf = new ImVector(9, 9, new IntPtr(77));

            Assert.Equal(1, original.Buf.Size);
            Assert.Equal(9, copy.Buf.Size);
        }
    }
}
