// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFormatTags.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Media.FFmpeg.Video.Models
{
    /// <summary>
    ///     Metadata tags specific to a video container format.
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
        ///     Major brand identifier of the ISOBMFF container.
        /// </summary>
        [JsonNativePropertyName("major_brand")]
        public string MajorBrand { get; set; }

        /// <summary>
        ///     Minor version of the ISOBMFF brand.
        /// </summary>
        [JsonNativePropertyName("minor_version")]
        public string MinorVersion { get; set; }

        /// <summary>
        ///     Comma-separated list of compatible ISOBMFF brands.
        /// </summary>
        [JsonNativePropertyName("compatible_brands")]
        public string CompatibleBrands { get; set; }

        /// <summary>
        ///     Creation timestamp of the container.
        /// </summary>
        [JsonNativePropertyName("creation_time")]
        public string CreationTime { get; set; }

        /// <summary>
        ///     Name of the encoder software used to create the file.
        /// </summary>
        [JsonNativePropertyName("encoder")]
        public string Encoder { get; set; }
    }
}