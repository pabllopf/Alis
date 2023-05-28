// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Mix_MusicType.cs
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

namespace Alis.Core.Audio.SDL
{
    /// <summary>
    ///     The mix musictype enum
    /// </summary>
    public enum Mix_MusicType
    {
        /// <summary>
        ///     The mus none mix musictype
        /// </summary>
        MUS_NONE,

        /// <summary>
        ///     The mus cmd mix musictype
        /// </summary>
        MUS_CMD,

        /// <summary>
        ///     The mus wav mix musictype
        /// </summary>
        MUS_WAV,

        /// <summary>
        ///     The mus mod mix musictype
        /// </summary>
        MUS_MOD,

        /// <summary>
        ///     The mus mid mix musictype
        /// </summary>
        MUS_MID,

        /// <summary>
        ///     The mus ogg mix musictype
        /// </summary>
        MUS_OGG,

        /// <summary>
        ///     The mus mp3 mix musictype
        /// </summary>
        MUS_MP3,

        /// <summary>
        ///     The mus mp3 mad unused mix musictype
        /// </summary>
        MUS_MP3_MAD_UNUSED,

        /// <summary>
        ///     The mus flac mix musictype
        /// </summary>
        MUS_FLAC,

        /// <summary>
        ///     The mus modplug unused mix musictype
        /// </summary>
        MUS_MODPLUG_UNUSED,

        /// <summary>
        ///     The mus opus mix musictype
        /// </summary>
        MUS_OPUS
    }
}