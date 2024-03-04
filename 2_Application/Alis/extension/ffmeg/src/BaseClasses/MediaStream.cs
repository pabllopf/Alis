using System.Collections.Generic;
using System.Globalization;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.FFMeg.BaseClasses
{
    /// <summary>
    /// The media stream class
    /// </summary>
    public class MediaStream
    {
        /// <summary>
        /// Gets or sets the value of the index
        /// </summary>
        [JsonPropertyName("index")]
        public long Index { get; set; }

        /// <summary>
        /// Gets or sets the value of the codec name
        /// </summary>
        [JsonPropertyName("codec_name")]
        public string CodecName { get; set; }

        /// <summary>
        /// Gets or sets the value of the codec long name
        /// </summary>
        [JsonPropertyName("codec_long_name")]
        public string CodecLongName { get; set; }

        /// <summary>
        /// Gets or sets the value of the profile
        /// </summary>
        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        /// <summary>
        /// Gets or sets the value of the codec type
        /// </summary>
        [JsonPropertyName("codec_type")]
        public string CodecType { get; set; }
        /// <summary>
        /// Gets the value of the is audio
        /// </summary>
        public bool IsAudio => CodecType.ToLowerInvariant().Trim() == "audio";
        /// <summary>
        /// Gets the value of the is video
        /// </summary>
        public bool IsVideo => CodecType.ToLowerInvariant().Trim() == "video";

        /// <summary>
        /// Gets or sets the value of the codec time base
        /// </summary>
        [JsonPropertyName("codec_time_base")]
        public string CodecTimeBase { get; set; }

        /// <summary>
        /// Gets or sets the value of the codec tag string
        /// </summary>
        [JsonPropertyName("codec_tag_string")]
        public string CodecTagString { get; set; }

        /// <summary>
        /// Gets or sets the value of the codec tag
        /// </summary>
        [JsonPropertyName("codec_tag")]
        public string CodecTag { get; set; }

        /// <summary>
        /// Gets or sets the value of the width
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the value of the height
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the value of the coded width
        /// </summary>
        [JsonPropertyName("coded_width")]
        public int? CodedWidth { get; set; }

        /// <summary>
        /// Gets or sets the value of the coded height
        /// </summary>
        [JsonPropertyName("coded_height")]
        public int? CodedHeight { get; set; }

        /// <summary>
        /// Gets or sets the value of the has b frames
        /// </summary>
        [JsonPropertyName("has_b_frames")]
        public int? HasBFrames { get; set; }

        /// <summary>
        /// Gets or sets the value of the sample aspect ratio
        /// </summary>
        [JsonPropertyName("sample_aspect_ratio")]
        public string SampleAspectRatio { get; set; }

        /// <summary>
        /// Gets or sets the value of the display aspect ratio
        /// </summary>
        [JsonPropertyName("display_aspect_ratio")]
        public string DisplayAspectRatio { get; set; }

        /// <summary>
        /// Gets or sets the value of the pix fmt
        /// </summary>
        [JsonPropertyName("pix_fmt")]
        public string PixFmt { get; set; }

        /// <summary>
        /// Gets or sets the value of the level
        /// </summary>
        [JsonPropertyName("level")]
        public int? Level { get; set; }

        /// <summary>
        /// Gets or sets the value of the color range
        /// </summary>
        [JsonPropertyName("color_range")]
        public string ColorRange { get; set; }

        /// <summary>
        /// Gets or sets the value of the color space
        /// </summary>
        [JsonPropertyName("color_space")]
        public string ColorSpace { get; set; }

        /// <summary>
        /// Gets or sets the value of the color transfer
        /// </summary>
        [JsonPropertyName("color_transfer")]
        public string ColorTransfer { get; set; }

        /// <summary>
        /// Gets or sets the value of the color primaries
        /// </summary>
        [JsonPropertyName("color_primaries")]
        public string ColorPrimaries { get; set; }

        /// <summary>
        /// Gets or sets the value of the chroma location
        /// </summary>
        [JsonPropertyName("chroma_location")]
        public string ChromaLocation { get; set; }

        /// <summary>
        /// Gets or sets the value of the refs
        /// </summary>
        [JsonPropertyName("refs")]
        public int? Refs { get; set; }

        /// <summary>
        /// Gets or sets the value of the is avc
        /// </summary>
        [JsonPropertyName("is_avc")]
        public string IsAvc { get; set; }

        /// <summary>
        /// Gets or sets the value of the nal length size
        /// </summary>
        [JsonPropertyName("nal_length_size")]
        public string NalLengthSize { get; set; }

        /// <summary>
        /// Gets or sets the value of the r frame rate
        /// </summary>
        [JsonPropertyName("r_frame_rate")]
        public string RFrameRate { get; set; }

        /// <summary>
        /// Gets or sets the value of the avg frame rate
        /// </summary>
        [JsonPropertyName("avg_frame_rate")]
        public string AvgFrameRate { get; set; }

        /// <summary>
        /// The avgfpsnum
        /// </summary>
        double? avgfpsnum = null;
        /// <summary>
        /// Gets the value of the avg frame rate number
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
                else avgfpsnum = double.Parse(AvgFrameRate, CultureInfo.InvariantCulture);
            }

            return avgfpsnum.Value;
        }
        }


        /// <summary>
        /// Gets or sets the value of the time base
        /// </summary>
        [JsonPropertyName("time_base")]
        public string TimeBase { get; set; }

        /// <summary>
        /// Gets or sets the value of the start pts
        /// </summary>
        [JsonPropertyName("start_pts")]
        public int StartPts { get; set; }

        /// <summary>
        /// Gets or sets the value of the start time
        /// </summary>
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the value of the duration ts
        /// </summary>
        [JsonPropertyName("duration_ts")]
        public int DurationTs { get; set; }

        /// <summary>
        /// Gets or sets the value of the duration
        /// </summary>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the value of the bit rate
        /// </summary>
        [JsonPropertyName("bit_rate")]
        public string BitRate { get; set; }

        /// <summary>
        /// Gets or sets the value of the bits per raw sample
        /// </summary>
        [JsonPropertyName("bits_per_raw_sample")]
        public string BitsPerRawSample { get; set; }

        /// <summary>
        /// Gets or sets the value of the nb frames
        /// </summary>
        [JsonPropertyName("nb_frames")]
        public string NbFrames { get; set; }

        /// <summary>
        /// Gets or sets the value of the disposition
        /// </summary>
        [JsonPropertyName("disposition")]
        public Dictionary<string, int> Disposition { get; set; }

        /// <summary>
        /// Gets or sets the value of the tags
        /// </summary>
        [JsonPropertyName("tags")]
        public StreamTags Tags { get; set; }

        /// <summary>
        /// Gets or sets the value of the sample fmt
        /// </summary>
        [JsonPropertyName("sample_fmt")]
        public string SampleFmt { get; set; }

        /// <summary>
        /// Gets or sets the value of the sample rate
        /// </summary>
        [JsonPropertyName("sample_rate")]
        public string SampleRate { get; set; }
        /// <summary>
        /// Gets the value of the sample rate number
        /// </summary>
        public int SampleRateNumber => string.IsNullOrEmpty(SampleRate) ? -1 : int.Parse(SampleRate);

        /// <summary>
        /// Gets or sets the value of the channels
        /// </summary>
        [JsonPropertyName("channels")]
        public int? Channels { get; set; }

        /// <summary>
        /// Gets or sets the value of the channel layout
        /// </summary>
        [JsonPropertyName("channel_layout")]
        public string ChannelLayout { get; set; }

        /// <summary>
        /// Gets or sets the value of the bits per sample
        /// </summary>
        [JsonPropertyName("bits_per_sample")]
        public int? BitsPerSample { get; set; }

        /// <summary>
        /// Gets or sets the value of the max bit rate
        /// </summary>
        [JsonPropertyName("max_bit_rate")]
        public string MaxBitRate { get; set; }
    }
}
