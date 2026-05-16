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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Media.FFmpeg.BaseClasses
{
    /// <summary>
    ///     Represents a media stream parsed by FFprobe.
    /// </summary>
    [Serializable]
    public partial class MediaStream
    {
        /// <summary>
        ///     Stream index within the container.
        /// </summary>
        [JsonNativePropertyName("index")]
        public long Index { get; set; }

        /// <summary>
        ///     Short codec name (e.g. h264, aac).
        /// </summary>
        [JsonNativePropertyName("codec_name")]
        public string CodecName { get; set; }

        /// <summary>
        ///     Full codec name (e.g. H.264 / AVC).
        /// </summary>
        [JsonNativePropertyName("codec_long_name")]
        public string CodecLongName { get; set; }

        /// <summary>
        ///     Encoding profile (e.g. Main, High).
        /// </summary>
        [JsonNativePropertyName("profile")]
        public string Profile { get; set; }

        /// <summary>
        ///     Type of stream: video, audio, subtitle, etc.
        /// </summary>
        [JsonNativePropertyName("codec_type")]
        public string CodecType { get; set; }

        /// <summary>
        ///     Whether this stream is an audio stream.
        /// </summary>
        [JsonNativeIgnore]
        public bool IsAudio => CodecType.ToLowerInvariant().Trim() == "audio";

        /// <summary>
        ///     Whether this stream is a video stream.
        /// </summary>
        [JsonNativeIgnore]
        public bool IsVideo => CodecType.ToLowerInvariant().Trim() == "video";

        /// <summary>
        ///     Codec time base as a rational number string.
        /// </summary>
        [JsonNativePropertyName("codec_time_base")]
        public string CodecTimeBase { get; set; }

        /// <summary>
        ///     Codec tag as a human-readable string.
        /// </summary>
        [JsonNativePropertyName("codec_tag_string")]
        public string CodecTagString { get; set; }

        /// <summary>
        ///     Numeric codec tag.
        /// </summary>
        [JsonNativePropertyName("codec_tag")]
        public string CodecTag { get; set; }

        /// <summary>
        ///     Video width in pixels.
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        ///     Video height in pixels.
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        ///     Coded width (may include padding).
        /// </summary>
        [JsonNativePropertyName("coded_width")]
        public int CodedWidth { get; set; }

        /// <summary>
        ///     Coded height (may include padding).
        /// </summary>
        [JsonNativePropertyName("coded_height")]
        public int CodedHeight { get; set; }

        /// <summary>
        ///     Number of B-frames in the stream.
        /// </summary>
        [JsonNativePropertyName("has_b_frames")]
        public int HasBFrames { get; set; }

        /// <summary>
        ///     Sample aspect ratio (e.g. 1:1).
        /// </summary>
        [JsonNativePropertyName("sample_aspect_ratio")]
        public string SampleAspectRatio { get; set; }

        /// <summary>
        ///     Display aspect ratio (e.g. 16:9).
        /// </summary>
        [JsonNativePropertyName("display_aspect_ratio")]
        public string DisplayAspectRatio { get; set; }

        /// <summary>
        ///     Pixel format (e.g. yuv420p).
        /// </summary>
        [JsonNativePropertyName("pix_fmt")]
        public string PixFmt { get; set; }

        /// <summary>
        ///     Codec level identifier.
        /// </summary>
        [JsonNativePropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        ///     Color range (e.g. tv, pc).
        /// </summary>
        [JsonNativePropertyName("color_range")]
        public string ColorRange { get; set; }

        /// <summary>
        ///     Color space (e.g. bt709).
        /// </summary>
        [JsonNativePropertyName("color_space")]
        public string ColorSpace { get; set; }

        /// <summary>
        ///     Color transfer characteristics.
        /// </summary>
        [JsonNativePropertyName("color_transfer")]
        public string ColorTransfer { get; set; }

        /// <summary>
        ///     Color primaries.
        /// </summary>
        [JsonNativePropertyName("color_primaries")]
        public string ColorPrimaries { get; set; }

        /// <summary>
        ///     Chroma sample location.
        /// </summary>
        [JsonNativePropertyName("chroma_location")]
        public string ChromaLocation { get; set; }

        /// <summary>
        ///     Number of reference frames.
        /// </summary>
        [JsonNativePropertyName("refs")]
        public int Refs { get; set; }

        /// <summary>
        ///     Whether the stream uses AVC (H.264) encoding.
        /// </summary>
        [JsonNativePropertyName("is_avc")]
        public string IsAvc { get; set; }

        /// <summary>
        ///     NAL unit length size in bytes.
        /// </summary>
        [JsonNativePropertyName("nal_length_size")]
        public string NalLengthSize { get; set; }

        /// <summary>
        ///     Real base frame rate as a rational string.
        /// </summary>
        [JsonNativePropertyName("r_frame_rate")]
        public string RFrameRate { get; set; }

        /// <summary>
        ///     Average frame rate as a rational string.
        /// </summary>
        [JsonNativePropertyName("avg_frame_rate")]
        public string AvgFrameRate { get; set; }

        /// <summary>
        ///     Average frame rate as a floating-point number.
        /// </summary>
        [JsonNativeIgnore]
        public double AvgFrameRateNumber { get; set; }

        /// <summary>
        ///     Stream time base as a rational string.
        /// </summary>
        [JsonNativePropertyName("time_base")]
        public string TimeBase { get; set; }

        /// <summary>
        ///     Starting presentation timestamp.
        /// </summary>
        [JsonNativePropertyName("start_pts")]
        public int StartPts { get; set; }

        /// <summary>
        ///     Stream start time in seconds.
        /// </summary>
        [JsonNativePropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        ///     Duration in time base units.
        /// </summary>
        [JsonNativePropertyName("duration_ts")]
        public int DurationTs { get; set; }

        /// <summary>
        ///     Stream duration as a string in seconds.
        /// </summary>
        [JsonNativePropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        ///     Stream bit rate in bits per second.
        /// </summary>
        [JsonNativePropertyName("bit_rate")]
        public string BitRate { get; set; }

        /// <summary>
        ///     Bits per raw sample.
        /// </summary>
        [JsonNativePropertyName("bits_per_raw_sample")]
        public string BitsPerRawSample { get; set; }

        /// <summary>
        ///     Number of frames in the stream.
        /// </summary>
        [JsonNativePropertyName("nb_frames")]
        public string NbFrames { get; set; }

        /// <summary>
        ///     Disposition flags for the stream.
        /// </summary>
        [JsonNativeIgnore]
        public Dictionary<string, int> Disposition { get; set; }

        /// <summary>
        ///     Metadata tags associated with the stream.
        /// </summary>
        [JsonNativePropertyName("tags")]
        public StreamTags Tags { get; set; }

        /// <summary>
        ///     Audio sample format (e.g. s16, fltp).
        /// </summary>
        [JsonNativePropertyName("sample_fmt")]
        public string SampleFmt { get; set; }

        /// <summary>
        ///     Audio sample rate as a string.
        /// </summary>
        [JsonNativePropertyName("sample_rate")]
        public string SampleRate { get; set; }

        /// <summary>
        ///     Audio sample rate as an integer, or -1 if unavailable.
        /// </summary>
        [JsonNativeIgnore]
        public int SampleRateNumber => string.IsNullOrEmpty(SampleRate) ? -1 : int.Parse(SampleRate);

        /// <summary>
        ///     Number of audio channels.
        /// </summary>
        [JsonNativePropertyName("channels")]
        public int Channels { get; set; }

        /// <summary>
        ///     Audio channel layout (e.g. stereo, 5.1).
        /// </summary>
        [JsonNativePropertyName("channel_layout")]
        public string ChannelLayout { get; set; }

        /// <summary>
        ///     Bits per audio sample.
        /// </summary>
        [JsonNativePropertyName("bits_per_sample")]
        public int BitsPerSample { get; set; }

        /// <summary>
        ///     Maximum bit rate.
        /// </summary>
        [JsonNativePropertyName("max_bit_rate")]
        public string MaxBitRate { get; set; }
    }
}