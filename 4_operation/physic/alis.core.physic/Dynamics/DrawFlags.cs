// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DrawFlags.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The draw flags enum
    /// </summary>
    [Flags]
    public enum DrawFlags
    {
        /// <summary>
        ///     The shape draw flags
        /// </summary>
        Shape = 0x0001, // draw shapes

        /// <summary>
        ///     The joint draw flags
        /// </summary>
        Joint = 0x0002, // draw joint connections

        /// <summary>
        ///     The core shape draw flags
        /// </summary>
        CoreShape = 0x0004, // draw core (TOI) shapes       // should be removed in this revision?

        /// <summary>
        ///     The aabb draw flags
        /// </summary>
        Aabb = 0x0008, // draw axis aligned bounding boxes

        /// <summary>
        ///     The obb draw flags
        /// </summary>
        Obb = 0x0010, // draw oriented bounding boxes       // should be removed in this revision?

        /// <summary>
        ///     The pair draw flags
        /// </summary>
        Pair = 0x0020, // draw broad-phase pairs

        /// <summary>
        ///     The center of mass draw flags
        /// </summary>
        CenterOfMass = 0x0040, // draw center of mass frame

        /// <summary>
        ///     The controller draw flags
        /// </summary>
        Controller = 0x0080 // draw center of mass frame
    }
}