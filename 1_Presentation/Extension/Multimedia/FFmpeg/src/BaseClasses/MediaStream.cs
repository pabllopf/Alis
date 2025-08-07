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
using System.Globalization;
using System.Linq;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Multimedia.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The media stream class
    /// </summary>
    public class MediaStream : IJsonSerializable, IJsonDesSerializable<MediaStream>
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
        [JsonNativePropertyName("disposition")]
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
        
        
        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()
        {
            yield return (nameof(Index), Index.ToString());
            yield return (nameof(CodecName), CodecName.ToString());
            yield return (nameof(CodecLongName), CodecLongName.ToString());
            yield return (nameof(Profile), Profile.ToString());
            yield return (nameof(CodecType), CodecType.ToString());
            yield return (nameof(CodecTimeBase), CodecTimeBase.ToString());
            yield return (nameof(CodecTagString), CodecTagString.ToString());
            yield return (nameof(CodecTag), CodecTag.ToString());
            yield return (nameof(Width), Width.ToString());
            yield return (nameof(Height), Height.ToString());
            yield return (nameof(CodedWidth), CodedWidth.ToString());
            yield return (nameof(CodedHeight), CodedHeight.ToString());
            yield return (nameof(HasBFrames), HasBFrames.ToString());
            yield return (nameof(SampleAspectRatio), SampleAspectRatio.ToString());
            yield return (nameof(DisplayAspectRatio), DisplayAspectRatio.ToString());
            yield return (nameof(PixFmt), PixFmt.ToString());
            yield return (nameof(Level), Level.ToString());
            yield return (nameof(ColorRange), ColorRange.ToString());
            yield return (nameof(ColorSpace), ColorSpace.ToString());
            yield return (nameof(ColorTransfer), ColorTransfer.ToString());
            yield return (nameof(ColorPrimaries), ColorPrimaries.ToString());
            yield return (nameof(ChromaLocation), ChromaLocation.ToString());
            yield return (nameof(Refs), Refs.ToString());
            yield return (nameof(IsAvc), IsAvc.ToString());
            yield return (nameof(NalLengthSize), NalLengthSize.ToString());
            yield return (nameof(RFrameRate), RFrameRate.ToString());
            yield return (nameof(AvgFrameRate), AvgFrameRate.ToString());
            yield return (nameof(TimeBase), TimeBase.ToString());
            yield return (nameof(StartPts), StartPts.ToString());
            yield return (nameof(StartTime), StartTime.ToString());
            yield return (nameof(DurationTs), DurationTs.ToString());
            yield return (nameof(Duration), Duration.ToString());
            yield return (nameof(BitRate), BitRate.ToString());
            yield return (nameof(BitsPerRawSample), BitsPerRawSample.ToString());
            yield return (nameof(NbFrames), NbFrames.ToString());
            
            
            // Serialización en GetSerializableProperties
            yield return (nameof(Disposition), 
                Disposition == null 
                    ? "{}" 
                    : "{" + string.Join(",", Disposition.Select(kv => $"\"{kv.Key}\":{kv.Value}")) + "}"
            );
            
            
            yield return (nameof(Tags), Tags.ToJson().ToString());
            
            yield return (nameof(SampleFmt), SampleFmt.ToString());
            yield return (nameof(SampleRate), SampleRate.ToString());
            yield return (nameof(Channels), Channels.ToString());
            yield return (nameof(ChannelLayout), ChannelLayout.ToString());
            yield return (nameof(BitsPerSample), BitsPerSample.ToString());
            yield return (nameof(MaxBitRate), MaxBitRate.ToString());
        }
        MediaStream IJsonDesSerializable<MediaStream>.CreateFromProperties(Dictionary<string, string> properties)
        {
            return new MediaStream
            {
                Index = properties.TryGetValue("index", out var v_Index) && long.TryParse(v_Index, out var l_Index) ? l_Index : 0L,
                CodecName = properties.TryGetValue("codec_name", out var v_CodecName) ? v_CodecName : null,
                CodecLongName = properties.TryGetValue("codec_long_name", out var v_CodecLongName) ? v_CodecLongName : null,
                Profile = properties.TryGetValue("profile", out var v_Profile) ? v_Profile : null,
                CodecType = properties.TryGetValue("codec_type", out var v_CodecType) ? v_CodecType : null,
                CodecTimeBase = properties.TryGetValue("codec_time_base", out var v_CodecTimeBase) ? v_CodecTimeBase : null,
                CodecTagString = properties.TryGetValue("codec_tag_string", out var v_CodecTagString) ? v_CodecTagString : null,
                CodecTag = properties.TryGetValue("codec_tag", out var v_CodecTag) ? v_CodecTag : null,
                Width = properties.TryGetValue("width", out var v_Width) && int.TryParse(v_Width, out var i_Width) ? i_Width : 0,
                Height = properties.TryGetValue("height", out var v_Height) && int.TryParse(v_Height, out var i_Height) ? i_Height : 0,
                CodedWidth = properties.TryGetValue("coded_width", out var v_CodedWidth) && int.TryParse(v_CodedWidth, out var i_CodedWidth) ? i_CodedWidth : 0,
                CodedHeight = properties.TryGetValue("coded_height", out var v_CodedHeight) && int.TryParse(v_CodedHeight, out var i_CodedHeight) ? i_CodedHeight : 0,
                HasBFrames = properties.TryGetValue("has_b_frames", out var v_HasBFrames) && int.TryParse(v_HasBFrames, out var i_HasBFrames) ? i_HasBFrames : 0,
                SampleAspectRatio = properties.TryGetValue("sample_aspect_ratio", out var v_SampleAspectRatio) ? v_SampleAspectRatio : null,
                DisplayAspectRatio = properties.TryGetValue("display_aspect_ratio", out var v_DisplayAspectRatio) ? v_DisplayAspectRatio : null,
                PixFmt = properties.TryGetValue("pix_fmt", out var v_PixFmt) ? v_PixFmt : null,
                Level = properties.TryGetValue("level", out var v_Level) && int.TryParse(v_Level, out var i_Level) ? i_Level : 0,
                ColorRange = properties.TryGetValue("color_range", out var v_ColorRange) ? v_ColorRange : null,
                ColorSpace = properties.TryGetValue("color_space", out var v_ColorSpace) ? v_ColorSpace : null,
                ColorTransfer = properties.TryGetValue("color_transfer", out var v_ColorTransfer) ? v_ColorTransfer : null,
                ColorPrimaries = properties.TryGetValue("color_primaries", out var v_ColorPrimaries) ? v_ColorPrimaries : null,
                ChromaLocation = properties.TryGetValue("chroma_location", out var v_ChromaLocation) ? v_ChromaLocation : null,
                Refs = properties.TryGetValue("refs", out var v_Refs) && int.TryParse(v_Refs, out var i_Refs) ? i_Refs : 0,
                IsAvc = properties.TryGetValue("is_avc", out var v_IsAvc) ? v_IsAvc : null,
                NalLengthSize = properties.TryGetValue("nal_length_size", out var v_NalLengthSize) ? v_NalLengthSize : null,
                RFrameRate = properties.TryGetValue("r_frame_rate", out var v_RFrameRate) ? v_RFrameRate : null,
                AvgFrameRate = properties.TryGetValue("avg_frame_rate", out var v_AvgFrameRate) ? v_AvgFrameRate : null,
                TimeBase = properties.TryGetValue("time_base", out var v_TimeBase) ? v_TimeBase : null,
                StartPts = properties.TryGetValue("start_pts", out var v_StartPts) && int.TryParse(v_StartPts, out var i_StartPts) ? i_StartPts : 0,
                StartTime = properties.TryGetValue("start_time", out var v_StartTime) ? v_StartTime : null,
                DurationTs = properties.TryGetValue("duration_ts", out var v_DurationTs) && int.TryParse(v_DurationTs, out var i_DurationTs) ? i_DurationTs : 0,
                Duration = properties.TryGetValue("duration", out var v_Duration) ? v_Duration : null,
                BitRate = properties.TryGetValue("bit_rate", out var v_BitRate) ? v_BitRate : null,
                BitsPerRawSample = properties.TryGetValue("bits_per_raw_sample", out var v_BitsPerRawSample) ? v_BitsPerRawSample : null,
                NbFrames = properties.TryGetValue("nb_frames", out var v_NbFrames) ? v_NbFrames : null,
                Disposition = properties.TryGetValue("disposition", out var v_Disposition) ? ParseDictionaryIntJson(v_Disposition) : new Dictionary<string, int>(),
                Tags = properties.TryGetValue("tags", out string v_Tags) ? JsonNativeAot.Deserialize<StreamTags>(v_Tags) : null,
                SampleFmt = properties.TryGetValue("sample_fmt", out var v_SampleFmt) ? v_SampleFmt : null,
                SampleRate = properties.TryGetValue("sample_rate", out var v_SampleRate) ? v_SampleRate : null,
                Channels = properties.TryGetValue("channels", out var v_Channels) && int.TryParse(v_Channels, out var i_Channels) ? i_Channels : 0,
                ChannelLayout = properties.TryGetValue("channel_layout", out var v_ChannelLayout) ? v_ChannelLayout : null,
                BitsPerSample = properties.TryGetValue("bits_per_sample", out var v_BitsPerSample) && int.TryParse(v_BitsPerSample, out var i_BitsPerSample) ? i_BitsPerSample : 0,
                MaxBitRate = properties.TryGetValue("max_bit_rate", out var v_MaxBitRate) ? v_MaxBitRate : null,
            };
        }
        
        // Método auxiliar para parsear el JSON simple
        private static Dictionary<string, int> ParseDictionaryIntJson(string json)
        {
            var dict = new Dictionary<string, int>();
            if (string.IsNullOrWhiteSpace(json) || json == "{}") return dict;
            json = json.Trim('{', '}');
            foreach (var pair in json.Split(','))
            {
                var kv = pair.Split(':');
                if (kv.Length == 2)
                {
                    var key = kv[0].Trim('\"');
                    if (int.TryParse(kv[1], out var value))
                        dict[key] = value;
                }
            }
            return dict;
        }
        
        public string ToJson() => JsonNativeAot.Serialize(this);
        
        public static MediaStream FromJson(string json) => JsonNativeAot.Deserialize<MediaStream>(json);
    
        
    }
}