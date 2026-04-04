// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfileSnapshotComprehensiveTest.cs
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
    ///     Comprehensive unit tests for ProfileSnapshot struct.
    ///     Tests all public members including constructors, properties, delta calculations,
    ///     equality operators, and edge cases for complete code coverage.
    /// </summary>
    public class ProfileSnapshotComprehensiveTest
    {
        /// <summary>
        ///     Tests that constructor successfully initializes with valid parameters.
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithValidParameters()
        {
            // Arrange
            TimeSpan elapsedTime = TimeSpan.FromMilliseconds(100);
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, startTime);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, endTime);

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(elapsedTime, startMetrics, endMetrics, startTime, endTime);

            // Assert
            Assert.Equal(elapsedTime, snapshot.ElapsedTime);
            Assert.Equal(startMetrics, snapshot.StartMetrics);
            Assert.Equal(endMetrics, snapshot.EndMetrics);
            Assert.Equal(startTime, snapshot.StartTime);
            Assert.Equal(endTime, snapshot.EndTime);
        }

        /// <summary>
        ///     Tests that constructor throws exception when elapsed time is negative.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentException_WhenElapsedTimeIsNegative()
        {
            // Arrange
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddSeconds(1);
            ResourceMetrics startMetrics = ResourceMetrics.Empty;
            ResourceMetrics endMetrics = ResourceMetrics.Empty;

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                new ProfileSnapshot(TimeSpan.FromMilliseconds(-1), startMetrics, endMetrics, startTime, endTime));

            Assert.Contains("Elapsed time cannot be negative", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor throws exception when end time is before start time.
        /// </summary>
        [Fact]
        public void Constructor_ThrowsArgumentException_WhenEndTimeIsBeforeStartTime()
        {
            // Arrange
            TimeSpan elapsedTime = TimeSpan.FromMilliseconds(100);
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddSeconds(-1);
            ResourceMetrics startMetrics = ResourceMetrics.Empty;
            ResourceMetrics endMetrics = ResourceMetrics.Empty;

            // Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
                new ProfileSnapshot(elapsedTime, startMetrics, endMetrics, startTime, endTime));

            Assert.Contains("End time cannot be before start time", ex.Message);
        }

        /// <summary>
        ///     Tests that constructor accepts zero elapsed time.
        /// </summary>
        [Fact]
        public void Constructor_AcceptsZeroElapsedTime()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = ResourceMetrics.Empty;
            ResourceMetrics endMetrics = ResourceMetrics.Empty;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(TimeSpan.Zero, startMetrics, endMetrics, now, now);

            // Assert
            Assert.Equal(TimeSpan.Zero, snapshot.ElapsedTime);
        }

        /// <summary>
        ///     Tests that Empty property returns a snapshot with default values.
        /// </summary>
        [Fact]
        public void Empty_ReturnsSnapshotWithDefaultValues()
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
        ///     Tests that CpuUsageDelta is calculated correctly.
        /// </summary>
        [Fact]
        public void CpuUsageDelta_CalculatesCorrectly()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(50, 0, 0, 0, now);
            ResourceMetrics endMetrics = new ResourceMetrics(150, 0, 0, 0, now);
            ProfileSnapshot snapshot = new ProfileSnapshot(TimeSpan.FromMilliseconds(100), startMetrics, endMetrics, now, now);

            // Act
            double cpuDelta = snapshot.CpuUsageDelta;

            // Assert
            Assert.Equal(100, cpuDelta);
        }

        /// <summary>
        ///     Tests that MemoryUsageDelta is calculated correctly.
        /// </summary>
        [Fact]
        public void MemoryUsageDelta_CalculatesCorrectly()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(0, 1000000, 0, 0, now);
            ResourceMetrics endMetrics = new ResourceMetrics(0, 2000000, 0, 0, now);
            ProfileSnapshot snapshot = new ProfileSnapshot(TimeSpan.FromMilliseconds(100), startMetrics, endMetrics, now, now);

            // Act
            long memoryDelta = snapshot.MemoryUsageDelta;

            // Assert
            Assert.Equal(1000000, memoryDelta);
        }

        /// <summary>
        ///     Tests that GarbageCollectionsDuringProfiling is calculated correctly.
        /// </summary>
        [Fact]
        public void GarbageCollectionsDuringProfiling_CalculatesCorrectly()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(0, 0, 5, 0, now);
            ResourceMetrics endMetrics = new ResourceMetrics(0, 0, 12, 0, now);
            ProfileSnapshot snapshot = new ProfileSnapshot(TimeSpan.FromMilliseconds(100), startMetrics, endMetrics, now, now);

            // Act
            int gcDelta = snapshot.GarbageCollectionsDuringProfiling;

            // Assert
            Assert.Equal(7, gcDelta);
        }

        /// <summary>
        ///     Tests that delta calculations handle negative deltas (e.g., memory decrease).
        /// </summary>
        [Fact]
        public void DeltaCalculations_HandleNegativeDeltas()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(100, 2000000, 10, 0, now);
            ResourceMetrics endMetrics = new ResourceMetrics(50, 1000000, 5, 0, now);
            ProfileSnapshot snapshot = new ProfileSnapshot(TimeSpan.FromMilliseconds(100), startMetrics, endMetrics, now, now);

            // Act
            double cpuDelta = snapshot.CpuUsageDelta;
            long memoryDelta = snapshot.MemoryUsageDelta;
            int gcDelta = snapshot.GarbageCollectionsDuringProfiling;

            // Assert
            Assert.Equal(-50, cpuDelta);
            Assert.Equal(-1000000, memoryDelta);
            Assert.Equal(-5, gcDelta);
        }

        /// <summary>
        ///     Tests that Equals method returns true for identical snapshots.
        /// </summary>
        [Fact]
        public void Equals_ReturnsTrueForIdenticalSnapshots()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Act & Assert
            Assert.True(snapshot1.Equals(snapshot2));
        }

        /// <summary>
        ///     Tests that Equals method returns false for different snapshots.
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalseForDifferentSnapshots()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed1 = TimeSpan.FromMilliseconds(100);
            TimeSpan elapsed2 = TimeSpan.FromMilliseconds(200);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed1, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed2, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Act & Assert
            Assert.False(snapshot1.Equals(snapshot2));
        }

        /// <summary>
        ///     Tests that Equals with object returns true for identical snapshots.
        /// </summary>
        [Fact]
        public void EqualsObject_ReturnsTrueForIdenticalSnapshots()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            object snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Act & Assert
            Assert.True(snapshot1.Equals(snapshot2));
        }

        /// <summary>
        ///     Tests that Equals with object returns false for non-ProfileSnapshot.
        /// </summary>
        [Fact]
        public void EqualsObject_ReturnsFalseForNonProfileSnapshot()
        {
            // Arrange
            ProfileSnapshot snapshot = ProfileSnapshot.Empty;

            // Act & Assert
            Assert.False(snapshot.Equals((object)"not a snapshot"));
        }

        /// <summary>
        ///     Tests that GetHashCode returns consistent values for identical snapshots.
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsSameValueForIdenticalSnapshots()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Act
            int hash1 = snapshot1.GetHashCode();
            int hash2 = snapshot2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that equality operator returns true for identical snapshots.
        /// </summary>
        [Fact]
        public void EqualityOperator_ReturnsTrueForIdenticalSnapshots()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Act & Assert
            Assert.True(snapshot1 == snapshot2);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different snapshots.
        /// </summary>
        [Fact]
        public void InequalityOperator_ReturnsTrueForDifferentSnapshots()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed1 = TimeSpan.FromMilliseconds(100);
            TimeSpan elapsed2 = TimeSpan.FromMilliseconds(200);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed1, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed2, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Act & Assert
            Assert.True(snapshot1 != snapshot2);
        }

        /// <summary>
        ///     Tests that ToString returns formatted string with snapshot information.
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            // Arrange
            DateTime startTime = new DateTime(2026, 4, 4, 12, 30, 45, 123);
            DateTime endTime = new DateTime(2026, 4, 4, 12, 30, 46, 123);
            TimeSpan elapsed = endTime - startTime;
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, startTime);
            ResourceMetrics endMetrics = new ResourceMetrics(150, 2000000, 10, 15, endTime);

            ProfileSnapshot snapshot = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);

            // Act
            string result = snapshot.ToString();

            // Assert
            Assert.Contains("ProfileSnapshot", result);
            Assert.Contains("Elapsed", result);
            Assert.Contains("CPU Delta", result);
            Assert.Contains("Memory Delta", result);
            Assert.Contains("GC During Session", result);
        }

        /// <summary>
        ///     Tests that all properties are read-only.
        /// </summary>
        [Fact]
        public void Properties_AreReadOnly()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            ProfileSnapshot snapshot = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Act - Properties should be readable
            TimeSpan readElapsed = snapshot.ElapsedTime;
            ResourceMetrics readStart = snapshot.StartMetrics;
            ResourceMetrics readEnd = snapshot.EndMetrics;
            DateTime readStartTime = snapshot.StartTime;
            DateTime readEndTime = snapshot.EndTime;

            // Assert
            Assert.Equal(elapsed, readElapsed);
            Assert.Equal(startMetrics, readStart);
            Assert.Equal(endMetrics, readEnd);
            Assert.Equal(now, readStartTime);
            Assert.Equal(now.AddMilliseconds(100), readEndTime);
        }

        /// <summary>
        ///     Tests that delta properties work with large values.
        /// </summary>
        [Fact]
        public void DeltaProperties_WorkWithLargeValues()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ResourceMetrics startMetrics = new ResourceMetrics(0, 0, 0, 0, now);
            ResourceMetrics endMetrics = new ResourceMetrics(double.MaxValue, long.MaxValue, int.MaxValue, 0, now);

            ProfileSnapshot snapshot = new ProfileSnapshot(TimeSpan.MaxValue, startMetrics, endMetrics, now, now);

            // Act
            double cpuDelta = snapshot.CpuUsageDelta;
            long memoryDelta = snapshot.MemoryUsageDelta;
            int gcDelta = snapshot.GarbageCollectionsDuringProfiling;

            // Assert
            Assert.Equal(double.MaxValue, cpuDelta);
            Assert.Equal(long.MaxValue, memoryDelta);
            Assert.Equal(int.MaxValue, gcDelta);
        }

        /// <summary>
        ///     Tests that constructor with same start and end times is valid.
        /// </summary>
        [Fact]
        public void Constructor_AcceptsSameStartAndEndTime()
        {
            // Arrange
            DateTime now = DateTime.Now;
            ResourceMetrics metrics = ResourceMetrics.Empty;

            // Act
            ProfileSnapshot snapshot = new ProfileSnapshot(TimeSpan.Zero, metrics, metrics, now, now);

            // Assert
            Assert.Equal(now, snapshot.StartTime);
            Assert.Equal(now, snapshot.EndTime);
            Assert.Equal(TimeSpan.Zero, snapshot.ElapsedTime);
        }

        /// <summary>
        ///     Tests that multiple snapshots with same data are equal.
        /// </summary>
        [Fact]
        public void MultipleSnapshots_WithSameData_AreEqual()
        {
            // Arrange
            DateTime now = DateTime.Now;
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics startMetrics = new ResourceMetrics(50, 1000000, 5, 10, now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 2000000, 10, 15, now.AddMilliseconds(100));

            // Act
            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));
            ProfileSnapshot snapshot3 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, now, now.AddMilliseconds(100));

            // Assert
            Assert.Equal(snapshot1, snapshot2);
            Assert.Equal(snapshot2, snapshot3);
            Assert.Equal(snapshot1, snapshot3);
        }
    }
}

