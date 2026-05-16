// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSpec.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Delegates;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL audio specification, describing the format, frequency, and callback configuration for audio devices.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioSpec
    {
        /// <summary>
        ///     The audio frequency in samples per second (Hz), e.g. 44100 or 48000.
        /// </summary>
        public int Freq { get; set; }

        /// <summary>
        ///     The SDL audio format (e.g. AUDIO_S16SYS), specifying the sample data type and byte order.
        /// </summary>
        public ushort Format { get; set; }

        /// <summary>
        ///     The number of audio channels: 1 for mono, 2 for stereo, etc.
        /// </summary>
        public byte Channels { get; set; }

        /// <summary>
        ///     The silence value used for audio buffer initialization, computed from the format.
        /// </summary>
        public readonly byte silence;

        /// <summary>
        ///     The audio buffer size in samples (per channel), defining latency and performance.
        /// </summary>
        public ushort Samples { get; set; }

        /// <summary>
        ///     The calculated audio buffer size in bytes, derived from format, channels, and samples.
        /// </summary>
        public readonly uint size;

        /// <summary>
        ///     The callback function invoked by SDL when the audio device needs more data.
        /// </summary>
        public SdlAudioCallback Callback { get; set; }

        /// <summary>
        ///     User-defined data pointer passed to the audio callback for custom context.
        /// </summary>
        public IntPtr Userdata { get; set; }
    }
}