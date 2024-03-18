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

using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.FFMeg.Audio.Models
{
    /// <summary>
    ///     The audio format class
    /// </summary>
    public class AudioFormat
    {
        /// <summary>
        ///     Gets or sets the value of the filename
        /// </summary>
        [JsonPropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb streams
        /// </summary>
        [JsonPropertyName("nb_streams")]
        public long NbStreams { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb programs
        /// </summary>
        [JsonPropertyName("nb_programs")]
        public long NbPrograms { get; set; }

        /// <summary>
        ///     Gets or sets the value of the format name
        /// </summary>
        [JsonPropertyName("format_name")]
        public string FormatName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the format long name
        /// </summary>
        [JsonPropertyName("format_long_name")]
        public string FormatLongName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the start time
        /// </summary>
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the duration
        /// </summary>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [JsonPropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bit rate
        /// </summary>
        [JsonPropertyName("bit_rate")]
        public string BitRate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the probe score
        /// </summary>
        [JsonPropertyName("probe_score")]
        public long ProbeScore { get; set; }
    }
}