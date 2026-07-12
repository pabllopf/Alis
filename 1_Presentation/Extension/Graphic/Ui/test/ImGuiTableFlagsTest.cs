// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableFlagsTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiTableFlags" /> values and aliases.
    /// </summary>
    public class ImGuiTableFlagsTest
    {
        /// <summary>
        ///     Verifies that border aliases match their component compositions.
        /// </summary>
        [Fact]
        public void BorderAliases_ShouldMatchComposition()
        {
            Assert.Equal(ImGuiTableFlags.BordersInnerH | ImGuiTableFlags.BordersOuterH, ImGuiTableFlags.BordersH);
            Assert.Equal(ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.BordersOuterV, ImGuiTableFlags.BordersV);
            Assert.Equal(ImGuiTableFlags.BordersH | ImGuiTableFlags.BordersV, ImGuiTableFlags.Borders);
        }

        /// <summary>
        ///     Verifies that sizing mask includes all sizing-related options.
        /// </summary>
        [Fact]
        public void SizingMask_ShouldContainSizingModes()
        {
            ImGuiTableFlags sizingModes = ImGuiTableFlags.SizingFixedFit
                                          | ImGuiTableFlags.SizingFixedSame
                                          | ImGuiTableFlags.SizingStretchProp
                                          | ImGuiTableFlags.SizingStretchSame;

            Assert.Equal(sizingModes, ImGuiTableFlags.SizingMask);
        }
    }
}