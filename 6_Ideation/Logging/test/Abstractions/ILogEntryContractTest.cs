

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Contract tests for ILogEntry behavior through LogEntry implementation.
    /// </summary>
    public class ILogEntryContractTest
    {
        /// <summary>
        ///     Tests that log entry exposes all contract members with provided values.
        /// </summary>
        [Fact]
        public void LogEntry_ExposesContractValues()
        {
            InvalidOperationException exception = new InvalidOperationException("boom");
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                ["entityId"] = 10,
                ["isCritical"] = true
            };
            List<object> scopes = new List<object> {"Frame:124", "RenderSystem"};

            ILogEntry entry = new LogEntry(
                LogLevel.Error,
                "Render failed",
                "Game.Render",
                exception,
                "corr-123",
                properties,
                scopes);

            Assert.Equal(LogLevel.Error, entry.Level);
            Assert.Equal("Render failed", entry.Message);
            Assert.Equal("Game.Render", entry.LoggerName);
            Assert.Same(exception, entry.Exception);
            Assert.Equal("corr-123", entry.CorrelationId);
            Assert.Equal(2, entry.Properties.Count);
            Assert.Equal(2, entry.Scopes.Count);
            Assert.True(entry.ThreadId > 0);
            Assert.True(entry.Timestamp <= DateTime.UtcNow);
        }
    }
}
