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

using System.Collections.Generic;
using System.Globalization;


namespace Alis.Extension.Multimedia.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The media stream class
    /// </summary>
    public class MediaStream
    {
        /// <summary>
        ///     The avgfpsnum
        /// </summary>
        private double? avgfpsnum;

        /// <summary>
        ///     Gets or sets the value of the index
        /// </summary>
        
        public long Index { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec name
        /// </summary>
        
        public string CodecName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec long name
        /// </summary>
        
        public string CodecLongName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the profile
        /// </summary>
        
        public string Profile { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec type
        /// </summary>
        
        public string CodecType { get; set; }

        /// <summary>
        ///     Gets the value of the is audio
        /// </summary>
        public bool IsAudio => CodecType.ToLowerInvariant().Trim() == "audio";

        /// <summary>
        ///     Gets the value of the is video
        /// </summary>
        public bool IsVideo => CodecType.ToLowerInvariant().Trim() == "video";

        /// <summary>
        ///     Gets or sets the value of the codec time base
        /// </summary>
        
        public string CodecTimeBase { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec tag string
        /// </summary>
        
        public string CodecTagString { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec tag
        /// </summary>
        
        public string CodecTag { get; set; }

        /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>
        
        public int? Width { get; set; }

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>
        
        public int? Height { get; set; }

        /// <summary>
        ///     Gets or sets the value of the coded width
        /// </summary>
        
        public int? CodedWidth { get; set; }

        /// <summary>
        ///     Gets or sets the value of the coded height
        /// </summary>
        
        public int? CodedHeight { get; set; }

        /// <summary>
        ///     Gets or sets the value of the has b frames
        /// </summary>
        
        public int? HasBFrames { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sample aspect ratio
        /// </summary>
        
        public string SampleAspectRatio { get; set; }

        /// <summary>
        ///     Gets or sets the value of the display aspect ratio
        /// </summary>
        
        public string DisplayAspectRatio { get; set; }

        /// <summary>
        ///     Gets or sets the value of the pix fmt
        /// </summary>
        
        public string PixFmt { get; set; }

        /// <summary>
        ///     Gets or sets the value of the level
        /// </summary>
        
        public int? Level { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color range
        /// </summary>
        
        public string ColorRange { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color space
        /// </summary>
        
        public string ColorSpace { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color transfer
        /// </summary>
        
        public string ColorTransfer { get; set; }

        /// <summary>
        ///     Gets or sets the value of the color primaries
        /// </summary>
        
        public string ColorPrimaries { get; set; }

        /// <summary>
        ///     Gets or sets the value of the chroma location
        /// </summary>
        
        public string ChromaLocation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the refs
        /// </summary>
        
        public int? Refs { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is avc
        /// </summary>
        
        public string IsAvc { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nal length size
        /// </summary>
        
        public string NalLengthSize { get; set; }

        /// <summary>
        ///     Gets or sets the value of the r frame rate
        /// </summary>
        
        public string RFrameRate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the avg frame rate
        /// </summary>
        
        public string AvgFrameRate { get; set; }

        /// <summary>
        ///     Gets the value of the avg frame rate number
        /// </summary>
        public double AvgFrameRateNumber
        {
            get
            {
                if (avgfpsnum == null)
                {
                    if (AvgFrameRate.Contains("/"))
                    {
                        string[] parsed = AvgFrameRate.Split('/');
                        avgfpsnum = double.Parse(parsed[0], CultureInfo.InvariantCulture) / double.Parse(parsed[1], CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        avgfpsnum = double.Parse(AvgFrameRate, CultureInfo.InvariantCulture);
                    }
                }

                return avgfpsnum.Value;
            }
        }


        /// <summary>
        ///     Gets or sets the value of the time base
        /// </summary>
        
        public string TimeBase { get; set; }

        /// <summary>
        ///     Gets or sets the value of the start pts
        /// </summary>
        
        public int StartPts { get; set; }

        /// <summary>
        ///     Gets or sets the value of the start time
        /// </summary>
        
        public string StartTime { get; set; }

        /// <summary>
        ///     Gets or sets the value of the duration ts
        /// </summary>
        
        public int DurationTs { get; set; }

        /// <summary>
        ///     Gets or sets the value of the duration
        /// </summary>
        
        public string Duration { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bit rate
        /// </summary>
        
        public string BitRate { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bits per raw sample
        /// </summary>
        
        public string BitsPerRawSample { get; set; }

        /// <summary>
        ///     Gets or sets the value of the nb frames
        /// </summary>
        
        public string NbFrames { get; set; }

        /// <summary>
        ///     Gets or sets the value of the disposition
        /// </summary>
        
        public Dictionary<string, int> Disposition { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tags
        /// </summary>
        
        public StreamTags Tags { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sample fmt
        /// </summary>
        
        public string SampleFmt { get; set; }

        /// <summary>
        ///     Gets or sets the value of the sample rate
        /// </summary>
        
        public string SampleRate { get; set; }

        /// <summary>
        ///     Gets the value of the sample rate number
        /// </summary>
        public int SampleRateNumber => string.IsNullOrEmpty(SampleRate) ? -1 : int.Parse(SampleRate);

        /// <summary>
        ///     Gets or sets the value of the channels
        /// </summary>
        
        public int? Channels { get; set; }

        /// <summary>
        ///     Gets or sets the value of the channel layout
        /// </summary>
        
        public string ChannelLayout { get; set; }

        /// <summary>
        ///     Gets or sets the value of the bits per sample
        /// </summary>
        
        public int? BitsPerSample { get; set; }

        /// <summary>
        ///     Gets or sets the value of the max bit rate
        /// </summary>
        
        public string MaxBitRate { get; set; }
    }
}