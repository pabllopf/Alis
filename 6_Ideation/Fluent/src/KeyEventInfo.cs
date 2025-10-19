using System;

namespace Alis.Core.Aspect.Fluent
{
    /// <summary>
    /// The key event info
    /// </summary>
    public struct KeyEventInfo
    {
        /// <summary>
        /// The key
        /// </summary>
        public ConsoleKey Key;
        /// <summary>
        /// The timestamp
        /// </summary>
        public DateTime Timestamp;
        /// <summary>
        /// The hold duration
        /// </summary>
        public TimeSpan HoldDuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEventInfo"/> class
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="timestamp">The timestamp</param>
        /// <param name="holdDuration">The hold duration</param>
        public KeyEventInfo(ConsoleKey key, DateTime timestamp, TimeSpan holdDuration)
        {
            Key = key;
            Timestamp = timestamp;
            HoldDuration = holdDuration;
        }
    }
}

