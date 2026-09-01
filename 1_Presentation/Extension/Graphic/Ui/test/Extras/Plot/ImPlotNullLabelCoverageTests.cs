// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotNullLabelCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot null label coverage tests class
    /// </summary>
    public class ImPlotNullLabelCoverageTests
    {
        /// <summary>
        ///     Plots the stems ushort_ref_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ushort_Ref_Flags()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0)));
        }

        /// <summary>
        ///     Plots the stems ushort_ref_flags_offset null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ushort_Ref_Flags_Offset()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0)));
        }

        /// <summary>
        ///     Plots the stems ushort_ref_flags_offset_stride null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ushort_Ref_Flags_Offset_Stride()
        {
            ushort xs = 0;
            ushort ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0, 0)));
        }

        /// <summary>
        ///     Plots the stems int_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Int_Base()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Plots the stems int_ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Int_Ref()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Plots the stems int_ref_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Int_Ref_Flags()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0)));
        }

        /// <summary>
        ///     Plots the stems int_ref_flags_offset null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Int_Ref_Flags_Offset()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0)));
        }

        /// <summary>
        ///     Plots the stems int_ref_flags_offset_stride null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Int_Ref_Flags_Offset_Stride()
        {
            int xs = 0;
            int ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0, 0)));
        }

        /// <summary>
        ///     Plots the stems uint_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Uint_Base()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Plots the stems uint_ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Uint_Ref()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Plots the stems uint_ref_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Uint_Ref_Flags()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0)));
        }

        /// <summary>
        ///     Plots the stems uint_ref_flags_offset null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Uint_Ref_Flags_Offset()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0)));
        }

        /// <summary>
        ///     Plots the stems uint_ref_flags_offset_stride null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Uint_Ref_Flags_Offset_Stride()
        {
            uint xs = 0;
            uint ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0, 0)));
        }

        /// <summary>
        ///     Plots the stems long_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Long_Base()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Plots the stems long_ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Long_Ref()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Plots the stems long_ref_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Long_Ref_Flags()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0)));
        }

        /// <summary>
        ///     Plots the stems long_ref_flags_offset null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Long_Ref_Flags_Offset()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0)));
        }

        /// <summary>
        ///     Plots the stems long_ref_flags_offset_stride null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Long_Ref_Flags_Offset_Stride()
        {
            long xs = 0;
            long ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0, 0)));
        }

        /// <summary>
        ///     Plots the stems ulong_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ulong_Base()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0)));
        }

        /// <summary>
        ///     Plots the stems ulong_ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ulong_Ref()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0)));
        }

        /// <summary>
        ///     Plots the stems ulong_ref_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ulong_Ref_Flags()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0)));
        }

        /// <summary>
        ///     Plots the stems ulong_ref_flags_offset null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ulong_Ref_Flags_Offset()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0)));
        }

        /// <summary>
        ///     Plots the stems ulong_ref_flags_offset_stride null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Ulong_Ref_Flags_Offset_Stride()
        {
            ulong xs = 0;
            ulong ys = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotStems(null, ref xs, ref ys, 0, 0.0, (ImPlotStemsFlags)0, 0, 0)));
        }

        /// <summary>
        ///     plots the text null text should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotText_Plain()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotText(null, 0.0, 0.0)));
        }

        /// <summary>
        ///     plots the text pixel offset null text should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotText_PixOffset()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotText(null, 0.0, 0.0, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     plots the text flags null text should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotText_Flags()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotText(null, 0.0, 0.0, new Vector2F(0, 0), (ImPlotTextFlags)0)));
        }

        /// <summary>
        ///     pushes the color map null name should throw argument null exception
        /// </summary>
        [Fact]
        public void PushColormap_NullName()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PushColormap((string)null)));
        }

        /// <summary>
        ///     setups the axes null x label should throw argument null exception
        /// </summary>
        [Fact]
        public void SetupAxes_Base()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxes(null, "y")));
        }

        /// <summary>
        ///     setups the axes x flags null x label should throw argument null exception
        /// </summary>
        [Fact]
        public void SetupAxes_XFlags()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxes(null, "y", (ImPlotAxisFlags)0)));
        }

        /// <summary>
        ///     setups the axes xy flags null x label should throw argument null exception
        /// </summary>
        [Fact]
        public void SetupAxes_XYFlags()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxes(null, "y", (ImPlotAxisFlags)0, (ImPlotAxisFlags)0)));
        }

        /// <summary>
        ///     setups the axis null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SetupAxis_Label()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxis((ImAxis)0, null)));
        }

        /// <summary>
        ///     setups the axis flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SetupAxis_Label_Flags()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxis((ImAxis)0, null, (ImPlotAxisFlags)0)));
        }

        /// <summary>
        ///     setups the axis format null fmt should throw argument null exception
        /// </summary>
        [Fact]
        public void SetupAxisFormat_NullFmt()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.SetupAxisFormat((ImAxis)0, (string)null)));
        }

        /// <summary>
        ///     shows the colormap selector null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ShowColormapSelector_NullLabel()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ShowColormapSelector(null)));
        }

        /// <summary>
        ///     shows the input map selector null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ShowInputMapSelector_NullLabel()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ShowInputMapSelector(null)));
        }

        /// <summary>
        ///     shows the style selector null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ShowStyleSelector_NullLabel()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.ShowStyleSelector(null)));
        }

        /// <summary>
        ///     tags the x null fmt should throw argument null exception
        /// </summary>
        [Fact]
        public void TagX_NullFmt()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.TagX(0.0, new Vector4F(0, 0, 0, 1), null)));
        }

        /// <summary>
        ///     tags the y null fmt should throw argument null exception
        /// </summary>
        [Fact]
        public void TagY_NullFmt()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.TagY(0.0, new Vector4F(0, 0, 0, 1), null)));
        }

    }
}
