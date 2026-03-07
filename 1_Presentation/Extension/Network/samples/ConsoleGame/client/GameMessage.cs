using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.ConsoleGame.Client
{
    /// <summary>
    ///     Simple message type for testing
    /// </summary>
    public class GameMessage : IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the value of the message type
        /// </summary>
        public string MessageType { get; set; }
        /// <summary>
        /// Gets or sets the value of the content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public System.Collections.Generic.IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(MessageType), MessageType);
            yield return (nameof(Content), Content);
        }
    }
}