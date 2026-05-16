// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogPriority.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl log priority enum
    /// </summary>
    public enum LogPriority
    {
    /// <summary>
    ///     Verbose debug log messages (most detailed output)
    /// </summary>
    SdlLogPriorityVerbose = 1,

    /// <summary>
    ///     Debug-level log messages
    /// </summary>
    SdlLogPriorityDebug,

    /// <summary>
    ///     Informational log messages
    /// </summary>
    SdlLogPriorityInfo,

    /// <summary>
    ///     Warning log messages (non-critical issues)
    /// </summary>
    SdlLogPriorityWarn,

    /// <summary>
    ///     Error log messages (recoverable errors)
    /// </summary>
    SdlLogPriorityError,

    /// <summary>
    ///     Critical log messages (unrecoverable errors)
    /// </summary>
    SdlLogPriorityCritical,

    /// <summary>
    ///     Total number of defined log priority levels (sentinel)
    /// </summary>
    SdlNumLogPriorities
    }
}