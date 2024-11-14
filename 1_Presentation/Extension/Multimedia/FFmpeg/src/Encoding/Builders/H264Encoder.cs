// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:H264Encoder.cs
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

using System.Globalization;

namespace Alis.Extension.Multimedia.FFmpeg.Encoding.Builders
{
    /// <summary>
    ///     The 264 encoder class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder" />
    public class H264Encoder : EncoderOptionsBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="H264Encoder" /> class
        /// </summary>
        public H264Encoder()
        {
            SetCQP();
        }

        /// <summary>
        ///     A slower preset will provide better compression (Default: medium)
        /// </summary>
        public Preset EncoderPreset { get; set; } = Preset.Medium;

        /// <summary>
        ///     Tune encoder settings based on the content that is being encoded. (Default: Auto)
        /// </summary>
        public Tune EncoderTune { get; set; } = Tune.Auto;

        /// <summary>
        ///     Limit encoder output to a specific profile. This affects compatibility with older players and compression
        ///     efficiency. (Default: Auto)
        /// </summary>
        public Profile EncoderProfile { get; set; } = Profile.Auto;

        /// <summary>
        ///     Gets or sets the value of the format
        /// </summary>
        public override string Format { get; set; } = "mp4";

        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public override string Name => "libx264";

        /// <summary>
        ///     Gets or sets the value of the current quality settings
        /// </summary>
        public string CurrentQualitySettings { get; private set; }

        /// <summary>
        ///     Constant quality (CQP/CRF) - Quality-based VBR encoding (Good of achieving best quality, bad for achieving certain
        ///     bitrate/size)
        /// </summary>
        /// <param name="crf">Float number from 0 to 51 (0=lossless)</param>
        public void SetCQP(float crf = 22)
        {
            CurrentQualitySettings = "-crf " + crf.ToString("0.00", CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     CBR encoding - Set constant bitrate (Good for streaming, inefficient use of bandwidth)
        /// </summary>
        /// <param name="bitrate">Target bitrate (ex: '1M', '1000k', ...)</param>
        /// <param name="bufsize">
        ///     Decoder buffer size, which determines the variability of the output bitrate. Used as a rate
        ///     control buffer that will enforce the requested average bitrate across [bufsize] worth of video. Fluctuation within
        ///     this range is acceptable. This is expected client buffer size. (ex: '1M', '1000k', ...)
        /// </param>
        public void SetCBR(string bitrate, string bufsize)
        {
            CurrentQualitySettings = $"-x264-params \"nal-hrd=cbr\" -b:v {bitrate} -minrate {bitrate} -maxrate {bitrate} -bufsize {bufsize}";
        }

        /// <summary>
        ///     Constrained quality encoding with a verifier - Set maximum bitrate (Good for streaming where certain frames need
        ///     less bitrate)
        ///     CRF is increased when [max_bitrate] is exceeded.
        /// </summary>
        /// <param name="crf">Float number from 0 to 51 (0=lossless)</param>
        /// <param name="max_bitrate">Max. allowed bitrate (ex: '1M', '1000k', ...)</param>
        /// <param name="bufsize">
        ///     Decoder buffer size, which determines the variability of the output bitrate. This is expected
        ///     client buffer size. (ex: '1M', '1000k', ... Should be more than the bitrate)
        /// </param>
        /// <param name="crf_max">Prevents lowering CRF beyond this point (-1 = auto)</param>
        public void SetVBV(float crf, string max_bitrate, string bufsize, float crf_max = -1)
        {
            CurrentQualitySettings = $"-crf {crf.ToString("0.00", CultureInfo.InvariantCulture)} -maxrate {max_bitrate} -bufsize {bufsize} -crf_max {crf_max}";
        }

        /// <summary>
        ///     Average bitrate encoding (Not recommended as it includes a lot of guessing ahead in time)
        /// </summary>
        /// <param name="avg_bitrate">Average target bitrate (ex: '1M', '1000k', ...)</param>
        public void SetABR(string avg_bitrate)
        {
            CurrentQualitySettings = $"-b:v {avg_bitrate}";
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
                               $"-preset {EncoderPreset.ToString().ToLowerInvariant()}" +
                               (EncoderTune == Tune.Auto ? "" : $" -tune {EncoderTune.ToString().ToLowerInvariant()}") +
                               (EncoderProfile == Profile.Auto ? "" : $" -profile:v {EncoderProfile.ToString().ToLowerInvariant()}")
        };
    }
}