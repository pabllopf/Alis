// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStyleVarTest.cs
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
    ///     Provides unit coverage for <see cref="ImGuiStyleVar" /> enum values.
    /// </summary>
    public class ImGuiStyleVarTest
    {
        /// <summary>
        ///     Verifies that style variable indices are defined.
        /// </summary>
        [Fact]
        public void Alpha_ShouldBeDefined()
        {
            ImGuiStyleVar styleVar = ImGuiStyleVar.Alpha;
            Assert.Equal(0, (int) styleVar);
        }

        /// <summary>
        ///     Verifies that different style variables have distinct indices.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldBeDistinct()
        {
            ImGuiStyleVar alpha = ImGuiStyleVar.Alpha;
            ImGuiStyleVar windowPadding = ImGuiStyleVar.WindowPadding;
            ImGuiStyleVar windowRounding = ImGuiStyleVar.WindowRounding;

            Assert.NotEqual((int) alpha, (int) windowPadding);
            Assert.NotEqual((int) windowPadding, (int) windowRounding);
            Assert.NotEqual((int) alpha, (int) windowRounding);
        }
    }
}