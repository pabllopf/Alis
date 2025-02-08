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
    ///     The sdl audio spec
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AudioSpec
    {
        /// <summary>
        ///     The freq
        /// </summary>
        public int Freq { get; set; }

        /// <summary>
        ///     The SDL_AudioFormat
        /// </summary>
        public ushort Format { get; set; }

        /// <summary>
        ///     The channels
        /// </summary>
        public byte Channels { get; set; }

        /// <summary>
        ///     The silence
        /// </summary>
        public readonly byte silence;

        /// <summary>
        ///     The samples
        /// </summary>
        public ushort Samples { get; set; }

        /// <summary>
        ///     The size
        /// </summary>
        public readonly uint size;

        /// <summary>
        ///     The callback
        /// </summary>
        public SdlAudioCallback Callback { get; set; }

        /// <summary>
        ///     The userdata
        /// </summary>
        public IntPtr Userdata { get; set; }
    }
}