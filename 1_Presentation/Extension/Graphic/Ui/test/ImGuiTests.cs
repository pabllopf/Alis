// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTests.cs
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
    ///     The im gui tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class ImGuiTests : IDisposable
    {
        /// <summary>
        ///     The ctx
        /// </summary>
        internal readonly IntPtr _ctx;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiTests"/> class
        /// </summary>
        public ImGuiTests()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            var io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            ImGuiNative.igDestroyContext(_ctx);
        }

        /// <summary>
        ///     Sliders the float 4 all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderFloat4_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            Vector4F v = new Vector4F(0, 0, 0, 0);
            bool r1 = ImGui.SliderFloat4("sf4_1", ref v, 0, 1);
            bool r2 = ImGui.SliderFloat4("sf4_2", ref v, 0, 1, "%.3f");
            bool r3 = ImGui.SliderFloat4("sf4_3", ref v, 0, 1, "%.3f", ImGuiSliderFlags.None);
            _ = r1;
            _ = r2;
            _ = r3;
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Sliders the scalar all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderScalar_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float val = 50.0f;
            float min = 0.0f;
            float max = 100.0f;

            IntPtr pData = Marshal.AllocHGlobal(sizeof(float));
            IntPtr pMin = Marshal.AllocHGlobal(sizeof(float));
            IntPtr pMax = Marshal.AllocHGlobal(sizeof(float));
            Marshal.StructureToPtr(val, pData, false);
            Marshal.StructureToPtr(min, pMin, false);
            Marshal.StructureToPtr(max, pMax, false);

            bool r1 = ImGui.SliderScalar("s1", ImGuiDataType.Float, pData, pMin, pMax);
            bool r2 = ImGui.SliderScalar("s2", ImGuiDataType.Float, pData, pMin, pMax, "%.1f");
            bool r3 = ImGui.SliderScalar("s3", ImGuiDataType.Float, pData, pMin, pMax, "%.1f", ImGuiSliderFlags.None);

            _ = r1;
            _ = r2;
            _ = r3;

            Marshal.FreeHGlobal(pData);
            Marshal.FreeHGlobal(pMin);
            Marshal.FreeHGlobal(pMax);

            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Sliders the scalar n all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void SliderScalarN_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float[] vals = { 10.0f, 20.0f, 30.0f };
            float min = 0.0f;
            float max = 100.0f;

            IntPtr pData = Marshal.AllocHGlobal(sizeof(float) * 3);
            IntPtr pMin = Marshal.AllocHGlobal(sizeof(float));
            IntPtr pMax = Marshal.AllocHGlobal(sizeof(float));
            Marshal.Copy(vals, 0, pData, 3);
            Marshal.StructureToPtr(min, pMin, false);
            Marshal.StructureToPtr(max, pMax, false);

            bool r1 = ImGui.SliderScalarN("s1", ImGuiDataType.Float, pData, 3, pMin, pMax);
            bool r2 = ImGui.SliderScalarN("s2", ImGuiDataType.Float, pData, 3, pMin, pMax, "%.1f");
            bool r3 = ImGui.SliderScalarN("s3", ImGuiDataType.Float, pData, 3, pMin, pMax, "%.1f", ImGuiSliderFlags.None);

            _ = r1;
            _ = r2;
            _ = r3;

            Marshal.FreeHGlobal(pData);
            Marshal.FreeHGlobal(pMin);
            Marshal.FreeHGlobal(pMax);

            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Tables the get column flags no arg should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void TableGetColumnFlags_NoArg_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("A");
                ImGui.TableSetupColumn("B");
                ImGui.TableHeadersRow();
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGuiTableColumnFlags flags = ImGui.TableGetColumnFlags();
                _ = flags;
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }

        /// <summary>
        ///     Tables the get column name all overloads should execute
        /// </summary>
        [RequireCImguiSystemFact]
        public void TableGetColumnName_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            if (ImGui.BeginTable("t", 2))
            {
                ImGui.TableSetupColumn("ColA");
                ImGui.TableSetupColumn("ColB");
                ImGui.TableHeadersRow();
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                string name = ImGui.TableGetColumnName();
                _ = name;
                string name0 = ImGui.TableGetColumnName(0);
                _ = name0;
                ImGui.EndTable();
            }
            ImGui.End();
            ImGui.Render();
        }
    }
}
