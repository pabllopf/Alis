using System.Text.Json.Serialization;

namespace Alis.Extension.FFMeg.BaseClasses
{
    /// <summary>

    /// The stream tags class

    /// </summary>

    public class StreamTags
    {
        /// <summary>
        /// Gets or sets the value of the creation time
        /// </summary>
        [JsonPropertyName("creation_time")]
        public string CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the value of the language
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the value of the handler name
        /// </summary>
        [JsonPropertyName("handler_name")]
        public string HandlerName { get; set; }
    }
}