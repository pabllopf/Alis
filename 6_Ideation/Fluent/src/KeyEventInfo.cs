using System;

namespace Alis.Core.Aspect.Fluent
{
    public struct KeyEventInfo
    {
        public ConsoleKey Key;
        public DateTime Timestamp;
        public TimeSpan HoldDuration;
        public KeyEventInfo(ConsoleKey key, DateTime timestamp, TimeSpan holdDuration)
        {
            Key = key;
            Timestamp = timestamp;
            HoldDuration = holdDuration;
        }
    }
}

