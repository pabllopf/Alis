// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiDirTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiDir" /> enum values.
    /// </summary>
    public class ImGuiDirTest
    {
        /// <summary>
        ///     Verifies that direction values are properly defined.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            ImGuiDir dir = ImGuiDir.None;
            Assert.Equal(-1, (int) dir);
        }

        /// <summary>
        ///     Verifies that different directions have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiDir left = ImGuiDir.Left;
            ImGuiDir right = ImGuiDir.Right;
            ImGuiDir up = ImGuiDir.Up;
            ImGuiDir down = ImGuiDir.Down;

            Assert.NotEqual((int) left, (int) right);
            Assert.NotEqual((int) up, (int) down);
            Assert.NotEqual((int) left, (int) up);
        }
    }
}