// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VP9Encoder.cs
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

namespace Alis.Extension.Media.FFmpeg.Encoding.Builders
{
    /// <summary>
    ///     The vp encoder class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder" />
    public class Vp9Encoder : EncoderOptionsBuilder
    {
        /// <summary>
        ///     The tune enum
        /// </summary>
        public enum Tune
        {
            /// <summary>
            ///     The default tune
            /// </summary>
            Default = 0,

            /// <summary>
            ///     Screen capture content
            /// </summary>
            Screen = 1,

            /// <summary>
            ///     Film content; improves grain retention
            /// </summary>
            Film = 2
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vp9Encoder" /> class
        /// </summary>
        public Vp9Encoder()
        {
            SetCqp();
        }

        /// <summary>
        ///     Encoder quality setting (Default: good)
        /// </summary>
        public Quality EncoderQuality { get; set; } = Quality.Good;

        /// <summary>
        ///     Tune encoder settings based on the content that is being encoded.
        /// </summary>
        public Tune EncoderTune { get; set; } = Tune.Default;

        /// <summary>
        ///     Quality/Speed ratio modifier (from -8 to 8, also depends on quality setting)
        /// </summary>
        public int? CpuUsed { get; set; } = null;

        /// <summary>
        ///     Enable row based multithreading
        /// </summary>
        public bool RowBasedMultithreading { get; set; } = false;


        /// <summary>
        ///     Gets or sets the value of the format
        /// </summary>
        public override string Format { get; set; } = "webm";

        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public override string Name => "libvpx-vp9";

        /// <summary>
        ///     Gets or sets the value of the current quality settings
        /// </summary>
        public string CurrentQualitySettings { get; private set; }

        /// <summary>
        ///     Constrained quality encoding - Set target quality and maximum bitrate
        ///     CRF is increased when [max_bitrate] is exceeded.
        /// </summary>
        /// <param name="crf">Number from 0 to 63 (Lower = higher quality)</param>
        public void SetCvbr(int crf, string maxBitrate)
        {
            CurrentQualitySettings = $"-crf {crf} -b:v {maxBitrate}";
        }

        /// <summary>
        ///     Constrained bitrate encoding - Set target, min and max bitrate.
        /// </summary>
        /// <param name="targetBitrate">Target bitrate (ex: '1M', '1000k', ...)</param>
        /// <param name="minBitrate">Min bitrate (ex: '1M', '1000k', ...)</param>
        /// <param name="maxBitrate">Max bitrate (ex: '1M', '1000k', ...)</param>
        public void SetCvbr(string targetBitrate, string minBitrate, string maxBitrate)
        {
            CurrentQualitySettings = $"-minrate {minBitrate} -b:v {targetBitrate} -maxrate {maxBitrate}";
        }

        /// <summary>
        ///     ABR encoding
        /// </summary>
        /// <param name="bitrate">Average target bitrate (ex: '1M', '1000k', ...)</param>
        public void SetAbr(string bitrate)
        {
            CurrentQualitySettings = $"-b:v {bitrate}";
        }

        /// <summary>
        ///     Constant quality encoding
        /// </summary>
        /// <param name="crf">Number from 0 to 63 (Lower = higher quality)</param>
        public void SetCqp(int crf = 31)
        {
            CurrentQualitySettings = $"-crf {crf} -b:v 0";
        }

        /// <summary>
        ///     Constant bitrate encoding
        /// </summary>
        /// <param name="bitrate">Average target bitrate (ex: '1M', '1000k', ...)</param>
        public void SetCbr(string bitrate)
        {
            CurrentQualitySettings = $"-minrate {bitrate} -maxrate {bitrate} -b:v {bitrate}";
        }

        /// <summary>
        ///     Sets the lossless
        /// </summary>
        public void SetLossless()
        {
            CurrentQualitySettings = "-lossless 1";
        }


        /// <summary>
        ///     Creates this instance
        /// </summary>
        /// <returns>The encoder options</returns>
        public override EncoderOptions Create() => new EncoderOptions
        {
            Format = Format,
            EncoderName = Name,
            EncoderArguments = $"{CurrentQualitySettings} " +
                               $"-tune-content {EncoderTune.ToString().ToLowerInvariant()} " +
                               $"-deadline {EncoderQuality.ToString().ToLowerInvariant()}" +
                               (CpuUsed == null ? "" : $" -cpu-used {CpuUsed.Value}") +
                               (RowBasedMultithreading ? " -row-mt 1" : "")
        };
    }
}