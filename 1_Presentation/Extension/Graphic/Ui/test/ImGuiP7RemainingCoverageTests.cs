// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7RemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The ImGuiP7 remaining coverage tests class
    /// </summary>
    public class ImGuiP7RemainingCoverageTests
    {
        /// <summary>
        /// Tests that MenuItem throws when native library is unavailable
        /// </summary>
        [Fact]
        public void MenuItem_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pSelected = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.MenuItem("label", "label", ref pSelected, false); });
            }
        }

        /// <summary>
        /// Tests that NewFrame throws when native library is unavailable
        /// </summary>
        [Fact]
        public void NewFrame_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.NewFrame(); });
            }
        }

        /// <summary>
        /// Tests that NewLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void NewLine_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.NewLine(); });
            }
        }

        /// <summary>
        /// Tests that NextColumn throws when native library is unavailable
        /// </summary>
        [Fact]
        public void NextColumn_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.NextColumn(); });
            }
        }

        /// <summary>
        /// Tests that OpenPopup throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OpenPopup_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.OpenPopup("label"); });
            }
        }

        /// <summary>
        /// Tests that OpenPopup throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OpenPopup_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.OpenPopup("label", 0); });
            }
        }

        /// <summary>
        /// Tests that OpenPopup throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OpenPopup_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.OpenPopup(0); });
            }
        }

        /// <summary>
        /// Tests that OpenPopup throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OpenPopup_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.OpenPopup(0, 0); });
            }
        }

        /// <summary>
        /// Tests that OpenPopupOnItemClick throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OpenPopupOnItemClick_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.OpenPopupOnItemClick(); });
            }
        }

        /// <summary>
        /// Tests that OpenPopupOnItemClick throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OpenPopupOnItemClick_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.OpenPopupOnItemClick("label"); });
            }
        }

        /// <summary>
        /// Tests that OpenPopupOnItemClick throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OpenPopupOnItemClick_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.OpenPopupOnItemClick("label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotHistogram("label", ref values, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotHistogram("label", ref values, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotHistogram("label", ref values, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotHistogram("label", ref values, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotHistogram("label", ref values, 0, 0, "label", 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotHistogram("label", ref values, 0, 0, "label", 0, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotHistogram("label", ref values, 0, 0, "label", 0, 0, default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLines_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotLines("label", ref values, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLines_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotLines("label", ref values, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLines_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotLines("label", ref values, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLines_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotLines("label", ref values, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLines_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotLines("label", ref values, 0, 0, "label", 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLines_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotLines("label", ref values, 0, 0, "label", 0, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PlotLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLines_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float values = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.PlotLines("label", ref values, 0, 0, "label", 0, 0, default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PopAllowKeyboardFocus throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopAllowKeyboardFocus_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopAllowKeyboardFocus(); });
            }
        }

        /// <summary>
        /// Tests that PopButtonRepeat throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopButtonRepeat_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopButtonRepeat(); });
            }
        }

        /// <summary>
        /// Tests that PopClipRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopClipRect_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopClipRect(); });
            }
        }

        /// <summary>
        /// Tests that PopFont throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopFont_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopFont(); });
            }
        }

        /// <summary>
        /// Tests that PopId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopId_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopId(); });
            }
        }

        /// <summary>
        /// Tests that PopItemWidth throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopItemWidth_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopItemWidth(); });
            }
        }

        /// <summary>
        /// Tests that PopStyleColor throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopStyleColor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopStyleColor(); });
            }
        }

        /// <summary>
        /// Tests that PopStyleColor throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopStyleColor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopStyleColor(0); });
            }
        }

        /// <summary>
        /// Tests that PopStyleVar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopStyleVar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopStyleVar(); });
            }
        }

        /// <summary>
        /// Tests that PopStyleVar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopStyleVar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopStyleVar(0); });
            }
        }

        /// <summary>
        /// Tests that PopTextWrapPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopTextWrapPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PopTextWrapPos(); });
            }
        }

        /// <summary>
        /// Tests that ProgressBar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ProgressBar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ProgressBar(0); });
            }
        }

        /// <summary>
        /// Tests that ProgressBar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ProgressBar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ProgressBar(0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that ProgressBar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ProgressBar_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ProgressBar(0, default(Vector2F), "label"); });
            }
        }

        /// <summary>
        /// Tests that PushAllowKeyboardFocus throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushAllowKeyboardFocus_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushAllowKeyboardFocus(false); });
            }
        }

        /// <summary>
        /// Tests that PushButtonRepeat throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushButtonRepeat_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushButtonRepeat(false); });
            }
        }

        /// <summary>
        /// Tests that PushClipRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushClipRect_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushClipRect(default(Vector2F), default(Vector2F), false); });
            }
        }

        /// <summary>
        /// Tests that PushFont throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushFont_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushFont(default(ImFontPtr)); });
            }
        }

        /// <summary>
        /// Tests that PushId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushId_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushId("label"); });
            }
        }

        /// <summary>
        /// Tests that PushId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushId_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushId(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that PushId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushId_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushId(0); });
            }
        }

        /// <summary>
        /// Tests that PushItemWidth throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushItemWidth_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushItemWidth(0); });
            }
        }

        /// <summary>
        /// Tests that PushStyleColor throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushStyleColor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushStyleColor(0, 0); });
            }
        }

        /// <summary>
        /// Tests that PushStyleColor throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushStyleColor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushStyleColor(0, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that PushStyleVar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushStyleVar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushStyleVar(0, 0); });
            }
        }

        /// <summary>
        /// Tests that PushStyleVar throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushStyleVar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushStyleVar(0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PushTextWrapPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushTextWrapPos_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushTextWrapPos(); });
            }
        }

        /// <summary>
        /// Tests that PushTextWrapPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushTextWrapPos_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.PushTextWrapPos(0); });
            }
        }

        /// <summary>
        /// Tests that RadioButton throws when native library is unavailable
        /// </summary>
        [Fact]
        public void RadioButton_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.RadioButton("label", false); });
            }
        }

        /// <summary>
        /// Tests that RadioButton throws when native library is unavailable
        /// </summary>
        [Fact]
        public void RadioButton_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.RadioButton("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that Render throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Render_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Render(); });
            }
        }

        /// <summary>
        /// Tests that RenderPlatformWindowsDefault throws when native library is unavailable
        /// </summary>
        [Fact]
        public void RenderPlatformWindowsDefault_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.RenderPlatformWindowsDefault(); });
            }
        }

        /// <summary>
        /// Tests that RenderPlatformWindowsDefault throws when native library is unavailable
        /// </summary>
        [Fact]
        public void RenderPlatformWindowsDefault_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.RenderPlatformWindowsDefault(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that RenderPlatformWindowsDefault throws when native library is unavailable
        /// </summary>
        [Fact]
        public void RenderPlatformWindowsDefault_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.RenderPlatformWindowsDefault(IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that ResetMouseDragDelta throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ResetMouseDragDelta_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ResetMouseDragDelta(); });
            }
        }

        /// <summary>
        /// Tests that ResetMouseDragDelta throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ResetMouseDragDelta_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.ResetMouseDragDelta(0); });
            }
        }

        /// <summary>
        /// Tests that SameLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SameLine_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SameLine(); });
            }
        }

        /// <summary>
        /// Tests that SameLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SameLine_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SameLine(0); });
            }
        }

        /// <summary>
        /// Tests that SameLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SameLine_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SameLine(0, 0); });
            }
        }

        /// <summary>
        /// Tests that SaveIniSettingsToDisk throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SaveIniSettingsToDisk_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SaveIniSettingsToDisk("label"); });
            }
        }

        /// <summary>
        /// Tests that SaveIniSettingsToMemory throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SaveIniSettingsToMemory_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SaveIniSettingsToMemory(); });
            }
        }

        /// <summary>
        /// Tests that SaveIniSettingsToMemory throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SaveIniSettingsToMemory_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint outIniSize = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SaveIniSettingsToMemory(out outIniSize); });
            }
        }

        /// <summary>
        /// Tests that Selectable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Selectable_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Selectable("label"); });
            }
        }

        /// <summary>
        /// Tests that Selectable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Selectable_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Selectable("label", false); });
            }
        }

        /// <summary>
        /// Tests that Selectable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Selectable_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Selectable("label", false, 0); });
            }
        }

        /// <summary>
        /// Tests that Selectable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Selectable_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Selectable("label", false, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that Selectable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Selectable_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pSelected = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Selectable("label", ref pSelected); });
            }
        }

        /// <summary>
        /// Tests that Selectable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Selectable_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pSelected = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Selectable("label", ref pSelected, 0); });
            }
        }

        /// <summary>
        /// Tests that Selectable throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Selectable_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pSelected = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Selectable("label", ref pSelected, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that Separator throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Separator_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.Separator(); });
            }
        }

        /// <summary>
        /// Tests that SetAllocatorFunctions throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetAllocatorFunctions_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetAllocatorFunctions(IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetAllocatorFunctions throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetAllocatorFunctions_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetAllocatorFunctions(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetClipboardText throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetClipboardText_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetClipboardText("label"); });
            }
        }

        /// <summary>
        /// Tests that SetColorEditOptions throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetColorEditOptions_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetColorEditOptions(0); });
            }
        }

        /// <summary>
        /// Tests that SetColumnOffset throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetColumnOffset_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetColumnOffset(0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetColumnWidth throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetColumnWidth_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetColumnWidth(0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetCurrentContext throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetCurrentContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetCurrentContext(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetCursorPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetCursorPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetCursorPos(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetCursorPosX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetCursorPosX_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetCursorPosX(0); });
            }
        }

        /// <summary>
        /// Tests that SetCursorPosY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetCursorPosY_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetCursorPosY(0); });
            }
        }

        /// <summary>
        /// Tests that SetCursorScreenPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetCursorScreenPos_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetCursorScreenPos(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetDragDropPayload throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetDragDropPayload_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetDragDropPayload("label", IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that SetDragDropPayload throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetDragDropPayload_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetDragDropPayload("label", IntPtr.Zero, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetItemAllowOverlap throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetItemAllowOverlap_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetItemAllowOverlap(); });
            }
        }

        /// <summary>
        /// Tests that SetItemDefaultFocus throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetItemDefaultFocus_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetItemDefaultFocus(); });
            }
        }

        /// <summary>
        /// Tests that SetKeyboardFocusHere throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetKeyboardFocusHere_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetKeyboardFocusHere(); });
            }
        }

        /// <summary>
        /// Tests that SetKeyboardFocusHere throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetKeyboardFocusHere_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetKeyboardFocusHere(0); });
            }
        }

        /// <summary>
        /// Tests that SetMouseCursor throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetMouseCursor_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetMouseCursor(0); });
            }
        }

        /// <summary>
        /// Tests that SetNextFrameWantCaptureKeyboard throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextFrameWantCaptureKeyboard_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextFrameWantCaptureKeyboard(false); });
            }
        }

        /// <summary>
        /// Tests that SetNextFrameWantCaptureMouse throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextFrameWantCaptureMouse_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextFrameWantCaptureMouse(false); });
            }
        }

        /// <summary>
        /// Tests that SetNextItemOpen throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextItemOpen_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextItemOpen(false); });
            }
        }

        /// <summary>
        /// Tests that SetNextItemOpen throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextItemOpen_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextItemOpen(false, 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextItemWidth throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextItemWidth_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextItemWidth(0); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowBgAlpha throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowBgAlpha_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowBgAlpha(0); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowClass throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowClass_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowClass(default(ImGuiWindowClass)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowCollapsed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowCollapsed_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowCollapsed(false); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowCollapsed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowCollapsed_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowCollapsed(false, 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowContentSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowContentSize_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowContentSize(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowDockId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowDockId_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowDockId(0); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowDockId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowDockId_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowDockId(0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowFocus throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowFocus_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowFocus(); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowPos_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowPos(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowPos_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowPos(default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowPos_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowPos(default(Vector2F), 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowScroll throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowScroll_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowScroll(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowSize_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowSize(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowSize_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowSize(default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowSizeConstraints throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowSizeConstraints_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowSizeConstraints(default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowSizeConstraints throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowSizeConstraints_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowSizeConstraints(default(Vector2F), default(Vector2F), default(ImGuiSizeCallback)); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowSizeConstraints throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowSizeConstraints_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowSizeConstraints(default(Vector2F), default(Vector2F), default(ImGuiSizeCallback), IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetNextWindowViewport throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetNextWindowViewport_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetNextWindowViewport(0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollFromPosX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollFromPosX_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollFromPosX(0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollFromPosX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollFromPosX_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollFromPosX(0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollFromPosY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollFromPosY_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollFromPosY(0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollFromPosY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollFromPosY_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollFromPosY(0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollHereX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollHereX_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollHereX(); });
            }
        }

        /// <summary>
        /// Tests that SetScrollHereX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollHereX_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollHereX(0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollHereY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollHereY_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollHereY(); });
            }
        }

        /// <summary>
        /// Tests that SetScrollHereY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollHereY_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollHereY(0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollX throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollX_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollX(0); });
            }
        }

        /// <summary>
        /// Tests that SetScrollY throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetScrollY_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetScrollY(0); });
            }
        }

        /// <summary>
        /// Tests that SetStateStorage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetStateStorage_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetStateStorage(default(ImGuiStorage)); });
            }
        }

        /// <summary>
        /// Tests that SetTabItemClosed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetTabItemClosed_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetTabItemClosed("label"); });
            }
        }

        /// <summary>
        /// Tests that SetTooltip throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetTooltip_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetTooltip("label"); });
            }
        }

        /// <summary>
        /// Tests that SetWindowCollapsed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowCollapsed_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowCollapsed(false); });
            }
        }

        /// <summary>
        /// Tests that SetWindowCollapsed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowCollapsed_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowCollapsed(false, 0); });
            }
        }

        /// <summary>
        /// Tests that SetWindowCollapsed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowCollapsed_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowCollapsed("label", false); });
            }
        }

        /// <summary>
        /// Tests that SetWindowCollapsed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowCollapsed_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowCollapsed("label", false, 0); });
            }
        }

        /// <summary>
        /// Tests that SetWindowFocus throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowFocus_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowFocus(); });
            }
        }

        /// <summary>
        /// Tests that SetWindowFocus throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowFocus_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowFocus("label"); });
            }
        }

        /// <summary>
        /// Tests that SetWindowFontScale throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowFontScale_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowFontScale(0); });
            }
        }

        /// <summary>
        /// Tests that SetWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowPos_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowPos(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowPos_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowPos(default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowPos_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowPos("label", default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetWindowPos throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowPos_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowPos("label", default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetWindowSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowSize_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowSize(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetWindowSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowSize_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowSize(default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetWindowSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowSize_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowSize("label", default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SetWindowSize throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetWindowSize_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGui.SetWindowSize("label", default(Vector2F), 0); });
            }
        }
        /// <summary>
        /// Determines whether the cimgui native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadCImguiLibrary()
        {
            if (NativeLibrary.TryLoad("cimgui", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP7RemainingCoverageTests).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "cimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
