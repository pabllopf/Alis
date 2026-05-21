

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
            TimeSpan expectedElapsed = TimeSpan.FromMilliseconds(500);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, DateTime.Now);
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;

            ProfileSnapshot snapshot = new ProfileSnapshot(
                expectedElapsed,
                startMetrics,
                endMetrics,
                startTime,
                endTime);

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
            TimeSpan negativeTime = TimeSpan.FromMilliseconds(-100);
            ResourceMetrics metrics = ResourceMetrics.Empty;
            DateTime now = DateTime.Now;

            Assert.Throws<ArgumentException>(() =>
                new ProfileSnapshot(negativeTime, metrics, metrics, now, now));
        }

        /// <summary>
        ///     Tests that constructor throws exception when end time is before start time
        /// </summary>
        [Fact]
        public void Constructor_ThrowsException_WhenEndTimeIsBeforeStartTime()
        {
            TimeSpan elapsed = TimeSpan.FromMilliseconds(100);
            ResourceMetrics metrics = ResourceMetrics.Empty;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(-1); // End before start

            Assert.Throws<ArgumentException>(() =>
                new ProfileSnapshot(elapsed, metrics, metrics, startTime, endTime));
        }

        /// <summary>
        ///     Tests that cpu usage delta calculates correctly
        /// </summary>
        [Fact]
        public void CpuUsageDelta_CalculatesCorrectly()
        {
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(250, 2048, 7, 3, DateTime.Now);
            DateTime now = DateTime.Now;

            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            Assert.Equal(150, snapshot.CpuUsageDelta);
        }

        /// <summary>
        ///     Tests that memory usage delta calculates correctly
        /// </summary>
        [Fact]
        public void MemoryUsageDelta_CalculatesCorrectly()
        {
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 3072, 5, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            Assert.Equal(2048, snapshot.MemoryUsageDelta);
        }

        /// <summary>
        ///     Tests that garbage collections during profiling calculates correctly
        /// </summary>
        [Fact]
        public void GarbageCollectionsDuringProfiling_CalculatesCorrectly()
        {
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 1024, 12, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            Assert.Equal(7, snapshot.GarbageCollectionsDuringProfiling);
        }

        /// <summary>
        ///     Tests that empty returns snapshot with default values
        /// </summary>
        [Fact]
        public void Empty_ReturnsSnapshot_WithDefaultValues()
        {
            ProfileSnapshot empty = ProfileSnapshot.Empty;

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
            TimeSpan elapsed = TimeSpan.FromMilliseconds(500);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, DateTime.Now);
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);

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
            ResourceMetrics metrics = ResourceMetrics.Empty;
            DateTime now = DateTime.Now;

            ProfileSnapshot snapshot1 = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100), metrics, metrics, now, now);
            ProfileSnapshot snapshot2 = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(200), metrics, metrics, now, now);

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
            TimeSpan elapsed = TimeSpan.FromMilliseconds(500);
            ResourceMetrics startMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(200, 2048, 7, 3, DateTime.Now);
            DateTime startTime = DateTime.Now.AddSeconds(-1);
            DateTime endTime = DateTime.Now;

            ProfileSnapshot snapshot1 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);
            ProfileSnapshot snapshot2 = new ProfileSnapshot(elapsed, startMetrics, endMetrics, startTime, endTime);

            Assert.Equal(snapshot1.GetHashCode(), snapshot2.GetHashCode());
        }

        /// <summary>
        ///     Tests that to string returns formatted string
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
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

            string result = snapshot.ToString();

            Assert.Contains("500", result);
            Assert.Contains("ProfileSnapshot", result);
        }

        /// <summary>
        ///     Tests that equals returns false when comparing with null
        /// </summary>
        [Fact]
        public void Equals_ReturnsFalse_WhenComparingWithNull()
        {
            ProfileSnapshot snapshot = ProfileSnapshot.Empty;

            Assert.False(snapshot.Equals(null));
        }

        /// <summary>
        ///     Tests that cpu usage delta can be negative
        /// </summary>
        [Fact]
        public void CpuUsageDelta_CanBeNegative_WhenEndIsLessThanStart()
        {
            ResourceMetrics startMetrics = new ResourceMetrics(200, 1024, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            Assert.Equal(-100, snapshot.CpuUsageDelta);
        }

        /// <summary>
        ///     Tests that memory usage delta can be negative
        /// </summary>
        [Fact]
        public void MemoryUsageDelta_CanBeNegative_WhenEndIsLessThanStart()
        {
            ResourceMetrics startMetrics = new ResourceMetrics(100, 3072, 5, 2, DateTime.Now);
            ResourceMetrics endMetrics = new ResourceMetrics(100, 1024, 5, 2, DateTime.Now);
            DateTime now = DateTime.Now;

            ProfileSnapshot snapshot = new ProfileSnapshot(
                TimeSpan.FromMilliseconds(100),
                startMetrics,
                endMetrics,
                now,
                now);

            Assert.Equal(-2048, snapshot.MemoryUsageDelta);
        }
    }
}