// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP2NullItemCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     The im plot p2 null item coverage tests class
    /// </summary>
    public class ImPlotP2NullItemCoverageTests
    {
        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_0_NullItem_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_1_NullItem_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_2_NullItem_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_3_NullItem_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_0_NullItem_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_1_NullItem_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_2_NullItem_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_3_NullItem_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_0_NullItem_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_1_NullItem_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_2_NullItem_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_3_NullItem_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_0_NullItem_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_1_NullItem_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_2_NullItem_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_3_NullItem_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_0_NullItem_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_1_NullItem_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_2_NullItem_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_3_NullItem_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_0_NullItem_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_1_NullItem_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_2_NullItem_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_3_NullItem_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_0_NullItem_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_1_NullItem_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_2_NullItem_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     plots the bar groups null item should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_3_NullItem_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     gets the colormap index null name should throw argument null exception
        /// </summary>
        [Fact]
        public void GetColormapIndex_NullName_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.GetColormapIndex(null)));
        }

        /// <summary>
        ///     shows whether the legend entry is hovered null label should throw argument null exception
        /// </summary>
        [Fact]
        public void IsLegendEntryHovered_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.IsLegendEntryHovered(null)));
        }

    }
}
