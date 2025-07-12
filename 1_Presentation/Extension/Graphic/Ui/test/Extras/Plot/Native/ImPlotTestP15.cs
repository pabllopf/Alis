// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP15.cs
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
    public class ImPlotTestP15
    {
        /// <summary>
        ///     Tests that plot bar groups u int 32 test
        /// </summary>
        [Fact]
        public void PlotBarGroups_UInt32_Test()
        {
            string[] labelIds = {"Label1", "Label2"};
            uint[] values = {1, 2};
            int itemCount = 2;
            int groupCount = 1;
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;

            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(labelIds, values, itemCount, groupCount, groupSize, shift, flags));
        }

        /// <summary>
        ///     Tests that plot bar groups int 64 test
        /// </summary>
        [Fact]
        public void PlotBarGroups_Int64_Test()
        {
            string[] labelIds = {"Label1", "Label2"};
            long[] values = {1, 2};
            int itemCount = 2;
            int groupCount = 1;
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;

            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(labelIds, values, itemCount, groupCount, groupSize, shift, flags));
        }

        /// <summary>
        ///     Tests that plot bar groups u int 64 test
        /// </summary>
        [Fact]
        public void PlotBarGroups_UInt64_Test()
        {
            string[] labelIds = {"Label1", "Label2"};
            ulong[] values = {1, 2};
            int itemCount = 2;
            int groupCount = 1;
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;

            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(labelIds, values, itemCount, groupCount, groupSize, shift, flags));
        }

        /// <summary>
        ///     Tests that plot bars float test
        /// </summary>
        [Fact]
        public void PlotBars_Float_Test()
        {
            string labelId = "Label1";
            float[] values = {1.0f, 2.0f};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, ref values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bars double test
        /// </summary>
        [Fact]
        public void PlotBars_Double_Test()
        {
            string labelId = "Label1";
            double[] values = {1.0, 2.0};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bars s byte test
        /// </summary>
        [Fact]
        public void PlotBars_SByte_Test()
        {
            string labelId = "Label1";
            sbyte[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bars byte test
        /// </summary>
        [Fact]
        public void PlotBars_Byte_Test()
        {
            string labelId = "Label1";
            byte[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bars int 16 test
        /// </summary>
        [Fact]
        public void PlotBars_Int16_Test()
        {
            string labelId = "Label1";
            short[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bars u int 16 test
        /// </summary>
        [Fact]
        public void PlotBars_UInt16_Test()
        {
            string labelId = "Label1";
            ushort[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bars int 32 test
        /// </summary>
        [Fact]
        public void PlotBars_Int32_Test()
        {
            string labelId = "Label1";
            int[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bars u int 32 test
        /// </summary>
        [Fact]
        public void PlotBars_UInt32_Test()
        {
            string labelId = "Label1";
            uint[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);

            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }

        /// <summary>
        ///     Tests that plot bar groups u int without shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_UInt_WithoutShift_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new uint[] {1}, 1, 1, 0.67));
        }

        /// <summary>
        ///     Tests that plot bar groups u int with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_UInt_WithShift_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new uint[] {1}, 1, 1, 0.67, 0.5));
        }

        /// <summary>
        ///     Tests that plot bar groups u int with shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_UInt_WithShiftAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new uint[] {1}, 1, 1, 0.67, 0.5, ImPlotBarGroupsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bar groups long without shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_Long_WithoutShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new long[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot bar groups long with group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_Long_WithGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new long[] {1}, 1, 1, 0.67));
        }

        /// <summary>
        ///     Tests that plot bar groups long with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_Long_WithShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new long[] {1}, 1, 1, 0.67, 0.5));
        }

        /// <summary>
        ///     Tests that plot bar groups long with shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_Long_WithShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new long[] {1}, 1, 1, 0.67, 0.5, ImPlotBarGroupsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bar groups u long without shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ULong_WithoutShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new ulong[] {1}, 1, 1));
        }

        /// <summary>
        ///     Tests that plot bar groups u long with group size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ULong_WithGroupSize_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new ulong[] {1}, 1, 1, 0.67));
        }

        /// <summary>
        ///     Tests that v 4 plot bar groups u long with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBarGroups_ULong_WithShift_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new ulong[] {1}, 1, 1, 0.67, 0.5));
        }

        /// <summary>
        ///     Tests that v 4 plot bar groups u long with shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBarGroups_ULong_WithShiftAndFlags_ThrowsMarshalDirectiveException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(new[] {"label1"}, new ulong[] {1}, 1, 1, 0.67, 0.5, ImPlotBarGroupsFlags.None));
        }

        /// <summary>
        ///     Tests that v 4 plot bars float without shift throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBars_Float_WithoutShift_ThrowsDllNotFoundException()
        {
            float[] values = {1.0f};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", ref values, 1));
        }

        /// <summary>
        ///     Tests that v 4 plot bars float with bar size throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBars_Float_WithBarSize_ThrowsDllNotFoundException()
        {
            float[] values = {1.0f};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", ref values, 1, 0.67));
        }

        /// <summary>
        ///     Tests that v 4 plot bars float with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBars_Float_WithShift_ThrowsDllNotFoundException()
        {
            float[] values = {1.0f};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", ref values, 1, 0.67, 0.5));
        }

        /// <summary>
        ///     Tests that v 4 plot bars float with shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBars_Float_WithShiftAndFlags_ThrowsDllNotFoundException()
        {
            float[] values = {1.0f};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", values, 1, 0.67, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that v 4 plot bars float with shift flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBars_Float_WithShiftFlagsAndOffset_ThrowsDllNotFoundException()
        {
            float[] values = {1.0f};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", ref values, 1, 0.67, 0.5, ImPlotBarsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that v 4 plot bars float with shift flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBars_Float_WithShiftFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            float[] values = {1.0f};
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", ref values, 1, 0.67, 0.5, ImPlotBarsFlags.None, 0, sizeof(float)));
        }

        /// <summary>
        ///     Tests that v 4 plot bars double without shift throws dll not found exception
        /// </summary>
        [Fact]
        public void v4_PlotBars_Double_WithoutShift_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new[] {1.0}, 1));
        }

        /// <summary>
        ///     Tests that plot bars double with bar size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithBarSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new[] {1.0}, 1, 0.67));
        }

        /// <summary>
        ///     Tests that plot bars double with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithShift_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new[] {1.0}, 1, 0.67, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars double with shift and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithShiftAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new[] {1.0}, 1, 0.67, 0.5, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars double with shift flags and offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithShiftFlagsAndOffset_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new[] {1.0}, 1, 0.67, 0.5, ImPlotBarsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot bars double with shift flags offset and stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithShiftFlagsOffsetAndStride_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new[] {1.0}, 1, 0.67, 0.5, ImPlotBarsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot bars s byte without shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByte_WithoutShift_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new sbyte[] {1}, 1));
        }

        /// <summary>
        ///     Tests that plot bars s byte with bar size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByte_WithBarSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new sbyte[] {1}, 1, 0.67));
        }

        /// <summary>
        ///     Tests that plot bars s byte with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByte_WithShift_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label1", new sbyte[] {1}, 1, 0.67, 0.5));
        }

        /// <summary>
        ///     Tests that plot bars float array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_FloatArray_ThrowsDllNotFoundException()
        {
            float[] values = new float[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref values, 0));
        }

        /// <summary>
        ///     Tests that plot bars float array with bar size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_FloatArray_WithBarSize_ThrowsDllNotFoundException()
        {
            float[] values = new float[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref values, 0, 0.67));
        }

        /// <summary>
        ///     Tests that plot bars float array with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_FloatArray_WithShift_ThrowsDllNotFoundException()
        {
            float[] values = new float[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref values, 0, 0.67, 0.0));
        }

        /// <summary>
        ///     Tests that plot bars float array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_FloatArray_WithFlags_ThrowsDllNotFoundException()
        {
            float[] values = new float[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars float array with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_FloatArray_WithOffset_ThrowsDllNotFoundException()
        {
            float[] values = new float[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref values, 0, 0.67, 0.0, ImPlotBarsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot bars float array with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_FloatArray_WithStride_ThrowsDllNotFoundException()
        {
            float[] values = new float[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref values, 0, 0.67, 0.0, ImPlotBarsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot bars double array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_DoubleArray_ThrowsDllNotFoundException()
        {
            double[] values = new double[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0));
        }

        /// <summary>
        ///     Tests that plot bars double array with bar size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_DoubleArray_WithBarSize_ThrowsDllNotFoundException()
        {
            double[] values = new double[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67));
        }

        /// <summary>
        ///     Tests that plot bars double array with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_DoubleArray_WithShift_ThrowsDllNotFoundException()
        {
            double[] values = new double[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0));
        }

        /// <summary>
        ///     Tests that plot bars double array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_DoubleArray_WithFlags_ThrowsDllNotFoundException()
        {
            double[] values = new double[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars double array with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_DoubleArray_WithOffset_ThrowsDllNotFoundException()
        {
            double[] values = new double[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot bars double array with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_DoubleArray_WithStride_ThrowsDllNotFoundException()
        {
            double[] values = new double[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot bars s byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByteArray_ThrowsDllNotFoundException()
        {
            sbyte[] values = new sbyte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0));
        }

        /// <summary>
        ///     Tests that plot bars s byte array with bar size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByteArray_WithBarSize_ThrowsDllNotFoundException()
        {
            sbyte[] values = new sbyte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67));
        }

        /// <summary>
        ///     Tests that plot bars s byte array with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByteArray_WithShift_ThrowsDllNotFoundException()
        {
            sbyte[] values = new sbyte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0));
        }

        /// <summary>
        ///     Tests that plot bars s byte array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByteArray_WithFlags_ThrowsDllNotFoundException()
        {
            sbyte[] values = new sbyte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars s byte array with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByteArray_WithOffset_ThrowsDllNotFoundException()
        {
            sbyte[] values = new sbyte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot bars s byte array with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_SByteArray_WithStride_ThrowsDllNotFoundException()
        {
            sbyte[] values = new sbyte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot bars byte array throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_ByteArray_ThrowsDllNotFoundException()
        {
            byte[] values = new byte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0));
        }

        /// <summary>
        ///     Tests that plot bars byte array with bar size throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_ByteArray_WithBarSize_ThrowsDllNotFoundException()
        {
            byte[] values = new byte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67));
        }

        /// <summary>
        ///     Tests that plot bars byte array with shift throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_ByteArray_WithShift_ThrowsDllNotFoundException()
        {
            byte[] values = new byte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0));
        }

        /// <summary>
        ///     Tests that plot bars byte array with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_ByteArray_WithFlags_ThrowsDllNotFoundException()
        {
            byte[] values = new byte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars byte array with offset throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_ByteArray_WithOffset_ThrowsDllNotFoundException()
        {
            byte[] values = new byte[0];
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", values, 0, 0.67, 0.0, ImPlotBarsFlags.None, 0));
        }
    }
}