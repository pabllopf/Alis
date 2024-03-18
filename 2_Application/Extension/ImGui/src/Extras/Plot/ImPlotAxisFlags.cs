// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotAxisFlags.cs
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

namespace Alis.Extension.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot axis flags enum
    /// </summary>
    [Flags]
    public enum ImPlotAxisFlags
    {
        /// <summary>
        ///     The none im plot axis flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     The no label im plot axis flags
        /// </summary>
        NoLabel = 1,

        /// <summary>
        ///     The no grid lines im plot axis flags
        /// </summary>
        NoGridLines = 2,

        /// <summary>
        ///     The no tick marks im plot axis flags
        /// </summary>
        NoTickMarks = 4,

        /// <summary>
        ///     The no tick labels im plot axis flags
        /// </summary>
        NoTickLabels = 8,

        /// <summary>
        ///     The no initial fit im plot axis flags
        /// </summary>
        NoInitialFit = 16,

        /// <summary>
        ///     The no menus im plot axis flags
        /// </summary>
        NoMenus = 32,

        /// <summary>
        ///     The no side switch im plot axis flags
        /// </summary>
        NoSideSwitch = 64,

        /// <summary>
        ///     The no highlight im plot axis flags
        /// </summary>
        NoHighlight = 128,

        /// <summary>
        ///     The opposite im plot axis flags
        /// </summary>
        Opposite = 256,

        /// <summary>
        ///     The foreground im plot axis flags
        /// </summary>
        Foreground = 512,

        /// <summary>
        ///     The invert im plot axis flags
        /// </summary>
        Invert = 1024,

        /// <summary>
        ///     The auto fit im plot axis flags
        /// </summary>
        AutoFit = 2048,

        /// <summary>
        ///     The range fit im plot axis flags
        /// </summary>
        RangeFit = 4096,

        /// <summary>
        ///     The pan stretch im plot axis flags
        /// </summary>
        PanStretch = 8192,

        /// <summary>
        ///     The lock min im plot axis flags
        /// </summary>
        LockMin = 16384,

        /// <summary>
        ///     The lock max im plot axis flags
        /// </summary>
        LockMax = 32768,

        /// <summary>
        ///     The lock im plot axis flags
        /// </summary>
        Lock = 49152,

        /// <summary>
        ///     The no decorations im plot axis flags
        /// </summary>
        NoDecorations = 15,

        /// <summary>
        ///     The aux default im plot axis flags
        /// </summary>
        AuxDefault = 258
    }
}