// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStyleTest.cs
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
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot style test class
    /// </summary>
    public class ImPlotStyleTest
    {
        /// <summary>
        ///     Tests that line weight should be initialized
        /// </summary>
        [Fact]
        public void LineWeight_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.LineWeight);
        }

        /// <summary>
        ///     Tests that marker should be initialized
        /// </summary>
        [Fact]
        public void Marker_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(int), style.Marker);
        }

        /// <summary>
        ///     Tests that marker size should be initialized
        /// </summary>
        [Fact]
        public void MarkerSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.MarkerSize);
        }

        /// <summary>
        ///     Tests that marker weight should be initialized
        /// </summary>
        [Fact]
        public void MarkerWeight_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.MarkerWeight);
        }

        /// <summary>
        ///     Tests that fill alpha should be initialized
        /// </summary>
        [Fact]
        public void FillAlpha_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.FillAlpha);
        }

        /// <summary>
        ///     Tests that error bar size should be initialized
        /// </summary>
        [Fact]
        public void ErrorBarSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.ErrorBarSize);
        }

        /// <summary>
        ///     Tests that error bar weight should be initialized
        /// </summary>
        [Fact]
        public void ErrorBarWeight_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.ErrorBarWeight);
        }

        /// <summary>
        ///     Tests that digital bit height should be initialized
        /// </summary>
        [Fact]
        public void DigitalBitHeight_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.DigitalBitHeight);
        }

        /// <summary>
        ///     Tests that digital bit gap should be initialized
        /// </summary>
        [Fact]
        public void DigitalBitGap_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.DigitalBitGap);
        }

        /// <summary>
        ///     Tests that plot border size should be initialized
        /// </summary>
        [Fact]
        public void PlotBorderSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.PlotBorderSize);
        }

        /// <summary>
        ///     Tests that minor alpha should be initialized
        /// </summary>
        [Fact]
        public void MinorAlpha_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(float), style.MinorAlpha);
        }

        /// <summary>
        ///     Tests that major tick len should be initialized
        /// </summary>
        [Fact]
        public void MajorTickLen_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.MajorTickLen);
        }

        /// <summary>
        ///     Tests that minor tick len should be initialized
        /// </summary>
        [Fact]
        public void MinorTickLen_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.MinorTickLen);
        }

        /// <summary>
        ///     Tests that major tick size should be initialized
        /// </summary>
        [Fact]
        public void MajorTickSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.MajorTickSize);
        }

        /// <summary>
        ///     Tests that minor tick size should be initialized
        /// </summary>
        [Fact]
        public void MinorTickSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.MinorTickSize);
        }

        /// <summary>
        ///     Tests that major grid size should be initialized
        /// </summary>
        [Fact]
        public void MajorGridSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.MajorGridSize);
        }

        /// <summary>
        ///     Tests that minor grid size should be initialized
        /// </summary>
        [Fact]
        public void MinorGridSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.MinorGridSize);
        }

        /// <summary>
        ///     Tests that plot padding should be initialized
        /// </summary>
        [Fact]
        public void PlotPadding_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.PlotPadding);
        }

        /// <summary>
        ///     Tests that label padding should be initialized
        /// </summary>
        [Fact]
        public void LabelPadding_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.LabelPadding);
        }

        /// <summary>
        ///     Tests that legend padding should be initialized
        /// </summary>
        [Fact]
        public void LegendPadding_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.LegendPadding);
        }

        /// <summary>
        ///     Tests that legend inner padding should be initialized
        /// </summary>
        [Fact]
        public void LegendInnerPadding_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.LegendInnerPadding);
        }

        /// <summary>
        ///     Tests that legend spacing should be initialized
        /// </summary>
        [Fact]
        public void LegendSpacing_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.LegendSpacing);
        }

        /// <summary>
        ///     Tests that mouse pos padding should be initialized
        /// </summary>
        [Fact]
        public void MousePosPadding_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.MousePosPadding);
        }

        /// <summary>
        ///     Tests that annotation padding should be initialized
        /// </summary>
        [Fact]
        public void AnnotationPadding_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.AnnotationPadding);
        }

        /// <summary>
        ///     Tests that fit padding should be initialized
        /// </summary>
        [Fact]
        public void FitPadding_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.FitPadding);
        }

        /// <summary>
        ///     Tests that plot default size should be initialized
        /// </summary>
        [Fact]
        public void PlotDefaultSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.PlotDefaultSize);
        }

        /// <summary>
        ///     Tests that plot min size should be initialized
        /// </summary>
        [Fact]
        public void PlotMinSize_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector2F), style.PlotMinSize);
        }

        /// <summary>
        ///     Tests that colors 0 should be initialized
        /// </summary>
        [Fact]
        public void Colors0_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors0);
        }

        /// <summary>
        ///     Tests that colors 1 should be initialized
        /// </summary>
        [Fact]
        public void Colors1_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors1);
        }

        /// <summary>
        ///     Tests that colors 2 should be initialized
        /// </summary>
        [Fact]
        public void Colors2_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors2);
        }

        /// <summary>
        ///     Tests that colors 3 should be initialized
        /// </summary>
        [Fact]
        public void Colors3_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors3);
        }

        /// <summary>
        ///     Tests that colors 4 should be initialized
        /// </summary>
        [Fact]
        public void Colors4_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors4);
        }

        /// <summary>
        ///     Tests that colors 5 should be initialized
        /// </summary>
        [Fact]
        public void Colors5_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors5);
        }

        /// <summary>
        ///     Tests that colors 6 should be initialized
        /// </summary>
        [Fact]
        public void Colors6_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors6);
        }

        /// <summary>
        ///     Tests that colors 7 should be initialized
        /// </summary>
        [Fact]
        public void Colors7_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors7);
        }

        /// <summary>
        ///     Tests that colors 8 should be initialized
        /// </summary>
        [Fact]
        public void Colors8_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors8);
        }

        /// <summary>
        ///     Tests that colors 9 should be initialized
        /// </summary>
        [Fact]
        public void Colors9_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors9);
        }

        /// <summary>
        ///     Tests that colors 10 should be initialized
        /// </summary>
        [Fact]
        public void Colors10_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors10);
        }

        /// <summary>
        ///     Tests that colors 11 should be initialized
        /// </summary>
        [Fact]
        public void Colors11_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors11);
        }

        /// <summary>
        ///     Tests that colors 12 should be initialized
        /// </summary>
        [Fact]
        public void Colors12_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors12);
        }

        /// <summary>
        ///     Tests that colors 13 should be initialized
        /// </summary>
        [Fact]
        public void Colors13_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors13);
        }

        /// <summary>
        ///     Tests that colors 14 should be initialized
        /// </summary>
        [Fact]
        public void Colors14_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors14);
        }

        /// <summary>
        ///     Tests that colors 15 should be initialized
        /// </summary>
        [Fact]
        public void Colors15_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors15);
        }

        /// <summary>
        ///     Tests that colors 16 should be initialized
        /// </summary>
        [Fact]
        public void Colors16_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors16);
        }

        /// <summary>
        ///     Tests that colors 17 should be initialized
        /// </summary>
        [Fact]
        public void Colors17_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors17);
        }

        /// <summary>
        ///     Tests that colors 18 should be initialized
        /// </summary>
        [Fact]
        public void Colors18_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors18);
        }

        /// <summary>
        ///     Tests that colors 19 should be initialized
        /// </summary>
        [Fact]
        public void Colors19_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors19);
        }

        /// <summary>
        ///     Tests that colors 20 should be initialized
        /// </summary>
        [Fact]
        public void Colors20_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(Vector4F), style.Colors20);
        }

        /// <summary>
        ///     Tests that colormap should be initialized
        /// </summary>
        [Fact]
        public void Colormap_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(ImPlotColormap), style.Colormap);
        }

        /// <summary>
        ///     Tests that use local time should be initialized
        /// </summary>
        [Fact]
        public void UseLocalTime_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(byte), style.UseLocalTime);
        }

        /// <summary>
        ///     Tests that use iso 8601 should be initialized
        /// </summary>
        [Fact]
        public void UseIso8601_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(byte), style.UseIso8601);
        }

        /// <summary>
        ///     Tests that use 24 hour clock should be initialized
        /// </summary>
        [Fact]
        public void Use24HourClock_ShouldBeInitialized()
        {
            ImPlotStyle style = new ImPlotStyle();
            Assert.Equal(default(byte), style.Use24HourClock);
        }

        /// <summary>
        ///     Tests that line weight should set and get correctly
        /// </summary>
        [Fact]
        public void LineWeight_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 1.0f;
            style.LineWeight = value;
            Assert.Equal(value, style.LineWeight);
        }

        /// <summary>
        ///     Tests that marker should set and get correctly
        /// </summary>
        [Fact]
        public void Marker_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            int value = 2;
            style.Marker = value;
            Assert.Equal(value, style.Marker);
        }

        /// <summary>
        ///     Tests that marker size should set and get correctly
        /// </summary>
        [Fact]
        public void MarkerSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 3.0f;
            style.MarkerSize = value;
            Assert.Equal(value, style.MarkerSize);
        }

        /// <summary>
        ///     Tests that marker weight should set and get correctly
        /// </summary>
        [Fact]
        public void MarkerWeight_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 4.0f;
            style.MarkerWeight = value;
            Assert.Equal(value, style.MarkerWeight);
        }

        /// <summary>
        ///     Tests that fill alpha should set and get correctly
        /// </summary>
        [Fact]
        public void FillAlpha_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 5.0f;
            style.FillAlpha = value;
            Assert.Equal(value, style.FillAlpha);
        }

        /// <summary>
        ///     Tests that error bar size should set and get correctly
        /// </summary>
        [Fact]
        public void ErrorBarSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 6.0f;
            style.ErrorBarSize = value;
            Assert.Equal(value, style.ErrorBarSize);
        }

        /// <summary>
        ///     Tests that error bar weight should set and get correctly
        /// </summary>
        [Fact]
        public void ErrorBarWeight_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 7.0f;
            style.ErrorBarWeight = value;
            Assert.Equal(value, style.ErrorBarWeight);
        }

        /// <summary>
        ///     Tests that digital bit height should set and get correctly
        /// </summary>
        [Fact]
        public void DigitalBitHeight_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 8.0f;
            style.DigitalBitHeight = value;
            Assert.Equal(value, style.DigitalBitHeight);
        }

        /// <summary>
        ///     Tests that digital bit gap should set and get correctly
        /// </summary>
        [Fact]
        public void DigitalBitGap_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 9.0f;
            style.DigitalBitGap = value;
            Assert.Equal(value, style.DigitalBitGap);
        }

        /// <summary>
        ///     Tests that plot border size should set and get correctly
        /// </summary>
        [Fact]
        public void PlotBorderSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 10.0f;
            style.PlotBorderSize = value;
            Assert.Equal(value, style.PlotBorderSize);
        }

        /// <summary>
        ///     Tests that minor alpha should set and get correctly
        /// </summary>
        [Fact]
        public void MinorAlpha_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            float value = 11.0f;
            style.MinorAlpha = value;
            Assert.Equal(value, style.MinorAlpha);
        }

        /// <summary>
        ///     Tests that major tick len should set and get correctly
        /// </summary>
        [Fact]
        public void MajorTickLen_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(1.0f, 2.0f);
            style.MajorTickLen = value;
            Assert.Equal(value, style.MajorTickLen);
        }

        /// <summary>
        ///     Tests that minor tick len should set and get correctly
        /// </summary>
        [Fact]
        public void MinorTickLen_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(3.0f, 4.0f);
            style.MinorTickLen = value;
            Assert.Equal(value, style.MinorTickLen);
        }

        /// <summary>
        ///     Tests that major tick size should set and get correctly
        /// </summary>
        [Fact]
        public void MajorTickSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(5.0f, 6.0f);
            style.MajorTickSize = value;
            Assert.Equal(value, style.MajorTickSize);
        }

        /// <summary>
        ///     Tests that minor tick size should set and get correctly
        /// </summary>
        [Fact]
        public void MinorTickSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(7.0f, 8.0f);
            style.MinorTickSize = value;
            Assert.Equal(value, style.MinorTickSize);
        }

        /// <summary>
        ///     Tests that major grid size should set and get correctly
        /// </summary>
        [Fact]
        public void MajorGridSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(9.0f, 10.0f);
            style.MajorGridSize = value;
            Assert.Equal(value, style.MajorGridSize);
        }

        /// <summary>
        ///     Tests that minor grid size should set and get correctly
        /// </summary>
        [Fact]
        public void MinorGridSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(11.0f, 12.0f);
            style.MinorGridSize = value;
            Assert.Equal(value, style.MinorGridSize);
        }

        /// <summary>
        ///     Tests that plot padding should set and get correctly
        /// </summary>
        [Fact]
        public void PlotPadding_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(13.0f, 14.0f);
            style.PlotPadding = value;
            Assert.Equal(value, style.PlotPadding);
        }

        /// <summary>
        ///     Tests that label padding should set and get correctly
        /// </summary>
        [Fact]
        public void LabelPadding_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(15.0f, 16.0f);
            style.LabelPadding = value;
            Assert.Equal(value, style.LabelPadding);
        }

        /// <summary>
        ///     Tests that legend padding should set and get correctly
        /// </summary>
        [Fact]
        public void LegendPadding_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(17.0f, 18.0f);
            style.LegendPadding = value;
            Assert.Equal(value, style.LegendPadding);
        }

        /// <summary>
        ///     Tests that legend inner padding should set and get correctly
        /// </summary>
        [Fact]
        public void LegendInnerPadding_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(19.0f, 20.0f);
            style.LegendInnerPadding = value;
            Assert.Equal(value, style.LegendInnerPadding);
        }

        /// <summary>
        ///     Tests that legend spacing should set and get correctly
        /// </summary>
        [Fact]
        public void LegendSpacing_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(21.0f, 22.0f);
            style.LegendSpacing = value;
            Assert.Equal(value, style.LegendSpacing);
        }

        /// <summary>
        ///     Tests that mouse pos padding should set and get correctly
        /// </summary>
        [Fact]
        public void MousePosPadding_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(23.0f, 24.0f);
            style.MousePosPadding = value;
            Assert.Equal(value, style.MousePosPadding);
        }

        /// <summary>
        ///     Tests that annotation padding should set and get correctly
        /// </summary>
        [Fact]
        public void AnnotationPadding_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(25.0f, 26.0f);
            style.AnnotationPadding = value;
            Assert.Equal(value, style.AnnotationPadding);
        }

        /// <summary>
        ///     Tests that fit padding should set and get correctly
        /// </summary>
        [Fact]
        public void FitPadding_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(27.0f, 28.0f);
            style.FitPadding = value;
            Assert.Equal(value, style.FitPadding);
        }

        /// <summary>
        ///     Tests that plot default size should set and get correctly
        /// </summary>
        [Fact]
        public void PlotDefaultSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(29.0f, 30.0f);
            style.PlotDefaultSize = value;
            Assert.Equal(value, style.PlotDefaultSize);
        }

        /// <summary>
        ///     Tests that plot min size should set and get correctly
        /// </summary>
        [Fact]
        public void PlotMinSize_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector2F value = new Vector2F(31.0f, 32.0f);
            style.PlotMinSize = value;
            Assert.Equal(value, style.PlotMinSize);
        }

        /// <summary>
        ///     Tests that colors 0 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors0_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            style.Colors0 = value;
            Assert.Equal(value, style.Colors0);
        }

        /// <summary>
        ///     Tests that colors 1 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors1_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(5.0f, 6.0f, 7.0f, 8.0f);
            style.Colors1 = value;
            Assert.Equal(value, style.Colors1);
        }

        /// <summary>
        ///     Tests that colors 2 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors2_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(9.0f, 10.0f, 11.0f, 12.0f);
            style.Colors2 = value;
            Assert.Equal(value, style.Colors2);
        }

        /// <summary>
        ///     Tests that colors 3 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors3_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(13.0f, 14.0f, 15.0f, 16.0f);
            style.Colors3 = value;
            Assert.Equal(value, style.Colors3);
        }

        /// <summary>
        ///     Tests that colors 4 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors4_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(17.0f, 18.0f, 19.0f, 20.0f);
            style.Colors4 = value;
            Assert.Equal(value, style.Colors4);
        }

        /// <summary>
        ///     Tests that colors 5 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors5_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(21.0f, 22.0f, 23.0f, 24.0f);
            style.Colors5 = value;
            Assert.Equal(value, style.Colors5);
        }

        /// <summary>
        ///     Tests that colors 6 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors6_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(25.0f, 26.0f, 27.0f, 28.0f);
            style.Colors6 = value;
            Assert.Equal(value, style.Colors6);
        }

        /// <summary>
        ///     Tests that colors 7 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors7_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(29.0f, 30.0f, 31.0f, 32.0f);
            style.Colors7 = value;
            Assert.Equal(value, style.Colors7);
        }

        /// <summary>
        ///     Tests that colors 8 should set and get correctly
        /// </summary>
        [Fact]
        public void Colors8_Should_SetAndGetCorrectly()
        {
            ImPlotStyle style = new ImPlotStyle();
            Vector4F value = new Vector4F(33.0f, 34.0f, 35.0f, 36.0f);
            style.Colors8 = value;
            Assert.Equal(value, style.Colors8);
        }

        /// <summary>
        ///     Tests that colors 9 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors9_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors9 = value;
            Assert.Equal(value, obj.Colors9);
        }

        /// <summary>
        ///     Tests that colors 10 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors10_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors10 = value;
            Assert.Equal(value, obj.Colors10);
        }

        /// <summary>
        ///     Tests that colors 11 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors11_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors11 = value;
            Assert.Equal(value, obj.Colors11);
        }

        /// <summary>
        ///     Tests that colors 12 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors12_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors12 = value;
            Assert.Equal(value, obj.Colors12);
        }

        /// <summary>
        ///     Tests that colors 13 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors13_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors13 = value;
            Assert.Equal(value, obj.Colors13);
        }

        /// <summary>
        ///     Tests that colors 14 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors14_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors14 = value;
            Assert.Equal(value, obj.Colors14);
        }

        /// <summary>
        ///     Tests that colors 15 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors15_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors15 = value;
            Assert.Equal(value, obj.Colors15);
        }

        /// <summary>
        ///     Tests that colors 16 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors16_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors16 = value;
            Assert.Equal(value, obj.Colors16);
        }

        /// <summary>
        ///     Tests that colors 17 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors17_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors17 = value;
            Assert.Equal(value, obj.Colors17);
        }

        /// <summary>
        ///     Tests that colors 18 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors18_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors18 = value;
            Assert.Equal(value, obj.Colors18);
        }

        /// <summary>
        ///     Tests that colors 19 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors19_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors19 = value;
            Assert.Equal(value, obj.Colors19);
        }

        /// <summary>
        ///     Tests that colors 20 set and get returns correct value
        /// </summary>
        [Fact]
        public void Colors20_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            Vector4F value = new Vector4F(1.0f, 2.0f, 3.0f, 4.0f);
            obj.Colors20 = value;
            Assert.Equal(value, obj.Colors20);
        }

        /// <summary>
        ///     Tests that colormap set and get returns correct value
        /// </summary>
        [Fact]
        public void Colormap_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            ImPlotColormap value = new ImPlotColormap();
            obj.Colormap = value;
            Assert.Equal(value, obj.Colormap);
        }

        /// <summary>
        ///     Tests that use local time set and get returns correct value
        /// </summary>
        [Fact]
        public void UseLocalTime_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            byte value = 1;
            obj.UseLocalTime = value;
            Assert.Equal(value, obj.UseLocalTime);
        }

        /// <summary>
        ///     Tests that use iso 8601 set and get returns correct value
        /// </summary>
        [Fact]
        public void UseIso8601_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            byte value = 1;
            obj.UseIso8601 = value;
            Assert.Equal(value, obj.UseIso8601);
        }

        /// <summary>
        ///     Tests that use 24 hour clock set and get returns correct value
        /// </summary>
        [Fact]
        public void Use24HourClock_SetAndGet_ReturnsCorrectValue()
        {
            ImPlotStyle obj = new ImPlotStyle();
            byte value = 1;
            obj.Use24HourClock = value;
            Assert.Equal(value, obj.Use24HourClock);
        }
    }
}