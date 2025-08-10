// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioMetadata.cs
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

namespace Alis.Extension.Multimedia.FFmpeg.Audio.Models
{
    /// <summary>
    ///     The audio metadata class
    /// </summary>
    public class AudioMetadata : IJsonSerializable, IJsonDesSerializable<AudioMetadata>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioMetadata" /> class
        /// </summary>
        public AudioMetadata()
        {
        }

        /// <summary>
        ///     Audio sample format
        /// </summary>
        public string SampleFormat { get; set; }

        /// <summary>
        ///     Audio codec (long name)
        /// </summary>
        public string CodecLongName { get; set; }

        /// <summary>
        ///     Audio codec
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        ///     Audio channel count
        /// </summary>
        public int Channels { get; set; }

        /// <summary>
        ///     Audio sample rate
        /// </summary>
        public int SampleRate { get; set; }

        /// <summary>
        ///     Audio duration in seconds
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        ///     Average audio bitrate
        /// </summary>
        public int BitRate { get; set; }

        /// <summary>
        ///     Bits per sample
        /// </summary>
        public int BitDepth { get; set; }

        /// <summary>
        ///     Predicted sample count based on sample rate and duration
        /// </summary>
        public long PredictedSampleCount { get; set; }

        /// <summary>
        ///     Media streams inside the file. Can contain non-video streams as well.
        /// </summary>
        [JsonNativePropertyName("streams")]
        public MediaStream[] Streams { get; set; }

        /// <summary>
        ///     File format information.
        /// </summary>
        [JsonNativePropertyName("format")]
        public AudioFormat Format { get; set; }

        /// <summary>
        ///     Get first video stream
        /// </summary>
        public MediaStream GetFirstVideoStream() => Streams.Where(x => x.IsVideo).FirstOrDefault();

        /// <summary>
        ///     Get first audio stream
        /// </summary>
        public MediaStream GetFirstAudioStream() => Streams.Where(x => x.IsAudio).FirstOrDefault();
        
        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()
        {
            yield return (nameof(SampleFormat), SampleFormat.ToString());
            yield return (nameof(CodecLongName), CodecLongName.ToString());
            yield return (nameof(Codec), Codec.ToString());
            yield return (nameof(Channels), Channels.ToString());
            yield return (nameof(SampleRate), SampleRate.ToString());
            yield return (nameof(Duration), Duration.ToString());
            yield return (nameof(BitRate), BitRate.ToString());
            yield return (nameof(BitDepth), BitDepth.ToString());
            yield return (nameof(PredictedSampleCount), PredictedSampleCount.ToString());
            
            // Serialización en GetSerializableProperties
            yield return (
                nameof(Streams),
                Streams == null
                    ? "[]"
                    : "[" + string.Join(",", Streams.Select(s => s.ToJson())) + "]"
            );
            
           
            
            yield return (nameof(Format), Format.ToJson());
        }
        
        AudioMetadata IJsonDesSerializable<AudioMetadata>.CreateFromProperties(Dictionary<string, string> properties)
        {
            return new AudioMetadata
            {
                SampleFormat = properties.TryGetValue(nameof(SampleFormat), out var v_SampleFormat) ? v_SampleFormat : null,
                CodecLongName = properties.TryGetValue(nameof(CodecLongName), out var v_CodecLongName) ? v_CodecLongName : null,
                Codec = properties.TryGetValue(nameof(Codec), out var v_Codec) ? v_Codec : null,
                Channels = properties.TryGetValue(nameof(Channels), out var v_Channels) && int.TryParse(v_Channels, out var i_Channels) ? i_Channels : 0,
                SampleRate = properties.TryGetValue(nameof(SampleRate), out var v_SampleRate) && int.TryParse(v_SampleRate, out var i_SampleRate) ? i_SampleRate : 0,
                Duration = properties.TryGetValue(nameof(Duration), out var v_Duration) && double.TryParse(v_Duration, out var d_Duration) ? d_Duration : 0d,
                BitRate = properties.TryGetValue(nameof(BitRate), out var v_BitRate) && int.TryParse(v_BitRate, out var i_BitRate) ? i_BitRate : 0,
                BitDepth = properties.TryGetValue(nameof(BitDepth), out var v_BitDepth) && int.TryParse(v_BitDepth, out var i_BitDepth) ? i_BitDepth : 0,
                PredictedSampleCount = properties.TryGetValue(nameof(PredictedSampleCount), out var v_PredictedSampleCount) && long.TryParse(v_PredictedSampleCount, out var l_PredictedSampleCount) ? l_PredictedSampleCount : 0L,
                
                // Deserialización en CreateFromProperties
                Streams = properties.TryGetValue(nameof(Streams), out var v_Streams)
                    ? ParseMediaStreamArrayJson(v_Streams)
                    : null,
                
                Format = properties.TryGetValue(nameof(Format), out var v_Format) ? JsonNativeAot.Deserialize<AudioFormat>(v_Format) : null // tipo no soportado, usar conversión personalizada
            };
        }
        public string ToJson() => JsonNativeAot.Serialize(this);
        public static AudioMetadata FromJson(string json) => JsonNativeAot.Deserialize<AudioMetadata>(json);
    
        // Método auxiliar para parsear el array JSON simple
        private static MediaStream[] ParseMediaStreamArrayJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json) || json == "[]") return Array.Empty<MediaStream>();
            var items = json.Trim('[', ']').Split(new[] { "},{" }, StringSplitOptions.None);
            for (int i = 1; i < items.Length; i++) items[i] = "{" + items[i];
            items[0] = items[0].StartsWith("{") ? items[0] : "{" + items[0];
            return items.Select(MediaStream.FromJson).ToArray();
        }
    }
}