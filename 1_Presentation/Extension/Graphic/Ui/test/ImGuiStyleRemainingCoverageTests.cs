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
using Alis.Extension.Graphic.Ui.Test.Attributes;
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
        public void ScaleAllSizes_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(1.5f);
        }

        /// <summary>
        /// Tests that scale all sizes with zero should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void ScaleAllSizes_WithZero_ShouldNotThrow()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ScaleAllSizes(0.0f);
        }

        /// <summary>
        /// Tests that scale all sizes with negative should not throw
        /// </summary>
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
        public void Alpha_ShouldHandleMaxValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.Alpha = float.MaxValue;
            Assert.Equal(float.MaxValue, style.Alpha);
        }

        /// <summary>
        /// Tests that alpha should handle min value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Alpha_ShouldHandleMinValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.Alpha = float.MinValue;
            Assert.Equal(float.MinValue, style.Alpha);
        }

        /// <summary>
        /// Tests that disabled alpha should handle zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void DisabledAlpha_ShouldHandleZero()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.DisabledAlpha = 0.0f;
            Assert.Equal(0.0f, style.DisabledAlpha, 5);
        }

        /// <summary>
        /// Tests that window rounding should handle max value
        /// </summary>
        [RequireCImguiSystemFact]
        public void WindowRounding_ShouldHandleMaxValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowRounding = float.MaxValue;
            Assert.Equal(float.MaxValue, style.WindowRounding);
        }

        /// <summary>
        /// Tests that window border size should handle negative value
        /// </summary>
        [RequireCImguiSystemFact]
        public void WindowBorderSize_ShouldHandleNegativeValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowBorderSize = -1.0f;
            Assert.Equal(-1.0f, style.WindowBorderSize, 5);
        }

        /// <summary>
        /// Tests that mouse cursor scale should handle zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void MouseCursorScale_ShouldHandleZero()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.MouseCursorScale = 0.0f;
            Assert.Equal(0.0f, style.MouseCursorScale, 5);
        }

        /// <summary>
        /// Tests that anti aliased lines should handle max byte
        /// </summary>
        [RequireCImguiSystemFact]
        public void AntiAliasedLines_ShouldHandleMaxByte()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedLines = 255;
            Assert.Equal(255, style.AntiAliasedLines);
        }

        /// <summary>
        /// Tests that anti aliased lines use tex should handle zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void AntiAliasedLinesUseTex_ShouldHandleZero()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedLinesUseTex = 0;
            Assert.Equal(0, style.AntiAliasedLinesUseTex);
        }

        /// <summary>
        /// Tests that anti aliased fill should handle max byte
        /// </summary>
        [RequireCImguiSystemFact]
        public void AntiAliasedFill_ShouldHandleMaxByte()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.AntiAliasedFill = 255;
            Assert.Equal(255, style.AntiAliasedFill);
        }

        /// <summary>
        /// Tests that curve tessellation tol should handle negative
        /// </summary>
        [RequireCImguiSystemFact]
        public void CurveTessellationTol_ShouldHandleNegative()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.CurveTessellationTol = -0.5f;
            Assert.Equal(-0.5f, style.CurveTessellationTol, 5);
        }

        /// <summary>
        /// Tests that circle tessellation max error should handle large value
        /// </summary>
        [RequireCImguiSystemFact]
        public void CircleTessellationMaxError_ShouldHandleLargeValue()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.CircleTessellationMaxError = 1000.0f;
            Assert.Equal(1000.0f, style.CircleTessellationMaxError, 5);
        }

        // ---------------------------------------------------------------
        //  WindowMenuButtonPosition / ColorButtonPosition edge cases
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that window menu button position should handle none
        /// </summary>
        [RequireCImguiSystemFact]
        public void WindowMenuButtonPosition_ShouldHandleNone()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowMenuButtonPosition = ImGuiDir.None;
            Assert.Equal(ImGuiDir.None, style.WindowMenuButtonPosition);
        }

        /// <summary>
        /// Tests that window menu button position should handle right
        /// </summary>
        [RequireCImguiSystemFact]
        public void WindowMenuButtonPosition_ShouldHandleRight()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.WindowMenuButtonPosition = ImGuiDir.Right;
            Assert.Equal(ImGuiDir.Right, style.WindowMenuButtonPosition);
        }

        /// <summary>
        /// Tests that color button position should handle left
        /// </summary>
        [RequireCImguiSystemFact]
        public void ColorButtonPosition_ShouldHandleLeft()
        {
            ImGuiStyle style = new ImGuiStyle();
            style.ColorButtonPosition = ImGuiDir.Left;
            Assert.Equal(ImGuiDir.Left, style.ColorButtonPosition);
        }

        // ---------------------------------------------------------------
        //  Round-trip through multiple properties
        // ---------------------------------------------------------------

        // ---------------------------------------------------------------
        //  Indexer coverage for remaining color indices 4-9, 11-19, 21-29, 31-39, 41-49, 51-52, 54
        // ---------------------------------------------------------------

        /// <summary>
        /// Tests that indexer get all remaining indices should return correct color
        /// </summary>
        /// <param name="index">The index</param>
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(31)]
        [InlineData(32)]
        [InlineData(33)]
        [InlineData(34)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(38)]
        [InlineData(39)]
        [InlineData(41)]
        [InlineData(42)]
        [InlineData(43)]
        [InlineData(44)]
        [InlineData(45)]
        [InlineData(46)]
        [InlineData(47)]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(51)]
        [InlineData(52)]
        [InlineData(53)]
        [InlineData(54)]
        public void Indexer_Get_AllRemainingIndices_ShouldReturnCorrectColor(int index)
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(index * 0.01f, index * 0.02f, index * 0.03f, index * 0.04f);

            // Set via Colors property directly
            switch (index)
            {
                case 4: style.Colors4 = expected; break;
                case 5: style.Colors5 = expected; break;
                case 6: style.Colors6 = expected; break;
                case 7: style.Colors7 = expected; break;
                case 8: style.Colors8 = expected; break;
                case 9: style.Colors9 = expected; break;
                case 11: style.Colors11 = expected; break;
                case 12: style.Colors12 = expected; break;
                case 13: style.Colors13 = expected; break;
                case 14: style.Colors14 = expected; break;
                case 15: style.Colors15 = expected; break;
                case 16: style.Colors16 = expected; break;
                case 17: style.Colors17 = expected; break;
                case 18: style.Colors18 = expected; break;
                case 19: style.Colors19 = expected; break;
                case 21: style.Colors21 = expected; break;
                case 22: style.Colors22 = expected; break;
                case 23: style.Colors23 = expected; break;
                case 24: style.Colors24 = expected; break;
                case 25: style.Colors25 = expected; break;
                case 26: style.Colors26 = expected; break;
                case 27: style.Colors27 = expected; break;
                case 28: style.Colors28 = expected; break;
                case 29: style.Colors29 = expected; break;
                case 31: style.Colors31 = expected; break;
                case 32: style.Colors32 = expected; break;
                case 33: style.Colors33 = expected; break;
                case 34: style.Colors34 = expected; break;
                case 35: style.Colors35 = expected; break;
                case 36: style.Colors36 = expected; break;
                case 37: style.Colors37 = expected; break;
                case 38: style.Colors38 = expected; break;
                case 39: style.Colors39 = expected; break;
                case 41: style.Colors41 = expected; break;
                case 42: style.Colors42 = expected; break;
                case 43: style.Colors43 = expected; break;
                case 44: style.Colors44 = expected; break;
                case 45: style.Colors45 = expected; break;
                case 46: style.Colors46 = expected; break;
                case 47: style.Colors47 = expected; break;
                case 48: style.Colors48 = expected; break;
                case 49: style.Colors49 = expected; break;
                case 51: style.Colors51 = expected; break;
                case 52: style.Colors52 = expected; break;
                case 53: style.Colors53 = expected; break;
                case 54: style.Colors54 = expected; break;
            }

            Assert.Equal(expected, style[index]);
        }

        /// <summary>
        /// Tests that indexer set all remaining indices should set correct color
        /// </summary>
        /// <param name="index">The index</param>
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(31)]
        [InlineData(32)]
        [InlineData(33)]
        [InlineData(34)]
        [InlineData(35)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(38)]
        [InlineData(39)]
        [InlineData(41)]
        [InlineData(42)]
        [InlineData(43)]
        [InlineData(44)]
        [InlineData(45)]
        [InlineData(46)]
        [InlineData(47)]
        [InlineData(48)]
        [InlineData(49)]
        [InlineData(51)]
        [InlineData(52)]
        [InlineData(53)]
        [InlineData(54)]
        public void Indexer_Set_AllRemainingIndices_ShouldSetCorrectColor(int index)
        {
            ImGuiStyle style = new ImGuiStyle();
            Vector4F expected = new Vector4F(index * 0.01f, index * 0.02f, index * 0.03f, index * 0.04f);

            style[index] = expected;

            switch (index)
            {
                case 4: Assert.Equal(expected, style.Colors4); break;
                case 5: Assert.Equal(expected, style.Colors5); break;
                case 6: Assert.Equal(expected, style.Colors6); break;
                case 7: Assert.Equal(expected, style.Colors7); break;
                case 8: Assert.Equal(expected, style.Colors8); break;
                case 9: Assert.Equal(expected, style.Colors9); break;
                case 11: Assert.Equal(expected, style.Colors11); break;
                case 12: Assert.Equal(expected, style.Colors12); break;
                case 13: Assert.Equal(expected, style.Colors13); break;
                case 14: Assert.Equal(expected, style.Colors14); break;
                case 15: Assert.Equal(expected, style.Colors15); break;
                case 16: Assert.Equal(expected, style.Colors16); break;
                case 17: Assert.Equal(expected, style.Colors17); break;
                case 18: Assert.Equal(expected, style.Colors18); break;
                case 19: Assert.Equal(expected, style.Colors19); break;
                case 21: Assert.Equal(expected, style.Colors21); break;
                case 22: Assert.Equal(expected, style.Colors22); break;
                case 23: Assert.Equal(expected, style.Colors23); break;
                case 24: Assert.Equal(expected, style.Colors24); break;
                case 25: Assert.Equal(expected, style.Colors25); break;
                case 26: Assert.Equal(expected, style.Colors26); break;
                case 27: Assert.Equal(expected, style.Colors27); break;
                case 28: Assert.Equal(expected, style.Colors28); break;
                case 29: Assert.Equal(expected, style.Colors29); break;
                case 31: Assert.Equal(expected, style.Colors31); break;
                case 32: Assert.Equal(expected, style.Colors32); break;
                case 33: Assert.Equal(expected, style.Colors33); break;
                case 34: Assert.Equal(expected, style.Colors34); break;
                case 35: Assert.Equal(expected, style.Colors35); break;
                case 36: Assert.Equal(expected, style.Colors36); break;
                case 37: Assert.Equal(expected, style.Colors37); break;
                case 38: Assert.Equal(expected, style.Colors38); break;
                case 39: Assert.Equal(expected, style.Colors39); break;
                case 41: Assert.Equal(expected, style.Colors41); break;
                case 42: Assert.Equal(expected, style.Colors42); break;
                case 43: Assert.Equal(expected, style.Colors43); break;
                case 44: Assert.Equal(expected, style.Colors44); break;
                case 45: Assert.Equal(expected, style.Colors45); break;
                case 46: Assert.Equal(expected, style.Colors46); break;
                case 47: Assert.Equal(expected, style.Colors47); break;
                case 48: Assert.Equal(expected, style.Colors48); break;
                case 49: Assert.Equal(expected, style.Colors49); break;
                case 51: Assert.Equal(expected, style.Colors51); break;
                case 52: Assert.Equal(expected, style.Colors52); break;
                case 53: Assert.Equal(expected, style.Colors53); break;
                case 54: Assert.Equal(expected, style.Colors54); break;
            }
        }

        /// <summary>
        /// Tests that multiple properties should round trip correctly
        /// </summary>
        [RequireCImguiSystemFact]
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

            Assert.Equal(0.8f, style.Alpha, 5);
            Assert.Equal(0.2f, style.DisabledAlpha, 5);
            Assert.Equal(new Vector2F(11, 22), style.WindowPadding);
            Assert.Equal(6.0f, style.WindowRounding, 5);
            Assert.Equal(2.0f, style.WindowBorderSize, 5);
            Assert.Equal(new Vector2F(120, 240), style.WindowMinSize);
            Assert.Equal(new Vector2F(0.3f, 0.7f), style.WindowTitleAlign);
            Assert.Equal(new Vector2F(7, 14), style.FramePadding);
            Assert.Equal(3.0f, style.FrameRounding, 5);
            Assert.Equal(1.5f, style.FrameBorderSize, 5);
            Assert.Equal(new Vector2F(9, 18), style.ItemSpacing);
            Assert.Equal(new Vector2F(5, 10), style.ItemInnerSpacing);
            Assert.Equal(new Vector2F(8, 16), style.CellPadding);
            Assert.Equal(new Vector2F(3, 6), style.TouchExtraPadding);
            Assert.Equal(20.0f, style.IndentSpacing, 5);
            Assert.Equal(18.0f, style.ScrollbarSize, 5);
            Assert.Equal(10.0f, style.GrabMinSize, 5);
            Assert.Equal(2.0f, style.MouseCursorScale, 5);
            Assert.Equal(2.5f, style.CurveTessellationTol, 5);
            Assert.Equal(0.5f, style.CircleTessellationMaxError, 5);
        }
    }
}
