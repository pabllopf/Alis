// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP4.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP4
    {
        /// <summary>
        ///     Tests that plot heatmap double array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1.0}, 1, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot heatmap double array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1.0}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }

        /// <summary>
        ///     Tests that plot heatmap double array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1.0}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap double array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1.0}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that plot heatmap short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap short array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap short array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot heatmap short array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }

        /// <summary>
        ///     Tests that plot heatmap short array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap short array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1}, 1, 1, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1}, 1, 1, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }

        /// <summary>
        ///     Tests that plot heatmap int array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap double array throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_DoubleArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap double array with bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_WithBoundsMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap double array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint(), ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_SByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[0], 0, 0));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_WithScaleMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[0], 0, 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array with scale max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_WithScaleMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[0], 0, 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array with label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_WithLabelFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[0], 0, 0, 0.0, 0.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array with bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_WithBoundsMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array with bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_WithBoundsMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap s byte array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint(), ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[0], 0, 0));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_WithScaleMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[0], 0, 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array with scale max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_WithScaleMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[0], 0, 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array with label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_WithLabelFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[0], 0, 0, 0.0, 0.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array with bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_WithBoundsMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array with bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_WithBoundsMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap byte array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint(), ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap short array throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[0], 0, 0));
        }

        /// <summary>
        ///     Tests that plot heatmap short array with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_WithScaleMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[0], 0, 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap short array with scale max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_WithScaleMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[0], 0, 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap short array with label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_WithLabelFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[0], 0, 0, 0.0, 0.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot heatmap short array with bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_WithBoundsMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap short array with bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_WithBoundsMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint(), ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[0], 0, 0));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_WithScaleMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[0], 0, 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array with scale max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_WithScaleMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[0], 0, 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array with label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_WithLabelFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[0], 0, 0, 0.0, 0.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array with bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_WithBoundsMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array with bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_WithBoundsMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap u short array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint(), ImPlotHeatmapFlags.None));
        }

        /// <summary>
        ///     Tests that v 2 plot heatmap int array throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotHeatmap_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[0], 0, 0));
        }

        /// <summary>
        ///     Tests that plot heatmap int array with scale min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_WithScaleMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[0], 0, 0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap int array with scale max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_WithScaleMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[0], 0, 0, 0.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot heatmap int array with label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_WithLabelFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[0], 0, 0, 0.0, 0.0, "fmt"));
        }

        /// <summary>
        ///     Tests that plot heatmap int array with bounds min throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_WithBoundsMin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap int array with bounds max throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_WithBoundsMax_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint()));
        }

        /// <summary>
        ///     Tests that plot heatmap int array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[0], 0, 0, 0.0, 0.0, "fmt", new ImPlotPoint(), new ImPlotPoint(), ImPlotHeatmapFlags.None));
        }
    }
}