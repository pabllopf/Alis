using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Extension.FFMeg.Audio.Models
{
    /// <summary>

    /// The tags class

    /// </summary>

    public class Tags
    {
        /// <summary>
        /// Gets or sets the value of the encoder
        /// </summary>
        [JsonPropertyName("encoder")]
        public string Encoder { get; set; }
    }
}