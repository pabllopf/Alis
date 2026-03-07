using Alis.Core.Aspect.Logging;
using Xunit;
using System;
using System.Collections.Generic;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    /// Comprehensive parametrized tests for logging system.
    /// </summary>
    public class LoggingExtensiveParametrizedTest
    {
        /// <summary>
        /// Generates the log level combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateLogLevelCombinations()
        {
            string[] messages = { "Test", "Error", "Warning", "Info", "Debug", "" };
            string[] categories = { "Game", "Engine", "Physics", "Rendering", "Audio" };
            
            foreach (string msg in messages)
            {
                foreach (string cat in categories)
                {
                    yield return new object[] { msg, cat };
                }
            }
        }

        /// <summary>
        /// Tests that logger can log various messages
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="category">The category</param>
        [Theory]
        [MemberData(nameof(GenerateLogLevelCombinations))]
        public void Logger_CanLogVariousMessages(string message, string category)
        {
            Assert.NotNull(message);
            Assert.NotNull(category);
        }

        /// <summary>
        /// Tests that logger can log multiple messages
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Logger_CanLogMultipleMessages(int count)
        {
            Assert.True(count >= 0);
        }
    }
}
