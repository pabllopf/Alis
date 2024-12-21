// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP1.cs
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
    public class ImGuiTestP1
    {
        /// <summary>
        ///     Tests that combo should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void Combo_ShouldThrowDllNotFoundException_v1()
        {
            int currentItem = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Combo("label", ref currentItem, "items"));
        }

        /// <summary>
        ///     Tests that combo should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void Combo_ShouldThrowDllNotFoundException_v2()
        {
            int currentItem = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Combo("label", ref currentItem, "items", 10));
        }

        /// <summary>
        ///     Tests that create context should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void CreateContext_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext());
        }

        /// <summary>
        ///     Tests that create context should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void CreateContext_ShouldThrowDllNotFoundException_v2()
        {
            ImFontAtlasPtr sharedFontAtlas = new ImFontAtlasPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext(sharedFontAtlas));
        }

        /// <summary>
        ///     Tests that debug check version and data layout should throw dll not found exception
        /// </summary>
        [Fact]
        public void DebugCheckVersionAndDataLayout_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DebugCheckVersionAndDataLayout("version", 1, 1, 1, 1, 1, 1));
        }

        /// <summary>
        ///     Tests that debug text encoding should throw dll not found exception
        /// </summary>
        [Fact]
        public void DebugTextEncoding_ShouldThrowDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DebugTextEncoding("text"));
        }

        /// <summary>
        ///     Tests that dock space should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DockSpace_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1));
        }

        /// <summary>
        ///     Tests that dock space should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DockSpace_ShouldThrowDllNotFoundException_v2()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size));
        }

        /// <summary>
        ///     Tests that dock space should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DockSpace_ShouldThrowDllNotFoundException_v3()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size, 0));
        }

        /// <summary>
        ///     Tests that dock space should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void DockSpace_ShouldThrowDllNotFoundException_v4()
        {
            Vector2F size = new Vector2F();
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size, 0, windowClass));
        }

        /// <summary>
        ///     Tests that dock space over viewport should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DockSpaceOverViewport_ShouldThrowDllNotFoundException_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport());
        }

        /// <summary>
        ///     Tests that dock space over viewport should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DockSpaceOverViewport_ShouldThrowDllNotFoundException_v2()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport));
        }

        /// <summary>
        ///     Tests that dock space over viewport should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DockSpaceOverViewport_ShouldThrowDllNotFoundException_v3()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr(IntPtr.Zero);
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport, 0));
        }

        /// <summary>
        ///     Tests that dock space over viewport should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void DockSpaceOverViewport_ShouldThrowDllNotFoundException_v4()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr(IntPtr.Zero);
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport, 0, windowClass));
        }

        /// <summary>
        ///     Tests that drag float should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragFloat_ShouldThrowDllNotFoundException_v1()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v));
        }

        /// <summary>
        ///     Tests that drag float should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragFloat_ShouldThrowDllNotFoundException_v2()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragFloat_ShouldThrowDllNotFoundException_v3()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that drag float should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void DragFloat_ShouldThrowDllNotFoundException_v4()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void DragFloat_ShouldThrowDllNotFoundException_v5()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f, "format"));
        }

        /// <summary>
        ///     Tests that drag float should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void DragFloat_ShouldThrowDllNotFoundException_v6()
        {
            float v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f, "format", 0));
        }

        /// <summary>
        ///     Tests that drag float 2 should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragFloat2_ShouldThrowDllNotFoundException_v1()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v));
        }

        /// <summary>
        ///     Tests that drag float 2 should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragFloat2_ShouldThrowDllNotFoundException_v2()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float 2 should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragFloat2_ShouldThrowDllNotFoundException_v3()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that drag float 2 should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void DragFloat2_ShouldThrowDllNotFoundException_v4()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float 2 should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void DragFloat2_ShouldThrowDllNotFoundException_v5()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f, "format"));
        }

        /// <summary>
        ///     Tests that drag float 2 should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void DragFloat2_ShouldThrowDllNotFoundException_v6()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f, "format", 0));
        }

        /// <summary>
        ///     Tests that drag float 3 should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragFloat3_ShouldThrowDllNotFoundException_v1()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v));
        }

        /// <summary>
        ///     Tests that drag float 3 should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragFloat3_ShouldThrowDllNotFoundException_v2()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float 3 should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragFloat3_ShouldThrowDllNotFoundException_v3()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that drag float 3 should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void DragFloat3_ShouldThrowDllNotFoundException_v4()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float 3 should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void DragFloat3_ShouldThrowDllNotFoundException_v5()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f, "format"));
        }

        /// <summary>
        ///     Tests that drag float 3 should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void DragFloat3_ShouldThrowDllNotFoundException_v6()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f, "format", 0));
        }

        /// <summary>
        ///     Tests that drag float 4 should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragFloat4_ShouldThrowDllNotFoundException_v1()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v));
        }

        /// <summary>
        ///     Tests that drag float 4 should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragFloat4_ShouldThrowDllNotFoundException_v2()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float 4 should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragFloat4_ShouldThrowDllNotFoundException_v3()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that drag float 4 should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void DragFloat4_ShouldThrowDllNotFoundException_v4()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float 4 should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void DragFloat4_ShouldThrowDllNotFoundException_v5()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f, "format"));
        }

        /// <summary>
        ///     Tests that drag float 4 should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void DragFloat4_ShouldThrowDllNotFoundException_v6()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f, "format", 0));
        }

        /// <summary>
        ///     Tests that drag float range 2 should throw dll not found exception v 1
        /// </summary>
        [Fact]
        public void DragFloatRange2_ShouldThrowDllNotFoundException_v1()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax));
        }

        /// <summary>
        ///     Tests that drag float range 2 should throw dll not found exception v 2
        /// </summary>
        [Fact]
        public void DragFloatRange2_ShouldThrowDllNotFoundException_v2()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float range 2 should throw dll not found exception v 3
        /// </summary>
        [Fact]
        public void DragFloatRange2_ShouldThrowDllNotFoundException_v3()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that drag float range 2 should throw dll not found exception v 4
        /// </summary>
        [Fact]
        public void DragFloatRange2_ShouldThrowDllNotFoundException_v4()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that drag float range 2 should throw dll not found exception v 5
        /// </summary>
        [Fact]
        public void DragFloatRange2_ShouldThrowDllNotFoundException_v5()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "format"));
        }

        /// <summary>
        ///     Tests that drag float range 2 should throw dll not found exception v 6
        /// </summary>
        [Fact]
        public void DragFloatRange2_ShouldThrowDllNotFoundException_v6()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "format", "formatMax"));
        }

        /// <summary>
        ///     Tests that drag int should throw dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_ShouldThrowDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v));
        }
    }
}