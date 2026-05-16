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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Media.FFmpeg.Audio.Models
{
    /// <summary>
    ///     Container-level format information parsed by FFprobe for an audio file.
    /// </summary>
    [Serializable]
    public partial class AudioFormat
    {
        /// <summary>
        ///     Path or URL of the probed audio file.
        /// </summary>
        [JsonNativePropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        ///     Number of streams (audio, video, subtitle) in the file.
        /// </summary>
        [JsonNativePropertyName("nb_streams")]
        public long NbStreams { get; set; }

        /// <summary>
        ///     Number of programs in the container.
        /// </summary>
        [JsonNativePropertyName("nb_programs")]
        public long NbPrograms { get; set; }

        /// <summary>
        ///     Short container format name (e.g. mp3, ogg, wav).
        /// </summary>
        [JsonNativePropertyName("format_name")]
        public string FormatName { get; set; }

        /// <summary>
        ///     Descriptive container format name.
        /// </summary>
        [JsonNativePropertyName("format_long_name")]
        public string FormatLongName { get; set; }

        /// <summary>
        ///     Timestamp of the first packet in seconds.
        /// </summary>
        [JsonNativePropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        ///     Total duration of the audio file in seconds.
        /// </summary>
        [JsonNativePropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        ///     File size in bytes.
        /// </summary>
        [JsonNativePropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        ///     Overall bit rate in bits per second.
        /// </summary>
        [JsonNativePropertyName("bit_rate")]
        public string BitRate { get; set; }

        /// <summary>
        ///     Confidence score of the format detection (higher is more confident).
        /// </summary>
        [JsonNativePropertyName("probe_score")]
        public long ProbeScore { get; set; }
    }
}