// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiColTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiCol" /> enum values.
    /// </summary>
    public class ImGuiColTest
    {
        /// <summary>
        ///     Verifies that color indices are properly defined.
        /// </summary>
        [Fact]
        public void Text_ShouldBeDefined()
        {
            ImGuiCol color = ImGuiCol.Text;
            Assert.Equal(0, (int) color);
        }

        /// <summary>
        ///     Verifies that different colors have distinct indices.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiCol text = ImGuiCol.Text;
            ImGuiCol bg = ImGuiCol.WindowBg;
            ImGuiCol border = ImGuiCol.Border;

            Assert.NotEqual((int) text, (int) bg);
            Assert.NotEqual((int) bg, (int) border);
            Assert.NotEqual((int) text, (int) border);
        }
    }
}