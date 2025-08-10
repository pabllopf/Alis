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

namespace Alis.Extension.Multimedia.FFmpeg.Video.Models
{
    /// <summary>
    ///     The video format tags class
    /// </summary>
    [Serializable]
    public partial class VideoFormatTags
    {
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