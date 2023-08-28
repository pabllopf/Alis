// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotBin.cs
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

namespace Alis.Core.Graphic.UI.Extras.Plot
{
    /// <summary>
    ///     The im plot bin enum
    /// </summary>
    public enum ImPlotBin
    {
        /// <summary>
        ///     The sqrt im plot bin
        /// </summary>
        Sqrt = -1,

        /// <summary>
        ///     The sturges im plot bin
        /// </summary>
        Sturges = -2,

        /// <summary>
        ///     The rice im plot bin
        /// </summary>
        Rice = -3,

        /// <summary>
        ///     The scott im plot bin
        /// </summary>
        Scott = -4
    }
}