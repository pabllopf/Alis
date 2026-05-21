

using System;

namespace Alis.Core.Aspect.Fluent
{
    /// <summary>
    ///     Value type holding metadata about a keyboard event, including which key was pressed or released,
    ///     when the event occurred, and how long the key was held down.
    /// </summary>
    public struct KeyEventInfo
    {
        /// <summary>
        ///     The console key associated with this event.
        /// </summary>
        public readonly ConsoleKey Key;

        /// <summary>
        ///     The UTC timestamp when the keyboard event occurred.
        /// </summary>
        public readonly DateTime Timestamp;

        /// <summary>
        ///     The duration the key was held down, measured from press to release.
        ///     Zero <see cref="TimeSpan" /> if the key was simply pressed or released without a hold.
        /// </summary>
        public readonly TimeSpan HoldDuration;

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyEventInfo" /> struct.
        /// </summary>
        /// <param name="key">The console key associated with the event.</param>
        /// <param name="timestamp">The UTC timestamp when the event occurred.</param>
        /// <param name="holdDuration">The duration the key was held down.</param>
        public KeyEventInfo(ConsoleKey key, DateTime timestamp, TimeSpan holdDuration)
        {
            Key = key;
            Timestamp = timestamp;
            HoldDuration = holdDuration;
        }
    }
}