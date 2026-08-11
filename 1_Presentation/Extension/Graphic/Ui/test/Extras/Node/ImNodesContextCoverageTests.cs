// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImNodesContextCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Node;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Invokes the context lifecycle entry points of the ImNodes wrapper. Only
    ///     context creation and switching are safe without an ImGui frame; editor
    ///     drawing and style access remain frame-dependent.
    /// </summary>
    public class ImNodesContextCoverageTests
    {
        /// <summary>
        ///     Verifies CreateContext executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void CreateContext_Executes()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                ImNodesContext context = ImNodes.CreateContext();
                _ = ImNodes.GetCurrentContext();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetCurrentContext and GetCurrentContext execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetCurrentContext_And_GetCurrentContext_Execute()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                ImNodesContext context = ImNodes.CreateContext();
                ImNodes.SetCurrentContext(context);
                _ = ImNodes.GetCurrentContext();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies DestroyContext with an explicit context executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DestroyContext_WithExplicitContext_Executes()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                ImNodesContext context = ImNodes.CreateContext();
                ImNodes.DestroyContext(context);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies DestroyContext without arguments executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DestroyContext_WithoutArguments_Executes()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                ImNodes.CreateContext();
                ImNodes.DestroyContext();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies EditorContextCreate executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void EditorContextCreate_Executes()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                ImNodesContext context = ImNodes.CreateContext();
                ImNodes.SetCurrentContext(context);
                _ = ImNodes.EditorContextCreate();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies GetIo throws because the generated wrapper cannot marshal the
        ///     backing struct fields.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetIo_ThrowsTypeLoadException()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                ImNodesContext context = ImNodes.CreateContext();
                ImNodes.SetCurrentContext(context);
                Assert.Throws<TypeLoadException>(() => ImNodes.GetIo());
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies GetStyle throws because the generated wrapper cannot marshal
        ///     the backing struct fields.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GetStyle_ThrowsTypeLoadException()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            try
            {
                ImGuiNative.igSetCurrentContext(imgui);
                ImNodesContext context = ImNodes.CreateContext();
                ImNodes.SetCurrentContext(context);
                Assert.Throws<TypeLoadException>(() => ImNodes.GetStyle());
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }
    }
}
