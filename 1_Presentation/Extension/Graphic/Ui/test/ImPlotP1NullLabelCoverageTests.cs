// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1NullLabelCoverageTests.cs
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
using Xunit;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.Plot;

namespace Alis.Extension.Graphic.Ui.Extras.Plot.Test
{
    /// <summary>
    ///     The im plot p1 null label coverage tests class
    /// </summary>
    public class ImPlotP1NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the addcolormap vec4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void AddColormap_Vec4_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F cols = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.AddColormap((string)null, ref cols, 0)));
        }

        /// <summary>
        ///     tests the addcolormap vec4 qual null label should throw argument null exception
        /// </summary>
        [Fact]
        public void AddColormap_Vec4_Qual_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F cols = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.AddColormap((string)null, ref cols, 0, true)));
        }

        /// <summary>
        ///     tests the addcolormap u32 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void AddColormap_U32_NullLabel_ShouldThrowArgumentNullException()
        {
            uint cols = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.AddColormap((string)null, ref cols, 0)));
        }

        /// <summary>
        ///     tests the addcolormap u32 qual null label should throw argument null exception
        /// </summary>
        [Fact]
        public void AddColormap_U32_Qual_NullLabel_ShouldThrowArgumentNullException()
        {
            uint cols = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.AddColormap((string)null, ref cols, 0, true)));
        }

        /// <summary>
        ///     tests the annotation fmt null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Annotation_Fmt_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.Annotation(0, 0, new Vector4F(0,0,0,1), new Vector2F(0,0), true, (string)null)));
        }

        /// <summary>
        ///     tests the beginalignedplots null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginAlignedPlots((string)null)));
        }

        /// <summary>
        ///     tests the beginalignedplots vertical null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginAlignedPlots_Vertical_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginAlignedPlots((string)null, true)));
        }

        /// <summary>
        ///     tests the begindragdropsourceitem null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginDragDropSourceItem((string)null)));
        }

        /// <summary>
        ///     tests the begindragdropsourceitem flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginDragDropSourceItem_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginDragDropSourceItem((string)null, ImGuiDragDropFlags.None)));
        }

        /// <summary>
        ///     tests the beginlegendpopup null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginLegendPopup_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginLegendPopup((string)null)));
        }

        /// <summary>
        ///     tests the beginlegendpopup mousebutton null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginLegendPopup_MouseButton_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginLegendPopup((string)null, ImGuiMouseButton.Left)));
        }

        /// <summary>
        ///     tests the beginplot null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPlot_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginPlot((string)null)));
        }

        /// <summary>
        ///     tests the beginplot size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPlot_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginPlot((string)null, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the beginplot size flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginPlot_Size_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginPlot((string)null, new Vector2F(0, 0), ImPlotFlags.None)));
        }

        /// <summary>
        ///     tests the beginsubplots null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginSubplots_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginSubplots((string)null, 1, 1, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the beginsubplots flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginSubplots_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginSubplots((string)null, 1, 1, new Vector2F(0, 0), ImPlotSubplotFlags.None)));
        }

        /// <summary>
        ///     tests the beginsubplots flags row null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginSubplots_Flags_Row_NullLabel_ShouldThrowArgumentNullException()
        {
            float rowRatios = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginSubplots((string)null, 1, 1, new Vector2F(0, 0), ImPlotSubplotFlags.None, ref rowRatios)));
        }

        /// <summary>
        ///     tests the beginsubplots flags row col null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BeginSubplots_Flags_Row_Col_NullLabel_ShouldThrowArgumentNullException()
        {
            float rowRatios = 0; float colRatios = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BeginSubplots((string)null, 1, 1, new Vector2F(0, 0), ImPlotSubplotFlags.None, ref rowRatios, ref colRatios)));
        }

        /// <summary>
        ///     tests the bustcolorcache null label should throw argument null exception
        /// </summary>
        [Fact]
        public void BustColorCache_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.BustColorCache((string)null)));
        }

        /// <summary>
        ///     tests the colormapbutton null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapButton_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapButton((string)null)));
        }

        /// <summary>
        ///     tests the colormapbutton size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapButton_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapButton((string)null, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the colormapbutton size cmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapButton_Size_Cmap_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapButton((string)null, new Vector2F(0, 0), (ImPlotColormap)0)));
        }

        /// <summary>
        ///     tests the colormapscale null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapScale_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapScale((string)null, 0, 1)));
        }

        /// <summary>
        ///     tests the colormapscale size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapScale_Size_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapScale((string)null, 0, 1, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the colormapscale size format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapScale_Size_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapScale((string)null, 0, 1, new Vector2F(0, 0), (string)null)));
        }

        /// <summary>
        ///     tests the colormapscale size format flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapScale_Size_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapScale((string)null, 0, 1, new Vector2F(0, 0), (string)null, ImPlotColormapScaleFlags.None)));
        }

        /// <summary>
        ///     tests the colormapscale size format flags cmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapScale_Size_Format_Flags_Cmap_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapScale((string)null, 0, 1, new Vector2F(0, 0), (string)null, ImPlotColormapScaleFlags.None, (ImPlotColormap)0)));
        }

        /// <summary>
        ///     tests the colormapslider null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapSlider_NullLabel_ShouldThrowArgumentNullException()
        {
            float t = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapSlider((string)null, ref t)));
        }

        /// <summary>
        ///     tests the colormapslider out null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapSlider_Out_NullLabel_ShouldThrowArgumentNullException()
        {
            float t = 0; Vector4F @out = new Vector4F(0,0,0,1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapSlider((string)null, ref t, out @out)));
        }

        /// <summary>
        ///     tests the colormapslider out format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapSlider_Out_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            float t = 0; Vector4F @out = new Vector4F(0,0,0,1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapSlider((string)null, ref t, out @out, (string)null)));
        }

        /// <summary>
        ///     tests the colormapslider out format cmap null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ColormapSlider_Out_Format_Cmap_NullLabel_ShouldThrowArgumentNullException()
        {
            float t = 0; Vector4F @out = new Vector4F(0,0,0,1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ColormapSlider((string)null, ref t, out @out, (string)null, (ImPlotColormap)0)));
        }

    }
}
