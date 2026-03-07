// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiModFlagsTest.cs
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

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for plot-specific <see cref="ImGuiModFlags" /> values.
    /// </summary>
    public class ImGuiModFlagsTest
    {
        /// <summary>
        ///     Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiModFlags.None);
        }

        /// <summary>
        ///     Verifies that modifier values are distinct bit flags.
        /// </summary>
        [Fact]
        public void Modifiers_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiModFlags.Ctrl, (int) ImGuiModFlags.Shift);
            Assert.NotEqual((int) ImGuiModFlags.Alt, (int) ImGuiModFlags.Super);
        }

        /// <summary>
        ///     Verifies that combining modifiers with OR preserves both bits.
        /// </summary>
        [Fact]
        public void CombinedModifiers_ShouldContainBothBits()
        {
            ImGuiModFlags combo = ImGuiModFlags.Ctrl | ImGuiModFlags.Shift;

            Assert.True((combo & ImGuiModFlags.Ctrl) != 0);
            Assert.True((combo & ImGuiModFlags.Shift) != 0);
        }
    }
}