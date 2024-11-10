// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStyleTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im gui style test class
    /// </summary>
    public class ImGuiStyleTest
    {
        /// <summary>
        /// Tests that alpha should set and get correctly
        /// </summary>
        [Fact]
        public void Alpha_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.Alpha = 0.5f;
            Assert.Equal(0.5f, style.Alpha);
        }

        /// <summary>
        /// Tests that disabled alpha should set and get correctly
        /// </summary>
        [Fact]
        public void DisabledAlpha_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.DisabledAlpha = 0.3f;
            Assert.Equal(0.3f, style.DisabledAlpha);
        }

        /// <summary>
        /// Tests that window padding should set and get correctly
        /// </summary>
        [Fact]
        public void WindowPadding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 padding = new Vector2(10, 20);
            style.WindowPadding = padding;
            Assert.Equal(padding, style.WindowPadding);
        }

        /// <summary>
        /// Tests that window rounding should set and get correctly
        /// </summary>
        [Fact]
        public void WindowRounding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowRounding = 5.0f;
            Assert.Equal(5.0f, style.WindowRounding);
        }

        /// <summary>
        /// Tests that window border size should set and get correctly
        /// </summary>
        [Fact]
        public void WindowBorderSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowBorderSize = 1.0f;
            Assert.Equal(1.0f, style.WindowBorderSize);
        }

        /// <summary>
        /// Tests that window min size should set and get correctly
        /// </summary>
        [Fact]
        public void WindowMinSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 minSize = new Vector2(100, 200);
            style.WindowMinSize = minSize;
            Assert.Equal(minSize, style.WindowMinSize);
        }

        /// <summary>
        /// Tests that window title align should set and get correctly
        /// </summary>
        [Fact]
        public void WindowTitleAlign_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 align = new Vector2(0.5f, 0.5f);
            style.WindowTitleAlign = align;
            Assert.Equal(align, style.WindowTitleAlign);
        }

        /// <summary>
        /// Tests that window menu button position should set and get correctly
        /// </summary>
        [Fact]
        public void WindowMenuButtonPosition_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowMenuButtonPosition = ImGuiDir.Left;
            Assert.Equal(ImGuiDir.Left, style.WindowMenuButtonPosition);
        }

        /// <summary>
        /// Tests that child rounding should set and get correctly
        /// </summary>
        [Fact]
        public void ChildRounding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ChildRounding = 3.0f;
            Assert.Equal(3.0f, style.ChildRounding);
        }

        /// <summary>
        /// Tests that child border size should set and get correctly
        /// </summary>
        [Fact]
        public void ChildBorderSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ChildBorderSize = 2.0f;
            Assert.Equal(2.0f, style.ChildBorderSize);
        }

        /// <summary>
        /// Tests that popup rounding should set and get correctly
        /// </summary>
        [Fact]
        public void PopupRounding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.PopupRounding = 4.0f;
            Assert.Equal(4.0f, style.PopupRounding);
        }

        /// <summary>
        /// Tests that popup border size should set and get correctly
        /// </summary>
        [Fact]
        public void PopupBorderSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.PopupBorderSize = 1.5f;
            Assert.Equal(1.5f, style.PopupBorderSize);
        }

        /// <summary>
        /// Tests that frame padding should set and get correctly
        /// </summary>
        [Fact]
        public void FramePadding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 padding = new Vector2(5, 10);
            style.FramePadding = padding;
            Assert.Equal(padding, style.FramePadding);
        }

        /// <summary>
        /// Tests that frame rounding should set and get correctly
        /// </summary>
        [Fact]
        public void FrameRounding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.FrameRounding = 2.0f;
            Assert.Equal(2.0f, style.FrameRounding);
        }

        /// <summary>
        /// Tests that frame border size should set and get correctly
        /// </summary>
        [Fact]
        public void FrameBorderSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.FrameBorderSize = 1.0f;
            Assert.Equal(1.0f, style.FrameBorderSize);
        }

        /// <summary>
        /// Tests that item spacing should set and get correctly
        /// </summary>
        [Fact]
        public void ItemSpacing_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 spacing = new Vector2(8, 16);
            style.ItemSpacing = spacing;
            Assert.Equal(spacing, style.ItemSpacing);
        }

        /// <summary>
        /// Tests that item inner spacing should set and get correctly
        /// </summary>
        [Fact]
        public void ItemInnerSpacing_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 innerSpacing = new Vector2(4, 8);
            style.ItemInnerSpacing = innerSpacing;
            Assert.Equal(innerSpacing, style.ItemInnerSpacing);
        }

        /// <summary>
        /// Tests that cell padding should set and get correctly
        /// </summary>
        [Fact]
        public void CellPadding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 padding = new Vector2(6, 12);
            style.CellPadding = padding;
            Assert.Equal(padding, style.CellPadding);
        }

        /// <summary>
        /// Tests that touch extra padding should set and get correctly
        /// </summary>
        [Fact]
        public void TouchExtraPadding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 padding = new Vector2(2, 4);
            style.TouchExtraPadding = padding;
            Assert.Equal(padding, style.TouchExtraPadding);
        }

        /// <summary>
        /// Tests that indent spacing should set and get correctly
        /// </summary>
        [Fact]
        public void IndentSpacing_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.IndentSpacing = 10.0f;
            Assert.Equal(10.0f, style.IndentSpacing);
        }

        /// <summary>
        /// Tests that columns min spacing should set and get correctly
        /// </summary>
        [Fact]
        public void ColumnsMinSpacing_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ColumnsMinSpacing = 5.0f;
            Assert.Equal(5.0f, style.ColumnsMinSpacing);
        }

        /// <summary>
        /// Tests that scrollbar size should set and get correctly
        /// </summary>
        [Fact]
        public void ScrollbarSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScrollbarSize = 15.0f;
            Assert.Equal(15.0f, style.ScrollbarSize);
        }

        /// <summary>
        /// Tests that scrollbar rounding should set and get correctly
        /// </summary>
        [Fact]
        public void ScrollbarRounding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScrollbarRounding = 3.0f;
            Assert.Equal(3.0f, style.ScrollbarRounding);
        }

        /// <summary>
        /// Tests that grab min size should set and get correctly
        /// </summary>
        [Fact]
        public void GrabMinSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.GrabMinSize = 8.0f;
            Assert.Equal(8.0f, style.GrabMinSize);
        }

        /// <summary>
        /// Tests that grab rounding should set and get correctly
        /// </summary>
        [Fact]
        public void GrabRounding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.GrabRounding = 2.0f;
            Assert.Equal(2.0f, style.GrabRounding);
        }

        /// <summary>
        /// Tests that log slider deadzone should set and get correctly
        /// </summary>
        [Fact]
        public void LogSliderDeadzone_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.LogSliderDeadzone = 0.1f;
            Assert.Equal(0.1f, style.LogSliderDeadzone);
        }

        /// <summary>
        /// Tests that tab rounding should set and get correctly
        /// </summary>
        [Fact]
        public void TabRounding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.TabRounding = 4.0f;
            Assert.Equal(4.0f, style.TabRounding);
        }

        /// <summary>
        /// Tests that tab border size should set and get correctly
        /// </summary>
        [Fact]
        public void TabBorderSize_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.TabBorderSize = 1.0f;
            Assert.Equal(1.0f, style.TabBorderSize);
        }

        /// <summary>
        /// Tests that tab min width for close button should set and get correctly
        /// </summary>
        [Fact]
        public void TabMinWidthForCloseButton_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.TabMinWidthForCloseButton = 20.0f;
            Assert.Equal(20.0f, style.TabMinWidthForCloseButton);
        }

        /// <summary>
        /// Tests that color button position should set and get correctly
        /// </summary>
        [Fact]
        public void ColorButtonPosition_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ColorButtonPosition = ImGuiDir.Right;
            Assert.Equal(ImGuiDir.Right, style.ColorButtonPosition);
        }

        /// <summary>
        /// Tests that button text align should set and get correctly
        /// </summary>
        [Fact]
        public void ButtonTextAlign_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 align = new Vector2(0.5f, 0.5f);
            style.ButtonTextAlign = align;
            Assert.Equal(align, style.ButtonTextAlign);
        }

        /// <summary>
        /// Tests that selectable text align should set and get correctly
        /// </summary>
        [Fact]
        public void SelectableTextAlign_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 align = new Vector2(0.5f, 0.5f);
            style.SelectableTextAlign = align;
            Assert.Equal(align, style.SelectableTextAlign);
        }

        /// <summary>
        /// Tests that display window padding should set and get correctly
        /// </summary>
        [Fact]
        public void DisplayWindowPadding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 padding = new Vector2(10, 10);
            style.DisplayWindowPadding = padding;
            Assert.Equal(padding, style.DisplayWindowPadding);
        }

        /// <summary>
        /// Tests that display safe area padding should set and get correctly
        /// </summary>
        [Fact]
        public void DisplaySafeAreaPadding_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector2 padding = new Vector2(5, 5);
            style.DisplaySafeAreaPadding = padding;
            Assert.Equal(padding, style.DisplaySafeAreaPadding);
        }

        /// <summary>
        /// Tests that mouse cursor scale should set and get correctly
        /// </summary>
        [Fact]
        public void MouseCursorScale_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.MouseCursorScale = 1.5f;
            Assert.Equal(1.5f, style.MouseCursorScale);
        }

        /// <summary>
        /// Tests that anti aliased lines should set and get correctly
        /// </summary>
        [Fact]
        public void AntiAliasedLines_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedLines = 1;
            Assert.Equal(1, style.AntiAliasedLines);
        }

        /// <summary>
        /// Tests that anti aliased lines use tex should set and get correctly
        /// </summary>
        [Fact]
        public void AntiAliasedLinesUseTex_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedLinesUseTex = 1;
            Assert.Equal(1, style.AntiAliasedLinesUseTex);
        }

        /// <summary>
        /// Tests that anti aliased fill should set and get correctly
        /// </summary>
        [Fact]
        public void AntiAliasedFill_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedFill = 1;
            Assert.Equal(1, style.AntiAliasedFill);
        }

        /// <summary>
        /// Tests that curve tessellation tol should set and get correctly
        /// </summary>
        [Fact]
        public void CurveTessellationTol_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.CurveTessellationTol = 1.25f;
            Assert.Equal(1.25f, style.CurveTessellationTol);
        }

        /// <summary>
        /// Tests that circle tessellation max error should set and get correctly
        /// </summary>
        [Fact]
        public void CircleTessellationMaxError_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.CircleTessellationMaxError = 0.3f;
            Assert.Equal(0.3f, style.CircleTessellationMaxError);
        }

        /// <summary>
        /// Tests that colors 0 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors0_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(1, 0, 0, 1);
            style.Colors0 = color;
            Assert.Equal(color, style.Colors0);
        }

        /// <summary>
        /// Tests that colors 1 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors1_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0, 1, 0, 1);
            style.Colors1 = color;
            Assert.Equal(color, style.Colors1);
        }

        /// <summary>
        /// Tests that colors 2 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors2_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0, 0, 1, 1);
            style.Colors2 = color;
            Assert.Equal(color, style.Colors2);
        }

        /// <summary>
        /// Tests that colors 3 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors3_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(1, 1, 0, 1);
            style.Colors3 = color;
            Assert.Equal(color, style.Colors3);
        }

        /// <summary>
        /// Tests that colors 4 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors4_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(1, 0, 1, 1);
            style.Colors4 = color;
            Assert.Equal(color, style.Colors4);
        }

        /// <summary>
        /// Tests that colors 5 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors5_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0, 1, 1, 1);
            style.Colors5 = color;
            Assert.Equal(color, style.Colors5);
        }

        /// <summary>
        /// Tests that colors 6 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors6_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.5f, 0.5f, 0.5f, 1);
            style.Colors6 = color;
            Assert.Equal(color, style.Colors6);
        }

        /// <summary>
        /// Tests that colors 7 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors7_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.25f, 0.25f, 0.25f, 1);
            style.Colors7 = color;
            Assert.Equal(color, style.Colors7);
        }

        /// <summary>
        /// Tests that colors 8 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors8_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.75f, 0.75f, 0.75f, 1);
            style.Colors8 = color;
            Assert.Equal(color, style.Colors8);
        }

        /// <summary>
        /// Tests that colors 9 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors9_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 1);
            style.Colors9 = color;
            Assert.Equal(color, style.Colors9);
        }

        /// <summary>
        /// Tests that colors 10 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors10_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.4f, 0.5f, 0.6f, 1);
            style.Colors10 = color;
            Assert.Equal(color, style.Colors10);
        }

        /// <summary>
        /// Tests that colors 11 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors11_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.7f, 0.8f, 0.9f, 1);
            style.Colors11 = color;
            Assert.Equal(color, style.Colors11);
        }

        /// <summary>
        /// Tests that colors 12 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors12_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.3f, 0.2f, 0.1f, 1);
            style.Colors12 = color;
            Assert.Equal(color, style.Colors12);
        }

        /// <summary>
        /// Tests that colors 13 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors13_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.6f, 0.5f, 0.4f, 1);
            style.Colors13 = color;
            Assert.Equal(color, style.Colors13);
        }

        /// <summary>
        /// Tests that colors 14 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors14_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.9f, 0.8f, 0.7f, 1);
            style.Colors14 = color;
            Assert.Equal(color, style.Colors14);
        }

        /// <summary>
        /// Tests that colors 15 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors15_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.2f, 0.3f, 0.4f, 1);
            style.Colors15 = color;
            Assert.Equal(color, style.Colors15);
        }

        /// <summary>
        /// Tests that colors 16 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors16_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.5f, 0.6f, 0.7f, 1);
            style.Colors16 = color;
            Assert.Equal(color, style.Colors16);
        }

        /// <summary>
        /// Tests that colors 17 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors17_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.8f, 0.9f, 1.0f, 1);
            style.Colors17 = color;
            Assert.Equal(color, style.Colors17);
        }

        /// <summary>
        /// Tests that colors 18 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors18_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.1f, 0.3f, 0.5f, 1);
            style.Colors18 = color;
            Assert.Equal(color, style.Colors18);
        }

        /// <summary>
        /// Tests that colors 19 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors19_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.4f, 0.6f, 0.8f, 1);
            style.Colors19 = color;
            Assert.Equal(color, style.Colors19);
        }

        /// <summary>
        /// Tests that colors 20 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors20_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.7f, 0.9f, 0.1f, 1);
            style.Colors20 = color;
            Assert.Equal(color, style.Colors20);
        }

        /// <summary>
        /// Tests that colors 21 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors21_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.2f, 0.4f, 0.6f, 1);
            style.Colors21 = color;
            Assert.Equal(color, style.Colors21);
        }

        /// <summary>
        /// Tests that colors 22 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors22_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.5f, 0.7f, 0.9f, 1);
            style.Colors22 = color;
            Assert.Equal(color, style.Colors22);
        }

        /// <summary>
        /// Tests that colors 23 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors23_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.8f, 0.1f, 0.3f, 1);
            style.Colors23 = color;
            Assert.Equal(color, style.Colors23);
        }

        /// <summary>
        /// Tests that colors 24 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors24_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.1f, 0.4f, 0.7f, 1);
            style.Colors24 = color;
            Assert.Equal(color, style.Colors24);
        }

        /// <summary>
        /// Tests that colors 25 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors25_Should_SetAndGetCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4 color = new Vector4(0.3f, 0.6f, 0.9f, 1);
            style.Colors25 = color;
            Assert.Equal(color, style.Colors25);
        }
    }
}