// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Verbosity.cs
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

namespace Alis.Extension.Media.FFmpeg
{
    /// <summary>
    ///     The verbosity enum
    /// </summary>
    public enum Verbosity
    {
        /// <summary>
        ///     Show nothing at all; be silent.
        /// </summary>
        Quiet = 0,

        /// <summary>
        ///     Show informative messages during processing. This is in addition to warnings and errors. This is the default value.
        /// </summary>
        Info = 1,

        /// <summary>
        ///     Same as info, except more verbose.
        /// </summary>
        Verbose = 2,

        /// <summary>
        ///     Show everything, including debugging information.
        /// </summary>
        Debug = 3,

        /// <summary>
        ///     Show all warnings and errors. Any message related to possibly incorrect or unexpected events will be shown.
        /// </summary>
        Warning = 4,

        /// <summary>
        ///     Show all errors, including ones which can be recovered from.
        /// </summary>
        Error = 5,

        /// <summary>
        ///     Only show fatal errors. These are errors after which the process absolutely cannot continue.
        /// </summary>
        Fatal = 6
    }
}