// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7Test.cs
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

using System.Linq;
using System.Reflection;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides API-surface coverage for methods contributed by ImGuiP7 wrappers.
    /// </summary>
    public class ImGuiP7Test
    {
        /// <summary>
        ///     Verifies popup APIs expose expected overloads.
        /// </summary>
        [Fact]
        public void PopupApis_ShouldExposeOverloads()
        {
            MethodInfo[] openPopup = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "OpenPopup").ToArray();
            MethodInfo[] openPopupOnItemClick = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "OpenPopupOnItemClick").ToArray();

            Assert.True(openPopup.Length >= 4);
            Assert.True(openPopupOnItemClick.Length >= 3);
        }

        /// <summary>
        ///     Verifies representative frame navigation methods exist.
        /// </summary>
        [Fact]
        public void FrameNavigationMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("NewFrame", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("NextColumn", BindingFlags.Public | BindingFlags.Static));
        }
    }
}