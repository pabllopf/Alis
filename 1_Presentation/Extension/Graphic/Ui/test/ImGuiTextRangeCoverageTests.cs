// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTextRangeCoverageTests.cs
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
    ///     The im gui text range coverage tests class
    /// </summary>
    public class ImGuiTextRangeCoverageTests
    {
        /// <summary>
        ///     Tests that default initialization properties have default values
        /// </summary>
        [Fact]
        public void ImGuiTextRange_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            ImGuiTextRange textRange = default(ImGuiTextRange);

            Assert.Equal(IntPtr.Zero, textRange.B);
            Assert.Equal(IntPtr.Zero, textRange.E);
        }

        /// <summary>
        ///     Tests that set properties stores values correctly
        /// </summary>
        [Fact]
        public void ImGuiTextRange_SetProperties_StoresValuesCorrectly()
        {
            ImGuiTextRange textRange = new ImGuiTextRange
            {
                B = new IntPtr(123),
                E = new IntPtr(456)
            };

            Assert.Equal(new IntPtr(123), textRange.B);
            Assert.Equal(new IntPtr(456), textRange.E);
        }

        /// <summary>
        ///     Tests that the struct is a value type and copies are independent
        /// </summary>
        [Fact]
        public void ImGuiTextRange_IsValueType_CopyIsIndependent()
        {
            ImGuiTextRange original = new ImGuiTextRange { B = new IntPtr(100) };
            ImGuiTextRange copy = original;

            copy.B = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.B);
            Assert.Equal(new IntPtr(200), copy.B);
        }
    }
}