// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextRangeTest.cs
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
    public class ImGuiTextRangeTest
    {
        [Fact]
        public void B_Default_ShouldBeZero()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            Assert.Equal(IntPtr.Zero, textRange.B);
        }

        [Fact]
        public void B_Should_SetAndGetCorrectly()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(123);
            textRange.B = ptr;
            Assert.Equal(ptr, textRange.B);
        }

        [Fact]
        public void B_Should_HandleMaxValue()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(unchecked((int)0x7FFFFFFF));
            textRange.B = ptr;
            Assert.Equal(ptr, textRange.B);
        }

        [Fact]
        public void B_Should_HandleZero()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            textRange.B = IntPtr.Zero;
            Assert.Equal(IntPtr.Zero, textRange.B);
        }

        [Fact]
        public void B_Should_HandleNegativeValue()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(-1);
            textRange.B = ptr;
            Assert.Equal(ptr, textRange.B);
        }

        [Fact]
        public void E_Default_ShouldBeZero()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            Assert.Equal(IntPtr.Zero, textRange.E);
        }

        [Fact]
        public void E_Should_SetAndGetCorrectly()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(456);
            textRange.E = ptr;
            Assert.Equal(ptr, textRange.E);
        }

        [Fact]
        public void E_Should_HandleMaxValue()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(unchecked((int)0x7FFFFFFF));
            textRange.E = ptr;
            Assert.Equal(ptr, textRange.E);
        }

        [Fact]
        public void E_Should_HandleZero()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            textRange.E = IntPtr.Zero;
            Assert.Equal(IntPtr.Zero, textRange.E);
        }

        [Fact]
        public void E_Should_HandleNegativeValue()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(-1);
            textRange.E = ptr;
            Assert.Equal(ptr, textRange.E);
        }

        [Fact]
        public void B_And_E_Should_BeIndependent()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr bPtr = new IntPtr(100);
            IntPtr ePtr = new IntPtr(200);
            textRange.B = bPtr;
            textRange.E = ePtr;
            Assert.Equal(bPtr, textRange.B);
            Assert.Equal(ePtr, textRange.E);
        }

        [Fact]
        public void Struct_Should_BeZeroedByDefault()
        {
            ImGuiTextRange textRange = default;
            Assert.Equal(IntPtr.Zero, textRange.B);
            Assert.Equal(IntPtr.Zero, textRange.E);
        }

        [Fact]
        public void Struct_Should_SupportValueSemantics()
        {
            ImGuiTextRange textRange1 = new ImGuiTextRange { B = new IntPtr(10), E = new IntPtr(20) };
            ImGuiTextRange textRange2 = textRange1;
            Assert.Equal(textRange1.B, textRange2.B);
            Assert.Equal(textRange1.E, textRange2.E);
            textRange2.B = new IntPtr(30);
            Assert.NotEqual(textRange1.B, textRange2.B);
        }
    }
}
