// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MixMusicType.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The mix musictype enum
    /// </summary>
    public enum MixMusicType
    {
        /// <summary>
        ///     The mus none mix musictype
        /// </summary>
        MusNone,

        /// <summary>
        ///     The mus cmd mix musictype
        /// </summary>
        MusCmd,

        /// <summary>
        ///     The mus wav mix musictype
        /// </summary>
        MusWav,

        /// <summary>
        ///     The mus mod mix musictype
        /// </summary>
        MusMod,

        /// <summary>
        ///     The mus mid mix musictype
        /// </summary>
        MusMid,

        /// <summary>
        ///     The mus ogg mix musictype
        /// </summary>
        MusOgg,

        /// <summary>
        ///     The mus mp3 mix musictype
        /// </summary>
        MusMp3,

        /// <summary>
        ///     The mus mp3 mad unused mix musictype
        /// </summary>
        MusMp3MadUnused,

        /// <summary>
        ///     The mus flac mix musictype
        /// </summary>
        MusFlac,

        /// <summary>
        ///     The mus modplug unused mix musictype
        /// </summary>
        MusModplugUnused,

        /// <summary>
        ///     The mus opus mix musictype
        /// </summary>
        MusOpus
    }
}