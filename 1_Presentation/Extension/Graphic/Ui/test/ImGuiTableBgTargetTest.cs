// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTableBgTargetTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiTableBgTarget" /> values.
    /// </summary>
    public class ImGuiTableBgTargetTest
    {
        /// <summary>
        ///     Verifies that row and cell background targets keep stable ordinals.
        /// </summary>
        [Fact]
        public void Targets_ShouldKeepExpectedOrder()
        {
            Assert.Equal(0, (int) ImGuiTableBgTarget.None);
            Assert.Equal(1, (int) ImGuiTableBgTarget.RowBg0);
            Assert.Equal(2, (int) ImGuiTableBgTarget.RowBg1);
            Assert.Equal(3, (int) ImGuiTableBgTarget.CellBg);
        }
    }
}