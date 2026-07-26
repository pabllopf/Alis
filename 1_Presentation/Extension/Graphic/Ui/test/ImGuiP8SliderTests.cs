// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP8SliderTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Drives coverage for the Slider overload families from ImGuiP8.
    /// </summary>
    public class ImGuiP8SliderTest : IDisposable
    {
        internal readonly IntPtr _ctx;

        public ImGuiP8SliderTest()
        {
            _ctx = ImGui.CreateContext();
            ImGui.SetCurrentContext(_ctx);
            ImGuiIoPtr io = ImGui.GetIo();
            io.DisplaySize = new Vector2F(1920f, 1080f);
            io.Fonts.Build();
        }

        public void Dispose()
        {
            ImGui.SetCurrentContext(IntPtr.Zero);
            ImGuiNative.igDestroyContext(_ctx);
        }

        [RequireCImguiSystemFact]
        public void AllSliderOverloads_ShouldExecute()
        {
            float sv = 45.0f;
            ImGui.NewFrame();
            ImGui.Begin("s_all");
            ImGui.SliderAngle("a1", ref sv);
            ImGui.SliderAngle("a2", ref sv, -180.0f);
            ImGui.SliderAngle("a3", ref sv, -180.0f, 180.0f);
            ImGui.SliderAngle("a4", ref sv, -180.0f, 180.0f, "%.1f deg");

            float fv = 50.0f;
            ImGui.SliderFloat("f1", ref fv, 0.0f, 100.0f);
            ImGui.SliderFloat("f2", ref fv, 0.0f, 100.0f, "%.2f");

            Vector2F v2 = new Vector2F(25.0f, 75.0f);
            ImGui.SliderFloat2("f2a", ref v2, 0.0f, 100.0f);
            ImGui.SliderFloat2("f2b", ref v2, 0.0f, 100.0f, "%.2f");

            Vector3F v3 = new Vector3F(10.0f, 50.0f, 90.0f);
            ImGui.SliderFloat3("f3a", ref v3, 0.0f, 100.0f);
            ImGui.SliderFloat3("f3b", ref v3, 0.0f, 100.0f, "%.2f");

            Vector4F v4 = new Vector4F(10.0f, 30.0f, 60.0f, 90.0f);
            ImGui.SliderFloat4("f4a", ref v4, 0.0f, 100.0f);
            ImGui.SliderFloat4("f4b", ref v4, 0.0f, 100.0f, "%.2f");

            ImGui.SliderAngle("a5", ref sv, -180.0f, 180.0f, "%.1f deg", (ImGuiSliderFlags)0);
            ImGui.SliderFloat("f3", ref fv, 0.0f, 100.0f, "%.2f", (ImGuiSliderFlags)0);
            ImGui.SliderFloat2("f2c", ref v2, 0.0f, 100.0f, "%.2f", (ImGuiSliderFlags)0);
            ImGui.SliderFloat3("f3c", ref v3, 0.0f, 100.0f, "%.2f", (ImGuiSliderFlags)0);
            ImGui.SliderFloat4("f4c", ref v4, 0.0f, 100.0f, "%.2f", (ImGuiSliderFlags)0);

            ImGui.End();
            ImGui.Render();
        }
    }
}
