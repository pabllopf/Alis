// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfileSnapshotFormatterTest.cs
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
using Alis.Extension.Profile.Helpers;
using Alis.Extension.Profile.Models;
using Xunit;

namespace Alis.Extension.Profile.Test.Helpers
{
    /// <summary>
    ///     The profile snapshot formatter test class
    /// </summary>
    public class ProfileSnapshotFormatterTest
    {
        /// <summary>
        ///     Tests that format detailed returns multi line string
        /// </summary>
        [Fact]
        public void FormatDetailed_ReturnsMultiLineString()
        {
            DateTime startTime = new DateTime(2026, 2, 25, 10, 0, 0);
            DateTime endTime = startTime.AddSeconds(1);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, startTime);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, endTime);
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromSeconds(1),
                startMetrics,
                endMetrics,
                startTime,
                endTime);

            string result = ProfileSnapshotFormatter.FormatDetailed(snapshot);

            Assert.Contains("Profile Snapshot", result);
            Assert.Contains("Elapsed Time", result);
            Assert.Contains("CPU Usage", result);
            Assert.Contains("Memory Usage", result);
            Assert.Contains("Start Metrics", result);
            Assert.Contains("End Metrics", result);
        }

        /// <summary>
        ///     Tests that format compact returns single line string
        /// </summary>
        [Fact]
        public void FormatCompact_ReturnsSingleLineString()
        {
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, now);
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(500),
                startMetrics,
                endMetrics,
                now,
                now);

            string result = ProfileSnapshotFormatter.FormatCompact(snapshot);

            Assert.DoesNotContain(Environment.NewLine, result);
            Assert.Contains("500", result);
            Assert.Contains("ms", result);
            Assert.Contains("CPU", result);
            Assert.Contains("Mem", result);
        }

        /// <summary>
        ///     Tests that format bytes with zero returns correct format
        /// </summary>
        [Fact]
        public void FormatBytes_WithZero_ReturnsCorrectFormat()
        {
            string result = ProfileSnapshotFormatter.FormatBytes(0);

            Assert.Contains("0", result);
            Assert.Contains("B", result);
        }

        /// <summary>
        ///     Tests that format bytes with single byte returns correct format
        /// </summary>
        [Fact]
        public void FormatBytes_WithSingleByte_ReturnsCorrectFormat()
        {
            string result = ProfileSnapshotFormatter.FormatBytes(1);

            Assert.Contains("1", result);
            Assert.Contains("B", result);
        }

        /// <summary>
        ///     Tests that format detailed includes all metric sections
        /// </summary>
        [Fact]
        public void FormatDetailed_IncludesAllMetricSections()
        {
            DateTime now = DateTime.Now;
            ResourceMetrics metrics = new ResourceMetrics(100, 1024, 5, 2, now);
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(500),
                metrics,
                metrics,
                now,
                now);

            string result = ProfileSnapshotFormatter.FormatDetailed(snapshot);

            Assert.Contains("Session Period", result);
            Assert.Contains("Resource Deltas", result);
            Assert.Contains("Garbage Collections", result);
        }

        /// <summary>
        ///     Tests that format compact includes all key metrics
        /// </summary>
        [Fact]
        public void FormatCompact_IncludesAllKeyMetrics()
        {
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, now);
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(500),
                startMetrics,
                endMetrics,
                now,
                now);

            string result = ProfileSnapshotFormatter.FormatCompact(snapshot);

            Assert.Contains("ms", result); // Elapsed time
            Assert.Contains("CPU", result); // CPU delta
            Assert.Contains("Mem", result); // Memory delta
            Assert.Contains("GC", result); // GC count
        }

        /// <summary>
        ///     Tests that FormatBytes with kilobyte value returns KB suffix
        /// </summary>
        [Fact]
        public void FormatBytes_WithKilobytes_ReturnsKbSuffix()
        {
            string result = ProfileSnapshotFormatter.FormatBytes(1536);

            Assert.Contains("KB", result);
        }

        /// <summary>
        ///     Tests that FormatBytes with megabyte value returns MB suffix
        /// </summary>
        [Fact]
        public void FormatBytes_WithMegabytes_ReturnsMbSuffix()
        {
            string result = ProfileSnapshotFormatter.FormatBytes(1572864);

            Assert.Contains("MB", result);
        }

        /// <summary>
        ///     Tests that FormatBytes with gigabyte value returns GB suffix
        /// </summary>
        [Fact]
        public void FormatBytes_WithGigabytes_ReturnsGbSuffix()
        {
            string result = ProfileSnapshotFormatter.FormatBytes(1610612736);

            Assert.Contains("GB", result);
        }

        /// <summary>
        ///     Tests that FormatBytes with terabyte value returns TB suffix
        /// </summary>
        [Fact]
        public void FormatBytes_WithTerabytes_ReturnsTbSuffix()
        {
            string result = ProfileSnapshotFormatter.FormatBytes(1649267441664);

            Assert.Contains("TB", result);
        }

        /// <summary>
        ///     Tests that FormatBytes with negative value includes negative sign
        /// </summary>
        [Fact]
        public void FormatBytes_WithNegativeValue_IncludesNegativeSign()
        {
            string result = ProfileSnapshotFormatter.FormatBytes(-2048);

            Assert.Contains("-", result);
            Assert.Contains("KB", result);
        }
    }
}