// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotLocation.cs
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

namespace Alis.Core.Extension.ImGui.Extras.Plot
{
    /// <summary>
    ///     The im plot location enum
    /// </summary>
    public enum ImPlotLocation
    {
        /// <summary>
        ///     The center im plot location
        /// </summary>
        Center = 0,

        /// <summary>
        ///     The north im plot location
        /// </summary>
        North = 1,

        /// <summary>
        ///     The south im plot location
        /// </summary>
        South = 2,

        /// <summary>
        ///     The west im plot location
        /// </summary>
        West = 4,

        /// <summary>
        ///     The east im plot location
        /// </summary>
        East = 8,

        /// <summary>
        ///     The north west im plot location
        /// </summary>
        NorthWest = 5,

        /// <summary>
        ///     The north east im plot location
        /// </summary>
        NorthEast = 9,

        /// <summary>
        ///     The south west im plot location
        /// </summary>
        SouthWest = 6,

        /// <summary>
        ///     The south east im plot location
        /// </summary>
        SouthEast = 10
    }
}