// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP9.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP9
    {
        /// <summary>
        ///     Tests that plot line s 32 ptr s 32 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S32PtrS32PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotLine("label", ref xs, ref xs, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line s 32 ptr s 32 ptr int flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S32PtrS32PtrIntFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags));
            });
        }

        /// <summary>
        ///     Tests that plot line s 32 ptr s 32 ptr int flags offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S32PtrS32PtrIntFlagsOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot line s 32 ptr s 32 ptr int flags offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S32PtrS32PtrIntFlagsOffsetStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line u 32 ptr u 32 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U32PtrU32PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotLine("label", ref xs, ref xs, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line u 32 ptr u 32 ptr int flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U32PtrU32PtrIntFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags));
            });
        }

        /// <summary>
        ///     Tests that plot line u 32 ptr u 32 ptr int flags offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U32PtrU32PtrIntFlagsOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot line u 32 ptr u 32 ptr int flags offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U32PtrU32PtrIntFlagsOffsetStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line s 64 ptr s 64 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S64PtrS64PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotLine("label", ref xs, ref xs, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line s 64 ptr s 64 ptr int flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S64PtrS64PtrIntFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags));
            });
        }

        /// <summary>
        ///     Tests that plot line s 64 ptr s 64 ptr int flags offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S64PtrS64PtrIntFlagsOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot line s 64 ptr s 64 ptr int flags offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_S64PtrS64PtrIntFlagsOffsetStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line u 64 ptr u 64 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U64PtrU64PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotLine("label", ref xs, ref xs, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line u 64 ptr u 64 ptr int flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U64PtrU64PtrIntFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags));
            });
        }

        /// <summary>
        ///     Tests that plot line u 64 ptr u 64 ptr int flags offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U64PtrU64PtrIntFlagsOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot line u 64 ptr u 64 ptr int flags offset stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLine_U64PtrU64PtrIntFlagsOffsetStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotLine("label", ref xs, ref xs, 0, default(ImPlotLineFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot line g int ptr int ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLineG_IntPtrIntPtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLineG("label", IntPtr.Zero, IntPtr.Zero, 0));
        }

        /// <summary>
        ///     Tests that plot line g int ptr int ptr int flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotLineG_IntPtrIntPtrIntFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotLineG("label", IntPtr.Zero, IntPtr.Zero, 0, default(ImPlotLineFlags)));
        }

        /// <summary>
        ///     Tests that plot pie chart float ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_FloatPtr_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new float[0], 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that plot pie chart float ptr label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_FloatPtrLabelFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new float[0], 0, 0, 0, 0, "labelFmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart float ptr label fmt angle 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_FloatPtrLabelFmtAngle0_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new float[0], 0, 0, 0, 0, "labelFmt", 0));
        }

        /// <summary>
        ///     Tests that plot pie chart float ptr label fmt angle 0 flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_FloatPtrLabelFmtAngle0Flags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new float[0], 0, 0, 0, 0, "labelFmt", 0, default(ImPlotPieChartFlags)));
        }

        /// <summary>
        ///     Tests that plot pie chart double ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_DoublePtr_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new double[0], 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that plot pie chart double ptr label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_DoublePtrLabelFmt_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new double[0], 0, 0, 0, 0, "labelFmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart double ptr label fmt angle 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_DoublePtrLabelFmtAngle0_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new double[0], 0, 0, 0, 0, "labelFmt", 0));
        }

        /// <summary>
        ///     Tests that plot pie chart double ptr label fmt angle 0 flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_DoublePtrLabelFmtAngle0Flags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new double[0], 0, 0, 0, 0, "labelFmt", 0, default(ImPlotPieChartFlags)));
        }

        /// <summary>
        ///     Tests that plot pie chart s 8 ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S8Ptr_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new sbyte[0], 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that plot pie chart s 8 ptr label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S8PtrLabelFmt_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new sbyte[0], 0, 0, 0, 0, "labelFmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart s 8 ptr label fmt angle 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S8PtrLabelFmtAngle0_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new sbyte[0], 0, 0, 0, 0, "labelFmt", 0));
        }

        /// <summary>
        ///     Tests that plot pie chart s 8 ptr label fmt angle 0 flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S8PtrLabelFmtAngle0Flags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new sbyte[0], 0, 0, 0, 0, "labelFmt", 0, default(ImPlotPieChartFlags)));
        }

        /// <summary>
        ///     Tests that plot pie chart u 8 ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_U8Ptr_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new byte[0], 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that plot pie chart u 8 ptr label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_U8PtrLabelFmt_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new byte[0], 0, 0, 0, 0, "labelFmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart u 8 ptr label fmt angle 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_U8PtrLabelFmtAngle0_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new byte[0], 0, 0, 0, 0, "labelFmt", 0));
        }

        /// <summary>
        ///     Tests that plot pie chart u 8 ptr label fmt angle 0 flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_U8PtrLabelFmtAngle0Flags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new byte[0], 0, 0, 0, 0, "labelFmt", 0, default(ImPlotPieChartFlags)));
        }

        /// <summary>
        ///     Tests that plot pie chart s 16 ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S16Ptr_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new short[0], 0, 0, 0, 0));
        }

        /// <summary>
        ///     Tests that plot pie chart s 16 ptr label fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S16PtrLabelFmt_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new short[0], 0, 0, 0, 0, "labelFmt"));
        }

        /// <summary>
        ///     Tests that plot pie chart s 16 ptr label fmt angle 0 throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S16PtrLabelFmtAngle0_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new short[0], 0, 0, 0, 0, "labelFmt", 0));
        }

        /// <summary>
        ///     Tests that plot pie chart s 16 ptr label fmt angle 0 flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_S16PtrLabelFmtAngle0Flags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new short[0], 0, 0, 0, 0, "labelFmt", 0, default(ImPlotPieChartFlags)));
        }

        /// <summary>
        ///     Tests that plot pie chart u 16 ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_U16Ptr_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new string[0], new ushort[0], 0, 0, 0, 0));
        }
    }
}