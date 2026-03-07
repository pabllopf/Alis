// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5Test.cs
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
    ///     Provides API-surface coverage for methods contributed by ImGuiP5 wrappers.
    /// </summary>
    public class ImGuiP5Test
    {
        /// <summary>
        ///     Verifies begin-family APIs expose overload sets.
        /// </summary>
        [Fact]
        public void BeginFamily_ShouldExposeOverloads()
        {
            MethodInfo[] begin = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Begin").ToArray();
            MethodInfo[] beginChild = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "BeginChild").ToArray();

            Assert.True(begin.Length >= 3);
            Assert.True(beginChild.Length >= 8);
        }

        /// <summary>
        ///     Verifies drag-drop payload acceptance overloads exist.
        /// </summary>
        [Fact]
        public void AcceptDragDropPayload_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "AcceptDragDropPayload").ToArray();

            Assert.True(methods.Length >= 2);
        }
    }
}