// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MediaStream.cs
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
using Alis.Core.Aspect.Data;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Multimedia.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The media stream class
    /// </summary>
    [Serializable]
    public partial class MediaStream 
    {
        /// <summary>
        ///     The avgfpsnum
        /// </summary>
        private double avgfpsnum;

        /// <summary>
        ///     Gets or sets the value of the index
        /// </summary>
        [JsonNativePropertyName("index")]
        public long Index { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec name
        /// </summary>
        [JsonNativePropertyName("codec_name")]
        public string CodecName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec long name
        /// </summary>
        [JsonNativePropertyName("codec_long_name")]
        public string CodecLongName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the profile
        /// </summary>
        [JsonNativePropertyName("profile")]
        public string Profile { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec type
        /// </summary>
        [JsonNativePropertyName("codec_type")]
        public string CodecType { get; set; }

        /// <summary>
        ///     Gets the value of the is audio
        /// </summary>
        [JsonNativeIgnore]
        public bool IsAudio => CodecType.ToLowerInvariant().Trim() == "audio";

        /// <summary>
        ///     Gets the value of the is video
        /// </summary>
        [JsonNativeIgnore]
        public bool IsVideo => CodecType.ToLowerInvariant().Trim() == "video";

        /// <summary>
        ///     Gets or sets the value of the codec time base
        /// </summary>
        [JsonNativePropertyName("codec_time_base")]
        public string CodecTimeBase { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec tag string
        /// </summary>
        [JsonNativePropertyName("codec_tag_string")]
        public string CodecTagString { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec tag
        /// </summary>
        [JsonNativePropertyName("codec_tag")]
        public string CodecTag { get; set; }

        /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        ///     Gets or sets the value of the coded width
        /// </summary>
        [JsonNativePropertyName("coded_width")]
        public int CodedWidth { get; set; }

        /// <summary>
        ///     Gets or sets the value of the coded height
        /// </summary>
        [JsonNativePropertyName("coded_height")]
        public int CodedHeight { get; set; }

        /// <summary>
        ///     Gets or sets the value of the has b frames
        /// </summary>
        [JsonNativePropertyName("has_b_frames")]
        public int HasBFrames { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sample aspect ratio
        /// </summary>
        [JsonNativePropertyName("sample_aspect_ratio")]
        public string SampleAspectRatio { get; set; }

        /// <summary>
        ///     Gets or sets the value of the display aspect ratio
        /// </summary>
        [JsonNativePropertyName("display_aspect_ratio")]
        public string DisplayAspectRatio { get; set; }

        /// <summary>
        ///     Gets or sets the value of the pix fmt
        /// </summary>
        [JsonNativePropertyName("pix_fmt")]
        public string PixFmt { get; set; }

        /// <summary>
        ///     Gets or sets the value of the level
        /// </summary>
        [JsonNativePropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color range
        /// </summary>
        [JsonNativePropertyName("color_range")]
        public string ColorRange { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color space
        /// </summary>
        [JsonNativePropertyName("color_space")]
        public string ColorSpace { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color transfer
        /// </summary>
        [JsonNativePropertyName("color_transfer")]
        public string ColorTransfer { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color primaries
        /// </summary>
        [JsonNativePropertyName("color_primaries")]
        public string ColorPrimaries { get; set; }

        /// <summary>
        ///     Gets or sets the value of the chroma location
        /// </summary>
        [JsonNativePropertyName("chroma_location")]
        public string ChromaLocation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the refs
        /// </summary>
        [JsonNativePropertyName("refs")]
        public int Refs { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is avc
        /// </summary>
        [JsonNativePropertyName("is_avc")]
        public string IsAvc { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nal length size
        /// </summary>
        [JsonNativePropertyName("nal_length_size")]
        public string NalLengthSize { get; set; }

        /// <summary>
        ///     Gets or sets the value of the r frame rate
        /// </summary>
        [JsonNativePropertyName("r_frame_rate")]
        public string RFrameRate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the avg frame rate
        /// </summary>
        [JsonNativePropertyName("avg_frame_rate")]
        public string AvgFrameRate { get; set; }

        /// <summary>
        ///     Gets the value of the avg frame rate number
        /// </summary>
        [JsonNativeIgnore]
        public double AvgFrameRateNumber
        {
            get
            {
                return avgfpsnum;
            }
        }


        /// <summary>
        ///     Gets or sets the value of the time base
        /// </summary>
        [JsonNativePropertyName("time_base")]
        public string TimeBase { get; set; }

        /// <summary>
        ///     Gets or sets the value of the start pts
        /// </summary>
        [JsonNativePropertyName("start_pts")]
        public int StartPts { get; set; }

        /// <summary>
        ///     Gets or sets the value of the start time
        /// </summary>
        [JsonNativePropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the duration ts
        /// </summary>
        [JsonNativePropertyName("duration_ts")]
        public int DurationTs { get; set; }

        /// <summary>
        ///     Gets or sets the value of the duration
        /// </summary>
        [JsonNativePropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bit rate
        /// </summary>
        [JsonNativePropertyName("bit_rate")]
        public string BitRate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bits per raw sample
        /// </summary>
        [JsonNativePropertyName("bits_per_raw_sample")]
        public string BitsPerRawSample { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb frames
        /// </summary>
        [JsonNativePropertyName("nb_frames")]
        public string NbFrames { get; set; }

        /// <summary>
        ///     Gets or sets the value of the disposition
        /// </summary>
        [JsonNativeIgnore]
        public Dictionary<string, int> Disposition { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tags
        /// </summary>
        [JsonNativePropertyName("tags")]
        public StreamTags Tags { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sample fmt
        /// </summary>
        [JsonNativePropertyName("sample_fmt")]
        public string SampleFmt { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sample rate
        /// </summary>
        [JsonNativePropertyName("sample_rate")]
        public string SampleRate { get; set; }

        /// <summary>
        ///     Gets the value of the sample rate number
        /// </summary>
        [JsonNativeIgnore]
        public int SampleRateNumber => string.IsNullOrEmpty(SampleRate) ? -1 : int.Parse(SampleRate);

        /// <summary>
        ///     Gets or sets the value of the channels
        /// </summary>
        [JsonNativePropertyName("channels")]
        public int Channels { get; set; }

        /// <summary>
        ///     Gets or sets the value of the channel layout
        /// </summary>
        [JsonNativePropertyName("channel_layout")]
        public string ChannelLayout { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bits per sample
        /// </summary>
        [JsonNativePropertyName("bits_per_sample")]
        public int BitsPerSample { get; set; }

        /// <summary>
        ///     Gets or sets the value of the max bit rate
        /// </summary>
        [JsonNativePropertyName("max_bit_rate")]
        public string MaxBitRate { get; set; }
    }
}