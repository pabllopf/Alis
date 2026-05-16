// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoFormat.cs
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
    ///     Container-level format information parsed by FFprobe for a video file.
    /// </summary>
    [Serializable]
    public partial class VideoFormat
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoFormat" /> class
        /// </summary>
        public VideoFormat() : this(string.Empty, 0, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, new VideoFormatTags())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoFormat" /> class
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="nbStreams">The nb streams</param>
        /// <param name="nbPrograms">The nb programs</param>
        /// <param name="formatName">The format name</param>
        /// <param name="formatLongName">The format long name</param>
        /// <param name="startTime">The start time</param>
        /// <param name="duration">The duration</param>
        /// <param name="size">The size</param>
        /// <param name="bitRate">The bit rate</param>
        /// <param name="probeScore">The probe score</param>
        /// <param name="tags">The tags</param>
        public VideoFormat(string filename, long nbStreams, long nbPrograms, string formatName, string formatLongName, string startTime, string duration, string size, string bitRate, long probeScore, VideoFormatTags tags)
        {
            Filename = filename;
            NbStreams = nbStreams;
            NbPrograms = nbPrograms;
            FormatName = formatName;
            FormatLongName = formatLongName;
            StartTime = startTime;
            Duration = duration;
            Size = size;
            BitRate = bitRate;
            ProbeScore = probeScore;
            Tags = tags;
        }

        /// <summary>
        ///     Path or URL of the probed media file.
        /// </summary>
        [JsonNativePropertyName("filename")]
        public string Filename { get; set; }

        /// <summary>
        ///     Number of media streams (audio, video, subtitle) in the file.
        /// </summary>
        [JsonNativePropertyName("nb_streams")]
        public long NbStreams { get; set; }

        /// <summary>
        ///     Number of programs in the container.
        /// </summary>
        [JsonNativePropertyName("nb_programs")]
        public long NbPrograms { get; set; }

        /// <summary>
        ///     Short container format name (e.g. mov, mp4, matroska).
        /// </summary>
        [JsonNativePropertyName("format_name")]
        public string FormatName { get; set; }

        /// <summary>
        ///     Descriptive container format name (e.g. QuickTime / MOV).
        /// </summary>
        [JsonNativePropertyName("format_long_name")]
        public string FormatLongName { get; set; }

        /// <summary>
        ///     Timestamp of the first packet in seconds.
        /// </summary>
        [JsonNativePropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        ///     Total duration of the file in seconds.
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

        /// <summary>
        ///     Metadata tags associated with the container.
        /// </summary>
        [JsonNativePropertyName("tags")]
        public VideoFormatTags Tags { get; set; }
    }
}