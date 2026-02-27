using Xunit;
using System;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     Unit tests for the KeyEventInfo struct.
    ///     Covers construction, field assignment, and edge cases.
    /// </summary>
    public class KeyEventInfoTest
    {
        /// <summary>
        ///     Tests that the struct is constructed with the correct values.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFieldsCorrectly()
        {
            ConsoleKey key = ConsoleKey.A;
            DateTime timestamp = DateTime.UtcNow;
            TimeSpan duration = TimeSpan.FromSeconds(2);
            KeyEventInfo info = new Alis.Core.Aspect.Fluent.KeyEventInfo(key, timestamp, duration);
            Assert.Equal(key, info.Key);
            Assert.Equal(timestamp, info.Timestamp);
            Assert.Equal(duration, info.HoldDuration);
        }

        /// <summary>
        ///     Tests edge cases for the struct fields.
        /// </summary>
        [Fact]
        public void Constructor_AllowsExtremeValues()
        {
            KeyEventInfo info = new Alis.Core.Aspect.Fluent.KeyEventInfo(ConsoleKey.Z, DateTime.MinValue, TimeSpan.Zero);
            Assert.Equal(ConsoleKey.Z, info.Key);
            Assert.Equal(DateTime.MinValue, info.Timestamp);
            Assert.Equal(TimeSpan.Zero, info.HoldDuration);
        }
    }
}
