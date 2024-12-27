// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTest.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Native
{
    /// <summary>
    ///     The im gui test class
    /// </summary>
    	  
	 public class ImGuiTest 
    {
        /// <summary>
        ///     Tests that test im gui version
        /// </summary>
        [Fact]
        public void Test_ImGui_Version()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetVersion());
        }

        /// <summary>
        ///     Tests that test im gui create context
        /// </summary>
        [Fact]
        public void Test_ImGui_CreateContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext());
        }

        /// <summary>
        ///     Tests that test combo with label and current item and items separated by zeros
        /// </summary>
        [Fact]
        public void Test_Combo_WithLabelAndCurrentItemAndItemsSeparatedByZeros()
        {
            int currentItem = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Combo("label", ref currentItem, "item1\0item2\0item3\0"));
        }

        /// <summary>
        ///     Tests that test combo with label and current item and items separated by zeros and popup max height in items
        /// </summary>
        [Fact]
        public void Test_Combo_WithLabelAndCurrentItemAndItemsSeparatedByZerosAndPopupMaxHeightInItems()
        {
            int currentItem = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Combo("label", ref currentItem, "item1\0item2\0item3\0", 10));
        }

        /// <summary>
        ///     Tests that test create context
        /// </summary>
        [Fact]
        public void Test_CreateContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext());
        }

        /// <summary>
        ///     Tests that test create context with shared font atlas
        /// </summary>
        [Fact]
        public void Test_CreateContext_WithSharedFontAtlas()
        {
            ImFontAtlasPtr sharedFontAtlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext(sharedFontAtlas));
        }

        /// <summary>
        ///     Tests that test debug check version and data layout
        /// </summary>
        [Fact]
        public void Test_DebugCheckVersionAndDataLayout()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DebugCheckVersionAndDataLayout("1.0.0", 1, 1, 1, 1, 1, 1));
        }

        /// <summary>
        ///     Tests that test debug text encoding
        /// </summary>
        [Fact]
        public void Test_DebugTextEncoding()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DebugTextEncoding("test"));
        }

        /// <summary>
        ///     Tests that test dock space with id
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithId()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1));
        }

        /// <summary>
        ///     Tests that test dock space with id and size
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithIdAndSize()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size));
        }

        /// <summary>
        ///     Tests that test dock space with id and size and flags
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithIdAndSizeAndFlags()
        {
            Vector2F size = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size, 0));
        }

        /// <summary>
        ///     Tests that test dock space with id and size and flags and window
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithIdAndSizeAndFlagsAndWindowClass()
        {
            Vector2F size = new Vector2F();
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size, 0, windowClass));
        }

        /// <summary>
        ///     Tests that test dock space over viewport
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport());
        }

        /// <summary>
        ///     Tests that test dock space over viewport with viewport
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport_WithViewport()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport));
        }

        /// <summary>
        ///     Tests that test dock space over viewport with viewport and flags
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport_WithViewportAndFlags()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport, 0));
        }

        /// <summary>
        ///     Tests that test dock space over viewport with viewport and flags and window
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport_WithViewportAndFlagsAndWindowClass()
        {
            ImGuiViewportPtr viewport = new ImGuiViewportPtr();
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport, 0, windowClass));
        }

        /// <summary>
        ///     Tests that test drag float with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndV()
        {
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v));
        }

        /// <summary>
        ///     Tests that test drag float with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeed()
        {
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMin()
        {
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that test drag float with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
        }


        /// <summary>
        ///     Tests that test drag float with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test drag float 2 with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndV()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v));
        }

        /// <summary>
        ///     Tests that test drag float 2 with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeed()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float 2 with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMin()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that test drag float 2 with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float 2 with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
        }

        /// <summary>
        ///     Tests that test drag float 2 with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            Vector2F v = new Vector2F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test drag float 3 with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndV()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v));
        }

        /// <summary>
        ///     Tests that test drag float 3 with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeed()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f));
        }


        /// <summary>
        ///     Tests that test drag float 3 with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMin()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that test drag float 3 with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float 3 with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
        }

        /// <summary>
        ///     Tests that test drag float 3 with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            Vector3F v = new Vector3F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test drag float 4 with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndV()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v));
        }

        /// <summary>
        ///     Tests that test drag float 4 with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeed()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float 4 with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMin()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that test drag float 4 with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f));
        }


        /// <summary>
        ///     Tests that test drag float 4 with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
        }

        /// <summary>
        ///     Tests that test drag float 4 with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test drag float range 2 with label and v current min and v current max
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMax()
        {
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax));
        }

        /// <summary>
        ///     Tests that test drag float range 2 with label and v current min and v current max and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeed()
        {
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float range 2 with label and v current min and v current max and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMin()
        {
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f));
        }

        /// <summary>
        ///     Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMax()
        {
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max
        ///     and format
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMaxAndFormat()
        {
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "%.3f"));
        }

        /// <summary>
        ///     Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max
        ///     and format and format max
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMaxAndFormatAndFormatMax()
        {
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "%.3f", "%.3f"));
        }

        /// <summary>
        ///     Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max
        ///     and format and format max and flags
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMaxAndFormatAndFormatMaxAndFlags()
        {
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "%.3f", "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test drag int with label and v
        /// </summary>
        [Fact]
        public void Test_DragInt_WithLabelAndV()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v));
        }

        /// <summary>
        ///     Tests that test slider float 4 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderFloat4_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            Vector4F v = new Vector4F();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat4("label", ref v, 0.0f, 1.0f, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test slider int with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt("label", ref v, 0, 100));
        }

        /// <summary>
        ///     Tests that test slider int with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt("label", ref v, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that test slider int with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt("label", ref v, 0, 100, "%d", 0));
        }

        /// <summary>
        ///     Tests that test slider int 2 with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100));
        }

        /// <summary>
        ///     Tests that test slider int 2 with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that test slider int 2 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d", 0));
        }

        /// <summary>
        ///     Tests that test slider int 3 with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100));
        }

        /// <summary>
        ///     Tests that test slider int 3 with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that test slider int 3 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d", 0));
        }

        /// <summary>
        ///     Tests that test slider int 4 with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100));
        }

        /// <summary>
        ///     Tests that test slider int 4 with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that test slider int 4 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d", 0));
        }

        /// <summary>
        ///     Tests that test slider scalar with label and data type and p data and p min and p max
        /// </summary>
        [Fact]
        public void Test_SliderScalar_WithLabelAndDataTypeAndPDataAndPMinAndPMax()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalar("label", ImGuiDataType.Float, pData, pMin, pMax));
        }

        /// <summary>
        ///     Tests that test slider scalar with label and data type and p data and p min and p max and format
        /// </summary>
        [Fact]
        public void Test_SliderScalar_WithLabelAndDataTypeAndPDataAndPMinAndPMaxAndFormat()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalar("label", ImGuiDataType.Float, pData, pMin, pMax, "%.3f"));
        }

        /// <summary>
        ///     Tests that test slider scalar with label and data type and p data and p min and p max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderScalar_WithLabelAndDataTypeAndPDataAndPMinAndPMaxAndFormatAndFlags()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalar("label", ImGuiDataType.Float, pData, pMin, pMax, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test slider scalar n with label and data type and p data and components and p min and p max
        /// </summary>
        [Fact]
        public void Test_SliderScalarN_WithLabelAndDataTypeAndPDataAndComponentsAndPMinAndPMax()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalarN("label", ImGuiDataType.Float, pData, 4, pMin, pMax));
        }

        /// <summary>
        ///     Tests that test slider scalar n with label and data type and p data and components and p min and p max and format
        /// </summary>
        [Fact]
        public void Test_SliderScalarN_WithLabelAndDataTypeAndPDataAndComponentsAndPMinAndPMaxAndFormat()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalarN("label", ImGuiDataType.Float, pData, 4, pMin, pMax, "%.3f"));
        }

        /// <summary>
        ///     Tests that test slider scalar n with label and data type and p data and components and p min and p max and format
        ///     and flags
        /// </summary>
        [Fact]
        public void Test_SliderScalarN_WithLabelAndDataTypeAndPDataAndComponentsAndPMinAndPMaxAndFormatAndFlags()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalarN("label", ImGuiDataType.Float, pData, 4, pMin, pMax, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test small button with label
        /// </summary>
        [Fact]
        public void Test_SmallButton_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SmallButton("label"));
        }

        /// <summary>
        ///     Tests that test spacing
        /// </summary>
        [Fact]
        public void Test_Spacing()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Spacing());
        }

        /// <summary>
        ///     Tests that test style colors classic
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic());
        }

        /// <summary>
        ///     Tests that test style colors classic with dst
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic_WithDst()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic(dst));
        }

        /// <summary>
        ///     Tests that test style colors dark
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark());
        }

        /// <summary>
        ///     Tests that test style colors dark with dst
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark_WithDst()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark(dst));
        }

        /// <summary>
        ///     Tests that test style colors light
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight());
        }

        /// <summary>
        ///     Tests that test style colors light with dst
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight_WithDst()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight(dst));
        }

        /// <summary>
        ///     Tests that test tab item button with label
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label"));
        }

        /// <summary>
        ///     Tests that test tab item button with label and flags
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabelAndFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label", 0));
        }

        /// <summary>
        ///     Tests that test table get column count
        /// </summary>
        [Fact]
        public void Test_TableGetColumnCount()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnCount());
        }

        /// <summary>
        ///     Tests that test table get column flags
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags());
        }

        /// <summary>
        ///     Tests that test table get column flags with column n
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags_WithColumnN()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags(0));
        }

        /// <summary>
        ///     Tests that test table get column index
        /// </summary>
        [Fact]
        public void Test_TableGetColumnIndex()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnIndex());
        }

        /// <summary>
        ///     Tests that test table get sort specs
        /// </summary>
        [Fact]
        public void Test_TableGetSortSpecs()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetSortSpecs());
        }

        /// <summary>
        ///     Tests that test table header with label
        /// </summary>
        [Fact]
        public void Test_TableHeader_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeader("label"));
        }

        /// <summary>
        ///     Tests that test table headers row
        /// </summary>
        [Fact]
        public void Test_TableHeadersRow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeadersRow());
        }

        /// <summary>
        ///     Tests that test table next column
        /// </summary>
        [Fact]
        public void Test_TableNextColumn()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextColumn());
        }

        /// <summary>
        ///     Tests that test table next row
        /// </summary>
        [Fact]
        public void Test_TableNextRow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow());
        }

        /// <summary>
        ///     Tests that test table next row with row flags
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0));
        }

        /// <summary>
        ///     Tests that test table next row with row flags and min row height
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlagsAndMinRowHeight()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0, 0.0f));
        }

        /// <summary>
        ///     Tests that test table set bg color with target and color
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColor()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0));
        }

        /// <summary>
        ///     Tests that test table set bg color with target and color and column n
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColorAndColumnN()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0, 0));
        }

        /// <summary>
        ///     Tests that test table set column enabled with column n and v
        /// </summary>
        [Fact]
        public void Test_TableSetColumnEnabled_WithColumnNAndV()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnEnabled(0, true));
        }

        /// <summary>
        ///     Tests that test table set column index with column n
        /// </summary>
        [Fact]
        public void Test_TableSetColumnIndex_WithColumnN()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnIndex(0));
        }

        /// <summary>
        ///     Tests that test table setup column with label
        /// </summary>
        [Fact]
        public void Test_TableSetupColumn_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetupColumn("label"));
        }

        /// <summary>
        ///     Tests that test menu item with label and enabled
        /// </summary>
        [Fact]
        public void Test_MenuItem_WithLabelAndEnabled()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.MenuItem("label", true));
        }

        /// <summary>
        ///     Tests that test im font config
        /// </summary>
        [Fact]
        public void Test_ImFontConfig()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImFontConfig());
        }

        /// <summary>
        ///     Tests that test slider int 2 with label and v and v min and v max v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMax_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100));
        }

        /// <summary>
        ///     Tests that test slider int 2 with label and v and v min and v max and format v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormat_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that test slider int 2 with label and v and v min and v max and format and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d", 0));
        }

        /// <summary>
        ///     Tests that test slider int 3 with label and v and v min and v max v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMax_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100));
        }

        /// <summary>
        ///     Tests that test slider int 3 with label and v and v min and v max and format v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormat_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that test slider int 3 with label and v and v min and v max and format and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d", 0));
        }

        /// <summary>
        ///     Tests that test slider int 4 with label and v and v min and v max v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMax_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100));
        }

        /// <summary>
        ///     Tests that test slider int 4 with label and v and v min and v max and format v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormat_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that test slider int 4 with label and v and v min and v max and format and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d", 0));
        }

        /// <summary>
        ///     Tests that test slider scalar with label and data type and p data and p min and p max v 2
        /// </summary>
        [Fact]
        public void Test_SliderScalar_WithLabelAndDataTypeAndPDataAndPMinAndPMax_v2()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalar("label", ImGuiDataType.Float, pData, pMin, pMax));
        }

        /// <summary>
        ///     Tests that test slider scalar with label and data type and p data and p min and p max and format v 2
        /// </summary>
        [Fact]
        public void Test_SliderScalar_WithLabelAndDataTypeAndPDataAndPMinAndPMaxAndFormat_v2()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalar("label", ImGuiDataType.Float, pData, pMin, pMax, "%.3f"));
        }

        /// <summary>
        ///     Tests that test slider scalar with label and data type and p data and p min and p max and format and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderScalar_WithLabelAndDataTypeAndPDataAndPMinAndPMaxAndFormatAndFlags_v2()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalar("label", ImGuiDataType.Float, pData, pMin, pMax, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test slider scalar n with label and data type and p data and components and p min and p max v 2
        /// </summary>
        [Fact]
        public void Test_SliderScalarN_WithLabelAndDataTypeAndPDataAndComponentsAndPMinAndPMax_v2()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalarN("label", ImGuiDataType.Float, pData, 4, pMin, pMax));
        }

        /// <summary>
        ///     Tests that test slider scalar n with label and data type and p data and components and p min and p max and format v
        ///     2
        /// </summary>
        [Fact]
        public void Test_SliderScalarN_WithLabelAndDataTypeAndPDataAndComponentsAndPMinAndPMaxAndFormat_v2()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalarN("label", ImGuiDataType.Float, pData, 4, pMin, pMax, "%.3f"));
        }

        /// <summary>
        ///     Tests that test slider scalar n with label and data type and p data and components and p min and p max and format
        ///     and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderScalarN_WithLabelAndDataTypeAndPDataAndComponentsAndPMinAndPMaxAndFormatAndFlags_v2()
        {
            IntPtr pData = IntPtr.Zero;
            IntPtr pMin = IntPtr.Zero;
            IntPtr pMax = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderScalarN("label", ImGuiDataType.Float, pData, 4, pMin, pMax, "%.3f", 0));
        }

        /// <summary>
        ///     Tests that test small button with label v 2
        /// </summary>
        [Fact]
        public void Test_SmallButton_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SmallButton("label"));
        }

        /// <summary>
        ///     Tests that test spacing v 2
        /// </summary>
        [Fact]
        public void Test_Spacing_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Spacing());
        }

        /// <summary>
        ///     Tests that test style colors classic v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic());
        }

        /// <summary>
        ///     Tests that test style colors classic with dst v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic_WithDst_v2()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic(dst));
        }

        /// <summary>
        ///     Tests that test style colors dark v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark());
        }

        /// <summary>
        ///     Tests that test style colors dark with dst v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark_WithDst_v2()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark(dst));
        }

        /// <summary>
        ///     Tests that test style colors light v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight());
        }

        /// <summary>
        ///     Tests that test style colors light with dst v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight_WithDst_v2()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight(dst));
        }

        /// <summary>
        ///     Tests that test tab item button with label v 2
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label"));
        }

        /// <summary>
        ///     Tests that test tab item button with label and flags v 2
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabelAndFlags_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label", 0));
        }

        /// <summary>
        ///     Tests that test table get column count v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnCount_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnCount());
        }

        /// <summary>
        ///     Tests that test table get column flags v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags());
        }

        /// <summary>
        ///     Tests that test table get column flags with column n v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags_WithColumnN_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags(0));
        }

        /// <summary>
        ///     Tests that test table get column index v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnIndex_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnIndex());
        }

        /// <summary>
        ///     Tests that test table get sort specs v 2
        /// </summary>
        [Fact]
        public void Test_TableGetSortSpecs_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetSortSpecs());
        }

        /// <summary>
        ///     Tests that test table header with label v 2
        /// </summary>
        [Fact]
        public void Test_TableHeader_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeader("label"));
        }

        /// <summary>
        ///     Tests that test table headers row v 2
        /// </summary>
        [Fact]
        public void Test_TableHeadersRow_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeadersRow());
        }

        /// <summary>
        ///     Tests that test table next column v 2
        /// </summary>
        [Fact]
        public void Test_TableNextColumn_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextColumn());
        }

        /// <summary>
        ///     Tests that test table next row v 2
        /// </summary>
        [Fact]
        public void Test_TableNextRow_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow());
        }

        /// <summary>
        ///     Tests that test table next row with row flags v 2
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlags_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0));
        }

        /// <summary>
        ///     Tests that test table next row with row flags and min row height v 2
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlagsAndMinRowHeight_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0, 0.0f));
        }

        /// <summary>
        ///     Tests that test table set bg color with target and color v 2
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColor_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0));
        }

        /// <summary>
        ///     Tests that test table set bg color with target and color and column n v 2
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColorAndColumnN_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0, 0));
        }

        /// <summary>
        ///     Tests that test table set column enabled with column n and v v 2
        /// </summary>
        [Fact]
        public void Test_TableSetColumnEnabled_WithColumnNAndV_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnEnabled(0, true));
        }

        /// <summary>
        ///     Tests that test table set column index with column n v 2
        /// </summary>
        [Fact]
        public void Test_TableSetColumnIndex_WithColumnN_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnIndex(0));
        }

        /// <summary>
        ///     Tests that test table setup column with label v 2
        /// </summary>
        [Fact]
        public void Test_TableSetupColumn_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetupColumn("label"));
        }

        /// <summary>
        ///     Tests that test menu item with label and enabled v 2
        /// </summary>
        [Fact]
        public void Test_MenuItem_WithLabelAndEnabled_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.MenuItem("label", true));
        }

        /// <summary>
        ///     Tests that test im font config v 2
        /// </summary>
        [Fact]
        public void Test_ImFontConfig_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImFontConfig());
        }

        /// <summary>
        ///     Tests that is item hovered no flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemHovered_NoFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsItemHovered(0));
        }

        /// <summary>
        ///     Tests that is item hovered with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemHovered_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsItemHovered(ImGuiHoveredFlags.None));
        }

        /// <summary>
        ///     Tests that is item toggled open throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemToggledOpen_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsItemToggledOpen());
        }

        /// <summary>
        ///     Tests that is item visible throws dll not found exception
        /// </summary>
        [Fact]
        public void IsItemVisible_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsItemVisible());
        }

        /// <summary>
        ///     Tests that is key down throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyDown_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsKeyDown_Nil(ImGuiKey.None));
        }

        /// <summary>
        ///     Tests that is key pressed no repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyPressed_NoRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsKeyPressed_Bool(ImGuiKey.None, 1));
        }

        /// <summary>
        ///     Tests that is key pressed with repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyPressed_WithRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsKeyPressed_Bool(ImGuiKey.None, 0));
        }

        /// <summary>
        ///     Tests that is key released throws dll not found exception
        /// </summary>
        [Fact]
        public void IsKeyReleased_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsKeyReleased_Nil(ImGuiKey.None));
        }

        /// <summary>
        ///     Tests that is mouse clicked no repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseClicked_NoRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseClicked_Bool(ImGuiMouseButton.Left, 0));
        }

        /// <summary>
        ///     Tests that is mouse clicked with repeat throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseClicked_WithRepeat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseClicked_Bool(ImGuiMouseButton.Left, 1));
        }

        /// <summary>
        ///     Tests that is mouse double clicked throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDoubleClicked_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseDoubleClicked(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is mouse down throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDown_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseDown_Nil(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is mouse dragging no threshold throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDragging_NoThreshold_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseDragging(ImGuiMouseButton.Left, -1.0f));
        }

        /// <summary>
        ///     Tests that is mouse dragging with threshold throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseDragging_WithThreshold_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseDragging(ImGuiMouseButton.Left, 0.0f));
        }

        /// <summary>
        ///     Tests that is mouse hovering rect no clip throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseHoveringRect_NoClip_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseHoveringRect(new Vector2F(), new Vector2F(), 1));
        }

        /// <summary>
        ///     Tests that is mouse hovering rect with clip throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseHoveringRect_WithClip_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseHoveringRect(new Vector2F(), new Vector2F(), 0));
        }

        /// <summary>
        ///     Tests that is mouse pos valid no pos throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMousePosValid_NoPos_ThrowsDllNotFoundException()
        {
            Vector2F mousePos = Vector2F.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMousePosValid(ref mousePos));
        }

        /// <summary>
        ///     Tests that is mouse pos valid with pos throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMousePosValid_WithPos_ThrowsDllNotFoundException()
        {
            Vector2F mousePos = new Vector2F(1, 1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMousePosValid(ref mousePos));
        }

        /// <summary>
        ///     Tests that is mouse released throws dll not found exception
        /// </summary>
        [Fact]
        public void IsMouseReleased_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsMouseReleased_Nil(ImGuiMouseButton.Left));
        }

        /// <summary>
        ///     Tests that is popup open no flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsPopupOpen_NoFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsPopupOpen_Str(Encoding.UTF8.GetBytes("test"), ImGuiPopupFlags.None));
        }

        /// <summary>
        ///     Tests that is popup open with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsPopupOpen_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsPopupOpen_Str(Encoding.UTF8.GetBytes("test"), ImGuiPopupFlags.AnyPopup));
        }

        /// <summary>
        ///     Tests that is rect visible no min max throws dll not found exception
        /// </summary>
        [Fact]
        public void IsRectVisible_NoMinMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsRectVisible_Nil(new Vector2F()));
        }

        /// <summary>
        ///     Tests that is rect visible with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void IsRectVisible_WithMinMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsRectVisible_Vec2(new Vector2F(), new Vector2F()));
        }

        /// <summary>
        ///     Tests that is window appearing throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowAppearing_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsWindowAppearing());
        }

        /// <summary>
        ///     Tests that is window collapsed throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowCollapsed_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsWindowCollapsed());
        }

        /// <summary>
        ///     Tests that is window docked throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowDocked_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsWindowDocked());
        }

        /// <summary>
        ///     Tests that is window focused no flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowFocused_NoFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsWindowFocused(0));
        }

        /// <summary>
        ///     Tests that is window focused with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowFocused_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsWindowFocused(ImGuiFocusedFlags.None));
        }

        /// <summary>
        ///     Tests that is window hovered no flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowHovered_NoFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsWindowHovered(0));
        }

        /// <summary>
        ///     Tests that is window hovered with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void IsWindowHovered_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igIsWindowHovered(ImGuiHoveredFlags.None));
        }

        /// <summary>
        ///     Tests that label text throws dll not found exception
        /// </summary>
        [Fact]
        public void LabelText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLabelText(Encoding.UTF8.GetBytes("label"), Encoding.UTF8.GetBytes("fmt")));
        }

        /// <summary>
        ///     Tests that list box no height throws dll not found exception
        /// </summary>
        [Fact]
        public void ListBox_NoHeight_ThrowsDllNotFoundException()
        {
            int currentItem = 0;
            string[] items = {"item1", "item2"};
            byte[][] itemsNative = items.Select(item => Encoding.UTF8.GetBytes(item)).ToArray();
            Assert.Throws<MarshalDirectiveException>(() => ImGuiNative.igListBox_Str_arr(Encoding.UTF8.GetBytes("label"), ref currentItem, itemsNative, items.Length, -1));
        }

        /// <summary>
        ///     Tests that list box with height throws dll not found exception
        /// </summary>
        [Fact]
        public void ListBox_WithHeight_ThrowsDllNotFoundException()
        {
            int currentItem = 0;
            string[] items = {"item1", "item2"};
            byte[][] itemsNative = items.Select(item => Encoding.UTF8.GetBytes(item)).ToArray();
            Assert.Throws<MarshalDirectiveException>(() => ImGuiNative.igListBox_Str_arr(Encoding.UTF8.GetBytes("label"), ref currentItem, itemsNative, items.Length, 2));
        }

        /// <summary>
        ///     Tests that load ini settings from disk throws dll not found exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromDisk_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLoadIniSettingsFromDisk(Encoding.UTF8.GetBytes("filename")));
        }

        /// <summary>
        ///     Tests that load ini settings from memory no size throws dll not found exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromMemory_NoSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLoadIniSettingsFromMemory(Encoding.UTF8.GetBytes("data"), 0));
        }

        /// <summary>
        ///     Tests that load ini settings from memory with size throws dll not found exception
        /// </summary>
        [Fact]
        public void LoadIniSettingsFromMemory_WithSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLoadIniSettingsFromMemory(Encoding.UTF8.GetBytes("data"), 10));
        }

        /// <summary>
        ///     Tests that log buttons throws dll not found exception
        /// </summary>
        [Fact]
        public void LogButtons_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogButtons());
        }

        /// <summary>
        ///     Tests that log finish throws dll not found exception
        /// </summary>
        [Fact]
        public void LogFinish_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogFinish());
        }

        /// <summary>
        ///     Tests that log text throws dll not found exception
        /// </summary>
        [Fact]
        public void LogText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogText(Encoding.UTF8.GetBytes("fmt")));
        }

        /// <summary>
        ///     Tests that log to clipboard no depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToClipboard_NoDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogToClipboard(-1));
        }

        /// <summary>
        ///     Tests that log to clipboard with depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToClipboard_WithDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogToClipboard(1));
        }

        /// <summary>
        ///     Tests that log to file no depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToFile_NoDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogToFile(-1, null));
        }

        /// <summary>
        ///     Tests that log to file with depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToFile_WithDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogToFile(1, null));
        }

        /// <summary>
        ///     Tests that log to file with filename throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToFile_WithFilename_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogToFile(1, Encoding.UTF8.GetBytes("filename")));
        }

        /// <summary>
        ///     Tests that log to tty no depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToTty_NoDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogToTTY(-1));
        }

        /// <summary>
        ///     Tests that log to tty with depth throws dll not found exception
        /// </summary>
        [Fact]
        public void LogToTty_WithDepth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igLogToTTY(1));
        }

        /// <summary>
        ///     Tests that mem alloc throws dll not found exception
        /// </summary>
        [Fact]
        public void MemAlloc_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igMemAlloc(10));
        }

        /// <summary>
        ///     Tests that mem free throws dll not found exception
        /// </summary>
        [Fact]
        public void MemFree_ThrowsDllNotFoundException()
        {
            IntPtr ptr = new IntPtr(10);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.igMemFree(ptr));
        }

        /// <summary>
        ///     Tests that table get column index throws dll not found exception
        /// </summary>
        [Fact]
        public void TableGetColumnIndex_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnIndex());
        }

        /// <summary>
        ///     Tests that table get column name throws dll not found exception
        /// </summary>
        [Fact]
        public void TableGetColumnName_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImGui.Native.ImGui.TableGetColumnName());
        }

        /// <summary>
        ///     Tests that table get column name with column n throws dll not found exception
        /// </summary>
        [Fact]
        public void TableGetColumnName_WithColumnN_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImGui.Native.ImGui.TableGetColumnName(0));
        }

        /// <summary>
        ///     Tests that table get row index throws dll not found exception
        /// </summary>
        [Fact]
        public void TableGetRowIndex_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetRowIndex());
        }

        /// <summary>
        ///     Tests that table get sort specs throws dll not found exception
        /// </summary>
        [Fact]
        public void TableGetSortSpecs_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetSortSpecs());
        }

        /// <summary>
        ///     Tests that table header throws dll not found exception
        /// </summary>
        [Fact]
        public void TableHeader_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeader("label"));
        }

        /// <summary>
        ///     Tests that table headers row throws dll not found exception
        /// </summary>
        [Fact]
        public void TableHeadersRow_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeadersRow());
        }

        /// <summary>
        ///     Tests that table next column throws dll not found exception
        /// </summary>
        [Fact]
        public void TableNextColumn_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextColumn());
        }

        /// <summary>
        ///     Tests that table next row throws dll not found exception
        /// </summary>
        [Fact]
        public void TableNextRow_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow());
        }

        /// <summary>
        ///     Tests that table next row with row flags throws dll not found exception
        /// </summary>
        [Fact]
        public void TableNextRow_WithRowFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(ImGuiTableRowFlags.None));
        }

        /// <summary>
        ///     Tests that table next row with row flags and min row height throws dll not found exception
        /// </summary>
        [Fact]
        public void TableNextRow_WithRowFlagsAndMinRowHeight_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(ImGuiTableRowFlags.None, 0.0f));
        }

        /// <summary>
        ///     Tests that table set bg color throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetBgColor_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0, 0));
        }

        /// <summary>
        ///     Tests that table set bg color with column n throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetBgColor_WithColumnN_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(ImGuiTableBgTarget.RowBg0, 0, 0));
        }

        /// <summary>
        ///     Tests that table set column enabled throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetColumnEnabled_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnEnabled(0, true));
        }

        /// <summary>
        ///     Tests that table set column index throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetColumnIndex_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnIndex(0));
        }

        /// <summary>
        ///     Tests that table setup column throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetupColumn("label"));
        }

        /// <summary>
        ///     Tests that menu item throws dll not found exception
        /// </summary>
        [Fact]
        public void MenuItem_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.MenuItem("label", true));
        }

        /// <summary>
        ///     Tests that im font config throws dll not found exception
        /// </summary>
        [Fact]
        public void ImFontConfig_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImFontConfig());
        }
    }
}