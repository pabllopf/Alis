// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AudioFormat.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Audio.Codec
{
    /// <summary>
    ///     Describes the format of a set of samples
    /// </summary>
    public struct AudioFormat
    {
        /// <summary>
        ///     The sample rate that is used for most input sounds. Will downsample to the actual supported rate.
        /// </summary>
        public int SampleRate;

        /// <summary>
        ///     The number of channels of the input
        /// </summary>
        public int Channels;

        /// <summary>
        ///     Bits per sample. Can either be 8 or 16
        /// </summary>
        public int BitsPerSample;

        /// <summary>
        ///     Gives the number of bytes per sample
        /// </summary>
        public int BytesPerSample => BitsPerSample / 8;

        /// <summary>
        ///     Gives the number of bytes that is processed per second
        /// </summary>
        public int BytesPerSecond => BytesPerSample * SampleRate * Channels;
    }
}