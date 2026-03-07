using System;
using System.Collections.Generic;

namespace Alis.Extension.Network.Sample.ConsoleGame.Client
{
    /// <summary>
    /// Game event
    /// </summary>
    public class GameEvent
    {
        /// <summary>
        /// Gets or sets the timestamp
        /// </summary>
        public long Timestamp { get; set; }
        
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        public string EventType { get; set; }
        
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the source player
        /// </summary>
        public string SourcePlayer { get; set; }
        
        /// <summary>
        /// Gets or sets the target player
        /// </summary>
        public string TargetPlayer { get; set; }
        
        /// <summary>
        /// Gets or sets the data
        /// </summary>
        public Dictionary<string, object> Data { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the GameEvent class
        /// </summary>
        public GameEvent()
        {
            Timestamp = DateTime.UtcNow.Ticks;
            Data = new Dictionary<string, object>();
        }
    }
}