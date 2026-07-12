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
using Alis.Extension.Graphic.Ui.Test.Attributes;
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
        [RequireCImguiSystemFact]
        public void TableSetupColumn_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TableSetupColumn").ToArray();

            Assert.True(methods.Length >= 4);
            Assert.Contains(methods, method => method.GetParameters().Length == 1);
            Assert.Contains(methods, method => method.GetParameters().Length == 2);
            Assert.Contains(methods, method => method.GetParameters().Length == 4);
        }

        /// <summary>
        ///     Verifies table setup APIs expose overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TableSetupScrollFreeze_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TableSetupScrollFreeze", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies tree-node methods expose pointer and string variants.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TreeNodeMethods_ShouldExposePointerAndStringVariants()
        {
            MethodInfo[] treeNode = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TreeNode").ToArray();
            MethodInfo[] treeNodeEx = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TreeNodeEx").ToArray();

            Assert.True(treeNode.Length >= 3);
            Assert.True(treeNodeEx.Length >= 4);
        }

        /// <summary>
        ///     Verifies TreePush pointer and string variants exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TreePush_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TreePush").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies TreePop method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TreePop_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("TreePop", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies Text methods exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TextMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("Text", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("TextColored", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("TextDisabled", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("TextUnformatted", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("TextWrapped", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies Unindent overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Unindent_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Unindent").ToArray();
            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies UpdatePlatformWindows method exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void UpdatePlatformWindows_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("UpdatePlatformWindows", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies Value overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Value_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Value").ToArray();
            Assert.True(methods.Length >= 5);
        }

        /// <summary>
        ///     Verifies VSliderFloat overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void VSliderFloat_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "VSliderFloat").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies VSliderInt overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void VSliderInt_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "VSliderInt").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies VSliderScalar overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void VSliderScalar_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "VSliderScalar").ToArray();
            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies InputText overload families exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputText_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputText").ToArray();
            Assert.True(methods.Length >= 12);
        }

        /// <summary>
        ///     Verifies InputTextMultiline overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputTextMultiline_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputTextMultiline").ToArray();
            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies InputTextWithHint overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void InputTextWithHint_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputTextWithHint").ToArray();
            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies CalcTextSize overloads exist.
        /// </summary>
        [RequireCImguiSystemFact]
        public void CalcTextSize_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "CalcTextSize").ToArray();
            Assert.True(methods.Length >= 9);
        }
    }
}