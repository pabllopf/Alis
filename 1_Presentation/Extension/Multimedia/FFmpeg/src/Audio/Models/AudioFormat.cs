// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioFormat.cs
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
using Alis.Core.Aspect.Data;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Multimedia.FFmpeg.Audio.Models
{
    /// <summary>
    ///     The audio format class
    /// </summary>
    [Serializable]
    public partial class AudioFormat
    {
        /// <summary>
        ///     Gets or sets the value of the filename
        /// </summary>
        [JsonNativePropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb streams
        /// </summary>
        [JsonNativePropertyName("nb_streams")]
        public long NbStreams { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb programs
        /// </summary>
        [JsonNativePropertyName("nb_programs")]
        public long NbPrograms { get; set; }

        /// <summary>
        ///     Gets or sets the value of the format name
        /// </summary>
        [JsonNativePropertyName("format_name")]
        public string FormatName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the format long name
        /// </summary>
        [JsonNativePropertyName("format_long_name")]
        public string FormatLongName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the start time
        /// </summary>
        [JsonNativePropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the duration
        /// </summary>
        [JsonNativePropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [JsonNativePropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bit rate
        /// </summary>
        [JsonNativePropertyName("bit_rate")]
        public string BitRate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the probe score
        /// </summary>
        [JsonNativePropertyName("probe_score")]
        public long ProbeScore { get; set; }
    }
}