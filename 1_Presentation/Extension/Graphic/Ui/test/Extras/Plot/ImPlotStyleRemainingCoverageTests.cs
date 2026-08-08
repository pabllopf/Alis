// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStyleRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot style remaining coverage tests
    /// </summary>
    public class ImPlotStyleRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that setting line weight returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LineWeight_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.LineWeight = 1.5f;

            Assert.Equal(1.5f, style.LineWeight, 5);
        }

        /// <summary>
        ///     Tests that setting marker size returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MarkerSize_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.MarkerSize = 5.0f;

            Assert.Equal(5.0f, style.MarkerSize, 5);
        }

        /// <summary>
        ///     Tests that setting marker weight returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MarkerWeight_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.MarkerWeight = 2.0f;

            Assert.Equal(2.0f, style.MarkerWeight, 5);
        }

        /// <summary>
        ///     Tests that setting fill alpha returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FillAlpha_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.FillAlpha = 0.5f;

            Assert.Equal(0.5f, style.FillAlpha, 5);
        }

        /// <summary>
        ///     Tests that setting error bar size returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ErrorBarSize_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.ErrorBarSize = 4.0f;

            Assert.Equal(4.0f, style.ErrorBarSize, 5);
        }

        /// <summary>
        ///     Tests that setting error bar weight returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ErrorBarWeight_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.ErrorBarWeight = 1.5f;

            Assert.Equal(1.5f, style.ErrorBarWeight, 5);
        }

        /// <summary>
        ///     Tests that setting digital bit height returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DigitalBitHeight_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.DigitalBitHeight = 8.0f;

            Assert.Equal(8.0f, style.DigitalBitHeight, 5);
        }

        /// <summary>
        ///     Tests that setting digital bit gap returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DigitalBitGap_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.DigitalBitGap = 4.0f;

            Assert.Equal(4.0f, style.DigitalBitGap, 5);
        }

        /// <summary>
        ///     Tests that setting plot border size returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotBorderSize_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.PlotBorderSize = 1.0f;

            Assert.Equal(1.0f, style.PlotBorderSize, 5);
        }

        /// <summary>
        ///     Tests that setting minor alpha returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void MinorAlpha_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.MinorAlpha = 0.25f;

            Assert.Equal(0.25f, style.MinorAlpha, 5);
        }

        /// <summary>
        ///     Tests that setting marker returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Marker_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Marker = 3;

            Assert.Equal(3, style.Marker);
        }

        /// <summary>
        ///     Tests that setting tick length properties returns the same values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TickLenProperties_SetValues_ReturnsSameValues()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.MajorTickLen = new Vector2F(1f, 2f);
            style.MinorTickLen = new Vector2F(3f, 4f);

            Assert.Equal(new Vector2F(1f, 2f), style.MajorTickLen);
            Assert.Equal(new Vector2F(3f, 4f), style.MinorTickLen);
        }

        /// <summary>
        ///     Tests that setting tick size properties returns the same values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void TickSizeProperties_SetValues_ReturnsSameValues()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.MajorTickSize = new Vector2F(1f, 2f);
            style.MinorTickSize = new Vector2F(3f, 4f);

            Assert.Equal(new Vector2F(1f, 2f), style.MajorTickSize);
            Assert.Equal(new Vector2F(3f, 4f), style.MinorTickSize);
        }

        /// <summary>
        ///     Tests that setting grid size properties returns the same values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void GridSizeProperties_SetValues_ReturnsSameValues()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.MajorGridSize = new Vector2F(1f, 2f);
            style.MinorGridSize = new Vector2F(3f, 4f);

            Assert.Equal(new Vector2F(1f, 2f), style.MajorGridSize);
            Assert.Equal(new Vector2F(3f, 4f), style.MinorGridSize);
        }

        /// <summary>
        ///     Tests that setting padding properties returns the same values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PaddingProperties_SetValues_ReturnsSameValues()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.PlotPadding = new Vector2F(1f, 2f);
            style.LabelPadding = new Vector2F(3f, 4f);
            style.LegendPadding = new Vector2F(5f, 6f);
            style.LegendInnerPadding = new Vector2F(7f, 8f);

            Assert.Equal(new Vector2F(1f, 2f), style.PlotPadding);
            Assert.Equal(new Vector2F(3f, 4f), style.LabelPadding);
            Assert.Equal(new Vector2F(5f, 6f), style.LegendPadding);
            Assert.Equal(new Vector2F(7f, 8f), style.LegendInnerPadding);
        }

        /// <summary>
        ///     Tests that setting spacing and annotation padding properties returns the same values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SpacingAndAnnotationPaddingProperties_SetValues_ReturnsSameValues()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.LegendSpacing = new Vector2F(1f, 2f);
            style.MousePosPadding = new Vector2F(3f, 4f);
            style.AnnotationPadding = new Vector2F(5f, 6f);

            Assert.Equal(new Vector2F(1f, 2f), style.LegendSpacing);
            Assert.Equal(new Vector2F(3f, 4f), style.MousePosPadding);
            Assert.Equal(new Vector2F(5f, 6f), style.AnnotationPadding);
        }

        /// <summary>
        ///     Tests that setting fit and plot size properties returns the same values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void FitAndPlotSizeProperties_SetValues_ReturnsSameValues()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.FitPadding = new Vector2F(1f, 2f);
            style.PlotDefaultSize = new Vector2F(3f, 4f);
            style.PlotMinSize = new Vector2F(5f, 6f);

            Assert.Equal(new Vector2F(1f, 2f), style.FitPadding);
            Assert.Equal(new Vector2F(3f, 4f), style.PlotDefaultSize);
            Assert.Equal(new Vector2F(5f, 6f), style.PlotMinSize);
        }

        /// <summary>
        ///     Tests that setting Colors0 returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Colors0_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors0 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(1f, style.Colors0.X, 5);
            Assert.Equal(2f, style.Colors0.Y, 5);
            Assert.Equal(3f, style.Colors0.Z, 5);
            Assert.Equal(4f, style.Colors0.W, 5);
        }

        /// <summary>
        ///     Tests that setting Colors5 returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Colors5_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors5 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(1f, style.Colors5.X, 5);
            Assert.Equal(2f, style.Colors5.Y, 5);
            Assert.Equal(3f, style.Colors5.Z, 5);
            Assert.Equal(4f, style.Colors5.W, 5);
        }

        /// <summary>
        ///     Tests that setting Colors10 returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Colors10_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors10 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(1f, style.Colors10.X, 5);
            Assert.Equal(2f, style.Colors10.Y, 5);
            Assert.Equal(3f, style.Colors10.Z, 5);
            Assert.Equal(4f, style.Colors10.W, 5);
        }

        /// <summary>
        ///     Tests that setting Colors15 returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Colors15_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors15 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(1f, style.Colors15.X, 5);
            Assert.Equal(2f, style.Colors15.Y, 5);
            Assert.Equal(3f, style.Colors15.Z, 5);
            Assert.Equal(4f, style.Colors15.W, 5);
        }

        /// <summary>
        ///     Tests that setting Colors20 returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Colors20_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors20 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(1f, style.Colors20.X, 5);
            Assert.Equal(2f, style.Colors20.Y, 5);
            Assert.Equal(3f, style.Colors20.Z, 5);
            Assert.Equal(4f, style.Colors20.W, 5);
        }

        /// <summary>
        ///     Tests that setting colormap to a non-default value returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Colormap_SetNonDefaultValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colormap = ImPlotColormap.Deep;

            Assert.Equal(ImPlotColormap.Deep, style.Colormap);
        }

        /// <summary>
        ///     Tests that the default colormap is the default enum value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Colormap_Default_IsDefaultEnum()
        {
            ImPlotStyle style = new ImPlotStyle();

            Assert.Equal(default(ImPlotColormap), style.Colormap);
        }

        /// <summary>
        ///     Tests that setting use local time returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void UseLocalTime_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.UseLocalTime = 1;

            Assert.Equal((byte)1, style.UseLocalTime);
        }

        /// <summary>
        ///     Tests that setting use iso 8601 returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void UseIso8601_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.UseIso8601 = 1;

            Assert.Equal((byte)1, style.UseIso8601);
        }

        /// <summary>
        ///     Tests that setting use 24 hour clock returns the same value.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Use24HourClock_SetValue_ReturnsSameValue()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Use24HourClock = 1;

            Assert.Equal((byte)1, style.Use24HourClock);
        }

        /// <summary>
        ///     Tests that the default im plot style has expected default values.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Default_Constructor_HasExpectedDefaults()
        {
            ImPlotStyle style = new ImPlotStyle();

            Assert.Equal(0f, style.LineWeight, 5);
            Assert.Equal(0, style.Marker);
            Assert.Equal(default(Vector2F), style.MajorTickLen);
            Assert.Equal(0f, style.Colors0.X, 5);
            Assert.Equal(0f, style.Colors0.Y, 5);
            Assert.Equal(0f, style.Colors0.Z, 5);
            Assert.Equal(0f, style.Colors0.W, 5);
            Assert.Equal(default(ImPlotColormap), style.Colormap);
            Assert.Equal((byte)0, style.UseLocalTime);
        }
    }
}