// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3Test.cs
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
    ///     Provides API-surface coverage for methods contributed by ImGuiP3 wrappers.
    /// </summary>
    public class ImGuiP3Test
    {
        /// <summary>
        ///     Verifies representative End* methods are exposed as void static methods.
        /// </summary>
        [Fact]
        public void EndMethods_ShouldBeAvailable()
        {
            string[] names = {"End", "EndChild", "EndCombo", "EndFrame", "EndMenu", "EndPopup"};

            foreach (string name in names)
            {
                MethodInfo method = typeof(ImGui).GetMethod(name, BindingFlags.Public | BindingFlags.Static);
                Assert.NotNull(method);
                Assert.Equal(typeof(void), method.ReturnType);
            }
        }

        /// <summary>
        ///     Verifies DragScalarN overloads exist.
        /// </summary>
        [Fact]
        public void DragScalarN_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragScalarN").ToArray();

            Assert.True(methods.Length >= 3);
        }
    }
}