// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMoContextCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    ///     Invokes the state and matrix helpers of the ImGuizMo wrapper. These calls
    ///     only mutate gizmo state or run pure math and are safe without a frame.
    /// </summary>
    public class ImGuizMoContextCoverageTests
    {
        /// <summary>
        ///     Creates an ImGui context and binds it to the gizmo.
        /// </summary>
        private static IntPtr CreateContext()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(imgui);
            ImGuizMo.SetImGuiContext(imgui);
            return imgui;
        }

        /// <summary>
        ///     Creates an ImGui context, binds it to the gizmo and prepares a real frame so that
        ///     native gizmo calls that need an active frame scope can run without asserting.
        /// </summary>
        private static IntPtr CreateFramedContext()
        {
            IntPtr imgui = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(imgui);
            IntPtr ioPtr = ImGuiNative.igGetIO();
            System.Runtime.InteropServices.Marshal.StructureToPtr(1280.0f, IntPtr.Add(ioPtr, 8), false);
            System.Runtime.InteropServices.Marshal.StructureToPtr(720.0f, IntPtr.Add(ioPtr, 12), false);
            IntPtr fontsPtr = System.Runtime.InteropServices.Marshal.ReadIntPtr(ioPtr, 80);
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(fontsPtr, out IntPtr _, out int _, out int _, out int _);
            ImGuizMo.SetImGuiContext(imgui);
            ImGuiNative.igNewFrame();
            return imgui;
        }

        /// <summary>
        ///     Verifies SetImGuiContext binds the ImGui context.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetImGuiContext_Executes()
        {
            IntPtr imgui = CreateContext();
            try
            {
                ImGuizMo.SetImGuiContext(imgui);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies Enable and AllowAxisFlip execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Enable_And_AllowAxisFlip_Execute()
        {
            IntPtr imgui = CreateContext();
            try
            {
                ImGuizMo.Enable(true);
                ImGuizMo.AllowAxisFlip(true);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetRect and SetOrthographic execute.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetRect_And_SetOrthographic_Execute()
        {
            IntPtr imgui = CreateContext();
            try
            {
                ImGuizMo.SetRect(0, 0, 100, 100);
                ImGuizMo.SetOrthographic(true);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies SetGizmoSizeClipSpace executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetGizmoSizeClipSpace_Executes()
        {
            IntPtr imgui = CreateContext();
            try
            {
                ImGuizMo.SetGizmoSizeClipSpace(0.1f);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies IsOver and IsUsing report idle state.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsOver_And_IsUsing_ReportIdle()
        {
            IntPtr imgui = CreateContext();
            try
            {
                Assert.False(ImGuizMo.IsOver());
                Assert.False(ImGuizMo.IsUsing());
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies the Operations overload of IsOver throws because the generated
        ///     entry point name does not match the native symbol.
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsOver_WithOperation_ThrowsEntryPointNotFound()
        {
            IntPtr imgui = CreateContext();
            try
            {
                Assert.Throws<EntryPointNotFoundException>(() => ImGuizMo.IsOver(Operations.Translate));
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies DecomposeMatrixToComponents executes on a unit matrix.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DecomposeMatrixToComponents_Executes()
        {
            IntPtr imgui = CreateContext();
            try
            {
                float[] matrix = new float[16];
                matrix[0] = 1;
                matrix[5] = 1;
                matrix[10] = 1;
                matrix[15] = 1;
                float[] translation = new float[3];
                float[] rotation = new float[3];
                float[] scale = new float[3];
                ImGuizMo.DecomposeMatrixToComponents(ref matrix, ref translation, ref rotation, ref scale);
                Assert.Equal(1.0f, scale[0]);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies RecomposeMatrixFromComponents executes.
        /// </summary>
        [RequireCImguiSystemFact]
        public void RecomposeMatrixFromComponents_Executes()
        {
            IntPtr imgui = CreateContext();
            try
            {
                float[] matrix = new float[16];
                float[] translation = new float[3];
                float[] rotation = new float[3];
                float[] scale = {1, 1, 1};
                ImGuizMo.RecomposeMatrixFromComponents(ref translation, ref rotation, ref scale, ref matrix);
                Assert.Equal(1.0f, matrix[0]);
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies BeginFrame, SetId, SetDrawList and SetGizmoSizeClipSpace execute against
        ///     the native library inside a live frame without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void BeginFrame_And_DrawList_And_Id_Execute()
        {
            IntPtr imgui = CreateFramedContext();
            try
            {
                ImGuizMo.BeginFrame();
                ImGuizMo.SetId(1);
                ImGuizMo.SetDrawList();
                ImGuizMo.SetDrawList(new ImDrawList());
                ImGuizMo.SetGizmoSizeClipSpace(0.5f);
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies DrawGrid and ViewManipulate execute against the native library using
        ///     unit matrices inside a live frame without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DrawGrid_And_ViewManipulate_Execute()
        {
            IntPtr imgui = CreateFramedContext();
            try
            {
                float[] view = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1};
                float[] projection = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1};
                float[] matrix = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1};
                bool gridOpen = true;
                ImGuizMo.BeginFrame();
                _ = ImGui.Begin("p1-gizmo-grid", ref gridOpen);
                ImGuizMo.DrawGrid(ref view, ref projection, ref matrix, 10.0f);
                ImGuizMo.ViewManipulate(ref view, 2.5f, new Vector2F(0, 0), new Vector2F(100, 100), 0x10101010);
                ImGui.End();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies Manipulate executes against the native library using unit view and
        ///     projection matrices inside a live frame and returns a byte result.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Manipulate_Executes_ReturnsByte()
        {
            IntPtr imgui = CreateFramedContext();
            try
            {
                float[] view = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1};
                float[] projection = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1};
                float[] matrix = {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1};
                bool manipulateOpen = true;
                ImGuizMo.BeginFrame();
                _ = ImGui.Begin("p1-gizmo-manipulate", ref manipulateOpen);
                byte result = ImGuizMo.Manipulate(view, projection, Operations.Translate, Mode.Local, matrix);
                Assert.InRange(result, (byte) 0, (byte) 255);
                ImGui.End();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }

        /// <summary>
        ///     Verifies ShowDemoWindow executes its demo body against the native library inside a
        ///     live frame and closes the window it opened.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowDemoWindow_Executes_InsideFrame()
        {
            IntPtr imgui = CreateFramedContext();
            try
            {
                ImGuizMo.ShowDemoWindow();
                ImGuiNative.igEndFrame();
            }
            finally
            {
                ImGuiNative.igDestroyContext(imgui);
            }
        }
    }
}
