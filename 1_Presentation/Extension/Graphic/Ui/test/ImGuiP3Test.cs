// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3Test.cs
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
using System.Linq;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiP3Test
    {
        [RequireCImguiSystemFact]
        public void EndMethods_ShouldBeAvailable()
        {
            string[] names = {"End", "EndChild", "EndChildFrame", "EndCombo", "EndDisabled", "EndDragDropSource", "EndDragDropTarget", "EndFrame", "EndGroup", "EndListBox", "EndMainMenuBar", "EndMenu", "EndMenuBar", "EndPopup", "EndTabBar", "EndTabItem", "EndTable", "EndTooltip"};

            foreach (string name in names)
            {
                MethodInfo method = typeof(ImGui).GetMethod(name, BindingFlags.Public | BindingFlags.Static);
                Assert.NotNull(method);
                Assert.Equal(typeof(void), method.ReturnType);
            }
        }

        [RequireCImguiSystemFact]
        public void DragScalarN_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "DragScalarN").ToArray();
            Assert.True(methods.Length >= 3);
        }

        [RequireCImguiSystemFact]
        public void Dummy_ShouldExist()
        {
            MethodInfo method = typeof(ImGui).GetMethod("Dummy", BindingFlags.Public | BindingFlags.Static);
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [RequireCImguiSystemFact]
        public void FindViewportMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("FindViewportById", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("FindViewportByPlatformHandle", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetAllocatorFunctions_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetAllocatorFunctions", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetBackgroundDrawList_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "GetBackgroundDrawList").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [RequireCImguiSystemFact]
        public void GetClipboardText_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetClipboardText", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetColorU32_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "GetColorU32").ToArray();
            Assert.True(methods.Length >= 4);
        }

        [RequireCImguiSystemFact]
        public void GetColumnBasics_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetColumnIndex", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetColumnsCount", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetColumnOffset_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "GetColumnOffset").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [RequireCImguiSystemFact]
        public void GetColumnWidth_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "GetColumnWidth").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [RequireCImguiSystemFact]
        public void GetContentRegionMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetContentRegionAvail", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetContentRegionMax", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetCurrentContext_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetCurrentContext", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetCursorMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetCursorPos", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetCursorPosX", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetCursorPosY", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetCursorScreenPos", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetCursorStartPos", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetDragDropAndDrawMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetDragDropPayload", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetDrawData", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetDrawListSharedData", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetFontMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetFont", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetFontSize", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetFontTexUvWhitePixel", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetForegroundDrawList_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "GetForegroundDrawList").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [RequireCImguiSystemFact]
        public void GetFrameMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetFrameCount", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetFrameHeight", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetFrameHeightWithSpacing", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetId_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "GetId").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [RequireCImguiSystemFact]
        public void GetIo_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetIo", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetItemRectMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetItemRectMax", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetItemRectMin", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetItemRectSize", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetKeyMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetKeyIndex", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetKeyName", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetKeyPressedAmount", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetMainViewport_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetMainViewport", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetMouseClickAndCursor_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetMouseClickedCount", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetMouseCursor", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetMouseDragDelta_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "GetMouseDragDelta").ToArray();
            Assert.True(methods.Length >= 3);
        }

        [RequireCImguiSystemFact]
        public void GetMousePosMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetMousePos", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetMousePosOnOpeningCurrentPopup", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetPlatformIo_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetPlatformIo", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetScrollMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetScrollMaxX", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetScrollMaxY", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetScrollX", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetScrollY", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetStyleMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetStateStorage", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetStyle", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetStyleColorName", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetStyleColorVec4", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetTextLineMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetTextLineHeight", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetTextLineHeightWithSpacing", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetTimeAndVersionMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetTime", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetTreeNodeToLabelSpacing", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetVersion", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void GetWindowMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowContentRegionMax", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowContentRegionMin", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowDockId", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowDpiScale", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowDrawList", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowHeight", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowPos", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowSize", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowViewport", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImGui).GetMethod("GetWindowWidth", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void Image_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Image").ToArray();
            Assert.True(methods.Length >= 5);
        }

        [RequireCImguiSystemFact]
        public void ImageButton_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "ImageButton").ToArray();
            Assert.True(methods.Length >= 6);
        }

        [RequireCImguiSystemFact]
        public void Indent_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "Indent").ToArray();
            Assert.True(methods.Length >= 2);
        }

        [RequireCImguiSystemFact]
        public void InputDouble_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputDouble").ToArray();
            Assert.True(methods.Length >= 5);
        }

        [RequireCImguiSystemFact]
        public void InputFloat_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputFloat").ToArray();
            Assert.True(methods.Length >= 5);
        }

        [RequireCImguiSystemFact]
        public void InputFloat2_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputFloat2").ToArray();
            Assert.True(methods.Length >= 3);
        }

        [RequireCImguiSystemFact]
        public void InputFloat3_ShouldExposeOverloads()
        {
            MethodInfo[] methods = typeof(ImGui).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "InputFloat3").ToArray();
            Assert.True(methods.Length >= 3);
        }

        [RequireCImguiSystemFact]
        public void InputFloat4_ShouldExist()
        {
            Assert.NotNull(typeof(ImGui).GetMethod("InputFloat4", BindingFlags.Public | BindingFlags.Static));
        }

        [RequireCImguiSystemFact]
        public void Dummy_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Dummy(new Vector2F(10f, 10f));
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void Indent_AllOverloads_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Indent();
            ImGui.Indent(20.0f);
            ImGui.Unindent();
            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetCursorMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            Vector2F pos = ImGui.GetCursorPos();
            _ = pos;
            float posX = ImGui.GetCursorPosX();
            _ = posX;
            float posY = ImGui.GetCursorPosY();
            _ = posY;
            Vector2F screenPos = ImGui.GetCursorScreenPos();
            _ = screenPos;
            Vector2F startPos = ImGui.GetCursorStartPos();
            _ = startPos;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetContentRegionMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            Vector2F avail = ImGui.GetContentRegionAvail();
            _ = avail;
            Vector2F max = ImGui.GetContentRegionMax();
            _ = max;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetFrameMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            int frameCount = ImGui.GetFrameCount();
            _ = frameCount;
            float frameH = ImGui.GetFrameHeight();
            _ = frameH;
            float frameHSpacing = ImGui.GetFrameHeightWithSpacing();
            _ = frameHSpacing;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetStyleMethods_ShouldExecute()
        {
            ref ImGuiStyle style = ref ImGui.GetStyle();
            _ = style;

            string styleColorName = ImGui.GetStyleColorName(ImGuiCol.Text);
            _ = styleColorName;

            Vector4F styleColor = ImGui.GetStyleColorVec4(ImGuiCol.Text);
            _ = styleColor;
        }

        [RequireCImguiSystemFact]
        public void GetTextLineMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float lineH = ImGui.GetTextLineHeight();
            _ = lineH;
            float lineHSpacing = ImGui.GetTextLineHeightWithSpacing();
            _ = lineHSpacing;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetWindowSizeMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            Vector2F winPos = ImGui.GetWindowPos();
            _ = winPos;
            Vector2F winSize = ImGui.GetWindowSize();
            _ = winSize;
            float winW = ImGui.GetWindowWidth();
            _ = winW;
            float winH = ImGui.GetWindowHeight();
            _ = winH;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetScrollMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float scrollX = ImGui.GetScrollX();
            _ = scrollX;
            float scrollY = ImGui.GetScrollY();
            _ = scrollY;
            float scrollMaxX = ImGui.GetScrollMaxX();
            _ = scrollMaxX;
            float scrollMaxY = ImGui.GetScrollMaxY();
            _ = scrollMaxY;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetItemRectMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");
            ImGui.Button("TestBtn");

            Vector2F rectMax = ImGui.GetItemRectMax();
            _ = rectMax;
            Vector2F rectMin = ImGui.GetItemRectMin();
            _ = rectMin;
            Vector2F rectSize = ImGui.GetItemRectSize();
            _ = rectSize;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetColorU32_AllOverloads_ShouldExecute()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            uint c1 = ImGui.GetColorU32(ImGuiCol.Text);
            _ = c1;
            uint c2 = ImGui.GetColorU32(ImGuiCol.Text, 0.5f);
            _ = c2;
            uint c3 = ImGui.GetColorU32(new Vector4F(1f, 0f, 0f, 1f));
            _ = c3;
            uint c4 = ImGui.GetColorU32(0xFF0000FF);
            _ = c4;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetMousePosMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            Vector2F mouse = ImGui.GetMousePos();
            _ = mouse;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetTime_ShouldExecute()
        {
            double time = ImGui.GetTime();
            _ = time;
        }

        [RequireCImguiSystemFact]
        public void GetFrameCount_ShouldExecute()
        {
            int count = ImGui.GetFrameCount();
            _ = count;
        }

        [RequireCImguiSystemFact]
        public void GetVersion_ShouldExecute()
        {
            string version = ImGui.GetVersion();
            Assert.False(string.IsNullOrEmpty(version));
        }

        [RequireCImguiSystemFact]
        public void GetFontSize_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float size = ImGui.GetFontSize();
            _ = size;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetCurrentContext_ShouldExecute()
        {
            IntPtr ctx = ImGui.GetCurrentContext();
            _ = ctx;
        }

        [RequireCImguiSystemFact]
        public void GetMainViewport_ShouldExecute()
        {
            ImGuiViewportPtr viewport = ImGui.GetMainViewport();
            _ = viewport;
        }

        [RequireCImguiSystemFact]
        public void GetFontTexUvWhitePixel_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            Vector2F uv = ImGui.GetFontTexUvWhitePixel();
            _ = uv;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetTreeNodeToLabelSpacing_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float spacing = ImGui.GetTreeNodeToLabelSpacing();
            _ = spacing;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetWindowContentRegionMethods_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            Vector2F max = ImGui.GetWindowContentRegionMax();
            _ = max;
            Vector2F min = ImGui.GetWindowContentRegionMin();
            _ = min;

            ImGui.End();
            ImGui.Render();
        }

        [RequireCImguiSystemFact]
        public void GetWindowDpiScale_ShouldExecuteInFrame()
        {
            ImGui.NewFrame();
            ImGui.Begin("TestWin");

            float scale = ImGui.GetWindowDpiScale();
            _ = scale;

            ImGui.End();
            ImGui.Render();
        }
    }
}
