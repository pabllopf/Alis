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
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot.Native
{
    /// <summary>
    /// The im plot test class
    /// </summary>
    public partial class ImPlotTest
    {
        /// <summary>
        /// Tests that plot heatmap double array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[] {1.0}, 1, 1, 0.0, 1.0, "%.1f"));
        }
        
        /// <summary>
        /// Tests that plot heatmap double array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[] {1.0}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }
        
        /// <summary>
        /// Tests that plot heatmap double array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[] {1.0}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }
        
        /// <summary>
        /// Tests that plot heatmap double array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new double[] {1.0}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }
        
        /// <summary>
        /// Tests that plot heatmap s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1));
        }
        
        /// <summary>
        /// Tests that plot heatmap s byte array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap s byte array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap s byte array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }
        
        /// <summary>
        /// Tests that plot heatmap s byte array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }
        
        /// <summary>
        /// Tests that plot heatmap s byte array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }
        
        /// <summary>
        /// Tests that plot heatmap s byte array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_SByteArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new sbyte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }
        
        /// <summary>
        /// Tests that plot heatmap byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1));
        }
        
        /// <summary>
        /// Tests that plot heatmap byte array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap byte array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap byte array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }
        
        /// <summary>
        /// Tests that plot heatmap byte array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }
        
        /// <summary>
        /// Tests that plot heatmap byte array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }
        
        /// <summary>
        /// Tests that plot heatmap byte array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_ByteArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new byte[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }
        
        /// <summary>
        /// Tests that plot heatmap short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1));
        }
        
        /// <summary>
        /// Tests that plot heatmap short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap short array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap short array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }
        
        /// <summary>
        /// Tests that plot heatmap short array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }
        
        /// <summary>
        /// Tests that plot heatmap short array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }
        
        /// <summary>
        /// Tests that plot heatmap short array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShortArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new short[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }
        
        /// <summary>
        /// Tests that plot heatmap u short array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1));
        }
        
        /// <summary>
        /// Tests that plot heatmap u short array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap u short array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap u short array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }
        
        /// <summary>
        /// Tests that plot heatmap u short array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }
        
        /// <summary>
        /// Tests that plot heatmap u short array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }
        
        /// <summary>
        /// Tests that plot heatmap u short array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_UShortArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new ushort[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }
        
        /// <summary>
        /// Tests that plot heatmap int array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[] {1}, 1, 1));
        }
        
        /// <summary>
        /// Tests that plot heatmap int array throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[] {1}, 1, 1, 0.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap int array throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[] {1}, 1, 1, 0.0, 1.0));
        }
        
        /// <summary>
        /// Tests that plot heatmap int array throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v4()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[] {1}, 1, 1, 0.0, 1.0, "%.1f"));
        }
        
        /// <summary>
        /// Tests that plot heatmap int array throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v5()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}));
        }
        
        /// <summary>
        /// Tests that plot heatmap int array throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v6()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}));
        }
        
        /// <summary>
        /// Tests that plot heatmap int array throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotHeatmap_IntArray_ThrowsDllNotFoundException_v7()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotHeatmap("label", new int[] {1}, 1, 1, 0.0, 1.0, "%.1f", new ImPlotPoint {X = 0, Y = 0}, new ImPlotPoint {X = 1, Y = 1}, ImPlotHeatmapFlags.None));
        }
    }
}