// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfileSnapshotTest.cs
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
using Alis.Extension.Profile.Models;
using Xunit;

namespace Alis.Extension.Profile.Test.Models
{
    /// <summary>
    ///     The profile snapshot test class
    /// </summary>
    public class ProfileSnapshotTest
    {
        /// <summary>
        ///     Tests that constructor initializes all properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesAllProperties_Correctly()
        {
            // Arrange
            TimeSpan expectedElapsed = TimeSpan.FromMilliseconds(500);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, DateTime.Now);
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(
                expectedElapsed,
                startMetrics,
                endMetrics,
                startTime,
                endTime);

            // Assert
            Assert.Equal(expectedElapsed, snapshot.ElapsedTime);
            Assert.Equal(startMetrics, snapshot.StartMetrics);
            Assert.Equal(endMetrics, snapshot.EndMetrics);
            Assert.Equal(startTime, snapshot.StartTime);
            Assert.Equal(endTime, snapshot.EndTime);
        }

        /// <summary>
        ///     Tests that constructor throws exception when elapsed time is negative
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenElapsedTimeIsNegative()
        {
            // Arrange
            TimeSpan negativeTime = TimeSpan.FromMilliseconds(-100);
            ResourceMetrics metrics = ResourceMetrics.Empty;
            DateTime now = DateTime.Now;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new ProfileSnapshot(negativeTime, metrics, metrics, now, now));
        }

        /// <summary>
        ///     Tests that constructor throws exception when end time is before start time
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenEndTimeIsBeforeStartTime()
        {
            // Arrange
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics metrics = ResourceMetrics.Empty;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(-1); // End before start

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new ProfileSnapshot(elapsed, metrics, metrics, startTime, endTime));
        }

        /// <summary>
        ///     Tests that cpu usage delta calculates correctly
        /// </summary>
        [Fact]
        public void CpuUsageDelta_CalculatesCorrectly()
        {
            // Arrange
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(250, 2048, 7, 3, DateTime.Now);
            DateTime now = DateTime.Now;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            // Assert
            Assert.Equal(150, snapshot.CpuUsageDelta);
        }

        /// <summary>
        ///     Tests that memory usage delta calculates correctly
        /// </summary>
        [Fact]
        public void MemoryUsageDelta_CalculatesCorrectly()
        {
            // Arrange
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 3072, 5, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            // Assert
            Assert.Equal(2048, snapshot.MemoryUsageDelta);
        }

        /// <summary>
        ///     Tests that garbage collections during profiling calculates correctly
        /// </summary>
        [Fact]
        public void GarbageCollectionsDuringProfiling_CalculatesCorrectly()
        {
            // Arrange
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 1024, 12, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            // Assert
            Assert.Equal(7, snapshot.GarbageCollectionsDuringProfiling);
        }

        /// <summary>
        ///     Tests that empty returns snapshot with default values
        /// </summary>
        [Fact]
        public void Empty_ReturnsSnapshot_WithDefaultValues()
        {
            // Act
            ProfileSnapshot empty = ProfileSnapshot.Empty;

            // Assert
            Assert.Equal(TimeSpan.Zero, empty.ElapsedTime);
            Assert.Equal(ResourceMetrics.Empty, empty.StartMetrics);
            Assert.Equal(ResourceMetrics.Empty, empty.EndMetrics);
            Assert.Equal(DateTime.MinValue, empty.StartTime);
            Assert.Equal(DateTime.MinValue, empty.EndTime);
        }

        /// <summary>
        ///     Tests that equals returns true for identical snapshots
        /// </summary>
        [Fact]
        public void Equals_ReturnsTrue_ForIdenticalSnapshots()
        {
            // Arrange
            TimeSpan elapsed = TimeSpan.FromMilliseconds(500);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, DateTime.Now);
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);

            // Act & Assert
            Assert.True(snapshot1.Equals(snapshot2));
            Assert.True(snapshot1 == snapshot2);
            Assert.False(snapshot1 != snapshot2);
        }

        /// <summary>
        ///     Tests that equals returns false for different snapshots
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_ForDifferentSnapshots()
        {
            // Arrange
            ResourceMetrics metrics = ResourceMetrics.Empty;
            DateTime now = DateTime.Now;

            ProfileSnapshot snapshot1 = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100), metrics, metrics, now, now);
            ProfileSnapshot snapshot2 = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(200), metrics, metrics, now, now);

            // Act & Assert
            Assert.False(snapshot1.Equals(snapshot2));
            Assert.False(snapshot1 == snapshot2);
            Assert.True(snapshot1 != snapshot2);
        }

        /// <summary>
        ///     Tests that get hash code returns same value for identical snapshots
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameValue_ForIdenticalSnapshots()
        {
            // Arrange
            TimeSpan elapsed = TimeSpan.FromMilliseconds(500);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, DateTime.Now);
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);

            // Act & Assert
            Assert.Equal(snapshot1.GetHashCode(), snapshot2.GetHashCode());
        }

        /// <summary>
        ///     Tests that to string returns formatted string
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            // Arrange
            DateTime startTime = new DateTime(2026, 2, 25, 10, 30, 45, 0);
            DateTime endTime = startTime.AddMilliseconds(500);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, startTime);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, endTime);

            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(500),
                startMetrics,
                endMetrics,
                startTime,
                endTime);

            // Act
            string result = snapshot.ToString();

            // Assert
            Assert.Contains("500", result);
            Assert.Contains("ProfileSnapshot", result);
        }

        /// <summary>
        ///     Tests that equals returns false when comparing with null
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenComparingWithNull()
        {
            // Arrange
            ProfileSnapshot snapshot = ProfileSnapshot.Empty;

            // Act & Assert
            Assert.False(snapshot.Equals(null));
        }

        /// <summary>
        ///     Tests that cpu usage delta can be negative
        /// </summary>
        [Fact]
        public void CpuUsageDelta_CanBeNegative_WhenEndIsLessThanStart()
        {
            // Arrange
            ResourceMetrics startMetrics = new ResourceMetrics(200, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            // Assert
            Assert.Equal(-100, snapshot.CpuUsageDelta);
        }

        /// <summary>
        ///     Tests that memory usage delta can be negative
        /// </summary>
        [Fact]
        public void MemoryUsageDelta_CanBeNegative_WhenEndIsLessThanStart()
        {
            // Arrange
            ResourceMetrics startMetrics = new ResourceMetrics(100, 3072, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            // Assert
            Assert.Equal(-2048, snapshot.MemoryUsageDelta);
        }
    }
}

