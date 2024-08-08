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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Native
{
    /// <summary>
    /// The im gui test class
    /// </summary>
    public partial class ImGuiTest
    {
        /// <summary>
        /// Tests that test im gui version
        /// </summary>
        [Fact]
        public void Test_ImGui_Version()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.GetVersion());
        }
        
        /// <summary>
        /// Tests that test im gui create context
        /// </summary>
        [Fact]
        public void Test_ImGui_CreateContext()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext());
        }
        
        /// <summary>
        /// Tests that test combo with label and current item and items separated by zeros
        /// </summary>
        [Fact]
        public void Test_Combo_WithLabelAndCurrentItemAndItemsSeparatedByZeros()
        {
            
            int currentItem = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Combo("label", ref currentItem, "item1\0item2\0item3\0"));
        }
        
        /// <summary>
        /// Tests that test combo with label and current item and items separated by zeros and popup max height in items
        /// </summary>
        [Fact]
        public void Test_Combo_WithLabelAndCurrentItemAndItemsSeparatedByZerosAndPopupMaxHeightInItems()
        {
            
            int currentItem = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Combo("label", ref currentItem, "item1\0item2\0item3\0", 10));
            
            
        }
        
        /// <summary>
        /// Tests that test create context
        /// </summary>
        [Fact]
        public void Test_CreateContext()
        {
            
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext());
        }
        
        /// <summary>
        /// Tests that test create context with shared font atlas
        /// </summary>
        [Fact]
        public void Test_CreateContext_WithSharedFontAtlas()
        {
            
            ImFontAtlasPtr sharedFontAtlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.CreateContext(sharedFontAtlas));
        }
        
        /// <summary>
        /// Tests that test debug check version and data layout
        /// </summary>
        [Fact]
        public void Test_DebugCheckVersionAndDataLayout()
        {
            
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DebugCheckVersionAndDataLayout("1.0.0", 1, 1, 1, 1, 1, 1));
            
            
        }
        
        /// <summary>
        /// Tests that test debug text encoding
        /// </summary>
        [Fact]
        public void Test_DebugTextEncoding()
        {
            
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DebugTextEncoding("test"));
            
        }
        
        /// <summary>
        /// Tests that test dock space with id
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithId()
        {
            
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1));
            
        }
        
        /// <summary>
        /// Tests that test dock space with id and size
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithIdAndSize()
        {
            
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size));
        }
        
        /// <summary>
        /// Tests that test dock space with id and size and flags
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithIdAndSizeAndFlags()
        {
            
            Vector2 size = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size, 0));
        }
        
        /// <summary>
        /// Tests that test dock space with id and size and flags and window
        /// </summary>
        [Fact]
        public void Test_DockSpace_WithIdAndSizeAndFlagsAndWindowClass()
        {
            
            Vector2 size = new Vector2();
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpace(1, size, 0, windowClass));
        }
        
        /// <summary>
        /// Tests that test dock space over viewport
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport()
        {
            
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport());
            
        }
        
        /// <summary>
        /// Tests that test dock space over viewport with viewport
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport_WithViewport()
        {
            
            ImGuiViewportPtr viewport = new ImGuiViewportPtr();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport));
            
        }
        
        /// <summary>
        /// Tests that test dock space over viewport with viewport and flags
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport_WithViewportAndFlags()
        {
            
            ImGuiViewportPtr viewport = new ImGuiViewportPtr();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport, 0));
        }
        
        /// <summary>
        /// Tests that test dock space over viewport with viewport and flags and window
        /// </summary>
        [Fact]
        public void Test_DockSpaceOverViewport_WithViewportAndFlagsAndWindowClass()
        {
            
            ImGuiViewportPtr viewport = new ImGuiViewportPtr();
            ImGuiWindowClass windowClass = new ImGuiWindowClass();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DockSpaceOverViewport(viewport, 0, windowClass));
        }
        
        /// <summary>
        /// Tests that test drag float with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndV()
        {
            
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeed()
        {
            
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMin()
        {
            
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
            
        }
        
        
        /// <summary>
        /// Tests that test drag float with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            
            float v = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 2 with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndV()
        {
            
            Vector2 v = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 2 with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeed()
        {
            
            Vector2 v = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 2 with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMin()
        {
            
            Vector2 v = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 2 with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            
            Vector2 v = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 2 with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            
            Vector2 v = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 2 with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat2_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            
            Vector2 v = new Vector2();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat2("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 3 with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndV()
        {
            
            Vector3 v = new Vector3();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 3 with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeed()
        {
            
            Vector3 v = new Vector3();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f));
            
        }
        
        
        /// <summary>
        /// Tests that test drag float 3 with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMin()
        {
            
            Vector3 v = new Vector3();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 3 with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            
            Vector3 v = new Vector3();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 3 with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            
            Vector3 v = new Vector3();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
            
        }
        
        /// <summary>
        /// Tests that test drag float 3 with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat3_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            
            Vector3 v = new Vector3();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat3("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 4 with label and v
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndV()
        {
            
            Vector4 v = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 4 with label and v and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeed()
        {
            
            Vector4 v = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 4 with label and v and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMin()
        {
            
            Vector4 v = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 4 with label and v and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMinAndVMax()
        {
            
            Vector4 v = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f));
            
        }
        
        
        /// <summary>
        /// Tests that test drag float 4 with label and v and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormat()
        {
            
            Vector4 v = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f"));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float 4 with label and v and v speed and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_DragFloat4_WithLabelAndVAndVSpeedAndVMinAndVMaxAndFormatAndFlags()
        {
            
            Vector4 v = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloat4("label", ref v, 1.0f, 0.0f, 1.0f, "%.3f", 0));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float range 2 with label and v current min and v current max
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMax()
        {
            
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float range 2 with label and v current min and v current max and v speed
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeed()
        {
            
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float range 2 with label and v current min and v current max and v speed and v min
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMin()
        {
            
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMax()
        {
            
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMaxAndFormat()
        {
            
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "%.3f"));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max and format and format max
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMaxAndFormatAndFormatMax()
        {
            
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "%.3f", "%.3f"));
            
            
        }
        
        /// <summary>
        /// Tests that test drag float range 2 with label and v current min and v current max and v speed and v min and v max and format and format max and flags
        /// </summary>
        [Fact]
        public void Test_DragFloatRange2_WithLabelAndVCurrentMinAndVCurrentMaxAndVSpeedAndVMinAndVMaxAndFormatAndFormatMaxAndFlags()
        {
            
            float vCurrentMin = 0.0f;
            float vCurrentMax = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 1.0f, 0.0f, 1.0f, "%.3f", "%.3f", 0));
            
        }
        
        /// <summary>
        /// Tests that test drag int with label and v
        /// </summary>
        [Fact]
        public void Test_DragInt_WithLabelAndV()
        {
            
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.DragInt("label", ref v));
            
        }
        
        /// <summary>
        /// Tests that test slider float 4 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderFloat4_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            Vector4 v = new Vector4();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderFloat4("label", ref v, 0.0f, 1.0f, "%.3f", 0));
        }
        
        /// <summary>
        /// Tests that test slider int with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt("label", ref v, 0, 100));
        }
        
        /// <summary>
        /// Tests that test slider int with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt("label", ref v, 0, 100, "%d"));
        }
        
        /// <summary>
        /// Tests that test slider int with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt("label", ref v, 0, 100, "%d", 0));
        }
        
        /// <summary>
        /// Tests that test slider int 2 with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100));
        }
        
        /// <summary>
        /// Tests that test slider int 2 with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d"));
        }
        
        /// <summary>
        /// Tests that test slider int 2 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d", 0));
        }
        
        /// <summary>
        /// Tests that test slider int 3 with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100));
        }
        
        /// <summary>
        /// Tests that test slider int 3 with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d"));
        }
        
        /// <summary>
        /// Tests that test slider int 3 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d", 0));
        }
        
        /// <summary>
        /// Tests that test slider int 4 with label and v and v min and v max
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMax()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100));
        }
        
        /// <summary>
        /// Tests that test slider int 4 with label and v and v min and v max and format
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormat()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d"));
        }
        
        /// <summary>
        /// Tests that test slider int 4 with label and v and v min and v max and format and flags
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d", 0));
        }
        
        /// <summary>
        /// Tests that test slider scalar with label and data type and p data and p min and p max
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
        /// Tests that test slider scalar with label and data type and p data and p min and p max and format
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
        /// Tests that test slider scalar with label and data type and p data and p min and p max and format and flags
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
        /// Tests that test slider scalar n with label and data type and p data and components and p min and p max
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
        /// Tests that test slider scalar n with label and data type and p data and components and p min and p max and format
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
        /// Tests that test slider scalar n with label and data type and p data and components and p min and p max and format and flags
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
        /// Tests that test small button with label
        /// </summary>
        [Fact]
        public void Test_SmallButton_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SmallButton("label"));
        }
        
        /// <summary>
        /// Tests that test spacing
        /// </summary>
        [Fact]
        public void Test_Spacing()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Spacing());
        }
        
        /// <summary>
        /// Tests that test style colors classic
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic());
        }
        
        /// <summary>
        /// Tests that test style colors classic with dst
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic_WithDst()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic(dst));
        }
        
        /// <summary>
        /// Tests that test style colors dark
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark());
        }
        
        /// <summary>
        /// Tests that test style colors dark with dst
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark_WithDst()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark(dst));
        }
        
        /// <summary>
        /// Tests that test style colors light
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight());
        }
        
        /// <summary>
        /// Tests that test style colors light with dst
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight_WithDst()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight(dst));
        }
        
        /// <summary>
        /// Tests that test tab item button with label
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label"));
        }
        
        /// <summary>
        /// Tests that test tab item button with label and flags
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabelAndFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label", 0));
        }
        
        /// <summary>
        /// Tests that test table get column count
        /// </summary>
        [Fact]
        public void Test_TableGetColumnCount()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnCount());
        }
        
        /// <summary>
        /// Tests that test table get column flags
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags());
        }
        
        /// <summary>
        /// Tests that test table get column flags with column n
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags_WithColumnN()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags(0));
        }
        
        /// <summary>
        /// Tests that test table get column index
        /// </summary>
        [Fact]
        public void Test_TableGetColumnIndex()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnIndex());
        }
        
        /// <summary>
        /// Tests that test table get sort specs
        /// </summary>
        [Fact]
        public void Test_TableGetSortSpecs()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetSortSpecs());
        }
        
        /// <summary>
        /// Tests that test table header with label
        /// </summary>
        [Fact]
        public void Test_TableHeader_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeader("label"));
        }
        
        /// <summary>
        /// Tests that test table headers row
        /// </summary>
        [Fact]
        public void Test_TableHeadersRow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeadersRow());
        }
        
        /// <summary>
        /// Tests that test table next column
        /// </summary>
        [Fact]
        public void Test_TableNextColumn()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextColumn());
        }
        
        /// <summary>
        /// Tests that test table next row
        /// </summary>
        [Fact]
        public void Test_TableNextRow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow());
        }
        
        /// <summary>
        /// Tests that test table next row with row flags
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlags()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0));
        }
        
        /// <summary>
        /// Tests that test table next row with row flags and min row height
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlagsAndMinRowHeight()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0, 0.0f));
        }
        
        /// <summary>
        /// Tests that test table set bg color with target and color
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColor()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0));
        }
        
        /// <summary>
        /// Tests that test table set bg color with target and color and column n
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColorAndColumnN()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0, 0));
        }
        
        /// <summary>
        /// Tests that test table set column enabled with column n and v
        /// </summary>
        [Fact]
        public void Test_TableSetColumnEnabled_WithColumnNAndV()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnEnabled(0, true));
        }
        
        /// <summary>
        /// Tests that test table set column index with column n
        /// </summary>
        [Fact]
        public void Test_TableSetColumnIndex_WithColumnN()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnIndex(0));
        }
        
        /// <summary>
        /// Tests that test table setup column with label
        /// </summary>
        [Fact]
        public void Test_TableSetupColumn_WithLabel()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetupColumn("label"));
        }
        
        /// <summary>
        /// Tests that test menu item with label and enabled
        /// </summary>
        [Fact]
        public void Test_MenuItem_WithLabelAndEnabled()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.MenuItem("label", true));
        }
        
        /// <summary>
        /// Tests that test im font config
        /// </summary>
        [Fact]
        public void Test_ImFontConfig()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImFontConfig());
        }
        
        /// <summary>
        /// Tests that test slider int 2 with label and v and v min and v max v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMax_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100));
        }
        
        /// <summary>
        /// Tests that test slider int 2 with label and v and v min and v max and format v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormat_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d"));
        }
        
        /// <summary>
        /// Tests that test slider int 2 with label and v and v min and v max and format and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt2_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt2("label", ref v, 0, 100, "%d", 0));
        }
        
        /// <summary>
        /// Tests that test slider int 3 with label and v and v min and v max v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMax_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100));
        }
        
        /// <summary>
        /// Tests that test slider int 3 with label and v and v min and v max and format v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormat_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d"));
        }
        
        /// <summary>
        /// Tests that test slider int 3 with label and v and v min and v max and format and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt3_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt3("label", ref v, 0, 100, "%d", 0));
        }
        
        /// <summary>
        /// Tests that test slider int 4 with label and v and v min and v max v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMax_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100));
        }
        
        /// <summary>
        /// Tests that test slider int 4 with label and v and v min and v max and format v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormat_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d"));
        }
        
        /// <summary>
        /// Tests that test slider int 4 with label and v and v min and v max and format and flags v 2
        /// </summary>
        [Fact]
        public void Test_SliderInt4_WithLabelAndVAndVMinAndVMaxAndFormatAndFlags_v2()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SliderInt4("label", ref v, 0, 100, "%d", 0));
        }
        
        /// <summary>
        /// Tests that test slider scalar with label and data type and p data and p min and p max v 2
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
        /// Tests that test slider scalar with label and data type and p data and p min and p max and format v 2
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
        /// Tests that test slider scalar with label and data type and p data and p min and p max and format and flags v 2
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
        /// Tests that test slider scalar n with label and data type and p data and components and p min and p max v 2
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
        /// Tests that test slider scalar n with label and data type and p data and components and p min and p max and format v 2
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
        /// Tests that test slider scalar n with label and data type and p data and components and p min and p max and format and flags v 2
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
        /// Tests that test small button with label v 2
        /// </summary>
        [Fact]
        public void Test_SmallButton_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.SmallButton("label"));
        }
        
        /// <summary>
        /// Tests that test spacing v 2
        /// </summary>
        [Fact]
        public void Test_Spacing_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.Spacing());
        }
        
        /// <summary>
        /// Tests that test style colors classic v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic());
        }
        
        /// <summary>
        /// Tests that test style colors classic with dst v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsClassic_WithDst_v2()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsClassic(dst));
        }
        
        /// <summary>
        /// Tests that test style colors dark v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark());
        }
        
        /// <summary>
        /// Tests that test style colors dark with dst v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsDark_WithDst_v2()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsDark(dst));
        }
        
        /// <summary>
        /// Tests that test style colors light v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight());
        }
        
        /// <summary>
        /// Tests that test style colors light with dst v 2
        /// </summary>
        [Fact]
        public void Test_StyleColorsLight_WithDst_v2()
        {
            ImGuiStyle dst = new ImGuiStyle();
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.StyleColorsLight(dst));
        }
        
        /// <summary>
        /// Tests that test tab item button with label v 2
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label"));
        }
        
        /// <summary>
        /// Tests that test tab item button with label and flags v 2
        /// </summary>
        [Fact]
        public void Test_TabItemButton_WithLabelAndFlags_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TabItemButton("label", 0));
        }
        
        /// <summary>
        /// Tests that test table get column count v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnCount_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnCount());
        }
        
        /// <summary>
        /// Tests that test table get column flags v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags());
        }
        
        /// <summary>
        /// Tests that test table get column flags with column n v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnFlags_WithColumnN_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnFlags(0));
        }
        
        /// <summary>
        /// Tests that test table get column index v 2
        /// </summary>
        [Fact]
        public void Test_TableGetColumnIndex_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetColumnIndex());
        }
        
        /// <summary>
        /// Tests that test table get sort specs v 2
        /// </summary>
        [Fact]
        public void Test_TableGetSortSpecs_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableGetSortSpecs());
        }
        
        /// <summary>
        /// Tests that test table header with label v 2
        /// </summary>
        [Fact]
        public void Test_TableHeader_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeader("label"));
        }
        
        /// <summary>
        /// Tests that test table headers row v 2
        /// </summary>
        [Fact]
        public void Test_TableHeadersRow_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableHeadersRow());
        }
        
        /// <summary>
        /// Tests that test table next column v 2
        /// </summary>
        [Fact]
        public void Test_TableNextColumn_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextColumn());
        }
        
        /// <summary>
        /// Tests that test table next row v 2
        /// </summary>
        [Fact]
        public void Test_TableNextRow_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow());
        }
        
        /// <summary>
        /// Tests that test table next row with row flags v 2
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlags_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0));
        }
        
        /// <summary>
        /// Tests that test table next row with row flags and min row height v 2
        /// </summary>
        [Fact]
        public void Test_TableNextRow_WithRowFlagsAndMinRowHeight_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableNextRow(0, 0.0f));
        }
        
        /// <summary>
        /// Tests that test table set bg color with target and color v 2
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColor_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0));
        }
        
        /// <summary>
        /// Tests that test table set bg color with target and color and column n v 2
        /// </summary>
        [Fact]
        public void Test_TableSetBgColor_WithTargetAndColorAndColumnN_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetBgColor(0, 0, 0));
        }
        
        /// <summary>
        /// Tests that test table set column enabled with column n and v v 2
        /// </summary>
        [Fact]
        public void Test_TableSetColumnEnabled_WithColumnNAndV_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnEnabled(0, true));
        }
        
        /// <summary>
        /// Tests that test table set column index with column n v 2
        /// </summary>
        [Fact]
        public void Test_TableSetColumnIndex_WithColumnN_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetColumnIndex(0));
        }
        
        /// <summary>
        /// Tests that test table setup column with label v 2
        /// </summary>
        [Fact]
        public void Test_TableSetupColumn_WithLabel_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.TableSetupColumn("label"));
        }
        
        /// <summary>
        /// Tests that test menu item with label and enabled v 2
        /// </summary>
        [Fact]
        public void Test_MenuItem_WithLabelAndEnabled_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.MenuItem("label", true));
        }
        
        /// <summary>
        /// Tests that test im font config v 2
        /// </summary>
        [Fact]
        public void Test_ImFontConfig_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Native.ImGui.ImFontConfig());
        }
    }
}