// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP8.cs
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
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Native
{
    /// <summary>
    ///     The im gui test class
    /// </summary>
    public class ImGuiTestP8
    {
        /// <summary>
        ///     Tests that show about window should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowAboutWindow_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowAboutWindow());
        }

        /// <summary>
        ///     Tests that show about window should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ShowAboutWindow_ShouldThrowDllNotFoundException_v2()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowAboutWindow(ref pOpen));
        }

        /// <summary>
        ///     Tests that show debug log window should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowDebugLogWindow_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowDebugLogWindow());
        }

        /// <summary>
        ///     Tests that show debug log window should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ShowDebugLogWindow_ShouldThrowDllNotFoundException_v2()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowDebugLogWindow(ref pOpen));
        }

        /// <summary>
        ///     Tests that show demo window should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowDemoWindow_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowDemoWindow());
        }

        /// <summary>
        ///     Tests that show demo window should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ShowDemoWindow_ShouldThrowDllNotFoundException_v2()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowDemoWindow(ref pOpen));
        }

        /// <summary>
        ///     Tests that show font selector should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowFontSelector_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowFontSelector("label"));
        }

        /// <summary>
        ///     Tests that show metrics window should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowMetricsWindow_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowMetricsWindow());
        }

        /// <summary>
        ///     Tests that show metrics window should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ShowMetricsWindow_ShouldThrowDllNotFoundException_v2()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowMetricsWindow(ref pOpen));
        }

        /// <summary>
        ///     Tests that show stack tool window should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowStackToolWindow_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowStackToolWindow());
        }

        /// <summary>
        ///     Tests that show stack tool window should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ShowStackToolWindow_ShouldThrowDllNotFoundException_v2()
        {
            bool pOpen = true;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowStackToolWindow(ref pOpen));
        }

        /// <summary>
        ///     Tests that show style editor should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowStyleEditor_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowStyleEditor());
        }

        /// <summary>
        ///     Tests that show style editor should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void ShowStyleEditor_ShouldThrowDllNotFoundException_v2()
        {
            ImGuiStyle style = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowStyleEditor(style));
        }

        /// <summary>
        ///     Tests that show style selector should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowStyleSelector_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowStyleSelector("label"));
        }

        /// <summary>
        ///     Tests that show user guide should throw dll not found exception
        /// </summary>
        [Fact]
        public void ShowUserGuide_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ShowUserGuide());
        }

        /// <summary>
        ///     Tests that slider angle should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void SliderAngle_ShouldThrowDllNotFoundException_v1()
        {
            float vRad = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderAngle("label", ref vRad));
        }

        /// <summary>
        ///     Tests that slider angle should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void SliderAngle_ShouldThrowDllNotFoundException_v2()
        {
            float vRad = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderAngle("label", ref vRad, -360.0f));
        }

        /// <summary>
        ///     Tests that slider angle should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void SliderAngle_ShouldThrowDllNotFoundException_v3()
        {
            float vRad = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderAngle("label", ref vRad, -360.0f, 360.0f));
        }

        /// <summary>
        ///     Tests that slider angle should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void SliderAngle_ShouldThrowDllNotFoundException_v4()
        {
            float vRad = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderAngle("label", ref vRad, -360.0f, 360.0f, "%.0f deg"));
        }

        /// <summary>
        ///     Tests that slider angle should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void SliderAngle_ShouldThrowDllNotFoundException_v5()
        {
            float vRad = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderAngle("label", ref vRad, -360.0f, 360.0f, "%.0f deg", 0));
        }

        /// <summary>
        ///     Tests that slider float should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void SliderFloat_ShouldThrowDllNotFoundException_v1()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat("label", ref v, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that slider float should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void SliderFloat_ShouldThrowDllNotFoundException_v2()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat("label", ref v, 0.0f, 1.0f, "%.3f"));
        }

        /// <summary>
        ///     Tests that slider float should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void SliderFloat_ShouldThrowDllNotFoundException_v3()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat("label", ref v, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that slider float 2 should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void SliderFloat2_ShouldThrowDllNotFoundException_v1()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat2("label", ref v, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that slider float 2 should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void SliderFloat2_ShouldThrowDllNotFoundException_v2()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat2("label", ref v, 0.0f, 1.0f, "%.3f"));
        }

        /// <summary>
        ///     Tests that slider float 2 should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void SliderFloat2_ShouldThrowDllNotFoundException_v3()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat2("label", ref v, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that slider float 3 should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void SliderFloat3_ShouldThrowDllNotFoundException_v1()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat3("label", ref v, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that slider float 3 should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void SliderFloat3_ShouldThrowDllNotFoundException_v2()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat3("label", ref v, 0.0f, 1.0f, "%.3f"));
        }

        /// <summary>
        ///     Tests that slider float 3 should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void SliderFloat3_ShouldThrowDllNotFoundException_v3()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat3("label", ref v, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that slider float 4 should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void SliderFloat4_ShouldThrowDllNotFoundException_v1()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat4("label", ref v, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that slider float 4 should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void SliderFloat4_ShouldThrowDllNotFoundException_v2()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat4("label", ref v, 0.0f, 1.0f, "%.3f"));
        }
    }
}