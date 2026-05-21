

using System;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Media.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The stream tags class
    /// </summary>
    [Serializable]
    public partial class StreamTags
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StreamTags" /> class
        /// </summary>
        public StreamTags() : this(string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StreamTags" /> class
        /// </summary>
        /// <param name="creationTime">The creation time</param>
        /// <param name="language">The language</param>
        /// <param name="handlerName">The handler name</param>
        public StreamTags(string creationTime, string language, string handlerName)
        {
            CreationTime = creationTime;
            Language = language;
            HandlerName = handlerName;
        }

        /// <summary>
        ///     Gets or sets the value of the creation time
        /// </summary>
        [JsonNativePropertyName("creation_time")]
        public string CreationTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the language
        /// </summary>
        [JsonNativePropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the value of the handler name
        /// </summary>
        [JsonNativePropertyName("handler_name")]
        public string HandlerName { get; set; }
    }
}