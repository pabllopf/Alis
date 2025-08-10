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
using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Multimedia.FFmpeg.Video.Models
{
    /// <summary>
    ///     The video format class
    /// </summary>
    public partial class VideoFormat : IJsonSerializable, IJsonDesSerializable<VideoFormat>
    {
        public string ToJson() => JsonNativeAot.Serialize(this);
        public static VideoFormat FromJson(string json) => JsonNativeAot.Deserialize<VideoFormat>(json);
    
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

        /// <summary>
        ///     Gets or sets the value of the tags
        /// </summary>
        [JsonNativePropertyName("tags")]
        public VideoFormatTags Tags { get; set; }
        
        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()
        {
            yield return (nameof(Filename), Filename.ToString());
            yield return (nameof(NbStreams), NbStreams.ToString());
            yield return (nameof(NbPrograms), NbPrograms.ToString());
            yield return (nameof(FormatName), FormatName.ToString());
            yield return (nameof(FormatLongName), FormatLongName.ToString());
            yield return (nameof(StartTime), StartTime.ToString());
            yield return (nameof(Duration), Duration.ToString());
            yield return (nameof(Size), Size.ToString());
            yield return (nameof(BitRate), BitRate.ToString());
            yield return (nameof(ProbeScore), ProbeScore.ToString());
            yield return (nameof(Tags), Tags.ToJson());
        }
        VideoFormat IJsonDesSerializable<VideoFormat>.CreateFromProperties(Dictionary<string, string> properties)
        {
            return new VideoFormat
            {
                Filename = properties.TryGetValue("filename", out var v_Filename) ? v_Filename : null,
                NbStreams = properties.TryGetValue("nb_streams", out var v_NbStreams) && long.TryParse(v_NbStreams, out var l_NbStreams) ? l_NbStreams : 0L,
                NbPrograms = properties.TryGetValue("nb_programs", out var v_NbPrograms) && long.TryParse(v_NbPrograms, out var l_NbPrograms) ? l_NbPrograms : 0L,
                FormatName = properties.TryGetValue("format_name", out var v_FormatName) ? v_FormatName : null,
                FormatLongName = properties.TryGetValue("format_long_name", out var v_FormatLongName) ? v_FormatLongName : null,
                StartTime = properties.TryGetValue("start_time", out var v_StartTime) ? v_StartTime : null,
                Duration = properties.TryGetValue("duration", out var v_Duration) ? v_Duration : null,
                Size = properties.TryGetValue("size", out var v_Size) ? v_Size : null,
                BitRate = properties.TryGetValue("bit_rate", out var v_BitRate) ? v_BitRate : null,
                ProbeScore = properties.TryGetValue("probe_score", out var v_ProbeScore) && long.TryParse(v_ProbeScore, out var l_ProbeScore) ? l_ProbeScore : 0L,
                Tags = properties.TryGetValue("tags", out var v_Tags) ? JsonNativeAot.Deserialize<VideoFormatTags>(v_Tags) : null, // tipo no soportado, usar conversión personalizada
            };
        }
    }
}