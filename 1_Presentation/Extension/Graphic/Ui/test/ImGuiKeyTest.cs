// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiKeyTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiKey" /> enum values.
    /// </summary>
    public class ImGuiKeyTest
    {
        /// <summary>
        ///     Verifies that keyboard key values are properly defined.
        /// </summary>
        [Fact]
        public void Tab_ShouldBeDefined()
        {
            ImGuiKey key = ImGuiKey.Tab;
            Assert.NotEqual(0, (int) key);
        }

        /// <summary>
        ///     Verifies that different keys have distinct values.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiKey tab = ImGuiKey.Tab;
            ImGuiKey enter = ImGuiKey.Enter;
            ImGuiKey escape = ImGuiKey.Escape;

            Assert.NotEqual((int) tab, (int) enter);
            Assert.NotEqual((int) enter, (int) escape);
            Assert.NotEqual((int) tab, (int) escape);
        }
    }
}