// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MP3Encoder.cs
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
    ///     The mp encoder class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder" />
    public class MP3Encoder : EncoderOptionsBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MP3Encoder" /> class
        /// </summary>
        public MP3Encoder()
        {
            SetCQP();
        }

        /// <summary>
        ///     Set channel count, leave 'null' to match source
        /// </summary>
        public int? ChannelCount { get; set; } = null;

        /// <summary>
        ///     Set sample rate, leave 'null' to match source
        /// </summary>
        public int? SampleRate { get; set; } = null;

        /// <summary>
        ///     Gets or sets the value of the format
        /// </summary>
        public override string Format { get; set; } = "mp3";

        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public override string Name => "libmp3lame";

        /// <summary>
        ///     Gets or sets the value of the current quality settings
        /// </summary>
        public string CurrentQualitySettings { get; private set; }

        /// <summary>
        ///     Constant bitrate encoding. (This mode is considered wasteful, use CQP instead)
        /// </summary>
        /// <param name="bitrate">Target bitrate (ex: '320k', '250k', ...)</param>
        public void SetCBR(string bitrate)
        {
            CurrentQualitySettings = $"-b:a {bitrate}";
        }

        /// <summary>
        ///     Average bitrate encoding.
        /// </summary>
        /// <param name="avg_bitrate">Average target bitrate (ex: '320k', '250k', ...)</param>
        public void SetABR(string avg_bitrate)
        {
            CurrentQualitySettings = $"-b:a {avg_bitrate} -abr 1";
        }

        /// <summary>
        ///     Constant quality encoding - VBR mode (0 produces around 240kbps, 1 -> 220kbps, 2 -> 190, ...)
        /// </summary>
        /// <param name="qscale">Number from 0 to 9 (Lower = higher quality)</param>
        public void SetCQP(int qscale = 4)
        {
            CurrentQualitySettings = $"-q:a {qscale}";
        }

        /// <summary>
        ///     Creates this instance
        /// </summary>
        /// <returns>The encoder options</returns>
        public override EncoderOptions Create() => new EncoderOptions
        {
            Format = Format,
            EncoderName = Name,
            EncoderArguments = $"{CurrentQualitySettings}" +
                               (ChannelCount == null ? "" : $" -ac {ChannelCount}") +
                               (SampleRate == null ? "" : $" -ar {SampleRate}")
        };
    }
}