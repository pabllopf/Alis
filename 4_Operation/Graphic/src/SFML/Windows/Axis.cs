// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Axis.cs
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

namespace Alis.Core.Graphic.D2.SFML.Windows
{
    /// <summary>
    ///     Axes supported by SFML joysticks
    /// </summary>
    ////////////////////////////////////////////////////////////
    public enum Axis
    {
        /// <summary>The X axis</summary>
        X,

        /// <summary>The Y axis</summary>
        Y,

        /// <summary>The Z axis</summary>
        Z,

        /// <summary>The R axis</summary>
        R,

        /// <summary>The U axis</summary>
        U,

        /// <summary>The V axis</summary>
        V,

        /// <summary>The X axis of the point-of-view hat</summary>
        PovX,

        /// <summary>TheY axis of the point-of-view hat</summary>
        PovY
    }
}