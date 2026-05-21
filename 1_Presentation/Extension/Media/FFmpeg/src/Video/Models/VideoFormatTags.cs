

using System;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Media.FFmpeg.Video.Models
{
    /// <summary>
    ///     The video format tags class
    /// </summary>
    [Serializable]
    public partial class VideoFormatTags
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoFormatTags" /> class
        /// </summary>
        public VideoFormatTags() : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoFormatTags" /> class
        /// </summary>
        /// <param name="majorBrand">The major brand</param>
        /// <param name="minorVersion">The minor version</param>
        /// <param name="compatibleBrands">The compatible brands</param>
        /// <param name="creationTime">The creation time</param>
        /// <param name="encoder">The encoder</param>
        public VideoFormatTags(string majorBrand, string minorVersion, string compatibleBrands, string creationTime, string encoder)
        {
            MajorBrand = majorBrand;
            MinorVersion = minorVersion;
            CompatibleBrands = compatibleBrands;
            CreationTime = creationTime;
            Encoder = encoder;
        }

        /// <summary>
        ///     Gets or sets the value of the major brand
        /// </summary>
        [JsonNativePropertyName("major_brand")]
        public string MajorBrand { get; set; }

        /// <summary>
        ///     Gets or sets the value of the minor version
        /// </summary>
        [JsonNativePropertyName("minor_version")]
        public string MinorVersion { get; set; }

        /// <summary>
        ///     Gets or sets the value of the compatible brands
        /// </summary>
        [JsonNativePropertyName("compatible_brands")]
        public string CompatibleBrands { get; set; }

        /// <summary>
        ///     Gets or sets the value of the creation time
        /// </summary>
        [JsonNativePropertyName("creation_time")]
        public string CreationTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the encoder
        /// </summary>
        [JsonNativePropertyName("encoder")]
        public string Encoder { get; set; }
    }
}