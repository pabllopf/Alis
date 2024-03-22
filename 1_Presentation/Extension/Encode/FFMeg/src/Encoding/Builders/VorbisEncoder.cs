// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VorbisEncoder.cs
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

namespace Alis.Extension.Encode.FFMeg.Encoding.Builders
{
    /// <summary>
    ///     The vorbis encoder class
    /// </summary>
    /// <seealso cref="EncoderOptionsBuilder" />
    public class VorbisEncoder : EncoderOptionsBuilder
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="VorbisEncoder" /> class
        /// </summary>
        public VorbisEncoder()
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
        public override string Format { get; set; } = "ogg";

        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        public override string Name => "libvorbis";

        /// <summary>
        ///     Gets or sets the value of the current quality settings
        /// </summary>
        public string CurrentQualitySettings { get; private set; }

        /// <summary>
        ///     Constant bitrate encoding.
        /// </summary>
        /// <param name="bitrate">Target bitrate (ex: '320k', '250k', ...)</param>
        public void SetCBR(string bitrate)
        {
            CurrentQualitySettings = $"-b:a {bitrate}";
        }

        /// <summary>
        ///     Constant quality encoding - VBR mode
        /// </summary>
        /// <param name="q">Float number from -1 to 10 (Higher = higher quality)</param>
        public void SetCQP(float q = 3)
        {
            CurrentQualitySettings = $"-q:a {q.ToString("0.00", CultureInfo.InvariantCulture)}";
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