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
using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Video.Models
{
    /// <summary>
    ///     The video metadata class
    /// </summary>
    [Serializable]
    public partial class VideoMetadata 
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoMetadata" /> class
        /// </summary>
        public VideoMetadata() : this (string.Empty, string.Empty, string.Empty, 0, 0, 0.0, 0.0, 0, 0, string.Empty, 0, Array.Empty<MediaStream>(), new VideoFormat())
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoMetadata"/> class
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="codecLongName">The codec long name</param>
        /// <param name="codec">The codec</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="duration">The duration</param>
        /// <param name="avgFramerate">The avg framerate</param>
        /// <param name="bitRate">The bit rate</param>
        /// <param name="bitDepth">The bit depth</param>
        /// <param name="sampleAspectRatio">The sample aspect ratio</param>
        /// <param name="predictedFrameCount">The predicted frame count</param>
        /// <param name="streams">The streams</param>
        /// <param name="format">The format</param>
        public VideoMetadata(string pixelFormat, string codecLongName, string codec, int width, int height, double duration, double avgFramerate, int bitRate, int bitDepth, string sampleAspectRatio, int predictedFrameCount, MediaStream[] streams, VideoFormat format)
        {
            PixelFormat = pixelFormat;
            CodecLongName = codecLongName;
            Codec = codec;
            Width = width;
            Height = height;
            Duration = duration;
            AvgFramerate = avgFramerate;
            BitRate = bitRate;
            BitDepth = bitDepth;
            SampleAspectRatio = sampleAspectRatio;
            PredictedFrameCount = predictedFrameCount;
            Streams = streams;
            Format = format;
        }

        /// <summary>
        ///     Video pixel format
        /// </summary>
        [JsonNativePropertyName("pix_fmt")]
        public string PixelFormat { get; set; }

        /// <summary>
        ///     Video codec (long name)
        /// </summary>
        [JsonNativePropertyName("codec_long_name")]
        public string CodecLongName { get; set; }

        /// <summary>
        ///     Video codec
        /// </summary>
        [JsonNativePropertyName("codec_name")]
        public string Codec { get; set; }

        /// <summary>
        ///     Video width
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        ///     Video height
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        ///     Video duration in seconds
        /// </summary>
        [JsonNativePropertyName("duration")]
        public double Duration { get; set; }

        /// <summary>
        ///     Average video framerate
        /// </summary>
        [JsonNativePropertyName("avg_frame_rate")]
        public double AvgFramerate { get; set; }

        /// <summary>
        ///     Average video bitrate
        /// </summary>
        [JsonNativePropertyName("bit_rate")]
        public int BitRate { get; set; }

        /// <summary>
        ///     Bits per sample
        /// </summary>
        [JsonNativePropertyName("bit_depth")]
        public int BitDepth { get; set; }

        /// <summary>
        ///     Pixel aspect ratio
        /// </summary>
        [JsonNativePropertyName("sample_aspect_ratio")]
        public string SampleAspectRatio { get; set; }

        /// <summary>
        ///     Predicted frame count based on average framerate and duration
        /// </summary>
        [JsonNativePropertyName("predicted_frame_count")]
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
    }
}