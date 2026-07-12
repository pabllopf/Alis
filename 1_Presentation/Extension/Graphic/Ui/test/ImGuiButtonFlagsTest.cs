// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiButtonFlagsTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiButtonFlags" /> enum values.
    /// </summary>
    public class ImGuiButtonFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiButtonFlags flag = ImGuiButtonFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that MouseButtonLeft has the expected value of 1.
        /// </summary>
        [Fact]
        public void MouseButtonLeft_ShouldHaveCorrectValue()
        {
            ImGuiButtonFlags flag = ImGuiButtonFlags.MouseButtonLeft;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that MouseButtonRight has the expected value of 2.
        /// </summary>
        [Fact]
        public void MouseButtonRight_ShouldHaveCorrectValue()
        {
            ImGuiButtonFlags flag = ImGuiButtonFlags.MouseButtonRight;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that MouseButtonMiddle has the expected value of 4.
        /// </summary>
        [Fact]
        public void MouseButtonMiddle_ShouldHaveCorrectValue()
        {
            ImGuiButtonFlags flag = ImGuiButtonFlags.MouseButtonMiddle;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that MouseButtonMask has the expected value of 7.
        /// </summary>
        [Fact]
        public void MouseButtonMask_ShouldHaveCorrectValue()
        {
            ImGuiButtonFlags flag = ImGuiButtonFlags.MouseButtonMask;
            Assert.Equal(7, (int)flag);
        }

        /// <summary>
        ///     Verifies that MouseButtonDefault has the expected value of 1.
        /// </summary>
        [Fact]
        public void MouseButtonDefault_ShouldHaveCorrectValue()
        {
            ImGuiButtonFlags flag = ImGuiButtonFlags.MouseButtonDefault;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiButtonFlags combined = ImGuiButtonFlags.MouseButtonLeft | ImGuiButtonFlags.MouseButtonRight;
            int expected = 1 | 2;
            Assert.Equal(expected, (int)combined);
        }
    }
}
