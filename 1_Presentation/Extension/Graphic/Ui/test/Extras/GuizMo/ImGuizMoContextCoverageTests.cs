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
    }
}
