// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLineFlags.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot line flags enum
    /// </summary>
    [Flags]
    public enum ImPlotLineFlags
    {
        /// <summary>
        ///     The none im plot line flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The segments im plot line flags
        /// </summary>
        Segments = 1024,

        /// <summary>
        ///     The loop im plot line flags
        /// </summary>
        Loop = 2048,

        /// <summary>
        ///     The skip na im plot line flags
        /// </summary>
        SkipNaN = 4096,

        /// <summary>
        ///     The no clip im plot line flags
        /// </summary>
        NoClip = 8192,

        /// <summary>
        ///     The shaded im plot line flags
        /// </summary>
        Shaded = 16384
    }
}