// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStyleRemainingCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Tests remaining coverage for <see cref="ImGuiStyle" />.
    /// </summary>
    public class ImGuiStyleRemainingCoverageTests
    {
        // ---------------------------------------------------------------
        //  Indexer Get – intermediate indices not covered in existing tests
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that indexer get index 1 should return colors 1
        /// </summary>
        [Fact]
        public void Indexer_Get_Index1_ShouldReturnColors1()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.1f, 0.2f, 0.3f, 0.4f);
            style.Colors1 = expected;
            Assert.Equal(expected, style[1]);
        }

        /// <summary>
        /// Tests that indexer get index 2 should return colors 2
        /// </summary>
        [Fact]
        public void Indexer_Get_Index2_ShouldReturnColors2()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.2f, 0.3f, 0.4f, 0.5f);
            style.Colors2 = expected;
            Assert.Equal(expected, style[2]);
        }

        /// <summary>
        /// Tests that indexer get index 3 should return colors 3
        /// </summary>
        [Fact]
        public void Indexer_Get_Index3_ShouldReturnColors3()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.3f, 0.4f, 0.5f, 0.6f);
            style.Colors3 = expected;
            Assert.Equal(expected, style[3]);
        }

        /// <summary>
        /// Tests that indexer get index 10 should return colors 10
        /// </summary>
        [Fact]
        public void Indexer_Get_Index10_ShouldReturnColors10()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.4f, 0.5f, 0.6f, 0.7f);
            style.Colors10 = expected;
            Assert.Equal(expected, style[10]);
        }

        /// <summary>
        /// Tests that indexer get index 20 should return colors 20
        /// </summary>
        [Fact]
        public void Indexer_Get_Index20_ShouldReturnColors20()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.5f, 0.6f, 0.7f, 0.8f);
            style.Colors20 = expected;
            Assert.Equal(expected, style[20]);
        }

        /// <summary>
        /// Tests that indexer get index 30 should return colors 30
        /// </summary>
        [Fact]
        public void Indexer_Get_Index30_ShouldReturnColors30()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.6f, 0.7f, 0.8f, 0.9f);
            style.Colors30 = expected;
            Assert.Equal(expected, style[30]);
        }

        /// <summary>
        /// Tests that indexer get index 40 should return colors 40
        /// </summary>
        [Fact]
        public void Indexer_Get_Index40_ShouldReturnColors40()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.7f, 0.8f, 0.9f, 1.0f);
            style.Colors40 = expected;
            Assert.Equal(expected, style[40]);
        }

        /// <summary>
        /// Tests that indexer get index 50 should return colors 50
        /// </summary>
        [Fact]
        public void Indexer_Get_Index50_ShouldReturnColors50()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.8f, 0.9f, 1.0f, 0.1f);
            style.Colors50 = expected;
            Assert.Equal(expected, style[50]);
        }

        /// <summary>
        /// Tests that indexer get index 53 should return colors 53
        /// </summary>
        [Fact]
        public void Indexer_Get_Index53_ShouldReturnColors53()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(0.9f, 0.1f, 0.2f, 0.3f);
            style.Colors53 = expected;
            Assert.Equal(expected, style[53]);
        }

        // ---------------------------------------------------------------
        //  Indexer Set – intermediate indices not covered in existing tests
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that indexer set index 1 should set colors 1
        /// </summary>
        [Fact]
        public void Indexer_Set_Index1_ShouldSetColors1()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.1f, 0.2f, 0.3f, 0.4f);
            style[1] = value;
            Assert.Equal(value, style.Colors1);
        }

        /// <summary>
        /// Tests that indexer set index 2 should set colors 2
        /// </summary>
        [Fact]
        public void Indexer_Set_Index2_ShouldSetColors2()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.2f, 0.3f, 0.4f, 0.5f);
            style[2] = value;
            Assert.Equal(value, style.Colors2);
        }

        /// <summary>
        /// Tests that indexer set index 3 should set colors 3
        /// </summary>
        [Fact]
        public void Indexer_Set_Index3_ShouldSetColors3()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.3f, 0.4f, 0.5f, 0.6f);
            style[3] = value;
            Assert.Equal(value, style.Colors3);
        }

        /// <summary>
        /// Tests that indexer set index 10 should set colors 10
        /// </summary>
        [Fact]
        public void Indexer_Set_Index10_ShouldSetColors10()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.4f, 0.5f, 0.6f, 0.7f);
            style[10] = value;
            Assert.Equal(value, style.Colors10);
        }

        /// <summary>
        /// Tests that indexer set index 20 should set colors 20
        /// </summary>
        [Fact]
        public void Indexer_Set_Index20_ShouldSetColors20()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.5f, 0.6f, 0.7f, 0.8f);
            style[20] = value;
            Assert.Equal(value, style.Colors20);
        }

        /// <summary>
        /// Tests that indexer set index 30 should set colors 30
        /// </summary>
        [Fact]
        public void Indexer_Set_Index30_ShouldSetColors30()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.6f, 0.7f, 0.8f, 0.9f);
            style[30] = value;
            Assert.Equal(value, style.Colors30);
        }

        /// <summary>
        /// Tests that indexer set index 40 should set colors 40
        /// </summary>
        [Fact]
        public void Indexer_Set_Index40_ShouldSetColors40()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.7f, 0.8f, 0.9f, 1.0f);
            style[40] = value;
            Assert.Equal(value, style.Colors40);
        }

        /// <summary>
        /// Tests that indexer set index 50 should set colors 50
        /// </summary>
        [Fact]
        public void Indexer_Set_Index50_ShouldSetColors50()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.8f, 0.9f, 1.0f, 0.1f);
            style[50] = value;
            Assert.Equal(value, style.Colors50);
        }

        /// <summary>
        /// Tests that indexer set index 54 should set colors 54
        /// </summary>
        [Fact]
        public void Indexer_Set_Index54_ShouldSetColors54()
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F value = new Vector4F(0.9f, 0.1f, 0.2f, 0.3f);
            style[54] = value;
            Assert.Equal(value, style.Colors54);
        }

        // ---------------------------------------------------------------
        //  ScaleAllSizes
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that scale all sizes should not throw
        /// </summary>
        [Fact]
        public void ScaleAllSizes_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(1.5f);
        }

        /// <summary>
        /// Tests that scale all sizes with zero should not throw
        /// </summary>
        [Fact]
        public void ScaleAllSizes_WithZero_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(0.0f);
        }

        /// <summary>
        /// Tests that scale all sizes with negative should not throw
        /// </summary>
        [Fact]
        public void ScaleAllSizes_WithNegative_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(-1.0f);
        }

        // ---------------------------------------------------------------
        //  Property edge-case values (float extremes)
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that alpha should handle max value
        /// </summary>
        [Fact]
        public void Alpha_ShouldHandleMaxValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.Alpha = float.MaxValue;
            Assert.Equal(float.MaxValue, style.Alpha);
        }

        /// <summary>
        /// Tests that alpha should handle min value
        /// </summary>
        [Fact]
        public void Alpha_ShouldHandleMinValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.Alpha = float.MinValue;
            Assert.Equal(float.MinValue, style.Alpha);
        }

        /// <summary>
        /// Tests that disabled alpha should handle zero
        /// </summary>
        [Fact]
        public void DisabledAlpha_ShouldHandleZero()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.DisabledAlpha = 0.0f;
            Assert.Equal(0.0f, style.DisabledAlpha);
        }

        /// <summary>
        /// Tests that window rounding should handle max value
        /// </summary>
        [Fact]
        public void WindowRounding_ShouldHandleMaxValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowRounding = float.MaxValue;
            Assert.Equal(float.MaxValue, style.WindowRounding);
        }

        /// <summary>
        /// Tests that window border size should handle negative value
        /// </summary>
        [Fact]
        public void WindowBorderSize_ShouldHandleNegativeValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowBorderSize = -1.0f;
            Assert.Equal(-1.0f, style.WindowBorderSize);
        }

        /// <summary>
        /// Tests that mouse cursor scale should handle zero
        /// </summary>
        [Fact]
        public void MouseCursorScale_ShouldHandleZero()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.MouseCursorScale = 0.0f;
            Assert.Equal(0.0f, style.MouseCursorScale);
        }

        /// <summary>
        /// Tests that anti aliased lines should handle max byte
        /// </summary>
        [Fact]
        public void AntiAliasedLines_ShouldHandleMaxByte()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedLines = 255;
            Assert.Equal(255, style.AntiAliasedLines);
        }

        /// <summary>
        /// Tests that anti aliased lines use tex should handle zero
        /// </summary>
        [Fact]
        public void AntiAliasedLinesUseTex_ShouldHandleZero()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedLinesUseTex = 0;
            Assert.Equal(0, style.AntiAliasedLinesUseTex);
        }

        /// <summary>
        /// Tests that anti aliased fill should handle max byte
        /// </summary>
        [Fact]
        public void AntiAliasedFill_ShouldHandleMaxByte()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedFill = 255;
            Assert.Equal(255, style.AntiAliasedFill);
        }

        /// <summary>
        /// Tests that curve tessellation tol should handle negative
        /// </summary>
        [Fact]
        public void CurveTessellationTol_ShouldHandleNegative()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.CurveTessellationTol = -0.5f;
            Assert.Equal(-0.5f, style.CurveTessellationTol);
        }

        /// <summary>
        /// Tests that circle tessellation max error should handle large value
        /// </summary>
        [Fact]
        public void CircleTessellationMaxError_ShouldHandleLargeValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.CircleTessellationMaxError = 1000.0f;
            Assert.Equal(1000.0f, style.CircleTessellationMaxError);
        }

        // ---------------------------------------------------------------
        //  WindowMenuButtonPosition / ColorButtonPosition edge cases
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that window menu button position should handle none
        /// </summary>
        [Fact]
        public void WindowMenuButtonPosition_ShouldHandleNone()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowMenuButtonPosition = ImGuiDir.None;
            Assert.Equal(ImGuiDir.None, style.WindowMenuButtonPosition);
        }

        /// <summary>
        /// Tests that window menu button position should handle right
        /// </summary>
        [Fact]
        public void WindowMenuButtonPosition_ShouldHandleRight()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowMenuButtonPosition = ImGuiDir.Right;
            Assert.Equal(ImGuiDir.Right, style.WindowMenuButtonPosition);
        }

        /// <summary>
        /// Tests that color button position should handle left
        /// </summary>
        [Fact]
        public void ColorButtonPosition_ShouldHandleLeft()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ColorButtonPosition = ImGuiDir.Left;
            Assert.Equal(ImGuiDir.Left, style.ColorButtonPosition);
        }

        // ---------------------------------------------------------------
        //  Round-trip through multiple properties
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that multiple properties should round trip correctly
        /// </summary>
        [Fact]
        public void MultipleProperties_ShouldRoundTripCorrectly()
        {
            ImGuiStyle style = new ImGuiStyle();
            
            style.Alpha = 0.8f;
            style.DisabledAlpha = 0.2f;
            style.WindowPadding = new Vector2F(11, 22);
            style.WindowRounding = 6.0f;
            style.WindowBorderSize = 2.0f;
            style.WindowMinSize = new Vector2F(120, 240);
            style.WindowTitleAlign = new Vector2F(0.3f, 0.7f);
            style.FramePadding = new Vector2F(7, 14);
            style.FrameRounding = 3.0f;
            style.FrameBorderSize = 1.5f;
            style.ItemSpacing = new Vector2F(9, 18);
            style.ItemInnerSpacing = new Vector2F(5, 10);
            style.CellPadding = new Vector2F(8, 16);
            style.TouchExtraPadding = new Vector2F(3, 6);
            style.IndentSpacing = 20.0f;
            style.ScrollbarSize = 18.0f;
            style.GrabMinSize = 10.0f;
            style.MouseCursorScale = 2.0f;
            style.CurveTessellationTol = 2.5f;
            style.CircleTessellationMaxError = 0.5f;

            Assert.Equal(0.8f, style.Alpha);
            Assert.Equal(0.2f, style.DisabledAlpha);
            Assert.Equal(new Vector2F(11, 22), style.WindowPadding);
            Assert.Equal(6.0f, style.WindowRounding);
            Assert.Equal(2.0f, style.WindowBorderSize);
            Assert.Equal(new Vector2F(120, 240), style.WindowMinSize);
            Assert.Equal(new Vector2F(0.3f, 0.7f), style.WindowTitleAlign);
            Assert.Equal(new Vector2F(7, 14), style.FramePadding);
            Assert.Equal(3.0f, style.FrameRounding);
            Assert.Equal(1.5f, style.FrameBorderSize);
            Assert.Equal(new Vector2F(9, 18), style.ItemSpacing);
            Assert.Equal(new Vector2F(5, 10), style.ItemInnerSpacing);
            Assert.Equal(new Vector2F(8, 16), style.CellPadding);
            Assert.Equal(new Vector2F(3, 6), style.TouchExtraPadding);
            Assert.Equal(20.0f, style.IndentSpacing);
            Assert.Equal(18.0f, style.ScrollbarSize);
            Assert.Equal(10.0f, style.GrabMinSize);
            Assert.Equal(2.0f, style.MouseCursorScale);
            Assert.Equal(2.5f, style.CurveTessellationTol);
            Assert.Equal(0.5f, style.CircleTessellationMaxError);
        }
    }
}
