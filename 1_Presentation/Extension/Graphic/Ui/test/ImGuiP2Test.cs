// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP2Test.cs
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
    ///     Provides API-surface coverage for methods contributed by ImGuiP2 wrappers.
    /// </summary>
    public class ImGuiP2Test
    {
        /// <summary>
        ///     Verifies that DragInt family exposes a broad overload set.
        /// </summary>
        [Fact]
        public void DragIntFamily_ShouldExposeManyOverloads()
        {
            MethodInfo[] dragInt = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragInt").ToArray();
            MethodInfo[] dragInt2 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragInt2").ToArray();
            MethodInfo[] dragInt3 = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragInt3").ToArray();

            Assert.True(dragInt.Length >= 6);
            Assert.True(dragInt2.Length >= 6);
            Assert.True(dragInt3.Length >= 6);
        }

        /// <summary>
        ///     Verifies DragInt4 family exposes expected overloads.
        /// </summary>
        [Fact]
        public void DragInt4_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragInt4").ToArray();
            Assert.True(methods.Length >= 6);
        }

        /// <summary>
        ///     Verifies DragIntRange2 family exposes expected overloads.
        /// </summary>
        [Fact]
        public void DragIntRange2_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragIntRange2").ToArray();
            Assert.True(methods.Length >= 7);
        }

        /// <summary>
        ///     Verifies DragScalar family exposes expected overloads.
        /// </summary>
        [Fact]
        public void DragScalar_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragScalar").ToArray();
            Assert.True(methods.Length >= 6);
        }

        /// <summary>
        ///     Verifies DragScalarN family exposes expected overloads.
        /// </summary>
        [Fact]
        public void DragScalarN_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragScalarN").ToArray();
            Assert.True(methods.Length >= 6);
        }
    }
}