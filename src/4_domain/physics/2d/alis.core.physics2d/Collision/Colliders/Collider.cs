// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Collider.cs
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

using Alis.Core.Physics2D.Shapes;

namespace Alis.Core.Physics2D.Colliders
{
    /// <summary>
    ///     The collider class
    /// </summary>
    internal abstract class Collider<TShapeA, TShapeB>
        where TShapeA : Shape where TShapeB : Shape
    {
        /// <summary>
        ///     Collides the manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="shapeA">The shape</param>
        /// <param name="xfA">The xf</param>
        /// <param name="shapeB">The shape</param>
        /// <param name="xfB">The xf</param>
        internal abstract void Collide(
            out Manifold manifold,
            in TShapeA shapeA,
            in Transform xfA,
            in TShapeB shapeB,
            in Transform xfB);
    }
}