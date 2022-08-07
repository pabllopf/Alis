// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ShapeType.cs
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

namespace Alis.Core.Physic.Collisions.Shapes
{
    /// <summary>
    ///     The various collision shape types supported by Box2D.
    /// </summary>
    public enum ShapeType
    {
        /// <summary>
        ///     The unknown shape shape type
        /// </summary>
        UnknownShape = -1,

        /// <summary>
        ///     The circle shape shape type
        /// </summary>
        CircleShape,

        /// <summary>
        ///     The polygon shape shape type
        /// </summary>
        PolygonShape,

        /// <summary>
        ///     The edge shape shape type
        /// </summary>
        EdgeShape,

        /// <summary>
        ///     The shape type count shape type
        /// </summary>
        ShapeTypeCount
    }
}