// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiComboFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiComboFlags" /> enum values.
    /// </summary>
    public class ImGuiComboFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that PopupAlignLeft has the expected value of 1.
        /// </summary>
        [Fact]
        public void PopupAlignLeft_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.PopupAlignLeft;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that HeightSmall has the expected value of 2.
        /// </summary>
        [Fact]
        public void HeightSmall_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.HeightSmall;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that HeightRegular has the expected value of 4.
        /// </summary>
        [Fact]
        public void HeightRegular_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.HeightRegular;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that HeightLarge has the expected value of 8.
        /// </summary>
        [Fact]
        public void HeightLarge_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.HeightLarge;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that HeightLargest has the expected value of 16.
        /// </summary>
        [Fact]
        public void HeightLargest_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.HeightLargest;
            Assert.Equal(16, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoArrowButton has the expected value of 32.
        /// </summary>
        [Fact]
        public void NoArrowButton_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.NoArrowButton;
            Assert.Equal(32, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoPreview has the expected value of 64.
        /// </summary>
        [Fact]
        public void NoPreview_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.NoPreview;
            Assert.Equal(64, (int)flag);
        }

        /// <summary>
        ///     Verifies that HeightMask has the expected value of 30.
        /// </summary>
        [Fact]
        public void HeightMask_ShouldHaveCorrectValue()
        {
            ImGuiComboFlags flag = ImGuiComboFlags.HeightMask;
            Assert.Equal(30, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiComboFlags combined = ImGuiComboFlags.PopupAlignLeft | ImGuiComboFlags.HeightSmall;
            int expected = 1 | 2;
            Assert.Equal(expected, (int)combined);
        }
    }
}
