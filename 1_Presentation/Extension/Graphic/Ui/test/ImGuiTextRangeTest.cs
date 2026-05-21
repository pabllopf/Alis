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
    /// <summary>
    ///     The im gui text range test class
    /// </summary>
    public class ImGuiTextRangeTest
    {
        /// <summary>
        ///     Tests that b should set and get correctly
        /// </summary>
        [Fact]
        public void B_Should_SetAndGetCorrectly()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(123);
            textRange.B = ptr;
            Assert.Equal(ptr, textRange.B);
        }

        /// <summary>
        ///     Tests that e should set and get correctly
        /// </summary>
        [Fact]
        public void E_Should_SetAndGetCorrectly()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(456);
            textRange.E = ptr;
            Assert.Equal(ptr, textRange.E);
        }
    }
}