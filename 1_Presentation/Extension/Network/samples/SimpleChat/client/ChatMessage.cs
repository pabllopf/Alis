using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.SimpleChat.Client
{
    /// <summary>
    ///     Chat message structure (shared with server)
    /// </summary>
    public class ChatMessage : IJsonSerializable
    {
        /// <summary>
        ///     Gets or sets sender name
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        ///     Gets or sets message content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     Gets or sets timestamp
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        ///     Gets serializable properties
        /// </summary>
        public IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(SenderName), SenderName);
            yield return (nameof(Content), Content);
            yield return (nameof(Timestamp), Timestamp);
        }
    }
}

