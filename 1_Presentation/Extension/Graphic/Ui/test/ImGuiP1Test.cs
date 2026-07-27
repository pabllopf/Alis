// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP1Test.cs
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

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides API-surface coverage for methods contributed by ImGuiP1 wrappers.
    /// </summary>
    public class ImGuiP1Test
    {
        /// <summary>
        ///     Verifies that docking and context API overloads are available on ImGui.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DockingAndContextApi_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] createContext = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "CreateContext").ToArray();
            MethodInfo[] dockSpace = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DockSpace").ToArray();
            MethodInfo[] dockSpaceOverViewport = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DockSpaceOverViewport").ToArray();

            Assert.True(createContext.Length >= 2);
            Assert.True(dockSpace.Length >= 4);
            Assert.True(dockSpaceOverViewport.Length >= 4);
        }

        /// <summary>
        ///     Verifies that Combo overload family exists.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Combo_ShouldExposeMultipleOverloads()
        {
            MethodInfo[] combo = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Combo").ToArray();

            Assert.True(combo.Length >= 2);
            Assert.Contains(combo, method => method.GetParameters().Length == 3);
            Assert.Contains(combo, method => method.GetParameters().Length == 4);
        }

        /// <summary>
        ///     Verifies DragFloat family exposes expected overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragFloat_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragFloat").ToArray();
            Assert.True(methods.Length >= 6);
        }

        /// <summary>
        ///     Verifies DragFloat2 family exposes expected overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragFloat2_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragFloat2").ToArray();
            Assert.True(methods.Length >= 6);
        }

        /// <summary>
        ///     Verifies DragFloat3 family exposes expected overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragFloat3_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragFloat3").ToArray();
            Assert.True(methods.Length >= 6);
        }

        /// <summary>
        ///     Verifies DragFloat4 family exposes expected overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragFloat4_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragFloat4").ToArray();
            Assert.True(methods.Length >= 6);
        }

        /// <summary>
        ///     Verifies DragFloatRange2 family exposes expected overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragFloatRange2_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragFloatRange2").ToArray();
            Assert.True(methods.Length >= 6);
        }

        /// <summary>
        ///     Verifies DebugCheckVersionAndDataLayout executes without error.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DebugCheckVersionAndDataLayout_ShouldExecute()
        {
            IntPtr ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(ctx);

            string version = ImGui.GetVersion();
            bool result = ImGui.DebugCheckVersionAndDataLayout(
                version,
                (uint)Marshal.SizeOf<ImGuiIo>(),
                (uint)Marshal.SizeOf<ImGuiStyle>(),
                (uint)Marshal.SizeOf<Vector2F>(),
                (uint)Marshal.SizeOf<Vector4F>(),
                (uint)Marshal.SizeOf<ImDrawVert>(),
                (uint)Marshal.SizeOf<ushort>());
            _ = result;

            ImGuiNative.igDestroyContext(ctx);
        }
    }
}
