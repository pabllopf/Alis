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

namespace Alis.Extension.FFMeg.Encoding.Builders
{
    /// <summary>
    ///     The vp encoder class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder" />
    public class VP9Encoder : EncoderOptionsBuilder
    {
        /// <summary>
        ///     The quality enum
        /// </summary>
        public enum Quality
        {
            /// <summary>
            ///     Default and recommended for most applications
            /// </summary>
            Good,

            /// <summary>
            ///     Recommended if you have lots of time and want the best compression efficiency.
            /// </summary>
            Best,

            /// <summary>
            ///     Recommended for live/fast encoding.
            /// </summary>
            RealTime
        }

        /// <summary>
        ///     The tune enum
        /// </summary>
        public enum Tune
        {
            /// <summary>
            ///     The default tune
            /// </summary>
            Default,

            /// <summary>
            ///     Screen capture content
            /// </summary>
            Screen,

            /// <summary>
            ///     Film content; improves grain retention
            /// </summary>
            Film
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="VP9Encoder" /> class
        /// </summary>
        public VP9Encoder()
        {
            SetCQP();
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
        public void SetCVBR(int crf, string max_bitrate)
        {
            CurrentQualitySettings = $"-crf {crf} -b:v {max_bitrate}";
        }

        /// <summary>
        ///     Constrained bitrate encoding - Set target, min and max bitrate.
        /// </summary>
        /// <param name="target_bitrate">Target bitrate (ex: '1M', '1000k', ...)</param>
        /// <param name="min_bitrate">Min bitrate (ex: '1M', '1000k', ...)</param>
        /// <param name="max_bitrate">Max bitrate (ex: '1M', '1000k', ...)</param>
        public void SetCVBR(string target_bitrate, string min_bitrate, string max_bitrate)
        {
            CurrentQualitySettings = $"-minrate {min_bitrate} -b:v {target_bitrate} -maxrate {max_bitrate}";
        }

        /// <summary>
        ///     ABR encoding
        /// </summary>
        /// <param name="bitrate">Average target bitrate (ex: '1M', '1000k', ...)</param>
        public void SetABR(string bitrate)
        {
            CurrentQualitySettings = $"-b:v {bitrate}";
        }

        /// <summary>
        ///     Constant quality encoding
        /// </summary>
        /// <param name="crf">Number from 0 to 63 (Lower = higher quality)</param>
        public void SetCQP(int crf = 31)
        {
            CurrentQualitySettings = $"-crf {crf} -b:v 0";
        }

        /// <summary>
        ///     Constant bitrate encoding
        /// </summary>
        /// <param name="bitrate">Average target bitrate (ex: '1M', '1000k', ...)</param>
        public void SetCBR(string bitrate)
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