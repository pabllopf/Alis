// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoMetadata.cs
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
using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Multimedia.FFmpeg.BaseClasses;

namespace Alis.Extension.Multimedia.FFmpeg.Video.Models
{
    /// <summary>
    ///     The video metadata class
    /// </summary>
    public class VideoMetadata : IJsonSerializable, IJsonDesSerializable<VideoMetadata>
    {
        
        public string ToJson() => JsonNativeAot.Serialize(this);
        public static VideoMetadata FromJson(string json) => JsonNativeAot.Deserialize<VideoMetadata>(json);
    
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoMetadata" /> class
        /// </summary>
        public VideoMetadata()
        {
        }

        /// <summary>
        ///     Video pixel format
        /// </summary>
        [JsonNativeIgnore]
        public string PixelFormat { get; set; }

        /// <summary>
        ///     Video codec (long name)
        /// </summary>
        [JsonNativeIgnore]
        public string CodecLongName { get; set; }

        /// <summary>
        ///     Video codec
        /// </summary>
        [JsonNativeIgnore]
        public string Codec { get; set; }

        /// <summary>
        ///     Video width
        /// </summary>
        [JsonNativeIgnore]
        public int Width { get; set; }

        /// <summary>
        ///     Video height
        /// </summary>
        [JsonNativeIgnore]
        public int Height { get; set; }

        /// <summary>
        ///     Video duration in seconds
        /// </summary>
        [JsonNativeIgnore]
        public double Duration { get; set; }

        /// <summary>
        ///     Average video framerate
        /// </summary>
        [JsonNativeIgnore]
        public double AvgFramerate { get; set; }

        /// <summary>
        ///     Average video bitrate
        /// </summary>
        [JsonNativeIgnore]
        public int BitRate { get; set; }

        /// <summary>
        ///     Bits per sample
        /// </summary>
        [JsonNativeIgnore]
        public int BitDepth { get; set; }

        /// <summary>
        ///     Pixel aspect ratio
        /// </summary>
        [JsonNativeIgnore]
        public string SampleAspectRatio { get; set; }

        /// <summary>
        ///     Predicted frame count based on average framerate and duration
        /// </summary>
        [JsonNativeIgnore]
        public int PredictedFrameCount { get; set; }

        /// <summary>
        ///     Media streams inside the file. Can contain non-video streams as well.
        /// </summary>
        [JsonNativePropertyName("streams")]
        public MediaStream[] Streams { get; set; }

        /// <summary>
        ///     File format information.
        /// </summary>
        [JsonNativePropertyName("format")]
        public VideoFormat Format { get; set; }

        /// <summary>
        ///     Get first video stream
        /// </summary>
        [JsonNativeIgnore]
        public MediaStream GetFirstVideoStream() => Streams.Where(x => x.IsVideo).FirstOrDefault();

        /// <summary>
        ///     Get first audio stream
        /// </summary>
        [JsonNativeIgnore]
        public MediaStream GetFirstAudioStream() => Streams.Where(x => x.IsAudio).FirstOrDefault();
        
        
        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()
        {
            // Serialización en GetSerializableProperties
            yield return (
                nameof(Streams),
                Streams == null
                    ? "[]"
                    : "[" + string.Join(",", Streams.Select(s => s.ToJson())) + "]"
            );
            
            yield return (nameof(Format), Format.ToJson());
        }
        VideoMetadata IJsonDesSerializable<VideoMetadata>.CreateFromProperties(Dictionary<string, string> properties)
        {
            return new VideoMetadata
            {
                // Deserialización en CreateFromProperties
                Streams = properties.TryGetValue("streams", out var v_Streams)
                    ? ParseMediaStreamArrayJson(v_Streams)
                    : null,
                
                
                Format = properties.TryGetValue("format", out string v_Format) ? JsonNativeAot.Deserialize<VideoFormat>(v_Format) : null, // tipo no soportado, usar conversión personalizada
            };
        }
        
        
            
        // Método auxiliar para parsear el array JSON simple
        private static MediaStream[] ParseMediaStreamArrayJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json) || json == "[]") return Array.Empty<MediaStream>();
            // Quita corchetes y separa objetos por '},{'
            var items = json.Trim('[', ']').Split(new[] { "},{" }, StringSplitOptions.None);
            for (int i = 1; i < items.Length; i++) items[i] = "{" + items[i];
            items[0] = items[0].StartsWith("{") ? items[0] : "{" + items[0];
            return items.Select(MediaStream.FromJson).ToArray();
        }
    }
}