// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP4Test.cs
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
    ///     Provides API-surface coverage for methods contributed by ImGuiP4 wrappers.
    /// </summary>
    public class ImGuiP4Test
    {
        /// <summary>
        ///     Verifies table setup APIs expose overloads.
        /// </summary>
        [Fact]
        public void TableSetupColumn_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TableSetupColumn").ToArray();

            Assert.True(methods.Length >= 3);
            Assert.Contains(methods, method => method.GetParameters().Length == 2);
            Assert.Contains(methods, method => method.GetParameters().Length == 4);
        }

        /// <summary>
        ///     Verifies tree-node methods expose pointer and string variants.
        /// </summary>
        [Fact]
        public void TreeNodeMethods_ShouldExposePointerAndStringVariants()
        {
            MethodInfo[] treeNode = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TreeNode").ToArray();
            MethodInfo[] treeNodeEx = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TreeNodeEx").ToArray();

            Assert.True(treeNode.Length >= 3);
            Assert.True(treeNodeEx.Length >= 4);
        }
    }
}