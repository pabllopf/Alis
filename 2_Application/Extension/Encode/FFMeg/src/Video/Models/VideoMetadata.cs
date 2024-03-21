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

using System.Linq;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Encode.FFMeg.BaseClasses;

namespace Alis.Extension.Encode.FFMeg.Video.Models
{
    // prepare for source generation

    /// <summary>
    ///     The video metadata class
    /// </summary>
    public class VideoMetadata
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VideoMetadata" /> class
        /// </summary>
        public VideoMetadata()
        {
        }

        /// <summary>
        ///     Video pixel format
        /// </summary>
        public string PixelFormat { get; set; }

        /// <summary>
        ///     Video codec (long name)
        /// </summary>
        public string CodecLongName { get; set; }

        /// <summary>
        ///     Video codec
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        ///     Video width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     Video height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     Video duration in seconds
        /// </summary>
        public double Duration { get; set; }

        /// <summary>
        ///     Average video framerate
        /// </summary>
        public double AvgFramerate { get; set; }

        /// <summary>
        ///     Average video bitrate
        /// </summary>
        public int BitRate { get; set; }

        /// <summary>
        ///     Bits per sample
        /// </summary>
        public int BitDepth { get; set; }

        /// <summary>
        ///     Pixel aspect ratio
        /// </summary>
        public string SampleAspectRatio { get; set; }

        /// <summary>
        ///     Predicted frame count based on average framerate and duration
        /// </summary>
        public int PredictedFrameCount { get; set; }

        /// <summary>
        ///     Media streams inside the file. Can contain non-video streams as well.
        /// </summary>
        [JsonPropertyName("streams")]
        public MediaStream[] Streams { get; set; }

        /// <summary>
        ///     File format information.
        /// </summary>
        [JsonPropertyName("format")]
        public VideoFormat Format { get; set; }

        /// <summary>
        ///     Get first video stream
        /// </summary>
        public MediaStream GetFirstVideoStream() => Streams.Where(x => x.IsVideo).FirstOrDefault();

        /// <summary>
        ///     Get first audio stream
        /// </summary>
        public MediaStream GetFirstAudioStream() => Streams.Where(x => x.IsAudio).FirstOrDefault();
    }
}