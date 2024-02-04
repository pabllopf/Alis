// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlLogPriority.cs
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

namespace Alis.Core.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl log priority enum
    /// </summary>
    public enum LogPriority
    {
        /// <summary>
        ///     The sdl log priority verbose sdl log priority
        /// </summary>
        SdlLogPriorityVerbose = 1,

        /// <summary>
        ///     The sdl log priority debug sdl log priority
        /// </summary>
        SdlLogPriorityDebug,

        /// <summary>
        ///     The sdl log priority info sdl log priority
        /// </summary>
        SdlLogPriorityInfo,

        /// <summary>
        ///     The sdl log priority warn sdl log priority
        /// </summary>
        SdlLogPriorityWarn,

        /// <summary>
        ///     The sdl log priority error sdl log priority
        /// </summary>
        SdlLogPriorityError,

        /// <summary>
        ///     The sdl log priority critical sdl log priority
        /// </summary>
        SdlLogPriorityCritical,

        /// <summary>
        ///     The sdl num log priorities sdl log priority
        /// </summary>
        SdlNumLogPriorities
    }
}