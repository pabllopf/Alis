using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.SimpleGame.Server
{
    /// <summary>
    /// Game message for network communication
    /// </summary>
    public class GameMessage : IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the message type
        /// </summary>
        public string MessageType { get; set; }
        
        /// <summary>
        /// Gets or sets the content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(MessageType), MessageType ?? "");
            yield return (nameof(Content), Content ?? "");
        }
    }
}