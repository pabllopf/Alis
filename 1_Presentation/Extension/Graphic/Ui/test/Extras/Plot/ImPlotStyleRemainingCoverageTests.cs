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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot style remaining coverage tests class
    /// </summary>
    public class ImPlotStyleRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that numeric properties round trip
        /// </summary>
        [Fact]
        public void NumericProperties_RoundTrip()
        {
            ImPlotStyle style = new ImPlotStyle
            {
                LineWeight = 1.5f,
                Marker = 2,
                MarkerSize = 4.0f,
                MarkerWeight = 1.0f,
                FillAlpha = 0.5f,
                ErrorBarSize = 3.0f,
                ErrorBarWeight = 1.0f,
                DigitalBitHeight = 8.0f,
                DigitalBitGap = 3.0f,
                UseLocalTime = 1,
                UseIso8601 = 1,
                Use24HourClock = 1
            };

            Assert.Equal(1.5f, style.LineWeight, 5);
            Assert.Equal(2, style.Marker);
            Assert.Equal(4.0f, style.MarkerSize, 5);
            Assert.Equal(1.0f, style.MarkerWeight, 5);
            Assert.Equal(0.5f, style.FillAlpha, 5);
            Assert.Equal(3.0f, style.ErrorBarSize, 5);
            Assert.Equal(1.0f, style.ErrorBarWeight, 5);
            Assert.Equal(8.0f, style.DigitalBitHeight, 5);
            Assert.Equal(3.0f, style.DigitalBitGap, 5);
            Assert.Equal(1, style.UseLocalTime);
            Assert.Equal(1, style.UseIso8601);
            Assert.Equal(1, style.Use24HourClock);
        }

        /// <summary>
        ///     Tests that color properties round trip
        /// </summary>
        [Fact]
        public void ColorProperties_RoundTrip()
        {
            ImPlotStyle style = new ImPlotStyle();

            style.Colors0 = new Vector4F(0.1f, 0.2f, 0.3f, 1.0f);
            style.Colors20 = new Vector4F(0.9f, 0.8f, 0.7f, 0.5f);

            Assert.Equal(0.1f, style.Colors0.X, 5);
            Assert.Equal(0.9f, style.Colors20.X, 5);
            Assert.Equal(0.5f, style.Colors20.W, 5);
        }

        /// <summary>
        ///     Tests that colormap property round trips
        /// </summary>
        [Fact]
        public void Colormap_Property_RoundTrips()
        {
            ImPlotStyle style = new ImPlotStyle
            {
                Colormap = ImPlotColormap.Deep
            };

            Assert.Equal(ImPlotColormap.Deep, style.Colormap);
        }

        /// <summary>
        ///     Tests that defaults are zero
        /// </summary>
        [Fact]
        public void Defaults_AreZero()
        {
            ImPlotStyle style = new ImPlotStyle();

            Assert.Equal(0.0f, style.LineWeight, 5);
            Assert.Equal(0, style.Marker);
            Assert.Equal(0.0f, style.MarkerSize, 5);
            Assert.Equal(0.0f, style.FillAlpha, 5);
            Assert.Equal(0, style.UseLocalTime);
        }

        /// <summary>
        ///     Tests that all numeric properties round trip
        /// </summary>
        [Fact]
        public void AllNumericProperties_RoundTrip()
        {
            ImPlotStyle style = new ImPlotStyle
            {
                PlotBorderSize = 1.0f,
                MinorAlpha = 2.0f,
                MajorTickLen = new Vector2F(3, 4),
                MinorTickLen = new Vector2F(5, 6),
                MajorTickSize = new Vector2F(7, 8),
                MinorTickSize = new Vector2F(9, 10),
                MajorGridSize = new Vector2F(11, 12),
                MinorGridSize = new Vector2F(13, 14),
                PlotPadding = new Vector2F(15, 16),
                LabelPadding = new Vector2F(17, 18),
                LegendPadding = new Vector2F(5, 5),
                LegendInnerPadding = new Vector2F(6, 6),
                LegendSpacing = new Vector2F(7, 7),
                MousePosPadding = new Vector2F(8, 8),
                AnnotationPadding = new Vector2F(9, 9),
                FitPadding = new Vector2F(10, 10),
                PlotDefaultSize = new Vector2F(11, 11),
                PlotMinSize = new Vector2F(12, 12)
            };

            Assert.Equal(1.0f, style.PlotBorderSize, 5);
            Assert.Equal(2.0f, style.MinorAlpha, 5);
            Assert.Equal(3, style.MajorTickLen.X);
            Assert.Equal(4, style.MajorTickLen.Y);
            Assert.Equal(5, style.MinorTickLen.X);
            Assert.Equal(6, style.MinorTickLen.Y);
            Assert.Equal(7, style.MajorTickSize.X);
            Assert.Equal(8, style.MajorTickSize.Y);
            Assert.Equal(9, style.MinorTickSize.X);
            Assert.Equal(10, style.MinorTickSize.Y);
            Assert.Equal(11, style.MajorGridSize.X);
            Assert.Equal(12, style.MajorGridSize.Y);
            Assert.Equal(13, style.MinorGridSize.X);
            Assert.Equal(14, style.MinorGridSize.Y);
            Assert.Equal(15, style.PlotPadding.X);
            Assert.Equal(16, style.PlotPadding.Y);
            Assert.Equal(17, style.LabelPadding.X);
            Assert.Equal(18, style.LabelPadding.Y);
            Assert.Equal(5, style.LegendPadding.X);
            Assert.Equal(6, style.LegendInnerPadding.Y);
            Assert.Equal(7, style.LegendSpacing.X);
            Assert.Equal(8, style.MousePosPadding.Y);
            Assert.Equal(9, style.AnnotationPadding.X);
            Assert.Equal(10, style.FitPadding.Y);
            Assert.Equal(11, style.PlotDefaultSize.X);
            Assert.Equal(12, style.PlotMinSize.Y);
        }
    }
}
