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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides API-surface and execution coverage for methods contributed by ImGuiP2 wrappers.
    /// </summary>
    public class ImGuiP2Test : IDisposable
    {
        internal readonly IntPtr _ctx;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiP2Test"/> class.
        /// </summary>
        public ImGuiP2Test()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        /// <summary>
        ///     Disposes the test context.
        /// </summary>
        public void Dispose()
        {
            ImGuiNative.igDestroyContext(_ctx);
        }

        /// <summary>
        ///     Verifies all DragInt overloads execute without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragInt_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;

            ImGui.DragInt("s1", ref v, 1.0f);
            ImGui.DragInt("s2", ref v, 1.0f, 0);
            ImGui.DragInt("s3", ref v, 1.0f, 0, 100);
            ImGui.DragInt("s4", ref v, 1.0f, 0, 100, "%d");
            ImGui.DragInt("s5", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None);

            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Verifies all DragInt2 overloads execute without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragInt2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;

            ImGui.DragInt2("s1", ref v);
            ImGui.DragInt2("s2", ref v, 1.0f);
            ImGui.DragInt2("s3", ref v, 1.0f, 0);
            ImGui.DragInt2("s4", ref v, 1.0f, 0, 100);
            ImGui.DragInt2("s5", ref v, 1.0f, 0, 100, "%d");
            ImGui.DragInt2("s6", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None);

            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Verifies all DragInt3 overloads execute without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragInt3_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;

            ImGui.DragInt3("s1", ref v);
            ImGui.DragInt3("s2", ref v, 1.0f);
            ImGui.DragInt3("s3", ref v, 1.0f, 0);
            ImGui.DragInt3("s4", ref v, 1.0f, 0, 100);
            ImGui.DragInt3("s5", ref v, 1.0f, 0, 100, "%d");
            ImGui.DragInt3("s6", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None);

            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Verifies all DragInt4 overloads execute without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragInt4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int v = 0;

            ImGui.DragInt4("s1", ref v);
            ImGui.DragInt4("s2", ref v, 1.0f);
            ImGui.DragInt4("s3", ref v, 1.0f, 0);
            ImGui.DragInt4("s4", ref v, 1.0f, 0, 100);
            ImGui.DragInt4("s5", ref v, 1.0f, 0, 100, "%d");
            ImGui.DragInt4("s6", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None);

            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Verifies all DragIntRange2 overloads execute without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragIntRange2_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            int vMin = 0;
            int vMax = 100;

            ImGui.DragIntRange2("s1", ref vMin, ref vMax);
            ImGui.DragIntRange2("s2", ref vMin, ref vMax, 1.0f);
            ImGui.DragIntRange2("s3", ref vMin, ref vMax, 1.0f, 0);
            ImGui.DragIntRange2("s4", ref vMin, ref vMax, 1.0f, 0, 100);
            ImGui.DragIntRange2("s5", ref vMin, ref vMax, 1.0f, 0, 100, "%d");
            ImGui.DragIntRange2("s6", ref vMin, ref vMax, 1.0f, 0, 100, "%d", "");
            ImGui.DragIntRange2("s7", ref vMin, ref vMax, 1.0f, 0, 100, "%d", "", ImGuiSliderFlags.None);

            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Verifies all DragScalar overloads execute without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragScalar_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            IntPtr pData = Marshal.AllocHGlobal(sizeof(int));
            Marshal.WriteInt32(pData, 0);

            ImGui.DragScalar("s1", ImGuiDataType.S32, pData);
            ImGui.DragScalar("s2", ImGuiDataType.S32, pData, 1.0f);
            ImGui.DragScalar("s3", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero);
            ImGui.DragScalar("s4", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero, IntPtr.Zero);
            ImGui.DragScalar("s5", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero, IntPtr.Zero, "%d");
            ImGui.DragScalar("s6", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero, IntPtr.Zero, "%d", ImGuiSliderFlags.None);

            Marshal.FreeHGlobal(pData);
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Verifies all DragScalarN overloads execute without throwing.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DragScalarN_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            IntPtr pData = Marshal.AllocHGlobal(sizeof(int) * 4);
            Marshal.WriteInt32(pData, 0);
            Marshal.WriteInt32(pData + sizeof(int), 0);
            Marshal.WriteInt32(pData + sizeof(int) * 2, 0);
            Marshal.WriteInt32(pData + sizeof(int) * 3, 0);

            ImGui.DragScalarN("s1", ImGuiDataType.S32, pData, 4);
            ImGui.DragScalarN("s2", ImGuiDataType.S32, pData, 4, 1.0f);
            ImGui.DragScalarN("s3", ImGuiDataType.S32, pData, 4, 1.0f, IntPtr.Zero);

            Marshal.FreeHGlobal(pData);
            ImGui.End();
            ImGui.Render();
        }
    }
}