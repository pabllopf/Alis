// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ManifoldPoint.cs
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

using System.Numerics;
using Alis.Core.Physic.Collision.ContactSystem;

namespace Alis.Core.Physic.Collision.Narrowphase
{
    /// <summary>
    ///     A manifold point is a contact point belonging to a contact
    ///     manifold. It holds details related to the geometry and dynamics
    ///     of the contact points.
    ///     The local point usage depends on the manifold type:
    ///     -ShapeType.Circles: the local center of circleB
    ///     -SeparationFunction.FaceA: the local center of cirlceB or the clip point of polygonB
    ///     -SeparationFunction.FaceB: the clip point of polygonA
    ///     This structure is stored across time steps, so we keep it small.
    ///     Note: the impulses are used for internal caching and may not
    ///     provide reliable contact forces, especially for high speed collisions.
    /// </summary>
    public struct ManifoldPoint
    {
        /// <summary>Uniquely identifies a contact point between two Shapes</summary>
        public ContactId Id;

        /// <summary>Usage depends on manifold type</summary>
        public Vector2 LocalPoint;

        /// <summary>The non-penetration impulse</summary>
        public float NormalImpulse;

        /// <summary>The friction impulse</summary>
        public float TangentImpulse;
    }
}