

using System;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Media.FFmpeg.Audio.Models
{
    /// <summary>
    ///     The tags class
    /// </summary>
    [Serializable]
    public partial class Tags
    {
        /// <summary>
        ///     Gets or sets the value of the encoder
        /// </summary>
        [JsonNativePropertyName("encoder")]
        public string Encoder { get; set; }
    }
}