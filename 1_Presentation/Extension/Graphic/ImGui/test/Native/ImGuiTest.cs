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
    public class ImGuiTest
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
        /// Tests that test im gui is imgui active
        /// </summary>
        [Fact]
        public void Test_ImGui_IsImguiActive()
        {
            Assert.False(ImGui.Native.ImGui.IsImguiActive());
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
    }
}