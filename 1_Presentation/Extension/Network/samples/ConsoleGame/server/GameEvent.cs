using System;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.ConsoleGame.Server
{
    /// <summary>
    /// Game event
    /// </summary>
    public class GameEvent : IJsonSerializable
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
        /// Initializes a new instance of the GameEvent class
        /// </summary>
        public GameEvent()
        {
            Timestamp = DateTime.UtcNow.Ticks;
        }
        
        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public System.Collections.Generic.IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(Timestamp), Timestamp.ToString());
            yield return (nameof(EventType), EventType ?? "");
            yield return (nameof(Description), Description ?? "");
            yield return (nameof(SourcePlayer), SourcePlayer ?? "");
            yield return (nameof(TargetPlayer), TargetPlayer ?? "");
        }
    }
}