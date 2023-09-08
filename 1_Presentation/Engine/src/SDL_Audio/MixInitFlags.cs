// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MixInitFlags.cs
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

namespace Alis.App.Engine.SDL_Audio
{
    /// <summary>
    ///     The mix initflags enum
    /// </summary>
    [Flags]
    public enum MixInitFlags
    {
        /// <summary>
        ///     The mix init flac mix initflags
        /// </summary>
        MixInitFlac = 0x00000001,

        /// <summary>
        ///     The mix init mod mix initflags
        /// </summary>
        MixInitMod = 0x00000002,

        /// <summary>
        ///     The mix init mp3 mix initflags
        /// </summary>
        MixInitMp3 = 0x00000008,

        /// <summary>
        ///     The mix init ogg mix initflags
        /// </summary>
        MixInitOgg = 0x00000010,

        /// <summary>
        ///     The mix init mid mix initflags
        /// </summary>
        MixInitMid = 0x00000020,

        /// <summary>
        ///     The mix init opus mix initflags
        /// </summary>
        MixInitOpus = 0x00000040
    }
}