using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.FFMeg.Video.Models
{
    /// <summary>

    /// The video format tags class

    /// </summary>

    public class VideoFormatTags
    {
        /// <summary>
        /// Gets or sets the value of the major brand
        /// </summary>
        [JsonPropertyName("major_brand")]
        public string MajorBrand { get; set; }

        /// <summary>
        /// Gets or sets the value of the minor version
        /// </summary>
        [JsonPropertyName("minor_version")]
        public string MinorVersion { get; set; }

        /// <summary>
        /// Gets or sets the value of the compatible brands
        /// </summary>
        [JsonPropertyName("compatible_brands")]
        public string CompatibleBrands { get; set; }

        /// <summary>
        /// Gets or sets the value of the creation time
        /// </summary>
        [JsonPropertyName("creation_time")]
        public string CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the value of the encoder
        /// </summary>
        [JsonPropertyName("encoder")]
        public string Encoder { get; set; }
    }
}